-- DROP POLICY
--BEGIN
--        DBMS_RLS.DROP_POLICY(
--            object_schema => 'ADMIN',
--            object_name   => 'tên b?ng',
--            policy_name   => 'tên chính sách'
--        );
--    EXCEPTION
--        WHEN OTHERS THEN
--            NULL; -- B? qua n?u chï¿½nh sï¿½ch khï¿½ng t?n t?i
--END;
--/

-- CHECK POLICY
SELECT *
FROM DBA_POLICIES
WHERE OBJECT_OWNER = 'ADMIN';
/

DROP USER ADMIN CASCADE;
CREATE USER ADMIN IDENTIFIED BY 123;
GRANT DBA TO ADMIN;
GRANT EXECUTE ANY PROCEDURE TO ADMIN;
GRANT CREATE USER TO ADMIN;
GRANT CREATE SESSION TO ADMIN WITH ADMIN OPTION;
/

GRANT EXEMPT ACCESS POLICY to ADMIN;

SELECT SYS_CONTEXT('USERENV', 'CON_NAME') AS container_name
FROM dual;
/
SELECT * FROM USER_SYS_PRIVS;
SELECT * FROM USER_TAB_PRIVS;
SELECT * FROM USER_ROLE_PRIVS;
/
DROP ROLE ROLE_SV;
DROP ROLE ROLE_TK;
DROP ROLE TRUONGDONVI;
DROP ROLE GIAOVU;
DROP ROLE GIANG_VIEN;
DROP ROLE NHAN_VIEN_CO_BAN;
/
CREATE ROLE ROLE_SV;
CREATE ROLE ROLE_TK;
CREATE ROLE TRUONGDONVI;
CREATE ROLE GIAOVU;
CREATE ROLE GIANG_VIEN;
CREATE ROLE NHAN_VIEN_CO_BAN;
/

--SHUTDOWN IMMEDIATE;
--STARTUP;
--COMMIT;
--/


SELECT * FROM DBA_USERS;

DECLARE
    CURSOR UsersToDrop IS
        SELECT username
        FROM all_users
        WHERE username LIKE 'NV%' OR username  LIKE 'SV%';
BEGIN
    FOR user_rec IN UsersToDrop LOOP
        EXECUTE IMMEDIATE 'DROP USER ' || user_rec.username || ' CASCADE';
        DBMS_OUTPUT.PUT_LINE('User ' || user_rec.username || ' dropped successfully.');
    END LOOP;
END;
/

CREATE OR REPLACE PROCEDURE SP_CREATEUSER
AS
    CURSOR NHANVIEN IS (SELECT MANV, VAITRO
                        FROM ADMIN.NHANSU
                        WHERE MANV NOT IN(SELECT USERNAME FROM ALL_USERS));
    CURSOR SINHVIEN IS (SELECT MASV
                        FROM ADMIN.SINHVIEN
                        WHERE MASV NOT IN(SELECT USERNAME FROM ALL_USERS));
    STRSQL CHAR(2000);
    USR CHAR(6);
    VAITRO VARCHAR2(20);
    USR_SV CHAR(8);
BEGIN    
    OPEN NHANVIEN;
    
    -- TAO USER LA NHANVIEN    
    LOOP
    BEGIN
        FETCH NHANVIEN INTO USR, VAITRO;
        EXIT WHEN NHANVIEN%NOTFOUND;
        
        STRSQL := 'CREATE USER '||USR||' IDENTIFIED BY '||USR;
--        STRSQL := 'DROP USER '||USR;
         DBMS_OUTPUT.PUT_LINE(strsql);
        EXECUTE IMMEDIATE (STRSQL);
        STRSQL := 'GRANT CREATE SESSION TO '||USR;
        EXECUTE IMMEDIATE(STRSQL);
        
        IF VAITRO = 'NHAN VIEN CO BAN' THEN        
            STRSQL := 'GRANT NHAN_VIEN_CO_BAN TO ' || USR;
            EXECUTE IMMEDIATE(STRSQL);
        ELSIF VAITRO = 'GIANG VIEN' THEN
            STRSQL := 'GRANT GIANG_VIEN TO ' || USR;
            EXECUTE IMMEDIATE(STRSQL);
        ELSIF VAITRO = 'GIAO VU' THEN
            STRSQL := 'GRANT GIAOVU TO ' || USR;
            EXECUTE IMMEDIATE(STRSQL);
        ELSIF VAITRO = 'TRUONG DON VI' THEN
            STRSQL := 'GRANT TRUONGDONVI TO ' || USR;
            EXECUTE IMMEDIATE(STRSQL);
        ELSIF VAITRO = 'TRUONG KHOA' THEN
            STRSQL := 'GRANT ROLE_TK TO ' || USR;
            EXECUTE IMMEDIATE(STRSQL);
        END IF;
    EXCEPTION
      WHEN OTHERS THEN
        -- Handle the error appropriately (e.g., log the error, report it, or take corrective action)
        DBMS_OUTPUT.PUT_LINE('Error occurred: ' || SQLERRM);

    END;
    END LOOP;
    CLOSE NHANVIEN;
    
    OPEN SINHVIEN;
    LOOP 
    BEGIN

        FETCH SINHVIEN INTO USR_SV;
        EXIT WHEN SINHVIEN%NOTFOUND;
        
        STRSQL := 'CREATE USER '||USR_SV||' IDENTIFIED BY '||USR_SV;
        EXECUTE IMMEDIATE (STRSQL);
        STRSQL := 'GRANT CREATE SESSION TO '||USR_SV;
        EXECUTE IMMEDIATE(STRSQL);
        STRSQL := 'GRANT ROLE_SV TO ' || USR_SV;
        EXECUTE IMMEDIATE(STRSQL);

    EXCEPTION
      WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Error occurred: ' || SQLERRM);
    END;
    END LOOP;
    CLOSE SINHVIEN;
END;
/
EXEC SP_CREATEUSER;
/


--#CS1
GRANT SELECT, UPDATE (DT) ON ADMIN.NHANSU TO NHAN_VIEN_CO_BAN;
GRANT SELECT ON ADMIN.SINHVIEN TO NHAN_VIEN_CO_BAN;
GRANT SELECT ON ADMIN.DONVI TO NHAN_VIEN_CO_BAN;
GRANT SELECT ON ADMIN.HOCPHAN TO NHAN_VIEN_CO_BAN;
GRANT SELECT ON ADMIN.KHMO TO NHAN_VIEN_CO_BAN;

SELECT * FROM DBA_ROLE_PRIVS WHERE GRANTEE = 'NHAN_VIEN_CO_BAN';
SELECT * FROM ROLE_TAB_PRIVS WHERE ROLE = 'NHAN_VIEN_CO_BAN';

CREATE OR REPLACE FUNCTION NHANSU_Function (
    p_schema IN VARCHAR2,
    p_object  IN VARCHAR2
) RETURN VARCHAR2
AS
    USR VARCHAR2(10);
BEGIN
    USR:= SYS_CONTEXT('USERENV', 'SESSION_USER');
    IF (USR = 'ADMIN') THEN
        RETURN '';
    END IF;
    
    RETURN 'EXISTS (SELECT * FROM SESSION_ROLES WHERE ROLE =''ROLE_TK'') OR (SYS_CONTEXT(''USERENV'', ''SESSION_USER'') = MANV)';
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema  => 'ADMIN',
        object_name    => 'NHANSU',
        policy_name    => 'NHANSU_Policy',
        policy_function => 'NHANSU_Function',
        statement_types => 'SELECT, UPDATE',
        update_check    => TRUE
    );
END;
/
--TEST
--SELECT * FROM ADMIN.NHANSU;
--SELECT * FROM ADMIN.SINHVIEN;
--SELECT * FROM ADMIN.DONVI;
--SELECT * FROM ADMIN.HOCPHAN;
--SELECT * FROM ADMIN.KHMO;

------------------------------------------------------------------------------------------------------------------------------------------

--#CS2
-- CO ROLE CUA NHAN VIEN CO BAN
GRANT NHAN_VIEN_CO_BAN TO GIANG_VIEN;
--CHINH SACH TREN BANG PHAN CONG + DANG KY
GRANT SELECT ON ADMIN.PHANCONG TO GIANG_VIEN;
GRANT SELECT, UPDATE (DIEMTH, DIEMQT, DIEMCK, DIEMTK) ON ADMIN.DANGKY TO GIANG_VIEN;

--SELECT * FROM DBA_ROLE_PRIVS WHERE GRANTEE = 'GIANG_VIEN';
--SELECT * FROM ROLE_TAB_PRIVS WHERE ROLE = 'GIANG_VIEN';


CREATE OR REPLACE FUNCTION PHANCONG_GIANGVIEN_Function (
    p_schema IN VARCHAR2,
    p_object  IN VARCHAR2
) RETURN VARCHAR2
AS
    USR VARCHAR2(10);
    VAITROUSR VARCHAR2(50);

BEGIN
    USR:= SYS_CONTEXT('USERENV', 'SESSION_USER');
    SELECT VAITRO INTO VAITROUSR FROM NHANSU WHERE MANV=USR;
    
    IF (USR = 'ADMIN') THEN
        RETURN '';
    END IF;
    
    IF (VAITROUSR = 'GIANG VIEN') THEN
        RETURN 'MAGV = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')'; 
    END IF;
    RETURN '';
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema  => 'ADMIN',
        object_name    => 'PHANCONG',
        policy_name    => 'PHANCONG_GIANGVIEN_Policy',
        policy_function => 'PHANCONG_GIANGVIEN_Function',
        statement_types => 'SELECT'
    );
END;
/

CREATE OR REPLACE FUNCTION DANGKY_GIANGVIEN_UPDATE_Function (
    p_schema IN VARCHAR2,
    p_object  IN VARCHAR2
) RETURN VARCHAR2
AS
    GV CHAR(6);
    HP CHAR(8);
    K NUMBER;
    N NUMBER;
    CT CHAR(4);
    STRSQL VARCHAR2(2000);
    CURSOR CUR IS (SELECT MAHP,HK,NAM,MACT FROM ADMIN.PHANCONG WHERE MAGV = SYS_CONTEXT('USERENV', 'SESSION_USER'));
    
    USR VARCHAR2(10);
    VAITROUSR VARCHAR2(50);
BEGIN

    USR:= SYS_CONTEXT('USERENV', 'SESSION_USER');
    SELECT VAITRO INTO VAITROUSR FROM NHANSU WHERE MANV=USR;
    
    IF (USR = 'ADMIN' OR USR='TESTER') THEN
        RETURN '';
    END IF;
    
    IF (VAITROUSR != 'GIAO VU' AND VAITROUSR != 'NHAN VIEN CO BAN') THEN
        OPEN CUR;
        LOOP
            FETCH CUR INTO  HP,K,N,CT;
            EXIT WHEN CUR%NOTFOUND;
            IF (STRSQL IS NOT NULL) THEN
                STRSQL := STRSQL || ', ';
            END IF;
            STRSQL := STRSQL || '(''' || HP || ''', ''' || CT || ''', ' || K || ', ' || N || ')';
        END LOOP;
        CLOSE CUR;
        RETURN '(MAHP, MACT, HK, NAM) IN (' || STRSQL || ')';
    END IF;
    RETURN '';
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema  => 'ADMIN',
        object_name    => 'DANGKY',
        policy_name    => 'DANGKY_GIANGVIEN_UPDATE_Policy',
        policy_function => 'DANGKY_GIANGVIEN_UPDATE_Function',
        statement_types => 'UPDATE',
        update_check    => TRUE
    );
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema  => 'ADMIN',
        object_name    => 'DANGKY',
        policy_name    => 'DANGKY_GIANGVIEN_UPDATE_Policy'

    );
END;
/

CREATE OR REPLACE FUNCTION DANGKY_GIANGVIEN_SELECT_Function (
    p_schema IN VARCHAR2,
    p_object  IN VARCHAR2
) RETURN VARCHAR2
AS
    USR VARCHAR2(10);
    VAITROUSR VARCHAR2(50);
BEGIN
    USR:= SYS_CONTEXT('USERENV', 'SESSION_USER');
    IF (USR NOT LIKE 'NV%') THEN
        RETURN '';
    END IF;
    
    SELECT VAITRO INTO VAITROUSR FROM NHANSU WHERE MANV=USR;
    
    IF (USR = 'ADMIN') THEN
        RETURN '';
    END IF;
    
    IF (VAITROUSR != 'GIAO VU' AND VAITROUSR != 'TRUONG KHOA') THEN
        RETURN 'MAGV = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')';
    END IF;
    RETURN '';
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema  => 'ADMIN',
        object_name    => 'DANGKY',
        policy_name    => 'DANGKY_GIANGVIEN_SELECT_Policy',
        policy_function => 'DANGKY_GIANGVIEN_SELECT_Function',
        statement_types => 'SELECT'
    );
END;
/
BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema  => 'ADMIN',
        object_name    => 'DANGKY',
        policy_name    => 'DANGKY_GIANGVIEN_SELECT_Policy'
    );
END;
/
SELECT *
FROM ALL_POLICIES

--TEST
--SELECT PHUCAP FROM ADMIN.NHANSU WHERE MANV = 'NV0001';
--SELECT * FROM ADMIN.SINHVIEN;
--SELECT * FROM ADMIN.DONVI;
--SELECT * FROM ADMIN.HOCPHAN;
--SELECT * FROM ADMIN.KHMO;
--SELECT * FROM ADMIN.PHANCONG;
--SELECT * FROM ADMIN.DANGKY;

UPDATE ADMIN.DANGKY
SET DIEMTH = 10, DIEMQT = 10, DIEMCK = 9.54, DIEMTK = 10
WHERE MAHP = 'MAHP0002' AND MASV = 'SV000010' AND MACT = 'CQ' AND HK = 2 AND NAM = 2025;
select * from admin.dangky WHERE MAGV ='TOAN';
commit;/
-----------------------------------------------------------------------------------------------------------------------------
--CS#3
GRANT NHAN_VIEN_CO_BAN TO GIAOVU;
GRANT SELECT, UPDATE, INSERT, DELETE ON SINHVIEN TO GIAOVU;
GRANT SELECT, UPDATE, INSERT, DELETE ON DONVI TO GIAOVU;
GRANT SELECT, UPDATE, INSERT, DELETE ON HOCPHAN TO GIAOVU;
GRANT SELECT, UPDATE, INSERT, DELETE ON KHMO TO GIAOVU;

GRANT SELECT, UPDATE, INSERT, DELETE ON PHANCONG TO GIAOVU;

GRANT SELECT, INSERT, DELETE ON DANGKY TO GIAOVU;

CREATE OR REPLACE FUNCTION PHANCONG_GIAOVU_FUNCTION (
    P_SCHEMA VARCHAR2, 
    P_OBJ VARCHAR2
) RETURN VARCHAR2
AS
    USR VARCHAR2(10);
    VAITROUSR VARCHAR2(100);
    CURSOR CUR IS (SELECT MAHP FROM HOCPHAN WHERE MADV = 'VPK');
    MA VARCHAR2(2000);
    STRSQL VARCHAR(2000);
BEGIN
    
    USR:= SYS_CONTEXT('USERENV', 'SESSION_USER');
    IF (USR = 'ADMIN') THEN
        RETURN '';
    END IF;
   
    SELECT VAITRO INTO VAITROUSR FROM NHANSU WHERE MANV=USR;
    
    IF (VAITROUSR = 'GIAO VU') THEN
         OPEN CUR;
            LOOP
            FETCH CUR INTO MA;
            EXIT WHEN CUR%NOTFOUND;
            IF (STRSQL IS NOT NULL) THEN
            STRSQL := STRSQL ||''',''';
            END IF;
            STRSQL := STRSQL || MA;
            END LOOP;
            RETURN 'MAHP IN ('''||STRSQL||''')';
    END IF;
    RETURN '';
END; 
/

BEGIN
DBMS_RLS.ADD_POLICY(
    object_schema   => 'ADMIN', 
    object_name     => 'PHANCONG',  
    policy_name     => 'PHANCONG_GIAOVU_POLICY', 
    policy_function => 'PHANCONG_GIAOVU_FUNCTION',  
    statement_types => 'INSERT, UPDATE, DELETE',
    update_check    => TRUE
  );
END;
/

CREATE OR REPLACE FUNCTION F_GIAOVU_DANGKY
(P_SCHEMA VARCHAR2, P_OBJ VARCHAR2)
RETURN VARCHAR2
AS
    MA VARCHAR2(5);
 STRSQLHK VARCHAR2(2000);
 STRSQLNAM VARCHAR2(2000);
 USR VARCHAR2(100);
 VAITROUSR VARCHAR2(100);
BEGIN
    USR:= SYS_CONTEXT('USERENV', 'SESSION_USER');
    IF (USR = 'ADMIN') THEN
        RETURN '';
    END IF;
    SELECT VAITRO INTO VAITROUSR FROM NHANSU WHERE MANV=USR;
    IF (VAITROUSR = 'GIAO VU') THEN 
        IF (1<= EXTRACT(DAY FROM SYSDATE) AND EXTRACT(DAY FROM SYSDATE)<=15) THEN
            SELECT DISTINCT HK, NAM INTO STRSQLHK, STRSQLNAM
            FROM DANGKY
            WHERE NAM=to_char(sysdate, 'YYYY') AND ((HK=1 AND to_char(sysdate, 'MM')='04') OR (HK=2 AND to_char(sysdate, 'MM')='05') OR (HK=3 AND to_char(sysdate, 'MM')='09'));
     
            RETURN 'HK = '''||STRSQLHK||''' AND NAM = ''' ||STRSQLNAM||'''';
        END IF;
    ELSE
        RETURN '';
    END IF;
    
  EXCEPTION
  WHEN NO_DATA_FOUND THEN
    RETURN '0=1';
  WHEN TOO_MANY_ROWS THEN
    RETURN 'Multiple rows returned';
END; 
/

BEGIN
DBMS_RLS.ADD_POLICY(
    object_schema   => 'ADMIN',
    object_name     => 'DANGKY',
    policy_name     => 'DANGKY_GIAOVU',
    policy_function => 'F_GIAOVU_DANGKY',
    statement_types => 'INSERT, DELETE',
    update_check    => TRUE
  );
END;
/
BEGIN
DBMS_RLS.DROP_POLICY(
    object_schema   => 'ADMIN',
    object_name     => 'DANGKY',
    policy_name     => 'DANGKY_GIAOVU'
   
  );
END;
--TEST
--SELECT * FROM ADMIN.NHANSU;
--SELECT * FROM ADMIN.SINHVIEN;
--SELECT * FROM ADMIN.DONVI;
--SELECT * FROM ADMIN.HOCPHAN;
--SELECT * FROM ADMIN.KHMO;
--SELECT * FROM ADMIN.PHANCONG;
--SELECT COUNT(*) FROM ADMIN.DANGKY;

------------------------------------------------------------------------------------------------------------------------

--CS#4
GRANT GIANG_VIEN TO TRUONGDONVI;
GRANT SELECT, UPDATE, INSERT, DELETE ON PHANCONG TO TRUONGDONVI;
/

CREATE OR REPLACE FUNCTION PHANCONG_TDV_FUNCTION
(P_SCHEMA VARCHAR2, P_OBJ VARCHAR2)
RETURN VARCHAR2
AS
    USR VARCHAR2(10);
    HP HOCPHAN.MAHP%TYPE;
    DV DONVI.TRGDV%TYPE;
    VAITROUSR VARCHAR2(20);
    STRSQL VARCHAR2(2000);
    CURSOR CUR IS (SELECT HP.MAHP, DVI.TRGDV FROM HOCPHAN HP JOIN DONVI DVI ON HP.MADV = DVI.MADV);
BEGIN
    USR:= SYS_CONTEXT('USERENV', 'SESSION_USER');
    
    IF (USR = 'ADMIN') THEN
        RETURN '';
    END IF;
    SELECT VAITRO INTO VAITROUSR FROM NHANSU WHERE MANV=USR;
    IF (VAITROUSR = 'TRUONG DON VI') THEN 
        OPEN CUR;
        LOOP
        FETCH CUR INTO HP,DV;
        EXIT WHEN CUR%NOTFOUND;
        
        IF (DV = USR) THEN 
            IF (STRSQL IS NOT NULL) THEN
            STRSQL := STRSQL ||''',''';
            END IF;
            STRSQL := STRSQL || HP;
        END IF;
        END LOOP;
        CLOSE CUR;    

    ELSE RETURN '';
    END IF;
       
    IF STRSQL IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('MAHP IN (''' || STRSQL || ''')');
            RETURN 'MAHP IN (''' || STRSQL || ''')';
        ELSE
            DBMS_OUTPUT.PUT_LINE('CHAY O DAY');
            RETURN '1=0'; -- Tr? v? ?i?u ki?n luï¿½n sai n?u khï¿½ng cï¿½ MAHP nï¿½o ???c tï¿½m th?y
        END IF;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
    //DBMS_OUTPUT.PUT_LINE('CHAY O DAY 2');
        RETURN '1=0';
END;  
/
BEGIN
DBMS_RLS.ADD_POLICY(
    object_schema   => 'ADMIN', 
    object_name     => 'PHANCONG',  
    policy_name     => 'PHANCONG_TDV_POLICY', 
    policy_function => 'PHANCONG_TDV_FUNCTION',  
    statement_types => 'DELETE, UPDATE,INSERT' ,     
    UPDATE_CHECK => TRUE
  );
END;
/
BEGIN
DBMS_RLS.DROP_POLICY(
    object_schema   => 'ADMIN', 
    object_name     => 'DANGKY',  
    policy_name     => 'CS6_4'
    );
    END;
    /
CREATE OR REPLACE FUNCTION F_PHANCONG_TRUONGDONVI_V2
(P_SCHEMA VARCHAR2, P_OBJ VARCHAR2)
RETURN VARCHAR2
AS
    USR VARCHAR2(10);
    HP HOCPHAN.MAHP%TYPE;
    DV DONVI.TRGDV%TYPE;
    VAITROUSR VARCHAR2(20);
    STRSQL VARCHAR2(2000);
    CURSOR CUR IS (SELECT HP.MAHP, DVI.TRGDV FROM HOCPHAN HP JOIN DONVI DVI ON HP.MADV = DVI.MADV);
    CURSOR CURV2 IS (SELECT MANV , MADV FROM NHANSU );
    NV NHANSU.MANV%TYPE;
    DVI NHANSU.MADV%TYPE;
    STRSQLV2 VARCHAR2(2000);
BEGIN
    USR:= SYS_CONTEXT('USERENV', 'SESSION_USER');
    
    IF (USR = 'ADMIN') THEN
        RETURN '';
    END IF;
    SELECT VAITRO INTO VAITROUSR FROM NHANSU WHERE MANV=USR;
    IF (VAITROUSR = 'TRUONG DON VI') THEN 
        OPEN CUR;
        LOOP
        FETCH CUR INTO HP,DV;
        EXIT WHEN CUR%NOTFOUND;
        IF (DV = USR) THEN 
            IF (STRSQL IS NOT NULL) THEN
            STRSQL := STRSQL ||''',''';
            END IF;
            STRSQL := STRSQL || HP;
        END IF;
        END LOOP;
        CLOSE CUR;  
        OPEN CURV2;
        LOOP
        FETCH CURV2 INTO NV,DVI;
        EXIT WHEN CURV2%NOTFOUND;
        IF (DVI = USR) THEN
            IF (STRSQLV2 IS NOT NULL) THEN
            STRSQLV2 := STRSQLV2 ||''',''';
            END IF;
            STRSQLV2 := STRSQLV2 || NV;
        END IF;
        END LOOP;
        CLOSE CURV2;  
    ELSE RETURN ''; 
    END IF;
    IF STRSQL IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('MAHP IN (''' || STRSQL || ''')');
            RETURN 'MAHP IN (''' || STRSQL || ''') OR MAGV IN (''' || STRSQLV2 || ''')';
      END IF;
END;
/
BEGIN
DBMS_RLS.ADD_POLICY(
    object_schema   => 'ADMIN', 
    object_name     => 'PHANCONG',  
    policy_name     => 'PHANCONG_TDV_POLICY_V2', 
    policy_function => 'F_PHANCONG_TRUONGDONVI_V2',  
    statement_types => 'SELECT'      
  );
END;
/
DECLARE
 USR VARCHAR2(10);
    HP ADMIN.HOCPHAN.MAHP%TYPE;
    DV ADMIN.DONVI.TRGDV%TYPE;
    VAITROUSR VARCHAR2(20);
    STRSQL VARCHAR2(2000);
    CURSOR CUR IS (SELECT HP.MAHP, DVI.TRGDV FROM ADMIN.HOCPHAN HP JOIN ADMIN.DONVI DVI ON HP.MADV = DVI.MADV);
    CURSOR CURV2 IS (SELECT MANV , MADV FROM ADMIN.NHANSU );
    NV ADMIN.NHANSU.MANV%TYPE;
    DVI ADMIN.NHANSU.MADV%TYPE;
    STRSQLV2 VARCHAR2(2000);
BEGIN

USR:= SYS_CONTEXT('USERENV', 'SESSION_USER');
    
    
    SELECT VAITRO INTO VAITROUSR FROM ADMIN.NHANSU WHERE MANV=USR;
    IF (VAITROUSR = 'TRUONG DON VI') THEN 
        OPEN CUR;
        LOOP
        FETCH CUR INTO HP,DV;
        EXIT WHEN CUR%NOTFOUND;
        IF (DV = USR) THEN 
            IF (STRSQL IS NOT NULL) THEN
            STRSQL := STRSQL ||''',''';
            END IF;
            STRSQL := STRSQL || HP;
        END IF;
        END LOOP;
        CLOSE CUR;  
        OPEN CURV2;
        LOOP
        FETCH CURV2 INTO NV,DVI;
        EXIT WHEN CURV2%NOTFOUND;
        IF (DVI = USR) THEN
            IF (STRSQLV2 IS NOT NULL) THEN
            STRSQLV2 := STRSQLV2 ||''',''';
            END IF;
            STRSQLV2 := STRSQLV2 || NV;
        END IF;
        END LOOP;
        CLOSE CURV2;  
    END IF;
    IF STRSQL IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('MAHP IN (''' || STRSQL || ''') OR MAGV IN (''' || STRSQLV2 || ''')');
          
      END IF;
END;

/
SELECT * FROM ADMIN.PHANCONG;
/
SET SERVEROUTPUT ON;
--TEST
--SELECT * FROM ADMIN.NHANSU;
--SELECT * FROM ADMIN.SINHVIEN;
--SELECT * FROM ADMIN.DONVI;
--SELECT * FROM ADMIN.HOCPHAN;
--SELECT * FROM ADMIN.KHMO;
--SELECT * FROM ADMIN.PHANCONG;
--SELECT * FROM ADMIN.DANGKY;

------------------------------------------------------------------------------------------------

--CS#5

GRANT GIANG_VIEN TO ROLE_TK;
GRANT SELECT,INSERT, DELETE, UPDATE ON PHANCONG TO ROLE_TK;
GRANT SELECT, DELETE, INSERT, UPDATE ON NHANSU TO ROLE_TK;
/

CREATE OR REPLACE FUNCTION PHANCONG_TRUONGKHOA_FUNCTION
    (P_SCHEMA VARCHAR2, P_OBJECT VARCHAR2)
RETURN VARCHAR2
AS
    USERNAME VARCHAR2(100);
    U_ROLE VARCHAR2(100);
BEGIN
   
    RETURN 'NOT EXISTS (SELECT * FROM SESSION_ROLES WHERE ROLE =''ROLE_TK'') OR MAHP IN (SELECT HP.MAHP FROM ADMIN.HOCPHAN HP JOIN ADMIN.DONVI DV ON HP.MADV = DV.MADV AND DV.MADV = ''VPK'')';

END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema => 'ADMIN',
        object_name => 'PHANCONG',
        policy_name => 'PHANCONG_TRUONGKHOA_POLICY',
        policy_function => 'PHANCONG_TRUONGKHOA_FUNCTION',
        statement_types => 'INSERT, DELETE, UPDATE',
        update_check => TRUE,
        enable => TRUE);
END;
/

--TEST
--SELECT * FROM ADMIN.NHANSU;
--SELECT * FROM ADMIN.SINHVIEN;
--SELECT * FROM ADMIN.DONVI;
--SELECT * FROM ADMIN.HOCPHAN;
--SELECT * FROM ADMIN.KHMO;
--SELECT * FROM ADMIN.PHANCONG;
--SELECT COUNT(*) FROM ADMIN.DANGKY;

--------------------------------------------------------------------------------------------

--CS#6
GRANT SELECT ON SINHVIEN TO ROLE_SV;
GRANT UPDATE (DCHI,DT) ON SINHVIEN TO ROLE_SV;
GRANT SELECT ON HOCPHAN TO ROLE_SV;
GRANT SELECT ON KHMO TO ROLE_SV;
GRANT SELECT, INSERT, UPDATE, DELETE ON DANGKY TO ROLE_SV;

CREATE OR REPLACE FUNCTION CS6_ONLYSV
    (P_SCHEMA VARCHAR2, P_OBJECT VARCHAR2)
RETURN VARCHAR2
AS
    USERNAME VARCHAR2(100);
    RESULT VARCHAR2(200);
BEGIN
    USERNAME := SYS_CONTEXT('USERENV', 'SESSION_USER');
    --Kiem tra xem user co role ROLE_SV khong
    RESULT := 'NOT EXISTS (SELECT * FROM SESSION_ROLES WHERE ROLE =''ROLE_SV'') OR MASV= ''' ||  USERNAME || '''';
    RETURN RESULT;
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema => 'ADMIN',
        object_name => 'SINHVIEN',
        policy_name => 'CS6_1',
        policy_function => 'CS6_ONLYSV',
        statement_types => 'SELECT,UPDATE',
        update_check => TRUE,
        enable => TRUE);
END;
/


BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'ADMIN',
        object_name => 'SINHVIEN',
        policy_name => 'CS6_1');
END;
/


CREATE OR REPLACE FUNCTION CS6_ONLYSV_DK
    (P_SCHEMA VARCHAR2, P_OBJECT VARCHAR2)
RETURN VARCHAR2
AS
    USERNAME VARCHAR2(100);
    RESULT VARCHAR2(200);
    IS_SV INT;
BEGIN
    USERNAME := SYS_CONTEXT('USERENV', 'SESSION_USER');
    SELECT COUNT(*) INTO IS_SV
    FROM ADMIN.SINHVIEN SV
    WHERE SV.masv = USERNAME ;
  
    IF (IS_SV = 1) THEN 
        RETURN 'MASV=''' || USERNAME || '''';
    END IF;
    RETURN '1=1';
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema => 'ADMIN',
        object_name => 'DANGKY',
        policy_name => 'CS6_1_DK',
        policy_function => 'CS6_ONLYSV_DK',
        statement_types => 'SELECT, INSERT, UPDATE, DELETE',
        update_check => TRUE,
        enable => TRUE);
END;
/
BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'ADMIN',
        object_name => 'DANGKY',
        policy_name => 'CS6_1_DK');
END;
/


CREATE OR REPLACE FUNCTION CS6_TKHMO
    (P_SCHEMA VARCHAR2, P_OBJECT VARCHAR2)
RETURN VARCHAR2
AS
    USERNAME VARCHAR2(100);
    IF_SV INT;
    U_MACT VARCHAR2(4);
BEGIN
    USERNAME := SYS_CONTEXT('USERENV', 'SESSION_USER');
    --Kiem tra xem user co role ROLE_SV khong
    SELECT COUNT(*) INTO IF_SV
    FROM SINHVIEN
    WHERE MASV = USERNAME;
    
    IF (IF_SV = 1) THEN
        SELECT MACT INTO U_MACT 
        FROM SINHVIEN 
        WHERE MASV = USERNAME;
        RETURN 'MACT = ''' || U_MACT || '''';
    ELSE 
        RETURN '1=1';
    END IF;
END;       
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema => 'ADMIN',
        object_name => 'KHMO',
        policy_name => 'CS6_2',
        policy_function => 'CS6_TKHMO',
        statement_types => 'SELECT',
        update_check => FALSE,
        enable => TRUE);
END;
/

-- CHINH SACH KHONG CHO SINH VIEN DANG KY SAU HAN MO HOC PHAN
CREATE OR REPLACE FUNCTION CS6_DANGKY_CD
    (P_SCHEMA VARCHAR2, P_OBJECT VARCHAR2)
RETURN VARCHAR2
AS
    USERNAME VARCHAR2(100);
    IS_SV INT;
    current_year NUMBER;
    current_semester NUMBER;
    current_day NUMBER;    
BEGIN
    USERNAME := SYS_CONTEXT('USERENV', 'SESSION_USER');
    --Kiem tra xem user co role ROLE_SV khong
   SELECT COUNT(*) INTO IS_SV
   FROM SINHVIEN   
   WHERE MASV = USERNAME;

    IF (IS_SV <1) THEN 
        RETURN '1=1';
    END IF;
    --lay nam, thang, ngay hien tai
    SELECT EXTRACT(YEAR FROM SYSDATE) INTO current_year FROM DUAL;
    SELECT EXTRACT(MONTH FROM SYSDATE) INTO current_semester FROM DUAL;
    SELECT EXTRACT(DAY FROM SYSDATE) INTO current_day FROM DUAL;
    -- KIEM TRA CO CON HAN DANG KY KHONG
--    RETURN 'NAM = ' || '2024' || ' AND HK = 1'; -- To test
    IF (current_day > 14) THEN
        RETURN '1=0';
    END IF;

    IF (current_semester = 1) THEN
        RETURN 'NAM = ' || current_year || ' AND HK = 1';
    ELSIF (current_semester = 5) THEN
        RETURN 'NAM = ' || current_year || ' AND HK = 2';
    ELSIF (current_semester = 9) THEN
        RETURN 'NAM = ' || current_year || ' AND HK = 3';
    END IF;
    
    RETURN '1=0';
END;
/

BEGIN
  DBMS_RLS.ADD_POLICY(
    object_schema => 'ADMIN',
    object_name => 'DANGKY',
    policy_name => 'CS6_4',
    policy_function => 'CS6_DANGKY_CD',
    statement_types => 'INSERT, DELETE',
    update_check => TRUE);
END;
/

BEGIN
  DBMS_RLS.DROP_POLICY(
    object_schema => 'ADMIN',
    object_name => 'DANGKY',
    policy_name => 'CS6_4',
END;
/

select * from ADMIN.SINHVIEN;
select * from ADMIN.khmo;
select * from session_roles;
SELECT * FROM ADMIN.DANGKY;
SELECT * FROM ADMIN.PHANCONG;
SELECT * FROM ADMIN.HOCPHAN;
select * from ADMIN.KHMO;
select * from nhansu;

INSERT INTO ADMIN.HOCPHAN VALUES ('MAHP0051','Toan Ti Phu',3,40,18,40,'VPK');
INSERT INTO KHMO VALUES ('MAHP0051',2,2024,'CTTT');
INSERT INTO PHANCONG VALUES ('NV0040','MAHP0051',2,2024,'CTTT');
/
INSERT INTO ADMIN.PHANCONG VALUES ('NV0042','MAHP0011',1,2024,'VP');


SELECT MAX(MANV) FROM ADMIN.NHANSU WHERE MANV LIKE 'NV%';

SELECT * FROM DANGKY WHERE NAM = '2024'

 

UPDATE DANGKY
SET NAM = 2024 WHERE M
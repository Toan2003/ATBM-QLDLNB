ALTER SESSION SET CURRENT_SCHEMA = ADMIN;
ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE;

CREATE ROLE GIAOVU;
GRANT NHAN_VIEN_CO_BAN TO GIAOVU;
GRANT SELECT, UPDATE, INSERT, DELETE ON SINHVIEN TO GIAOVU;
GRANT SELECT, UPDATE, INSERT, DELETE ON DONVI TO GIAOVU;
GRANT SELECT, UPDATE, INSERT, DELETE ON HOCPHAN TO GIAOVU;
GRANT SELECT, UPDATE, INSERT, DELETE ON KHMO TO GIAOVU;

GRANT SELECT ON PHANCONG TO GIAOVU;

CREATE OR REPLACE FUNCTION F_GIAOVU_PHANCONG
    (P_SCHEMA VARCHAR2, P_OBJ VARCHAR2)
RETURN VARCHAR2
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
    object_schema   => 'ADMIN', -- Thay th? b?ng schema c?a b?n
    object_name     => 'PHANCONG',  -- Thay th? b?ng tên b?ng c?a b?n
    policy_name     => 'PHANCONG_GIAOVU', --Tên cho chính sách c?a b?n
    policy_function => 'F_GIAOVU_PHANCONG',  -- Hàm chính sách c?a b?n
    statement_types => 'UPDATE'      -- Lo?i câu l?nh áp d?ng chính sách (ví d?: SELECT, INSERT, UPDATE, DELETE)
           -- Ki?m tra c?p nh?t (n?u c?n)
  );
END;
/

CREATE USER NV0019 IDENTIFIED BY 123;
GRANT CREATE SESSION TO NV0019;
GRANT GIAOVU TO NV0019;
SELECT * FROM ADMIN.PHANCONG;
GRANT SELECT , UPDATE ON PHANCONG TO GIAOVU;

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
    END IF;
    RETURN '';
    EXCEPTION
  WHEN NO_DATA_FOUND THEN
    -- X? lý tr??ng h?p không tìm th?y d? li?u
    RETURN '0=1';
  WHEN TOO_MANY_ROWS THEN
    -- X? lý tr??ng h?p có nhi?u h?n m?t hàng th?a mãn ?i?u ki?n
    RETURN 'Multiple rows returned';

END; 
/

BEGIN
DBMS_RLS.ADD_POLICY(
    object_schema   => 'ADMIN', -- Thay th? b?ng schema c?a b?n
    object_name     => 'DANGKY',  -- Thay th? b?ng tên b?ng c?a b?n
    policy_name     => 'DANGKY_GIAOVU', --Tên cho chính sách c?a b?n
    policy_function => 'F_GIAOVU_DANGKY',  -- Hàm chính sách c?a b?n
    statement_types => 'DELETE, UPDATE'      -- Lo?i câu l?nh áp d?ng chính sách (ví d?: SELECT, INSERT, UPDATE, DELETE)
           -- Ki?m tra c?p nh?t (n?u c?n)
  );
END;
/
SELECT * FROM ADMIN.DANGKY;

GRANT SELECT ON DANGKY TO GIAOVU;
GRANT DELETE, UPDATE ON DANGKY TO GIAOVU;







/
CREATE ROLE TRUONGDONVI;
CREATE USER NV0003 IDENTIFIED BY 123;
GRANT CREATE SESSION TO NV0003 ;
GRANT TRUONGDONVI TO NV0003 ;
DROP USER NV0003;
/
SET SERVEROUTPUT ON;
--Thêm, Xóa, C?p nh?t d? li?u trên quan h? PHANCONG, ??i v?i các h?c ph?n ???c
--ph? trách chuyên môn b?i ??n v? mà mình làm tr??ng, 
CREATE OR REPLACE FUNCTION F_TDV_PHANCONG
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
        
    END IF;
    IF STRSQL IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('MAHP IN (''' || STRSQL || ''')');
            RETURN 'MAHP IN (''' || STRSQL || ''')';
        ELSE
            DBMS_OUTPUT.PUT_LINE('CHAY O DAY');
            RETURN '1=0'; -- Tr? v? ?i?u ki?n luôn sai n?u không có MAHP nào ???c tìm th?y
        END IF;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
    DBMS_OUTPUT.PUT_LINE('CHAY O DAY 2');
        RETURN '1=0';
END;  
/
BEGIN
DBMS_RLS.ADD_POLICY(
    object_schema   => 'ADMIN', -- Thay th? b?ng schema c?a b?n
    object_name     => 'PHANCONG',  -- Thay th? b?ng tên b?ng c?a b?n
    policy_name     => 'PHANCONG_TRUONGDONVI', --Tên cho chính sách c?a b?n
    policy_function => 'F_TDV_PHANCONG',  -- Hàm chính sách c?a b?n
    statement_types => 'SELECT,DELETE, UPDATE,INSERT' ,     -- Lo?i câu l?nh áp d?ng chính sách (ví d?: SELECT, INSERT, UPDATE, DELETE)
           -- Ki?m tra c?p nh?t (n?u c?n)
    UPDATE_CHECK => TRUE
  );
END;

 /
 BEGIN
DBMS_RLS.DROP_POLICY(
    object_schema   => 'ADMIN', -- Thay th? b?ng schema c?a b?n
    object_name     => 'PHANCONG',  -- Thay th? b?ng tên b?ng c?a b?n
    policy_name     => 'PHANCONG_TRUONGDONVI' --Tên cho chính sách c?a b?n
   
  );
END;
/
SELECT * FROM ADMIN.PHANCONG;   
/
GRANT GIANG_VIEN TO TRUONGDONVI;
/
GRANT SELECT, UPDATE, INSERT, DELETE ON PHANCONG TO TRUONGDONVI;
/
SELECT HP.MAHP, DV.TRGDV FROM HOCPHAN HP JOIN DONVI DV ON HP.MADV = DV.MADV AND DV.TRGDV='NV0003';
/
CREATE OR REPLACE FUNCTION F_TEST
RETURN VARCHAR2
AS
HP HOCPHAN.MAHP%TYPE;
    DV DONVI.TRGDV%TYPE;
STRSQL VARCHAR2(2000);
CURSOR CUR IS SELECT HP.MAHP, DVI.TRGDV FROM HOCPHAN HP, DONVI DVI WHERE HP.MADV = DVI.MADV;
BEGIN
    OPEN CUR;
        LOOP
        FETCH CUR INTO HP,DV;
        EXIT WHEN CUR%NOTFOUND;
        
        IF (DV = 'NV0003') THEN 
            IF (STRSQL IS NOT NULL) THEN
            STRSQL := STRSQL ||''',''';
            END IF;
            STRSQL := STRSQL || HP;
        END IF;
        END LOOP;
    CLOSE CUR;
    DBMS_OUTPUT.PUT_LINE('MAHP IN (' || STRSQL || ')');
    RETURN 'MAHP IN (''' || STRSQL || ''')';
EXCEPTION
    WHEN OTHERS THEN
        -- X? lý ngo?i l? t?i ?ây
        RETURN NULL;
END;
/
SELECT F_TEST() FROM DUAL;

SELECT * FROM HOCPHAN;

INSERT INTO HOCPHAN(MAHP, TENHP, SOTC, STLT, STTH, SOSVTD, MADV)
VALUES ('MAHP1000', 'TESST THOI', 2,28,20,35,'HTTT');

SELECT * FROM PHANCONG;
INSERT INTO PHANCONG(MAGV, MAHP, HK, NAM, MACT)
VALUES ('NV0002', 'MAHP1000', 2,2025,'CLC');

SELECT * FROM KHMO;
INSERT INTO KHMO(MAHP,HK,NAM,MACT)
VALUES ( 'MAHP1000', 2,2025,'CLC');

SELECT * FROM ADMIN.PHANCONG WHERE MAHP='MAHP1000';
/

select * from sinhvien where masv = 'SV004003'
SELECT MAX(MASV) FROM SINHVIEN
select * from nhansu

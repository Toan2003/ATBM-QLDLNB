--Pham Phu Toan

-- Restart the database again
SHUTDOWN IMMEDIATE;
STARTUP;

--CAC LENH KIEM TRA
--CREATE USER SV000011 IDENTIFIED BY SV000011;
--GRANT CONNECT TO SV000012;
--SET SERVEROUTPUT ON;
--GRANT ROLE_SV TO SV000011;
--GRANT SELECT ON SINHVIEN TO SV000012;

--SELECT * FROM DBA_ROLE_PRIVS WHERE GRANTED_ROLE = 'ROLE_SV';
--SELECT * FROM DBA_ROLE_PRIVS WHERE GRANTEE = 'ROLE_SV';
--SELECT * FROM DBA_TAB_PRIVS WHERE GRANTEE = 'ROLE_SV';

-- TEST THU CHINH SACH
SELECT * FROM ADMIN.SINHVIEN;
/
UPDATE ADMIN.SINHVIEN
SET DT= '0000',
    DCHI = '11111';
/
--CS#6
--CREATE ROLE ROLE_SV;
----CAPQUYEN
----XEM THONG TIN CA NHAN CUA BAN THAN
--GRANT SELECT ON SINHVIEN TO ROLE_SV;
----CHINH SUA (DCHI,DT) CUA BAN THAN
--GRANT UPDATE (DCHI,DT) ON SINHVIEN TO ROLE_SV;
----XEM THONG TIN CUA HOC PHAN
--GRANT SELECT ON HOCPHAN TO ROLE_SV;
----XEM THONG TIN KE HOACH MO MON
--GRANT SELECT ON KHMO TO ROLE_SV;
----CRUD THONG TIN DANG KY HOC PHAN
--GRANT SELECT, INSERT, UPDATE, DELETE ON DANGKY TO ROLE_SV;
--/



DECLARE
    STRSQL VARCHAR(200);
BEGIN
    STRSQL := 'ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE';
    EXECUTE IMMEDIATE(STRSQL);
    
--    STRSQL := 'CREATE USER SV000012 IDENTIFIED BY SV000012';
--    EXECUTE IMMEDIATE(STRSQL);
    
    EXECUTE IMMEDIATE 'CREATE ROLE ROLE_SV';

    --CAPQUYEN
    --XEM THONG TIN CA NHAN CUA BAN THAN
    EXECUTE IMMEDIATE 'GRANT SELECT ON SINHVIEN TO ROLE_SV';
    --CHINH SUA (DCHI,DT) CUA BAN THAN
    EXECUTE IMMEDIATE 'GRANT UPDATE (DCHI,DT) ON SINHVIEN TO ROLE_SV';
    --XEM THONG TIN CUA HOC PHAN
    EXECUTE IMMEDIATE 'GRANT SELECT ON HOCPHAN TO ROLE_SV';
    --XEM THONG TIN KE HOACH MO MON
    EXECUTE IMMEDIATE 'GRANT SELECT ON KHMO TO ROLE_SV';
    --CRUD THONG TIN DANG KY HOC PHAN
    EXECUTE IMMEDIATE 'GRANT SELECT, INSERT, UPDATE, DELETE ON DANGKY TO ROLE_SV';
    
    STRSQL := 'ALTER SESSION SET "_ORACLE_SCRIPT" = FALSE';
    EXECUTE IMMEDIATE(STRSQL);

END;

--HAM CHINH SACH
--TRA VE MA SINH VIEN
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
--    SELECT COUNT(*) INTO IS_SINHVIEN
--    FROM ADMIN.SINHVIEN SV
--    WHERE SV.masv = USERNAME ;
-- 
--    IF (IS_SINHVIEN = 1) THEN 
--        RETURN 'MASV=''' || USERNAME || '''';
--    END IF;
    RETURN RESULT;
END;
/
--SELECT SYS_CONTEXT('SYS_SESSION_ROLES','ROLE_SV') FROM DUAL;
--SELECT * FROM SESSION_ROLES;
--GRANT EXECUTE ON CS6_ONLYSV TO SV000012;
SELECT ADMIN.CS6_ONLYSV('tt','ttt') FROM dual;

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

-- TRA VE MA SINH VIEN CHO DANG KY (KHONG DUNG CHUNG VOI CHINH SACH TREN DE TRANH BI XUNG DOT)
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
SELECT * FROM ADMIN.DANGKY;
--BEGIN
--     DBMS_RLS.DROP_POLICY(
--         object_schema => 'ADMIN',
--         object_name => 'DANGKY',
--         policy_name => 'CS6_1_DK');
-- END;
-- /
 
-- TRA VE MA CHUONG TRINH DAO TAO CUA SINH VIEN
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
--GRANT EXECUTE ON CS6_TKHMO TO SV000011;
--SELECT ADMIN.CS6_TKHMO('tt','ttt') FROM dual;
SELECT * FROM ADMIN.KHMO;
GRANT SELECT ON ADMIN.DANGKY TO SV000012;
SELECT * FROM ADMIN.DANGKY;
select* from ADMIN.SINHVIEN;
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

-- BEGIN
--     DBMS_RLS.DROP_POLICY(
--         object_schema => 'ADMIN',
--         object_name => 'KHMO',
--         policy_name => 'CS6_2');
-- END;
-- /

-- CHINH SACH CHO HOC PHAN
--CREATE OR REPLACE FUNCTION CS6_HOCPHAN
--    (P_SCHEMA VARCHAR2, P_OBJECT VARCHAR2)
--RETURN VARCHAR2
--AS
--    USERNAME VARCHAR2(100);
--    IF_SV INT;
--    SQLSTR VARCHAR2 (2000);
--    MAHP VARCHAR2(8);
--    CURSOR CUR IS (SELECT MAHP 
--                    FROM ADMIN.KHMO 
--                    WHERE MACT IN (SELECT MACT 
--                                    FROM ADMIN.SINHVIEN 
--                                    WHERE MASV =SYS_CONTEXT('USERENV', 'SESSION_USER')));
--BEGIN
--    USERNAME := SYS_CONTEXT('USERENV', 'SESSION_USER');
--    --Kiem tra xem user co role ROLE_SV khong
--    SELECT COUNT(*) INTO IF_SV
--    FROM SINHVIEN
--    WHERE MASV = USERNAME;
--    
--    IF (IF_SV = 1) THEN
--        OPEN CUR;
--        LOOP
--            FETCH CUR INTO MAHP;
--            EXIT WHEN CUR%NOTFOUND;
--            IF (SQLSTR IS NOT NULL) THEN
--                SQLSTR := SQLSTR || ''',''';
--            END IF;
--            SQLSTR := SQLSTR || MAHP;
--        END LOOP;
--        RETURN 'MAHP IN (''' ||SQLSTR||''')';
--    ELSE 
--        RETURN '1=1';
--    END IF;
--END;       
--/

SELECT * FROM HOCPHAN WHERE mahp in (SELECT MAHP FROM KHMO WHERE MACT IN (SELECT MACT FROM SINHVIEN WHERE MASV ='SV000011'));
SELECT ADMIN.CS6_HOCPHAN('tt','ttt') FROM dual;
GRANT SELECT ON ADMIN.KHMO TO SV000012;
GRANT EXECUTE ON CS6_HOCPHAN TO SV000012;
REVOKE EXECUTE ON CS6_HOCPHAN FROM SV000012;
SELECT * FROM ADMIN.HOCPHAN;
SELECT * FROM ADMIN.KHMO;
/

--CREATE OR REPLACE FUNCTION CS6_HOCPHAN
--    (P_SCHEMA VARCHAR2, P_OBJECT VARCHAR2)
--RETURN VARCHAR2
--AS
--    USERNAME VARCHAR2(100);
--    IF_SV INT;
----    CURSOR CUR IS (SELECT MAHP 
----                    FROM ADMIN.KHMO 
----                    WHERE MACT IN (SELECT MACT 
----                                    FROM ADMIN.SINHVIEN 
----                                    WHERE MASV =SYS_CONTEXT('USERENV', 'SESSION_USER')));
--BEGIN
--    USERNAME := SYS_CONTEXT('USERENV', 'SESSION_USER');
--    --Kiem tra xem user co role ROLE_SV khong
--    SELECT COUNT(*) INTO IF_SV
--    FROM SINHVIEN
--    WHERE MASV = USERNAME;
--    
--    IF (IF_SV = 1) THEN
--        RETURN 'MAHP IN (SELECT MAHP FROM ADMIN.KHMO)'; -- DA CO CHINH SACH CHI XEM KHMO CUA BAN THAN 
--    ELSE 
--        RETURN '1=1';
--    END IF;
--END;       
--/

--BEGIN
--    DBMS_RLS.ADD_POLICY(
--        object_schema => 'ADMIN',
--        object_name => 'HOCPHAN',
--        policy_name => 'CS6_3',
--        policy_function => 'CS6_HOCPHAN',
--        statement_types => 'SELECT',
--        update_check => FALSE,
--        enable => TRUE);
--END;
--/

-- BEGIN
--     DBMS_RLS.DROP_POLICY(
--         object_schema => 'ADMIN',
--         object_name => 'HOCPHAN',
--         policy_name => 'CS6_3');
-- END;
-- /
select * from ADMIN.DANGKY;

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
select * from ADMIN.dangky;
GRANT EXECUTE ON CS6_DANGKY_CD TO SV000011;
SELECT ADMIN.CS6_DANGKY_CD('tt','ttt') FROM dual;

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

INSERT INTO ADMIN.DANGKY (MASV,MAGV,MAHP, HK, NAM,MACT)
VALUES ('SV000011','NV0091','MAHP0033',1,2024,'VP')
/
DELETE FROM ADMIN.DANGKY WHERE MASV = SYS_CONTEXT('USERENV', 'SESSION_USER') AND MAHP = 'MAHP0033';
/
BEGIN
     DBMS_RLS.DROP_POLICY(
         object_schema    => 'ADMIN',
         object_name      => 'DANGKY',
         policy_name      => 'CS6_4'
     );
 END;
/

--CHINH SACH SINH VIEN KHONG DUOC UPDATE DIEM SO TREN DANGKY
CREATE OR REPLACE FUNCTION CS6_NCUD_ON_SCORE 
    (P_SCHEMA VARCHAR2, P_OBJECT VARCHAR2)
RETURN VARCHAR2
AS
  username VARCHAR2(100);
  u_role VARCHAR2(100);
BEGIN
  username := SYS_CONTEXT('USERENV', 'SESSION_USER');
  
  -- Kiem tra xem user co role ROLE_SV khong
  SELECT granted_role INTO u_role
  FROM user_role_privs
  WHERE grantee = username AND granted_role = 'ROLE_SV';
  
  IF u_role IS NOT NULL THEN
    RETURN '1=0'; -- Khong the cap nhat truong diem so
  ELSE
    RETURN NULL; -- co the truy cap
  END IF;
END;
/

BEGIN
  DBMS_RLS.ADD_POLICY(
    object_schema => 'ADMIN',
    object_name => 'DANGKY',
    policy_name => 'CS6_4',
    policy_function => 'CS6_NCUD_ON_SCORE',
    statement_types => 'UPDATE, INSERT, DELETE',
    sec_relevant_cols => 'DIEMTH, DIEMQT, DIEMCK, DIEMTK',
    sec_relevant_cols_opt => DBMS_RLS.ALL_ROWS,
    update_check => TRUE,
    enable => TRUE);
END;
/

-- BEGIN
--     DBMS_RLS.DROP_POLICY(
--         object_schema    => 'ADMIN',
--         object_name      => 'DANGKY',
--         policy_name      => 'CS6_4'
--     );
-- END;
-- /
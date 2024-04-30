SELECT * FROM  DBA_FGA_AUDIT_TRAIL;
select * from UNIFIED_AUDIT_TRAIL ;
select * from STMT_AUDIT_OPTION_MAP;
ALTER SESSION SET "_ORACLE_SCRIPT" = FALSE;
create role TEST123;

ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE;
CREATE USER TESTER IDENTIFIED BY 123;
/
GRANT TEST123 TO TESTER;
/

AUDIT SELECT ON ADMIN.NHANSU ;

AUDIT SELECT ON NHANSU;

SHOW PARAMETER audit_trail;

SELECT * FROM ADMIN.NHANSU;

SELECT username FROM dba_users WHERE username = 'ADMIN';


SELECT * FROM dba_sys_privs WHERE privilege = 'AUDIT SYSTEM';

SELECT username FROM dba_users WHERE USERNAME = 'ADMIN';


SELECT table_name FROM dba_tables WHERE owner = 'ADMIN';

AUDIT SELECT ON ADMIN.NHANSU;

SELECT * FROM DBA_SYS_PRIVS WHERE GRANTEE = 'ADMIN' AND PRIVILEGE LIKE 'AUDIT%';

SELECT * FROM DBA_TAB_PRIVS WHERE  TABLE_NAME = 'DBA_AUDIT_TRAIL';


-- Ki?m tra xem schema ADMIN có t?n t?i không
SELECT username FROM dba_users WHERE username = 'ADMIN';

-- Ki?m tra xem b?ng NHANSU có trong schema ADMIN không
SELECT table_name FROM dba_tables WHERE owner = 'ADMIN' AND table_name = 'NHANSU';


AUDIT SELECT ON ADMIN.NHANSU BY ACCESS;

CREATE TABLE employees (
    employee_id NUMBER(6) PRIMARY KEY,
    name VARCHAR2(50) NOT NULL,
    email VARCHAR2(100) UNIQUE NOT NULL,
    department_id NUMBER(4)
);
AUDIT SELECT ON ADMIN.DANGKY BY ACCESS;

AUDIT SELECT ON ADMIN.EMPLOYEES BY ACCESS;

SELECT * FROM dba_tab_privs WHERE TABLE_NAME = 'DANGKY';


CREATE TABLE Dangky1 AS SELECT * FROM DANGKY;
DROP TABLE DANGKY;
RENAME DANGKY1 TO DANGKY;
AUDIT SELECT ON ADMIN.DANGKY;

grant create session to tester;
grant select on admin.dangky to tester;

SELECT * FROM DBA_AUDIT_TRAIL;
--kich hoat audit
ALTER SYSTEM SET audit_trail=db, extended SCOPE=SPFILE;
SET SERVEROUTPUT ON;

--theo doi hanh vi cua nhung user 
CREATE OR REPLACE FUNCTION ISGIANGVIEN
RETURN INT
AS
    RESULT INT;
BEGIN
    SELECT COUNT(*) INTO RESULT  FROM ADMIN.NHANSU WHERE MANV = SYS_CONTEXT('USERENV', 'SESSION_USER') AND VAITRO = 'GIANG VIEN';
    DBMS_OUTPUT.PUT_LINE(SYS_CONTEXT('USERENV', 'SESSION_USER'));
    DBMS_OUTPUT.PUT_LINE(RESULT);
    
    RETURN RESULT;
END;
 /   
GRANT EXECUTE ON ISGIANGVIEN TO NV0001;
DECLARE 
    TET INT;
BEGIN
    SELECT ADMIN.ISGIANGVIEN FROM DUAL;
END;
/

SELECT * FROM ALL_ERRORS WHERE OWNER = 'ADMIN' AND NAME = 'ISGIANGVIEN' AND TYPE = 'FUNCTION';

SELECT COUNT(*) FROM ADMIN.NHANSU WHERE MANV = SYS_CONTEXT('USERENV', 'SESSION_USER') AND VAITRO = 'GIANG VIEN';
SELECT SYS_CONTEXT('USERENV', 'SESSION_USER') FROM DUAL;
--T?O FINE-GRAINED-AUDIT:
SELECT * FROM ADMIN.DANGKY;
/
BEGIN
  DBMS_FGA.add_policy(
    object_schema   => 'ADMIN',
    object_name     => 'DANGKY',
    policy_name     => 'FGA_1',
   audit_condition => 'ISGIANGVIEN=0',
    audit_column    => 'DIEMTH, DIEMQT, DIEMTK, DIEMCK',
    audit_column_opts   => DBMS_FGA.ANY_COLUMNS,
    enable          => TRUE,
    statement_types => 'UPDATE,SELECT'
   
  );
END;
/

BEGIN
  DBMS_FGA.drop_policy(
    object_schema   => 'ADMIN',
    object_name     => 'DANGKY',
    policy_name     => 'FGA_1'
  );
END;
/
BEGIN
  DBMS_FGA.add_policy(
    object_schema   => 'ADMIN',          -- Schema ch?a b?ng
    object_name     => 'NHANSU',   -- Tên b?ng
    policy_name     => 'audit_salary_selects', -- Tên chính sách FGA
    audit_condition => 'manv != SYS_CONTEXT(''USERENV'', ''SESSION_USER'')' ,
    audit_column    => 'PHUCAP',      -- C?t ???c audit
    enable          => TRUE,          -- Kích ho?t chính sách
    statement_types => 'SELECT'       -- Lo?i câu l?nh ???c audit
  );
END;
/
BEGIN
  DBMS_FGA.drop_policy(
    object_schema   => 'ADMIN',          -- Schema ch?a b?ng
    object_name     => 'NHANSU',   -- Tên b?ng
    policy_name     => 'audit_salary_selects'
  );
END;
/
BEGIN
  DBMS_FGA.add_policy(
    object_schema   => 'ADMIN',          -- Schema ch?a b?ng
    object_name     => 'NHANSU',   -- Tên b?ng
    policy_name     => 'MANV', -- Tên chính sách FGA
    audit_column    => 'PHUCAP',      -- C?t ???c audit
    enable          => TRUE,          -- Kích ho?t chính sách
    statement_types => 'SELECT'       -- Lo?i câu l?nh ???c audit
  );
END;
SELECT * FROM USER_ERRORS WHERE NAME = 'FGA_1';

SELECT * FROM DBA_FGA_AUDIT_TRAIL;
SELECT * FROM NHANSU WHERE MANV = 'tester' AND VAITRO ='GIANG VIEN';
grant select on dangky to tester;
CREATE USER NV0028 IDENTIFIED BY 123;
GRANT CREATE SESSION TO NV0028;

GRANT UPDATE(DIEMTH) ON ADMIN.DANGKY TO NV0028;
GRANT UPDATE ON ADMIN.DANGKY TO TESTER;
SELECT * FROM DBA_TAB_PRIVS WHERE TABLE_NAME = 'DANGKY';

GRANT SELECT ON NHANSU TO tester;

GRANT SELECT ON DANGKY TO NV0028;
/
SELECT * FROM DBA_FGA_AUDIT_TRAIL;


show parameter db_create_file_dest;



ALTER SYSTEM SET audit_trail=db, extended SCOPE=SPFILE;

SELECT TABLE_NAME FROM ALL_TABLES WHERE OWNER = 'ADMIN';

SELECT * FROM DBA_AUDIT_TRAIL WHERE USERNAME = 'NV0001' AND RETURNCODE = 0;

DESCRIBE DBA_AUDIT_TRAIL;

SELECT * FROM DBA_AUDIT_TRAIL WHERE OBJ_NAME='NHANVIEN';

SELECT *
FROM DBA_AUDIT_POLICIES;

cr


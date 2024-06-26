--Pham Phu Toan

--CS#5
-- DROP ROLE_TK;

CREATE ROLE ROLE_TK; 

GRANT ROLE_GIANGVIEN TO ROLE_TK;

GRANT SELECT,INSERT, DELETE, UPDATE ON PHANCONG TO ROLE_TK;
GRANT SELECT, DELETE, INSERT, UPDATE ON NHANSU TO ROLE_TK;

GRANT SELECT ON ADMIN.DANGKY TO ROLE_TK;
GRANT SELECT ON ADMIN.SINHVIEN TO ROLE_TK;
GRANT SELECT ON ADMIN.KHMO TO ROLE_TK;
GRANT SELECT ON ADMIN.DONVI TO ROLE_TK;
GRANT SELECT ON ADMIN.HOCPHAN TO ROLE_TK;

/

--CHINH SACH
CREATE OR REPLACE FUNCTION CS5_HOCPHAN_VPK
    (P_SCHEMA VARCHAR2, P_OBJECT VARCHAR2)
RETURN VARCHAR2
AS
    USERNAME VARCHAR2(100);
    U_ROLE VARCHAR2(100);
BEGIN
   
    RETURN 'NOT EXISTS (SELECT * FROM SESSION_ROLES WHERE ROLE =''ROLE_TK'') OR MAHP IN (SELECT HP.MAHP FROM ADMIN.HOCPHAN HP JOIN ADMIN.DONVI DV ON WHERE HP.MADV = DV.MADV AND DV.MADV = ''VPK'')';

END;
/

-- BEGIN
--     DBMS_RLS.DROP_POLICY(
--         object_schema => 'ADMIN',
--         object_name => 'PHANCONG',
--         policy_name => 'CS5_1');
-- END;


BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema => 'ADMIN',
        object_name => 'PHANCONG',
        policy_name => 'CS5_1',
        policy_function => 'CS5_HOCPHAN_VPK',
        statement_types => 'INSERT, DELETE, UPDATE',
        update_check => TRUE,
        enable => TRUE);
END;
/
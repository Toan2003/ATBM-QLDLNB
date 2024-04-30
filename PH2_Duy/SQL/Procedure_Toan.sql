SET SERVEROUTPUT ON;
GRANT EXECUTE ON GetListKHMOToRegisterSV TO ROLE_SV;
GRANT EXECUTE ON GetTheListOfDangKy TO ROLE_SV;
--AUTHID CURRENT_USER

CREATE OR REPLACE PROCEDURE GetListKHMOToRegisterSV
    (p_cursor OUT SYS_REFCURSOR)
IS 
    CUR_MONTH NUMBER;
    CUR_HK NUMBER;
    CUR_MACT VARCHAR(4);
BEGIN
    SELECT EXTRACT(MONTH FROM SYSDATE) INTO CUR_MONTH FROM DUAL;
    
    BEGIN
        SELECT SV.MACT INTO CUR_MACT
        FROM SINHVIEN SV
        WHERE SV.MASV = SYS_CONTEXT('USERENV', 'SESSION_USER');
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            -- Handle the case when no rows are found for the session user
            -- For example, set a default value for CUR_MACT
            CUR_MACT := '';
    END;
        
    IF (CUR_MONTH = 1) THEN
        CUR_HK := 1;
    ELSIF (CUR_MONTH = 5) THEN
        CUR_HK :=2;
    ELSIF (CUR_MONTH = 9) THEN
        CUR_HK :=3;
    END IF;
--    CUR_MACT := 'VP  ';
    OPEN p_cursor FOR
        SELECT H.TENHP ,C.MAGV, C.MAHP, C.HK, C.NAM, C.MACT
        FROM PHANCONG C JOIN HOCPHAN H ON C.MAHP =H.MAHP
--        WHERE C.HK = CUR_HK AND C.NAM = EXTRACT(YEAR FROM SYSDATE) AND C.MACT=CUR_MACT;
-- TEST
        WHERE C.HK = CUR_HK AND C.NAM = EXTRACT(YEAR FROM SYSDATE) AND C.MACT=CUR_MACT AND C.MAHP NOT IN (SELECT DK.MAHP
                                                                                                    FROM DANGKY DK
                                                                                                    WHERE DK.MASV = SYS_CONTEXT('USERENV', 'SESSION_USER')
                                                                                                    AND DK.HK = CUR_HK
                                                                                                    AND DK.NAM =  EXTRACT(YEAR FROM SYSDATE)
                                                                                                    AND DK.MACT = CUR_MACT);
END;
/
-- TEST PROCEDURE
DECLARE
    v_cursor SYS_REFCURSOR;
    v_TENHP   VARCHAR2(50);
    v_MAGV   VARCHAR2(20);
    v_MAHP   VARCHAR2(20);
    HK NUMBER;
    NAM NUMBER;
    MACT VARCHAR2(20);
BEGIN
    ADMIN.GetListKHMOToRegisterSV(p_cursor => v_cursor);
    
    -- Fetch and display the results from the cursor
    LOOP
        BEGIN
            FETCH v_cursor INTO v_TENHP,v_MAGV, v_MAHP,HK,NAM,MACT;
            EXIT WHEN v_cursor%NOTFOUND;
            -- Display or process each record as needed
            DBMS_OUTPUT.PUT_LINE('MAGV: ' || v_MAGV || ', MAHP: ' || v_MAHP || ',HK: '||HK || ',NAM: '||NAM || ',MACT: '||MACT);
        EXCEPTION
            WHEN NO_DATA_FOUND THEN
                EXIT; -- Exit the loop if no data found
        END;
    END LOOP;
    
    -- Close the cursor after processing
    CLOSE v_cursor;
END;
/
CREATE OR REPLACE PROCEDURE GetTheListOfDangKy
    ( HK1 IN INT , 
    NAM1 IN INT,
    p_cursor OUT SYS_REFCURSOR)
AUTHID CURRENT_USER
IS
BEGIN
     OPEN p_cursor FOR
        SELECT HP.TENHP,DK.MAHP,DK.MASV, DK.HK, DK.NAM, DK.MACT, DK.MAGV, DK.DIEMTH, DK.DIEMQT, DK.DIEMCK, DK.DIEMTK
        FROM ADMIN.DANGKY DK 
        JOIN ADMIN.HOCPHAN HP ON DK.MAHP = HP.MAHP
        WHERE DK.HK = HK1 and DK.NAM = NAM1;
END;
/
GRANT EXECUTE ON GetTheListOfDangKy TO SV000011;
select * from ADMIN.DANGKY WHERE HK =3 AND NAM = 2024;
select * from ADMIN.DANGKY dk join ADMIN.hocphan hp on dk.mahp=hp.mahp WHERE dk.HK =3 AND dk.NAM = 2024;
/
-- DANG BI DINH CHINH SACH MA HOC PHAN
select * from ADMIN.hocphan WHERE mahp = 'MAHP0003';

CREATE OR REPLACE PROCEDURE InsertNewDangKy
    ( U_MASV IN VARCHAR2,
    U_MAGV IN VARCHAR2, 
    U_MAHP IN VARCHAR2,
    U_HK IN INT,
    U_NAM IN INT,
    U_MACT IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR)
AUTHID CURRENT_USER
IS
BEGIN
     INSERT INTO ADMIN.DANGKY (MASV,MAGV,MAHP,HK,NAM,MACT)
     VALUES (U_MASV,U_MAGV,U_MAHP,U_HK,U_NAM,U_MACT);
END;
/

CREATE OR REPLACE PROCEDURE DeleteFromDangKy
    (U_MASV IN VARCHAR2,
    U_MAGV IN VARCHAR2,
    U_MAHP IN VARCHAR2,
    U_HK IN INT,
    U_NAM IN INT,
    U_MACT IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR)
AUTHID CURRENT_USER
IS
BEGIN
     DELETE FROM ADMIN.DANGKY WHERE MASV = U_MASV AND MAHP = U_MAHP AND MAGV= U_MAGV AND HK = U_HK AND NAM = U_NAM AND MACT=U_MACT;
END;
/

-- cho giao vu

CREATE OR REPLACE PROCEDURE GetListKHMOToRegisterGVu
    (CUR_MASV IN VARCHAR2,
    CUR_HK IN INT, 
    CUR_NAM IN INT, 
    p_cursor OUT SYS_REFCURSOR)
IS
    CUR_MACT VARCHAR(4);
BEGIN
     BEGIN
        SELECT SV.MACT INTO CUR_MACT
        FROM SINHVIEN SV
        WHERE SV.MASV = CUR_MASV;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            -- Handle the case when no rows are found for the session user
            -- For example, set a default value for CUR_MACT
            CUR_MACT := '';
    END;

    OPEN p_cursor FOR
        SELECT H.TENHP ,C.MAGV, C.MAHP, C.HK, C.NAM, C.MACT
        FROM PHANCONG C JOIN HOCPHAN H ON C.MAHP =H.MAHP
        WHERE C.HK = CUR_HK 
                AND C.NAM = CUR_NAM 
                AND C.MACT = CUR_MACT 
                AND C.MAHP NOT IN (SELECT DK.MAHP
                                    FROM DANGKY DK
                                    WHERE DK.MASV = CUR_MASV
                                    AND DK.HK = CUR_HK
                                    AND DK.NAM = CUR_NAM);                                                              
END;
/
GRANT EXECUTE ON InsertNewDangKy TO ROLE_SV;
GRANT EXECUTE ON DeleteFromDangKy TO ROLE_SV;

INSERT INTO ADMIN.KHMO VALUES ('MAHP0041', 1, 2024, 'VP');
INSERT INTO ADMIN.KHMO VALUES ('MAHP0033', 1, 2024, 'VP');
INSERT INTO ADMIN.KHMO VALUES ('MAHP0022', 1, 2024, 'VP');
/
INSERT INTO ADMIN.PHANCONG(MAGV,MAHP,HK,NAM,MACT) VALUES ('NV0091','MAHP0009',2,2024,'CTTT');
INSERT INTO ADMIN.PHANCONG(MAGV,MAHP,HK,NAM,MACT) VALUES ('NV0091','MAHP0012',2,2024,'VP');
INSERT INTO ADMIN.DANGKY(MASV,MAGV,MAHP,HK,NAM,MACT) VALUES('SV000001','NV0091','MAHP0012',2,2024,'VP');
delete from admin.dangky where masv = 'SV000001' and mahp ='MAHP0012';
INSERT INTO ADMIN.PHANCONG(MAGV,MAHP,HK,NAM,MACT) VALUES ('NV0091','MAHP0022',1,2024,'VP');

alter session pluggable database pdbqldlnb open;
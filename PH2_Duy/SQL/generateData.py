import random
from faker import Faker
import pandas as pd

# Đọc dữ liệu từ file Excel
fake = Faker()

# Số lượng records
num_nhansu = 107
num_sinhvien = 4000
num_donvi = 7
num_hocphan = 50
num_khmo = 50
num_phancong = 50
num_dangky = 4000

def generate_data():
    nhansu_data = []
    sinhvien_data = []
    donvi_data = []
    hocphan_data = []
    khmo_data = []
    phancong_data = []
    dangky_data = []

    ten_don_vi_list = ['VAN PHONG KHOA', 'BO MON HTTTT', 'BO MON CNPM', 'BO MON KHMT', 'BO MON CNTT', 'BO MON TGMTT', 'BO MON MMT VA VIEN THONG']
    ma_don_vi_list = ['VPK','HTTT','CNPM','KHMT','CNTT','TGMT','MMTVT']
    ma_chuong_trinh_list = ['CQ', 'CLC', 'CTTT', 'VP']

    #Trưởng khoa
    lastDigit = random.randrange(10, 50)
    firstDigit = random.randrange(1000, 5000)
    nhansu = {
        'MANV': 'NV0001',
        'HOTEN': fake.name(),
        'PHAI': random.choice(['NAM', 'NU']),
        'NGSINH': fake.date_of_birth(minimum_age=20, maximum_age=60),
        'PHUCAP': round(random.uniform(0, 100), 2),
        'DT': f'0{firstDigit}{000}{lastDigit}',
        'VAITRO': 'TRUONG KHOA',
        'MADV': 'VPK'
    }
    nhansu_data.append(nhansu)
    #Trưởng đơn vị
    for i in range(2, 8):
        lastDigit = random.randrange(10, 50)
        firstDigit = random.randrange(1000, 5000)
        nhansu = {
            'MANV': f'NV{i:04d}',
            'HOTEN': fake.name(),
            'PHAI': random.choice(['NAM', 'NU']),
            'NGSINH': fake.date_of_birth(minimum_age=20, maximum_age=60),
            'PHUCAP': round(random.uniform(0, 100), 2),
            'DT': f'0{firstDigit}{i:03d}{lastDigit}',
            'VAITRO': 'TRUONG DON VI',
            'MADV': ma_don_vi_list[i-1]
        }
        nhansu_data.append(nhansu)
    
    #Nhân viên cơ bản
    for i in range(8, 18):
        lastDigit = random.randrange(10, 50)
        firstDigit = random.randrange(1000, 5000)
        nhansu = {
            'MANV': f'NV{i:04d}',
            'HOTEN': fake.name(),
            'PHAI': random.choice((['NAM', 'NU'])),
            'NGSINH': fake.date_of_birth(minimum_age=20, maximum_age=60),
            'PHUCAP': round(random.uniform(0, 100), 2),
            'DT': f'0{firstDigit}{i:03d}{lastDigit}',
            'VAITRO': 'NHAN VIEN CO BAN',
            'MADV': random.choice(ma_don_vi_list)
        }
        nhansu_data.append(nhansu)

    #Giáo vụ
    for i in range(18, 28):
        lastDigit = random.randrange(10, 50)
        firstDigit = random.randrange(1000, 5000)
        nhansu = {
            'MANV': f'NV{i:04d}',
            'HOTEN': fake.name(),
            'PHAI': random.choice(['NAM', 'NU']),
            'NGSINH': fake.date_of_birth(minimum_age=20, maximum_age=60),
            'PHUCAP': round(random.uniform(0, 100), 2),
            'DT': f'0{firstDigit}{i:03d}{lastDigit}',
            'VAITRO': 'GIAO VU',
            'MADV': random.choice(ma_don_vi_list)
        }
        nhansu_data.append(nhansu)
    #Giảng viên
    for i in range(28, 108):
        lastDigit = random.randrange(10, 50)
        firstDigit = random.randrange(1000, 5000)
        nhansu = {
            'MANV': f'NV{i:04d}',
            'HOTEN': fake.name(),
            'PHAI': random.choice(['NAM', 'NU']),
            'NGSINH': fake.date_of_birth(minimum_age=20, maximum_age=60),
            'PHUCAP': round(random.uniform(0, 100), 2),
            'DT': f'0{firstDigit}{i:03d}{lastDigit}',
            'VAITRO': 'GIANG VIEN',
            'MADV': random.choice(ma_don_vi_list)
        }
        nhansu_data.append(nhansu)
    
    #Sinh viên    
    for i in range(1, num_sinhvien + 1):
        lastDigit = random.randrange(50, 100)
        firstDigit = random.randrange(1, 10)
        sinhvien = {
            'MASV': f'SV{i:06d}',
            'HOTEN': fake.name(),
            'PHAI': random.choice(['NAM', 'NU']),
            'NGSINH': fake.date_of_birth(minimum_age=18, maximum_age=30),
            'DCHI': fake.address(),
            'DT': f'0{firstDigit}{i:06d}{lastDigit}',
            'MACT': random.choice(ma_chuong_trinh_list),
            'MANGANH': random.choice(['HTTT','CNPM','KHMT','CNTT','TGMT','MMTVT']),
            'SOTCTL': random.randint(120, 160),
            'DTBTL': round(random.uniform(5, 10), 2)
        }
        sinhvien_data.append(sinhvien)
    
    #Đơn vị
    for i in range(1, len(ten_don_vi_list)):
        donvi = {
            'MADV': ma_don_vi_list[i],
            'TENDV': ten_don_vi_list[i],
            'TRGDV': f'NV{i+1:04d}',
        }
        donvi_data.append(donvi)

    #Học phần
    for i in range(1, num_hocphan + 1):
        hocphan = {
            'MAHP': f'MAHP{i:04d}',
            'TENHP': fake.sentence(nb_words=5)[:30],
            'SOTC': random.randint(1, 4),
            'STLT': random.randint(20, 30),
            'STTH': random.randint(10, 20),
            'SOSVTD': random.randint(20, 50),
            'MADV': random.choice(ma_don_vi_list[1:])
        }
        hocphan_data.append(hocphan)

    #Kế hoạch mở
    for i in range(1, num_khmo + 1):
        khmo = {
            'MAHP': f'MAHP{i:04d}',
            'HK': random.randint(1, 3),
            'NAM': random.randint(2024, 2026),
            'MACT': random.choice(ma_chuong_trinh_list)
        }
        khmo_data.append(khmo)
    
    #Phân công
    for i in range(num_phancong):
        id_giaovien = random.choice([n['MANV'] for n in nhansu_data if n['VAITRO'] == 'GIANG VIEN' or 'TRUONG KHOA' or 'TRUONG DON VI'])
        phancong = {
            'MAGV': id_giaovien,
            'MAHP': khmo_data[i]['MAHP'],
            'HK': khmo_data[i]['HK'],
            'NAM': khmo_data[i]['NAM'],
            'MACT': khmo_data[i]['MACT']
        }
        phancong_data.append(phancong)
    
    #Đăng ký
    for i in range(1, num_dangky + 1):
        rd_phan_cong = random.choice(phancong_data)
        dangky = {
            'MASV': f'SV{i:06d}',
            'MAGV': rd_phan_cong['MAGV'],
            'MAHP': rd_phan_cong['MAHP'],
            'HK': rd_phan_cong['HK'],
            'NAM': rd_phan_cong['NAM'],
            'MACT': rd_phan_cong['MACT'],
            'DIEMTH': round(random.uniform(0, 10), 2),
            'DIEMQT': round(random.uniform(0, 10), 2),
            'DIEMCK': round(random.uniform(0, 10), 2),
            'DIEMTK': round(random.uniform(0, 10), 2)
        }
        dangky_data.append(dangky)

    return nhansu_data, sinhvien_data, donvi_data, hocphan_data, khmo_data, phancong_data, dangky_data


# Lưu dữ liệu vào file SQL
def save_to_sql():
    with open('data.sql', 'w', encoding='utf-8') as f:
        nhansu_data, sinhvien_data, donvi_data, hocphan_data, khmo_data, phancong_data, dangky_data = generate_data()

        # Ghi dữ liệu cho bảng NHANSU
        for nhansu in nhansu_data:
            f.write(f"INSERT INTO NHANSU VALUES ('{nhansu['MANV']}', '{nhansu['HOTEN']}', '{nhansu['PHAI']}', TO_DATE('{nhansu['NGSINH']}', 'YYYY-MM-DD'), {nhansu['PHUCAP']}, '{nhansu['DT']}', '{nhansu['VAITRO']}', '{nhansu['MADV']}');\n")

        # Ghi dữ liệu cho bảng SINHVIEN
        for sinhvien in sinhvien_data:
            f.write(f"INSERT INTO SINHVIEN VALUES ('{sinhvien['MASV']}', '{sinhvien['HOTEN']}', '{sinhvien['PHAI']}', TO_DATE('{sinhvien['NGSINH']}', 'YYYY-MM-DD'), '{sinhvien['DCHI']}', '{sinhvien['DT']}', '{sinhvien['MACT']}', '{sinhvien['MANGANH']}', {sinhvien['SOTCTL']}, {sinhvien['DTBTL']});\n")

        # Ghi dữ liệu cho bảng DONVI
        for donvi in donvi_data:
            f.write(f"INSERT INTO DONVI VALUES ('{donvi['MADV']}', '{donvi['TENDV']}', '{donvi['TRGDV']}');\n")

        # Ghi dữ liệu cho bảng HOCPHAN
        for hocphan in hocphan_data:
            f.write(f"INSERT INTO HOCPHAN VALUES ('{hocphan['MAHP']}', '{hocphan['TENHP']}', {hocphan['SOTC']}, {hocphan['STLT']}, {hocphan['STTH']}, {hocphan['SOSVTD']}, '{hocphan['MADV']}');\n")

        # Ghi dữ liệu cho bảng KHMO
        for khmo in khmo_data:
            f.write(f"INSERT INTO KHMO VALUES ('{khmo['MAHP']}', {khmo['HK']}, {khmo['NAM']}, '{khmo['MACT']}');\n")

        # Ghi dữ liệu cho bảng PHANCONG
        for phancong in phancong_data:
            f.write(f"INSERT INTO PHANCONG VALUES ('{phancong['MAGV']}', '{phancong['MAHP']}', {phancong['HK']}, {phancong['NAM']}, '{phancong['MACT']}');\n")

        # Ghi dữ liệu cho bảng DANGKY
        for dangky in dangky_data:
            f.write(f"INSERT INTO DANGKY VALUES ('{dangky['MASV']}', '{dangky['MAGV']}', '{dangky['MAHP']}', {dangky['HK']}, {dangky['NAM']}, '{dangky['MACT']}', {dangky['DIEMTH']}, {dangky['DIEMQT']}, {dangky['DIEMCK']}, {dangky['DIEMTK']});\n")

# Gọi hàm lưu dữ liệu vào file SQL
save_to_sql()

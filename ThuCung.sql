---------------------------------------------------------
-- XÓA DATABASE NẾU ĐÃ TỒN TẠI
---------------------------------------------------------
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'QuanLyThuCung')
BEGIN
    USE master;
    ALTER DATABASE QuanLyThuCung SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QuanLyThuCung;
END;
GO
CREATE DATABASE QuanLyThuCung;
GO
USE QuanLyThuCung;
GO

-- Tạo các bảng với tiền tố tb (theo code của bạn)
CREATE TABLE tbVaiTro (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TenVaiTro NVARCHAR(50) NOT NULL
);

CREATE TABLE tbNguoiDung (
    Id INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100),
    Email NVARCHAR(100),
    MatKhau NVARCHAR(100),
    Sdt NVARCHAR(15),
    IdVaiTro INT,
    FOREIGN KEY (IdVaiTro) REFERENCES tbVaiTro(Id)
);

CREATE TABLE tbLoai (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TenLoai NVARCHAR(50)
);

CREATE TABLE tbThuCung (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TenThuCung NVARCHAR(100),
    Tuoi INT,
    GioiTinh NVARCHAR(10),
    MauSac NVARCHAR(50),
    CanNang FLOAT,
    GiongThuCung NVARCHAR(100),
    TieuChuanCanNang FLOAT,
    AnhThuCung NVARCHAR(255),
    GiaBan DECIMAL(18,2),
    IdLoai INT,
    FOREIGN KEY (IdLoai) REFERENCES tbLoai(Id)
);

CREATE TABLE tbHoaDon (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdNguoiDung INT,
    NgayLap DATETIME,
    TongTien DECIMAL(18,2),
    GhiChu NVARCHAR(255),
    FOREIGN KEY (IdNguoiDung) REFERENCES tbNguoiDung(Id)
);

CREATE TABLE tbChiTietHoaDon (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdHoaDon INT,
    IdThuCung INT,
    SoLuong INT,
    DonGia DECIMAL(18,2),
    ThanhTien DECIMAL(18,2),
    FOREIGN KEY (IdHoaDon) REFERENCES tbHoaDon(Id) ON DELETE CASCADE,
    FOREIGN KEY (IdThuCung) REFERENCES tbThuCung(Id)
);
---------------------------------------------------------
-- KIỂM TRA
---------------------------------------------------------
SELECT * FROM tbVaiTro;

SELECT * FROM tbLoai;
SELECT * FROM tbThuCung;
SELECT * FROM tbHoaDon;
SELECT * FROM tbChiTietHoaDon;
SELECT * FROM tbNguoiDung;
GO


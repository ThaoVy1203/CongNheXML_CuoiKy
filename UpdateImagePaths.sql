-- Script cập nhật đường dẫn ảnh cho thú cưng
USE QuanLyThuCung;
GO

-- Cập nhật đường dẫn ảnh (chỉ tên file, code sẽ tự tìm trong thư mục Images)
UPDATE tbThuCung SET anhThuCung = 'bong.png' WHERE tenThuCung = N'Bông';
UPDATE tbThuCung SET anhThuCung = 'cun.png' WHERE tenThuCung = N'Cún';
UPDATE tbThuCung SET anhThuCung = 'bingo.jpg' WHERE tenThuCung = N'Bingo';
UPDATE tbThuCung SET anhThuCung = 'milu.png' WHERE tenThuCung = N'Milu';
UPDATE tbThuCung SET anhThuCung = 'toby.png' WHERE tenThuCung = N'Toby';
UPDATE tbThuCung SET anhThuCung = 'lucy.png' WHERE tenThuCung = N'Lucy';
GO

-- Kiểm tra
SELECT idThuCung, tenThuCung, anhThuCung FROM tbThuCung;
GO

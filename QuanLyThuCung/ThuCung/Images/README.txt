HƯỚNG DẪN ĐẶT ẢNH THÚ CƯNG
=============================

Đặt các file ảnh vào thư mục này với tên như sau:

- bong.png (hoặc bong.jpg)
- cun.png
- bingo.jpg
- milu.png
- toby.png
- lucy.png

Sau đó chạy script UpdateImagePaths.sql để cập nhật database.

Hoặc bạn có thể đặt ảnh ở bất kỳ đâu và cập nhật đường dẫn đầy đủ trong database:
UPDATE tbThuCung SET anhThuCung = 'E:\Images\bong.png' WHERE tenThuCung = N'Bông';

Ứng dụng sẽ tự động tìm ảnh ở các vị trí:
1. Đường dẫn trong database
2. Thư mục bin\Debug\Images\
3. Thư mục project\Images\

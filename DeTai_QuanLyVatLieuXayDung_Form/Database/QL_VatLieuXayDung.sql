create DATABASE QL_VatLieuXayDung;
go
use QL_VatLieuXayDung
go
-- Bảng loại sản phẩm
CREATE TABLE LoaiSanPham (
    MaLoai INT IDENTITY(1,1)  PRIMARY KEY,
    TenLoai NVARCHAR(50) UNIQUE,
    MoTa NVARCHAR(255) ,
)

-- Bảng nhân viên
CREATE TABLE NhanVien (
    MaNV INT IDENTITY(1,1)  PRIMARY KEY,
    TenNV NVARCHAR(255) NOT NULL,
    Phai NVARCHAR(5) NOT NULL,
    NgaySinh DATE,
    DiaChi NVARCHAR(255) NOT NULL,
    SDT NVARCHAR(10) UNIQUE,
    TrangThai NVARCHAR(50) DEFAULT N'Đang làm',
	
	
    
)

-- Bảng sản phẩm
CREATE TABLE SanPham (
    MaSP INT IDENTITY(1,1)  PRIMARY KEY,
    TenSP NVARCHAR(255) UNIQUE ,
    DonViTinh  NVARCHAR(50) NOT NULL,
	SoSao int,
    GiaBan int,
    GiaNhap int,
    TinhTrang  NVARCHAR(50)  ,
    MoTa  NVARCHAR(255) NOT NULL,
    ThongTin  NVARCHAR(255) NOT NULL,
    ImageUrl  NVARCHAR(255) NOT NULL,
    MaLoai INT,
	TonKho int ,
	FOREIGN KEY (MaLoai) REFERENCES LoaiSanPham(MaLoai),
	
   
)

-- Bảng khách hàng
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1)  PRIMARY KEY,
    TenKH NVARCHAR(255) NOT NULL,
    Phai NVARCHAR(5) NOT NULL,
    NgaySinh DATE,
    DiaChi NVARCHAR(255) NOT NULL,
    SDT NVARCHAR(10) UNIQUE,
    UserName NVARCHAR(50) UNIQUE ,
    MatKhau NVARCHAR(255) ,
    Email NVARCHAR(255) ,
    TrangThai NVARCHAR(50) DEFAULT N'Không khoá',
		
)


create table PhanQuyen(
maquyen varchar(10) primary key,
tenquyen nvarchar(50),
trangthai nvarchar(50),
)

-- Bảng tài khoản nhân viên
CREATE TABLE TaiKhoanNV (
    UserName NVARCHAR(50) PRIMARY KEY,
    MatKhau NVARCHAR(255) NOT NULL,
    MaNV int Unique,
    maquyen varchar(10),
    TrangThai NVARCHAR(50) DEFAULT N'Off' ,
	FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
	foreign key (maquyen) references phanquyen(maquyen),
	
)



-- Bảng hãng sản xuất
CREATE TABLE HangSanXuat 
(
    MaHSX INT IDENTITY(1,1)  PRIMARY KEY,
    TenHSX NVARCHAR(255) UNIQUE,
    DiaChi NVARCHAR(255),
    SDT NVARCHAR(10) UNIQUE
)
--Khuyến mãi 
CREATE TABLE KhuyenMai (
    MaKhuyenMai NVarChar(50),
    PhanTramGiam INT,
    NgayApDung date,
	NgayHetHan date , 
	
	PRIMARY KEY (MaKhuyenMai),

)

-- Bảng hoá đơn
CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1)  PRIMARY KEY,
    MaKH INT,
    NgayLapHD DATETIME,
	SoHoaDon int,
	TenNguoiNhan NVARCHAR(255) NOT NULL,  
	DiaChi NVARCHAR(255) NOT NULL, 
    SDT NVARCHAR(10),
    Email NVARCHAR(255) ,
    ThanhTien INT,
	TienCoc int,
	MaKhuyenMai NVarChar(50) ,
	GhiChu NVARCHAR(255),
    TrangThai bit,
	FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
	FOREIGN KEY (MaKhuyenMai) REFERENCES KhuyenMai(MaKhuyenMai),
)


-- Bảng chi tiết hoá đơn
CREATE TABLE ChiTietHoaDon (
    MaHD INT,
    MaSP INT,
    SoLuong INT,
	GiaBan INT , 
	ThanhTien INT,
	PRIMARY KEY (MaHD, MaSP),
	FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
	FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
    
)

-- Bảng chi tiết xác nhận hoá đơn
CREATE TABLE XacNhanHoaDon (
    MaHD INT unique,
    MaNV INT UNIQUE,
    NgayXacNhan DATETIME,
	PRIMARY KEY (mahd, Manv),
	FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
	FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
    
)





-- Bảng phiếu đặt
CREATE TABLE PhieuDat (
    MaPhieuDat INT IDENTITY(1,1)  PRIMARY KEY,
    NgayLap DATE,
    TrangThai NVARCHAR(50),
    MaHSX int,
	FOREIGN KEY (MaHSX) REFERENCES HangSanXuat(MaHSX)
)
-- Bảng phiếu nhập
CREATE TABLE PhieuNhap (
    MaPhieuNhap INT IDENTITY(1,1)  PRIMARY KEY,
    MaNV INT,
    NgayNhap DATE,
    MaPhieuDat int,
    TongTien int,
    TrangThai NVARCHAR(50),
	FOREIGN KEY (MaPhieuDat) REFERENCES PhieuDat(MaPhieuDat),
	FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)

    
)
-- Bảng chi tiết phiếu đặt
CREATE TABLE ChiTietPhieuDat (
    MaPhieuDat INT,
    MaSanPham INT,
    SoLuong INT,
	PRIMARY KEY (MaPhieuDat, MaSanPham),
	FOREIGN KEY (MaPhieuDat) REFERENCES PhieuDat(MaPhieuDat),
	FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSP)
    
)

-- Bảng chi tiết phiếu nhập
CREATE TABLE ChiTietPhieuNhap (
    MaPhieuNhap INT,
    MaSP INT,
    SoLuong INT,
	GiaNhap INT , 
	ThanhTien INT,
	PRIMARY KEY (MaPhieuNhap, MaSP),
	FOREIGN KEY (MaPhieuNhap) REFERENCES PhieuNhap(MaPhieuNhap),
	FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP),

	 
)


-- Bảng tin tức
CREATE TABLE TinTuc (
    MaTin INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
	ImageUrl NVARCHAR (255),
    NoiDung TEXT,
    NgayDang DATE
    
)

-- Bảng lịch sử hoạt động
CREATE TABLE LichSuHoatDong (
    UserName  NVARCHAR(50),
    ThoiGian DATETIME,
    HoatDong NVARCHAR(255),
    TrangThai  NVARCHAR(50),
	PRIMARY KEY (UserName, ThoiGian),
)

-- Bảng sản phẩm yêu thích
CREATE TABLE SanPham_YeuThich (
    MaSP INT,
    MaKH int
	PRIMARY KEY (MaSP, MaKH),
	FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
	FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)

)
-- Bảng sản phẩm trong gio hang
CREATE TABLE SanPham_TrongGioHang(
    MaSP INT,
    MaKH int,
	SoLuong int,
	PRIMARY KEY (MaSP, MaKH),
	FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
	FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)

)

-- Bảng chi tiết sản phẩm hãng sản xuất
CREATE TABLE ChiTiet_SanPham_HangSanXuat (
    MaSP INT unique,
    MaHSX int
	PRIMARY KEY (MaSP, MaHSX),
	FOREIGN KEY (MaHSX) REFERENCES HangSanXuat(MaHSX),
	FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)

) 

CREATE TABLE LichSuGia (
    MaSP INT ,
	Gia INT,
    NgayCapNhat date,
	PRIMARY KEY (MaSP, Gia),
	FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)

) 

INSERT INTO NhanVien (TenNV, Phai, NgaySinh, DiaChi, SDT, TrangThai)
VALUES (N'Trương Thành Trung', N'Nam', '2002-01-15', N'Hà Nội', '0123456781', N'Đang làm'),
       (N'Mai Nguyễn Phước Yến', N'Nữ', '2002-03-20', N'Hồ Chí Minh', '0927655654', N'Đang làm'),
		(N'Nguyễn Nguyên Bảo', N'Nam', '2002-04-15', N'Bình Thuận', '0964788265', N'Đang làm'),
		(N'Trương Nhật Phong', N'Nam', '2002-01-13', N'Ninh Bình', '0935777841', N'Đang làm'),
		(N'Lý Hoàng Long', N'Nam', '2002-09-26', N'Bình Dương', '0927999865', N'Đang làm'),
		(N'Cao Thiên Ân', N'Nam', '2002-03-23', N'Đồng Nai', '0928155489', N'Đang làm'),
		(N'Võ Hương Quỳnh', N'Nữ', '2002-02-27', N'Bình Định', '0605227744', N'Đang làm'),
		(N'Nguyễn Thành Phú', N'Nam', '2002-06-09', N'Hồ Chí Minh', '0706443246', N'Đang làm'),
		(N'Hồ Mộng Như Uyên', N'Nữ', '2002-10-17', N'Hồ Chí Minh', '0255148645', N'Đang làm'),
		(N'Cao Ngọc Bảo Trân', N'Nữ', '2002-04-22', N'Nha Trang', '0953666297', N'Đang làm'),
		(N'Nguyễn Anh Vũ', N'Nam', '2002-09-11', N'Bình Dương', '0376841195', N'Đang làm'),
       (N'Nguyễn Thị Ngọc My', N'Nữ', '2002-05-28', N'Nha Trang', '0935788264', N'Đang làm');



INSERT INTO PhanQuyen (maquyen, tenquyen, trangthai)
VALUES ('USER', N'Quyền User', N'Hoạt động'),
		('ADMIN', N'Quyền Admin', N'Hoạt động');

INSERT INTO TaiKhoanNV (UserName, MatKhau, MaNV, maquyen, TrangThai)
VALUES ('admin1', '123', 1, 'ADMIN', N'Off'),
		('admin2', '123', 2, 'ADMIN', N'Off');



INSERT INTO LoaiSanPham (TenLoai, MoTa)
VALUES (N'Bê tông', N'VL'),
		(N'Cát', N'VL'),
		(N'Gạch', N'VL'),
		(N'Gỗ', N'VL'),
		(N'Thép', N'VL'),
		(N'Tôn', N'VL'),
		(N'Vật liệu cách âm', N'VL'),
		(N'Vật liệu cách nhiệt', N'VL'),
		(N'Xi măng', N'VL'),
		(N'Công cụ xây dựng', N'TB'),
		(N'Máy cắt', N'TB'),
		(N'Máy đào', N'TB'),
		(N'Máy hàn', N'TB'),
		(N'Máy khoan', N'TB'),
		(N'Máy nén khí', N'TB'),
		(N'Máy trộn bê tông', N'TB'),
		(N'Máy ủi', N'TB'),
		(N'Máy xúc', N'TB'),
		(N'Máy mài', N'TB');
		

INSERT INTO SanPham (TenSP, DonViTinh, SoSao, GiaBan, GiaNhap, TinhTrang, MoTa, ThongTin, ImageUrl, MaLoai, TonKho)
VALUES  (N'Bê tông M100R28', N'm3', 4, 1070000, 913000, N'Còn hàng', N'Độ sụt 10 + 2 , đơn vị tính m3', N'Thông tin sản phẩm 1', 'betong1.jpg', 1, 100),
		(N'Tấm Tường Bê Tông Cốt Thép Lõi Rỗng PBCOM', N'm3', 3, 1234000, 1002000, N'Còn hàng', N'Tấm tường lõi rỗng PBCOM được sản xuất theo quy cách chuẩn của nhà máy. Có 2 loại: HCW – 80×600 (tường dày 80mm, rộng 600mm) và HCW – 50×300 (tường dày 50mm, rộng 300mm).', N'Thông tin sản phẩm 2', 'betong2.jpg', 1, 100),
		(N'Tấm sàn bê tông cốt thép lõi rỗng PBCOM', N'm3', 5, 1700000, 1450000, N'Còn hàng', N'Tấm sàn lõi rỗng PBCOM được sản xuất theo quy cách chuẩn của nhà máy, dày 120mm và rộng 600mm, dày 50mm và rộng 300mm.', N'Thông tin sản phẩm 2', 'betong3.jpg', 1, 100),

		(N'Cát xây tô', N'm3', 5, 205000, 157000, N'Còn hàng', N'Cát xây tô là cát cho vữa xây trát là phần da thịt của công trình nên có vai trò rất quan trọng vì vậy cát xây tô được chúng tôi áp dụng những tiêu chuẩn khai thác.', N'Thông tin sản phẩm 2', 'cat1.jpg', 2, 100),
		(N'Cát vàng xây dựng', N'm3', 4, 330.000, 293000, N'Còn hàng', N'Cát vàng xây dựng được sử dụng phổ biến để đổ bê tông tươi, loại cát này có màu vàng đặc trưng. Khi sử dụng dòng cát vàng đổ bê tông giúp nhanh khô. Bên cạnh đó nhược điểm là cát không được sạch, vì vậy khi dùng đổ bê tông cần sàn lộc thật sạch.', N'Thông tin sản phẩm 2', 'cat2.jpg', 2, 100),
		(N'Cát san lấp', N'm3', 3, 175.000, 152000, N'Còn hàng', N'Cát san lấp mặt bằng chất lượng và uy tín nhất tại TPHCM. Việc san lấp mặt bằng với loại cát san lấp đúng chuẩn sẽ giúp mặt bằng trở nên chắc chắn và àn toàn.', N'Thông tin sản phẩm 2', 'cat3.jpg', 2, 100),
		
		(N'NIPPON GS06', N'Viên', 5, 21000, 19000, N'Còn hàng', N'Siêu nhẹ - Siêu Cứng với sợi gia cường PVA nhập khẩu, Siêu bền màu - Siêu bóng với công nghệ sơn Nano silicon, Kháng rêu mốc - chống bức xạ nhiệt tối đa', N'Thông tin sản phẩm 2', 'gach1.jpg', 3, 1000),
		(N'NIPPON NP 106', N'Viên', 5, 15000, 13500, N'Còn hàng', N'Ngói màu Nippon được sản xuất trên dây chuyền công nghệ tiên tiến từ Nhật Bản . Ưu điểm của ngói Nippon là : Bảo hành sơn màu sắc 10 năm, Độ bền kết cấu tĩnh 20 năm', N'Thông tin sản phẩm 2', 'gach2.jpg', 3, 1000),
		(N'NIPPON NP02', N'Viên', 2, 15000, 14000, N'Còn hàng', N'Kích thước viên ngói: 424 x335 mmm, Kích thước ngói sau khi lợp: 363 x303 mmm, Định lượng  1m2: 10 viên/1 m2', N'Thông tin sản phẩm 2', 'gach3.jpg', 3, 1000),
		
		(N'Pallet Gỗ', N'Tấm', 4, 120000, 105000, N'Còn hàng', N'Pallet Gỗ được sử dụng khá nhiều trong các khu vực kho xưởng với công dụng giúp cố định hàng hóa trong quá trình nâng chuyển, đảm bảo hàng hóa không tiếp xúc trực tiếp với sàn xưởng, nhà kho.', N'Thông tin sản phẩm 2', 'go1.jpg', 4, 1000),
		(N'Sàn gỗ công nghiệp Morser MB157', N'm2', 3, 385000, 362000, N'Còn hàng', N'Xuất xứ: Việt Nam – Bảo hành: 15 năm. Tính năng: Chống trầy, chống ẩm, chống mối mọt, an toàn sức khỏe với người sử dụng.', N'Thông tin sản phẩm 2', 'go2.jpg', 4, 1000),
		(N'Sàn gỗ công nghiệp Wilson W557', N'm2', 5, 200000, 175000, N'Còn hàng', N'Ứng dụng Lót sàn nhà ở, văn phòng, showroom… .Thương hiệu Wilson.Độ dày 8mm .Kích thước Ngang 202mm x 1225mm . Chất liệu Cốt gỗ HDF phủ phim vân gỗ.', N'Thông tin sản phẩm 2', 'go3.jpg', 4, 1000),

		(N'Thép tấm', N'Tấm 3ly', 1, 3180000, 2913000, N'Còn hàng', N'Thép tấm là loại thép thường được dùng trong các ngành đóng tàu, kết cấu nhà xưởng, cầu cảng, thùng, bồn xăng dầu, nồi hơi, cơ khí, các ngành xây dựng dân dụng, làm tủ điện, container, sàn xe, xe lửa, dùng để sơn mạ.', N'Thông tin sản phẩm 2', 'thep1.jpg', 5, 100),
		(N'Thép tấm chịu nhiệt ASTM-A515', N'Tấm 3ly', 4, 4438000, 4245000, N'Còn hàng', N'Thép tấm chịu nhiệt là thép chất lượng với ưu điểm chịu nhiệt, chịu áp suất tốt thường được sử dụng cho chế tạo nồi hơi, nồi hơi áp suất. Với độ bền và độ dẻo dai tốt nên còn đươc sử dụng cho các lò hơi công nghiệp.', N'Thông tin sản phẩm 2', 'thep2.jpg', 5, 100),
		(N'Thép tấm, lá CT3C-SS400-08KP-Q235B', N'Tấm 3ly', 5, 5950000, 5613000, N'Còn hàng', N'Khổ rộng: 1000mm-3000mm, Kích Thước :Độ dày :1mm-300mm, Tiêu Chuẩn :JIS G3101-JIS G3106,ASTM,JIS,TCVN,DIN,GOST,EN.', N'Thông tin sản phẩm 2', 'thep3.jpg', 5, 100),
		
		(N'Kìm bấm rive nhôm 43001 TOL 10inch', N'Chiếc', 4, 121000, 105000, N'Còn hàng', N'Thân máy bằng hợp kim nhôm, tiết kiệm nhân công hơn 40%. Thích hợp cho đinh tán nhôm, đinh tán thép, đinh tán thép không gỉ; Đinh tán áp dụng: 2,4mm (3/32 "), 3,2mm (1/8"), 4mm (5/32 "), 4,8mm (3/16")', N'Thông tin sản phẩm 2', 'cc1.jpg', 10, 100),
		(N'Kìm bấm nhọn 9 inch 10052 Tolsen', N'Chiếc', 5, 110000, 95000, N'Còn hàng', N'Kềm bấm nhọn 9 inch TOLSEN 10052 được làm bằng thép hợp kim CrV nên thân kềm rất chắc chắn, ngoài ra bước cuối cùng sản phẩm còn được xử lý kim loại Niken chống gĩ sét hiệu quả , khắc phục nhược điểm gỉ sét của hợp kim CrV', N'Thông tin sản phẩm 2', 'cc2.jpg', 10, 100),
		(N'Kìm nhọn mini 4.5 inch 10031 Tolsen', N'Chiếc', 3, 62000, 55000, N'Còn hàng', N'Kềm cắt Tolsen 4.5 inch thuộc dòng dân dụng Tolsen thường được sử dụng trong gia đình, cơ xưởng sản xuất hoặc sữa chữa nhỏ. Sản phẩm được ưa chuộng sử dụng trong xưởng gia công sửa chữa các đồ dùng nhỏ như sản xuất dày dép và túi xách.', N'Thông tin sản phẩm 2', 'cc3.jpg', 10, 100),
		
		(N'Máy hàn Jasic MIG250', N'Chiếc', 5, 11800000, 11200000, N'Còn hàng', N'Công nghệ inverter IGBT, hồ quang ổn định, hàn êm, độ bắn tóe ít, mối hàn ngấu sâu, sáng bóng. Điều khiển phản hồi vòng lặp kín, điện áp đầu ra ổn định. Chế độ tự động bù điện áp dao động khoảng ±15%.', N'Thông tin sản phẩm 2', 'mayhan1.jpg', 13, 100),
		(N'Máy hàn que dùng điện Jasic ARES 200', N'Chiếc', 4, 4340000, 4050000, N'Còn hàng', N'Máy hàn que dùng điện Jasic ARES 200 là dòng máy hàn que siêu khỏe, thay thế máy hàn cơ Sử dụng công nghệ inverter IGBT, linh kiện chính hãng, lắp đặt theo tiêu chuẩn quốc tế.', N'Thông tin sản phẩm 2', 'mayhan2.jpg', 13, 100),
		(N'Máy hàn que Jasic ARC 200', N'Chiếc', 2, 4150000, 4000000, N'Còn hàng', N'Máy hàn que Jasic ARC 200 là sản phẩm được sản xuất theo công nghệ của Anh Quốc có tính năng nổi bật là tiết kiệm năng lượng hơn so với máy hàn thông thường. Việc sử dụng máy hàn Jasic sẽ có hiệu suất làm việc rất cao, thời gian hàn không giới hạn.', N'Thông tin sản phẩm 2', 'mayhan3.jpg', 13, 100),
		
		(N'Máy khoan động lực Bosch GSB 16 RE', N'Chiếc', 5, 2169000, 1849000, N'Còn hàng', N'Máy khoan Bosch GSB 16 RE là sản phẩm máy khoan động lực mạnh mẽ và đa năng, được thiết kế để đáp ứng nhu cầu khoan đa dạng từ gỗ, bê tông đến thép.', N'Thông tin sản phẩm 2', 'maykhoan1.png', 14, 100),
		(N'Máy khoan bắt vít Makita M6201B', N'Chiếc', 4, 1741000, 1520000, N'Còn hàng', N'Máy khoan bắt vít Makita M6201B dùng điện, công suất 750W. Thiết bị có thể khoan sắt với đường kính 13mm, khoan gỗ với đường kính 36mm. Máy được ứng dụng trong các lĩnh vực cơ khí, nội thất, sửa chữa các thiết bị.', N'Thông tin sản phẩm 2', 'maykhoan2.jpg', 14, 100),
		(N'Máy khoan búa Makita HP1630', N'Chiếc', 5, 1490000, 1315000, N'Còn hàng', N'Dây dẫn dài ,Máy khoan Makita HP1630 được trang bị dây dẫn dài 2.0m, giúp người dùng dễ dàng di chuyển và sử dụng trong các không gian lớn hay vị trí khó tiếp cận.Trọng lượng nhẹ ,Với trọng lượng chỉ 2kg.', N'Thông tin sản phẩm 2', 'maykhoan3.jpg', 14, 100);


INSERT INTO KhachHang (TenKH, Phai, NgaySinh, DiaChi, SDT, UserName, MatKhau, Email, TrangThai)
VALUES (N'Nguyễn Văn Tuấn', N'Nam','1985-09-30', N'TP. Hồ Chí Minh', N'0946777364', N'tuan12', N'123', N'tuan12@gmail.com', N'Không khoá'),
		(N'Nguyễn Nguyên Bảo', N'Nam','2002-08-04', N'TP. Hồ Chí Minh', N'0569512477', N'1', N'1', N'040802.nguyenbao@gmail.com', N'Không khoá'),
		(N'Nguyễn Thị Ánh ', N'Nữ', '1985-08-10', N'TP. Hồ Chí Minh', N'0278555643', N'anhnguyen', N'123', N'anhnguyen@gmail.com', N'Không khoá'),
		(N'Trần Thị Quỳnh Như', N'Nữ', '1993-05-25', N'TP. Hồ Chí Minh', N'0797444362', N'nhu', N'123', N'nhu@gmail.com', N'Không khoá'),
		(N'Lê Thị Hồng', N'Nữ', '1998-12-05', N'TP. Hồ Chí Minh', N'0942888764', N'user5', N'hongle', N'hongle@gmail.com', N'Không khoá'),
		(N'Nguyễn Tuấn Tú', N'Nam', '1995-03-20', N'TP. Hồ Chí Minh', N'0124777652', N'user2', N'tu111', N'tu111@gmail.com', N'Không khoá');


INSERT INTO HangSanXuat (TenHSX, DiaChi, SDT)
VALUES (N'DURAflex', N'Lô G.02, Đường số 1, KCN Long Hậu, Long An', N'2838734701'),
		(N'CÔNG TY CỔ PHẦN ALLYBUILD VIỆT NAM', N'128 Hồng Hà, Phường 09, Quận Phú Nhuận, Tp.HCM', N'18009237'),
		(N'TOLSEN', N'Số 26A Trần Đại Nghĩa, P.Tân Tạo A, Q.Bình Tân, Hồ Chí Minh', N'0819005505'),
		(N'CTCP Tập Đoàn Hòa Phát', N'643 Điện Biên Phủ, P. 25, Q. Bình Thạnh, TP Hồ Chí Minh', N'2862985599'),
		(N'CTCP Tập Đoàn Hoa Sen', N'183 Nguyễn Văn Trỗi, Phường 10, Quận Phú Nhuận, TP Hồ Chí Minh', N'18001515'),
		(N'CTCP Tôn Đông Á', N'Số 5, đường số 5, Khu Công Nghiệp Sóng Thần 1, TP Dĩ An, tỉnh Bình Dương', N'2743790420'),
		(N'CTCP Vicostone', N'Khu công nghệ cao Hòa Lạc, Thạch Hòa, Thạch Thất, Hà Nội', N'18006766'),
		(N'CTCP Eurowindow', N'Số 02 Tôn Thất Tùng, Đống Đa, Hà Nội', N'8437474777'),
		(N'CTCP Công Nghiệp Vĩnh Tường', N'Lô C23a, Khu Công Nghiệp Hiệp Phước, Huyện Nhà Bè,TP Hồ Chí Minh', N'0837818554'),
		(N'CTCP Nhựa Thiếu Niên Tiền Phong', N'222 Mạc Đăng Doanh, Hưng Đạo, Dương Kinh, Hải Phòng', N'2253813979'),
		(N'Công ty TNHH Siam City Cement', N'Tòa Nhà E-Town Central 11 Đường Đoàn Văn Bơ, Quận 4, TP. HCM', N'2873017018'),
		(N'Tổng công ty Viglacera - CTCP', N'Tòa nhà Viglacera, Số 1 Đại lộ Thăng Long, Hà Nội', N'2435536660'),
		(N'CÔNG TY XI MĂNG NGHI SƠN', N'Phường Hải Thượng, Thị xã Nghi Sơn, Tỉnh Thanh Hóa, KCN Long Hậu, Long An', N'2373862013');

INSERT INTO ChiTiet_SanPham_HangSanXuat (MaSP, MaHSX)
VALUES (1, 3),
(12, 13),
(11, 13),
(13, 2),
(14, 2),
(15, 2),
 (16, 1),
 (17, 1),
 (18, 1),
 (19, 1),
 (20, 1);

INSERT INTO KhuyenMai
VALUES (N'Không có mã giảm giá', 0,null, null),
		(N'pynbatu', 30,'2023-11-27', '2023-12-10'),
		(N'nguyenbao', 20,'2023-11-27', '2023-12-10'),
		(N'phuocyen', 20,'2023-11-27', '2023-12-10'),
		(N'thanhtrung', 20,'2023-11-27', '2023-12-10'),
		(N'3dajazka', 10,'2023-11-27', '2023-12-10'),
		(N'gjfpskad', 10,'2023-11-27', '2023-12-10');


 -- Trigger để giảm số lượng tồn kho khi có hoá đơn mua hàng
GO
CREATE TRIGGER Trg_GiamTonKho
ON ChiTietHoaDon
AFTER INSERT
AS
BEGIN
    -- Cập nhật số lượng tồn kho của sản phẩm
    UPDATE SanPham
    SET TonKho = TonKho - i.SoLuong
    FROM SanPham
    INNER JOIN inserted i ON SanPham.MaSP = i.MaSP;
END;

-- Trigger để cập nhật trạng thái sản phẩm khi có hoá đơn mua hàng
GO
CREATE TRIGGER Trg_CapNhatTrangThai
ON ChiTietHoaDon
AFTER INSERT
AS
BEGIN
    -- Cập nhật trạng thái của sản phẩm khi số lượng tồn kho giảm xuống 0
    UPDATE SanPham
    SET TinhTrang = N'Hết hàng'
    WHERE MaSP IN (SELECT i.MaSP FROM inserted i
                   JOIN SanPham sp ON i.MaSP = sp.MaSP
                   WHERE sp.TonKho - i.SoLuong <= 0);
END;

-- Trigger để tăng số lượng tồn kho khi có chi tiết phiếu nhập
GO
CREATE TRIGGER Trg_TangTonKho
ON ChiTietPhieuNhap
AFTER INSERT
AS
BEGIN
    -- Cập nhật số lượng tồn kho của sản phẩm khi có chi tiết phiếu nhập
    UPDATE SanPham
    SET TonKho = TonKho + i.SoLuong
    FROM SanPham
    INNER JOIN inserted i ON SanPham.MaSP = i.MaSP;
END;

-- Trigger để tự động cập nhật lịch sử giá khi có chi tiết phiếu nhập
GO
CREATE TRIGGER Trg_CapNhatLichSuGia
ON ChiTietPhieuNhap
AFTER INSERT
AS
BEGIN
    -- Chèn thông tin lịch sử giá cho các sản phẩm trong chi tiết phiếu nhập
    INSERT INTO LichSuGia (MaSP, Gia, NgayCapNhat)
    SELECT i.MaSP, i.GiaNhap, CONVERT(DATE, GETDATE())
    FROM inserted i;
END;

-- Tạo trigger tự động cập nhật trạng thái phiếu đặt khi có chi tiết phiếu nhập
GO
CREATE TRIGGER UpdateTrangThaiPhieuDat
ON ChiTietPhieuNhap
AFTER INSERT
AS
BEGIN
    DECLARE @MaPhieuNhap INT, @SoLuongDat INT, @SoLuongNhap INT;
    
    -- Lấy thông tin MaPhieuNhap và SoLuongNhap từ dòng mới được chèn vào ChiTietPhieuNhap
    SELECT @MaPhieuNhap = i.MaPhieuNhap, @SoLuongNhap = i.SoLuong
    FROM inserted i;

    -- Lấy số lượng đặt từ bảng ChiTietPhieuDat
    SELECT @SoLuongDat = d.SoLuong
    FROM ChiTietPhieuDat d
    WHERE d.MaPhieuDat = (SELECT MaPhieuDat FROM ChiTietPhieuNhap WHERE MaPhieuNhap = @MaPhieuNhap);

    -- Kiểm tra xem số lượng nhập không lớn hơn số lượng đặt
    IF @SoLuongNhap >= @SoLuongDat
    BEGIN
        -- Cập nhật trạng thái của phiếu đặt sang 'Hoàn thành' nếu đủ số lượng nhập
        UPDATE PhieuDat
        SET TrangThai = N'Hoàn thành'
        WHERE MaPhieuDat = (SELECT MaPhieuDat FROM PhieuNhap WHERE MaPhieuNhap = @MaPhieuNhap);
    END;
END;

-- Trigger để cập nhật trạng thái của sản phẩm khi có chi tiết phiếu nhập được thêm vào
GO
CREATE TRIGGER Trg_CapNhatTrangThaiSanPham
ON ChiTietPhieuNhap
AFTER INSERT
AS
BEGIN
    -- Cập nhật trạng thái của sản phẩm thành 'Còn hàng' khi có chi tiết phiếu nhập được thêm vào
    UPDATE SanPham
SET TinhTrang = N'Còn hàng'
    FROM SanPham sp
    INNER JOIN inserted i ON sp.MaSP = i.MaSP;
END;

-- Trigger để cập nhật giá nhập của sản phẩm khi có chi tiết phiếu nhập được thêm vào
GO
CREATE TRIGGER Trg_CapNhatGiaNhapSanPham
ON ChiTietPhieuNhap
AFTER INSERT
AS
BEGIN
    -- Cập nhật giá nhập của sản phẩm khi có chi tiết phiếu nhập được thêm vào
    UPDATE SanPham
    SET GiaNhap = i.GiaNhap  -- Giả sử GiaNhap là cột trong ChiTietPhieuNhap
    FROM SanPham sp
    INNER JOIN inserted i ON sp.MaSP = i.MaSP;
END;


SELECT
    HD.NgayLapHD AS Ngay,
    SUM(CT.ThanhTien) AS DoanhThu,
    SUM(CT.ThanhTien - (COALESCE(LS.Gia, LSCuoiCung.Gia) * CT.SoLuong)) AS TienLoi
FROM
    HoaDon HD
JOIN
    ChiTietHoaDon CT ON HD.MaHD = CT.MaHD
OUTER APPLY (
    SELECT TOP 1 Gia
    FROM LichSuGia LS
    WHERE CT.MaSP = LS.MaSP AND HD.NgayLapHD >= LS.NgayCapNhat
    ORDER BY LS.NgayCapNhat DESC
) AS LS
OUTER APPLY (
    SELECT TOP 1 Gia
    FROM LichSuGia LS
    WHERE CT.MaSP = LS.MaSP
    ORDER BY LS.NgayCapNhat DESC
) AS LSCuoiCung
WHERE
    HD.TrangThai = 1 -- Lọc theo hóa đơn có trạng thái "đã thanh toán" (hoặc theo điều kiện của bạn)
GROUP BY
    HD.NgayLapHD;
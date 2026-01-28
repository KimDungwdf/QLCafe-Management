CREATE DATABASE QLCafe
GO

USE QLCafe
GO

DROP TABLE TaiKhoan

-- 1.1. Bảng Vai Trò (Phân quyền)
CREATE TABLE VaiTro (
    IDVaiTro INT PRIMARY KEY,
    TenVaiTro NVARCHAR(50) NOT NULL UNIQUE
)
GO

-- 1.2. Bảng Tài Khoản (Người dùng) - DÙNG PLAIN TEXT
CREATE TABLE TaiKhoan (
    TenDangNhap NVARCHAR(100) PRIMARY KEY,
    TenHienThi NVARCHAR(100) NOT NULL,
    MatKhau NVARCHAR(100) NOT NULL, -- PLAIN TEXT '123'
    IDVaiTro INT NOT NULL,
    FOREIGN KEY (IDVaiTro) REFERENCES VaiTro(IDVaiTro)
)
GO

-- 1.3. Bảng Danh Mục Món (Phân loại)
CREATE TABLE DanhMucMon (
    IDDanhMuc INT IDENTITY(1,1) PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL UNIQUE
)
GO

-- 1.4. Bảng Sản Phẩm (Món ăn, Đồ uống)
CREATE TABLE SanPham (
    IDSanPham INT IDENTITY(1,1) PRIMARY KEY,
    TenSanPham NVARCHAR(100) NOT NULL,
    IDDanhMuc INT NOT NULL,
    DonGia DECIMAL(18, 0) NOT NULL CHECK (DonGia >= 0),
    FOREIGN KEY (IDDanhMuc) REFERENCES DanhMucMon(IDDanhMuc)
)
GO

-- 1.5. Bảng Bàn
CREATE TABLE Ban (
    IDBan INT IDENTITY(1,1) PRIMARY KEY,
    TenBan NVARCHAR(100) NOT NULL UNIQUE,
    -- 0: Trống, 1: Có khách
    TrangThai INT NOT NULL DEFAULT 0 
)
GO

-- 1.6. Bảng Hóa Đơn
CREATE TABLE HoaDon (
    IDHoaDon INT IDENTITY(1,1) PRIMARY KEY,
    NgayLap DATETIME NOT NULL DEFAULT GETDATE(),
    TenDangNhap NVARCHAR(100) NOT NULL, -- Thu ngân lập
    IDBan INT NOT NULL,
    TongTien DECIMAL(18, 0) NOT NULL DEFAULT 0,
    GiamGia DECIMAL(18, 0) NOT NULL DEFAULT 0,
    -- 0: Chưa thanh toán (đang order), 1: Đã thanh toán
    TrangThai INT NOT NULL DEFAULT 0, 
    FOREIGN KEY (TenDangNhap) REFERENCES TaiKhoan(TenDangNhap),
    FOREIGN KEY (IDBan) REFERENCES Ban(IDBan)
)
GO

-- 1.7. Bảng Chi Tiết Hóa Đơn
CREATE TABLE ChiTietHoaDon (
    IDChiTietHD INT IDENTITY(1,1) PRIMARY KEY,
    IDHoaDon INT NOT NULL,
    IDSanPham INT NOT NULL,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGiaTaiThoiDiem DECIMAL(18, 0) NOT NULL,
    FOREIGN KEY (IDHoaDon) REFERENCES HoaDon(IDHoaDon) ON DELETE CASCADE,
    FOREIGN KEY (IDSanPham) REFERENCES SanPham(IDSanPham)
)
GO

-- 1.8. Bảng Đơn Vị Tính (Kho)
CREATE TABLE DonViTinh (
    IDDonViTinh INT IDENTITY(1,1) PRIMARY KEY,
    TenDVT NVARCHAR(50) NOT NULL UNIQUE
)
GO

-- 1.9. Bảng Nguyên Liệu (Kho)
CREATE TABLE NguyenLieu (
    IDNguyenLieu INT IDENTITY(1,1) PRIMARY KEY,
    TenNguyenLieu NVARCHAR(100) NOT NULL UNIQUE,
    IDDonViTinh INT NOT NULL,
    SoLuongTon DECIMAL(18, 2) NOT NULL DEFAULT 0,
    -- Định mức tồn kho tối thiểu để cảnh báo
    TonKhoToiThieu DECIMAL(18, 2) NOT NULL DEFAULT 10,
    FOREIGN KEY (IDDonViTinh) REFERENCES DonViTinh(IDDonViTinh)
)
GO

-- 1.10. Bảng Định Lượng (BOM)
CREATE TABLE DinhLuong (
    IDSanPham INT NOT NULL,
    IDNguyenLieu INT NOT NULL,
    SoLuongCan DECIMAL(18, 2) NOT NULL, -- Lượng NVL cần cho 1 SP
    PRIMARY KEY (IDSanPham, IDNguyenLieu),
    FOREIGN KEY (IDSanPham) REFERENCES SanPham(IDSanPham) ON DELETE CASCADE,
    FOREIGN KEY (IDNguyenLieu) REFERENCES NguyenLieu(IDNguyenLieu) ON DELETE CASCADE
)
GO

-- 1.11. Bảng Nhà Cung Cấp
CREATE TABLE NhaCungCap (
    IDNhaCungCap INT IDENTITY(1,1) PRIMARY KEY,
    TenNCC NVARCHAR(200) NOT NULL,
    DienThoai NVARCHAR(20),
    DiaChi NVARCHAR(255)
)
GO

-- 1.12. Bảng Phiếu Nhập Kho
CREATE TABLE PhieuNhap (
    IDPhieuNhap INT IDENTITY(1,1) PRIMARY KEY,
    NgayNhap DATETIME NOT NULL DEFAULT GETDATE(),
    IDNhaCungCap INT NOT NULL,
    TenDangNhap NVARCHAR(100) NOT NULL, -- Thủ kho nhập
    TongTienNhap DECIMAL(18, 0) NOT NULL DEFAULT 0,
    FOREIGN KEY (IDNhaCungCap) REFERENCES NhaCungCap(IDNhaCungCap),
    FOREIGN KEY (TenDangNhap) REFERENCES TaiKhoan(TenDangNhap)
)
GO

-- 1.13. Bảng Chi Tiết Phiếu Nhập
CREATE TABLE ChiTietPhieuNhap (
    IDChiTietPN INT IDENTITY(1,1) PRIMARY KEY,
    IDPhieuNhap INT NOT NULL,
    IDNguyenLieu INT NOT NULL,
    SoLuongNhap DECIMAL(18, 2) NOT NULL CHECK (SoLuongNhap > 0),
    DonGiaNhap DECIMAL(18, 0) NOT NULL,
    FOREIGN KEY (IDPhieuNhap) REFERENCES PhieuNhap(IDPhieuNhap) ON DELETE CASCADE,
    FOREIGN KEY (IDNguyenLieu) REFERENCES NguyenLieu(IDNguyenLieu)
)
GO

-- Chèn Vai Trò
INSERT INTO VaiTro (IDVaiTro, TenVaiTro) VALUES
(1, N'Admin'),
(2, N'Thu ngân'),
(3, N'Thủ kho')
GO

-- Chèn Tài Khoản (Mật khẩu plain text '123')
INSERT INTO TaiKhoan (TenDangNhap, TenHienThi, MatKhau, IDVaiTro) VALUES
(N'admin', N'Quản Trị Viên', '123', 1),
(N'thungan1', N'Thu Ngân Ca Sáng', '123', 2),
(N'thukho1', N'Nhân Viên Kho A', '123', 3)
GO

-- Chèn Danh Mục Món
INSERT INTO DanhMucMon (TenDanhMuc) VALUES
(N'Cà phê'),
(N'Nước ép & Trà'),
(N'Đồ ăn vặt')
GO

-- Chèn Sản Phẩm
INSERT INTO SanPham (TenSanPham, IDDanhMuc, DonGia) VALUES
(N'Cà phê Đen', 1, 25000),
(N'Cà phê Sữa', 1, 30000),
(N'Bạc Xỉu', 1, 35000),
(N'Trà Chanh', 2, 20000),
(N'Nước ép Cam', 2, 35000),
(N'Bánh Mì Chảo', 3, 45000),
(N'Hướng Dương', 3, 15000)
GO

-- Chèn Bàn
INSERT INTO Ban (TenBan, TrangThai) VALUES
(N'Bàn 1', 0), (N'Bàn 2', 0), (N'Bàn 3', 0), (N'Bàn 4', 0), (N'Bàn 5', 0),
(N'Bàn 6', 0), (N'Bàn 7', 0), (N'Bàn 8', 0), (N'Bàn 9', 0), (N'Bàn 10', 0)
GO

-- Chèn Đơn Vị Tính
INSERT INTO DonViTinh (TenDVT) VALUES
(N'Kg'), (N'Gram'), (N'Lít'), (N'Ml'), (N'Cái'), (N'Gói')
GO

-- Chèn Nguyên Liệu (Tồn kho ban đầu = 0, sẽ nhập sau)
INSERT INTO NguyenLieu (TenNguyenLieu, IDDonViTinh, SoLuongTon, TonKhoToiThieu) VALUES
(N'Hạt cà phê', 1, 0, 5), -- Kg
(N'Sữa đặc Ông Thọ', 4, 0, 500), -- Ml
(N'Đường trắng', 1, 0, 10), -- Kg
(N'Quả Cam', 5, 0, 20), -- Cái
(N'Trà túi lọc', 6, 0, 30), -- Gói
(N'Quả Chanh', 5, 0, 15) -- Cái
GO

-- Chèn Định Lượng (BOM)
-- IDSanPham: 1-Cà phê Đen, 2-Cà phê Sữa, 4-Trà Chanh, 5-Nước ép Cam
-- IDNguyenLieu: 1-Cà phê (Kg), 2-Sữa đặc (Ml), 3-Đường (Kg), 4-Cam (Cái), 5-Trà (Gói), 6-Chanh (Cái)
-- Đơn vị trong DinhLuong PHẢI KHỚP với đơn vị của SoLuongTon trong NguyenLieu
-- Ví dụ: Cà phê Sữa (ID 2) = 0.02 Kg cà phê (20g) + 30 Ml sữa đặc
INSERT INTO DinhLuong (IDSanPham, IDNguyenLieu, SoLuongCan) VALUES
(1, 1, 0.02), -- Cà phê Đen = 0.02 Kg Cà phê
(1, 3, 0.01), -- Cà phê Đen = 0.01 Kg Đường
(2, 1, 0.02), -- Cà phê Sữa = 0.02 Kg Cà phê
(2, 2, 30),   -- Cà phê Sữa = 30 Ml Sữa đặc
(4, 5, 1),    -- Trà Chanh = 1 Gói Trà
(4, 6, 1),    -- Trà Chanh = 1 Cái Chanh
(4, 3, 0.01), -- Trà Chanh = 0.01 Kg Đường
(5, 4, 3)     -- Nước ép Cam = 3 Cái Cam
GO

-- Chèn Nhà Cung Cấp
INSERT INTO NhaCungCap (TenNCC, DienThoai, DiaChi) VALUES
(N'NCC Tổng hợp Đà Lạt', '0909111222', N'123 Lâm Đồng'),
(N'NCC Tạp hóa Sài Gòn', '0909333444', N'456 TP. HCM')
GO


-- 3. TẠO INDEX TĂNG TỐC (INDEXES)

CREATE INDEX IX_HoaDon_IDBan ON HoaDon(IDBan);
CREATE INDEX IX_ChiTietHoaDon_IDHoaDon ON ChiTietHoaDon(IDHoaDon);
CREATE INDEX IX_ChiTietHoaDon_IDSanPham ON ChiTietHoaDon(IDSanPham);
CREATE INDEX IX_ChiTietPhieuNhap_IDPhieuNhap ON ChiTietPhieuNhap(IDPhieuNhap);
CREATE INDEX IX_ChiTietPhieuNhap_IDNguyenLieu ON ChiTietPhieuNhap(IDNguyenLieu);
GO

-- 4. TẠO TRIGGERS TỰ ĐỘNG

-- 4.1. Trigger TỰ ĐỘNG CẬP NHẬT TRẠNG THÁI BÀN
CREATE TRIGGER trg_UpdateTableStatus
ON HoaDon AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @IDBan_Inserted INT
    DECLARE @IDBan_Deleted INT
    DECLARE @TrangThai_Inserted INT

    -- Lấy thông tin từ bản ghi vừa được tác động
    SELECT @IDBan_Inserted = i.IDBan, @TrangThai_Inserted = i.TrangThai
    FROM inserted i
    
    SELECT @IDBan_Deleted = d.IDBan
    FROM deleted d

    -- Trường hợp 1: Thêm hóa đơn mới (INSERT) -> Bàn có khách
    IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)
    BEGIN
        UPDATE Ban
        SET TrangThai = 1 -- Có khách
        WHERE IDBan = @IDBan_Inserted
    END

    -- Trường hợp 2: Cập nhật hóa đơn (UPDATE)
    IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        -- Nếu hóa đơn được thanh toán (TrangThai từ 0 -> 1)
        IF @TrangThai_Inserted = 1
        BEGIN
            UPDATE Ban
            SET TrangThai = 0 -- Trống
            WHERE IDBan = @IDBan_Inserted
        END
        -- (Có thể xử lý thêm logic chuyển bàn ở đây nếu cần)
    END
END
GO

-- 4.2. Trigger TỰ ĐỘNG TRỪ KHO NGUYÊN LIỆU (Khi bán hàng)
CREATE TRIGGER trg_UpdateInventoryOnSale
ON ChiTietHoaDon AFTER INSERT
AS
BEGIN
    -- Cập nhật số lượng tồn kho
    UPDATE NguyenLieu
    SET SoLuongTon = NguyenLieu.SoLuongTon - (
        SELECT i.SoLuong * dl.SoLuongCan
        FROM inserted AS i
        JOIN DinhLuong AS dl ON i.IDSanPham = dl.IDSanPham
        WHERE dl.IDNguyenLieu = NguyenLieu.IDNguyenLieu
    )
    FROM NguyenLieu
    JOIN DinhLuong AS dl ON NguyenLieu.IDNguyenLieu = dl.IDNguyenLieu
    JOIN inserted AS i ON dl.IDSanPham = i.IDSanPham;
END
GO

-- 4.3. Trigger TỰ ĐỘNG CỘNG KHO NGUYÊN LIỆU (Khi nhập hàng)
CREATE TRIGGER trg_UpdateInventoryOnStockIn
ON ChiTietPhieuNhap AFTER INSERT
AS
BEGIN
    UPDATE NguyenLieu
    SET SoLuongTon = NguyenLieu.SoLuongTon + i.SoLuongNhap
    FROM NguyenLieu
    JOIN inserted AS i ON NguyenLieu.IDNguyenLieu = i.IDNguyenLieu;
END
GO

-- 4.4. Trigger TỰ ĐỘNG CẬP NHẬT TỔNG TIỀN (Hóa đơn)
CREATE TRIGGER trg_UpdateBillTotal
ON ChiTietHoaDon AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    -- Cập nhật tổng tiền cho Hóa đơn bị ảnh hưởng
    UPDATE HoaDon
    SET TongTien = (
        SELECT SUM(ct.SoLuong * ct.DonGiaTaiThoiDiem)
        FROM ChiTietHoaDon AS ct
        WHERE ct.IDHoaDon = HoaDon.IDHoaDon
    )
    WHERE IDHoaDon IN (SELECT IDHoaDon FROM inserted UNION SELECT IDHoaDon FROM deleted);

    -- Xử lý trường hợp hóa đơn không còn chi tiết nào
    UPDATE HoaDon
    SET TongTien = 0
    WHERE IDHoaDon NOT IN (SELECT DISTINCT IDHoaDon FROM ChiTietHoaDon)
    AND IDHoaDon IN (SELECT IDHoaDon FROM deleted);
END
GO

-- 4.5. Trigger TỰ ĐỘNG CẬP NHẬT TỔNG TIỀN (Phiếu Nhập)
CREATE TRIGGER trg_UpdateStockInTotal
ON ChiTietPhieuNhap AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    -- Cập nhật tổng tiền cho Phiếu Nhập bị ảnh hưởng
    UPDATE PhieuNhap
    SET TongTienNhap = (
        SELECT SUM(ct.SoLuongNhap * ct.DonGiaNhap)
        FROM ChiTietPhieuNhap AS ct
        WHERE ct.IDPhieuNhap = PhieuNhap.IDPhieuNhap
    )
    WHERE IDPhieuNhap IN (SELECT IDPhieuNhap FROM inserted UNION SELECT IDPhieuNhap FROM deleted);
END
GO

-- 5. TẠO STORED PROCEDURES (CORE LOGIC)
-- Đây là "API" mà C# WinForms sẽ gọi

-- 5.1. SP Đăng nhập
CREATE PROCEDURE sp_Login
    @tenDangNhap NVARCHAR(100),
    @matKhau NVARCHAR(100)
AS
BEGIN
    SELECT 
        TenDangNhap, 
        TenHienThi, 
        IDVaiTro
    FROM TaiKhoan 
    WHERE TenDangNhap = @tenDangNhap 
      AND MatKhau = @matKhau
END
GO

-- 5.2. SP Lấy danh sách Bàn
CREATE PROCEDURE sp_GetTableList
AS
BEGIN
    SELECT IDBan, TenBan, TrangThai FROM Ban;
END
GO

-- 5.3. SP Lấy thông tin hóa đơn của 1 Bàn (danh sách món đã gọi)
CREATE PROCEDURE sp_GetBillInfoByTableID
    @IDBan INT
AS
BEGIN
    SELECT 
        ct.IDSanPham,
        sp.TenSanPham,
        ct.SoLuong,
        ct.DonGiaTaiThoiDiem,
        (ct.SoLuong * ct.DonGiaTaiThoiDiem) AS ThanhTien
    FROM ChiTietHoaDon AS ct
    JOIN HoaDon AS hd ON ct.IDHoaDon = hd.IDHoaDon
    JOIN SanPham AS sp ON ct.IDSanPham = sp.IDSanPham
    WHERE 
        hd.IDBan = @IDBan 
        AND hd.TrangThai = 0; -- Chỉ lấy hóa đơn chưa thanh toán
END
GO

-- 5.4. SP Thêm món vào Hóa đơn (Logic cốt lõi của Thu ngân)
CREATE PROCEDURE sp_AddBillDetail
    @IDBan INT,
    @IDSanPham INT,
    @SoLuong INT,
    @TenDangNhap NVARCHAR(100)
AS
BEGIN
    IF @SoLuong <= 0
    BEGIN
        -- Nếu số lượng âm, coi như là xóa món
        DELETE FROM ChiTietHoaDon
        WHERE IDSanPham = @IDSanPham
        AND IDHoaDon = (
            SELECT IDHoaDon FROM HoaDon WHERE IDBan = @IDBan AND TrangThai = 0
        )
        RETURN
    END

    DECLARE @IDHoaDon_HienTai INT
    DECLARE @DonGia_HienTai DECIMAL(18, 0)
    DECLARE @SoLuong_DaCo INT

    -- 1. Tìm hóa đơn CHƯA THANH TOÁN của bàn này
    SELECT @IDHoaDon_HienTai = IDHoaDon
    FROM HoaDon
    WHERE IDBan = @IDBan AND TrangThai = 0;

    -- 2. Nếu bàn này CHƯA CÓ hóa đơn (khách mới vào)
    IF @IDHoaDon_HienTai IS NULL
    BEGIN
        -- Tạo hóa đơn mới
        INSERT INTO HoaDon (TenDangNhap, IDBan, TrangThai)
        VALUES (@TenDangNhap, @IDBan, 0); -- TrangThai 0 = Chưa thanh toán
        
        -- Lấy ID của hóa đơn vừa tạo
        SET @IDHoaDon_HienTai = SCOPE_IDENTITY(); 
        -- Trigger trg_UpdateTableStatus sẽ tự động cập nhật trạng thái bàn
    END

    -- 3. Lấy đơn giá hiện tại của sản phẩm
    SELECT @DonGia_HienTai = DonGia FROM SanPham WHERE IDSanPham = @IDSanPham;

    -- 4. Kiểm tra xem món này ĐÃ CÓ trong hóa đơn chưa
    SELECT @SoLuong_DaCo = SoLuong
    FROM ChiTietHoaDon
    WHERE IDHoaDon = @IDHoaDon_HienTai AND IDSanPham = @IDSanPham;

    -- 5. Xử lý thêm/cập nhật ChiTietHoaDon
    IF @SoLuong_DaCo IS NULL
    BEGIN
        -- Món này chưa có -> Thêm mới
        INSERT INTO ChiTietHoaDon (IDHoaDon, IDSanPham, SoLuong, DonGiaTaiThoiDiem)
        VALUES (@IDHoaDon_HienTai, @IDSanPham, @SoLuong, @DonGia_HienTai);
    END
    ELSE
    BEGIN
        -- Món này đã có -> Cập nhật số lượng
        UPDATE ChiTietHoaDon
        SET SoLuong = @SoLuong_DaCo + @SoLuong
        WHERE IDHoaDon = @IDHoaDon_HienTai AND IDSanPham = @IDSanPham;
    END

    -- Trigger trg_UpdateBillTotal sẽ tự động tính lại tổng tiền
    -- Trigger trg_UpdateInventoryOnSale sẽ tự động trừ kho
END
GO

-- 5.5. SP Thanh toán Hóa đơn
CREATE PROCEDURE sp_Checkout
    @IDBan INT,
    @GiamGia DECIMAL(18, 0)
AS
BEGIN
    DECLARE @IDHoaDon INT
    DECLARE @TongTienSauCung DECIMAL(18, 0)

    -- 1. Tìm hóa đơn chưa thanh toán của bàn
    SELECT @IDHoaDon = IDHoaDon, @TongTienSauCung = TongTien
    FROM HoaDon
    WHERE IDBan = @IDBan AND TrangThai = 0;

    -- 2. Cập nhật hóa đơn
    IF @IDHoaDon IS NOT NULL
    BEGIN
        UPDATE HoaDon
        SET 
            TrangThai = 1, -- Đã thanh toán
            GiamGia = @GiamGia,
            -- Cập nhật lại tổng tiền cuối cùng (nếu cần)
            TongTien = @TongTienSauCung - @GiamGia,
            -- Cập nhật thời gian chốt đơn
            NgayLap = GETDATE()
        WHERE IDHoaDon = @IDHoaDon;
        
        -- Trigger trg_UpdateTableStatus sẽ tự động chuyển bàn về Trạng thái 0 (Trống)
    END
END
GO

-- 5.6. SP Chuyển bàn
CREATE PROCEDURE sp_SwitchTable
    @IDBan_Tu INT,
    @IDBan_Den INT
AS
BEGIN
    -- 1. Kiểm tra xem Bàn đến có trống không
    DECLARE @TrangThaiBanDen INT
    SELECT @TrangThaiBanDen = TrangThai FROM Ban WHERE IDBan = @IDBan_Den

    IF @TrangThaiBanDen = 1
    BEGIN
        RAISERROR(N'Bàn đến đang có khách, không thể chuyển!', 16, 1)
        RETURN
    END

    -- 2. Tìm hóa đơn chưa thanh toán của Bàn đi
    DECLARE @IDHoaDon_Chuyen INT
    SELECT @IDHoaDon_Chuyen = IDHoaDon FROM HoaDon WHERE IDBan = @IDBan_Tu AND TrangThai = 0

    IF @IDHoaDon_Chuyen IS NULL
    BEGIN
        RAISERROR(N'Bàn đi không có hóa đơn để chuyển!', 16, 1)
        RETURN
    END

    -- 3. Cập nhật IDBan trong Hóa đơn
    UPDATE HoaDon
    SET IDBan = @IDBan_Den
    WHERE IDHoaDon = @IDHoaDon_Chuyen

    -- 4. Cập nhật trạng thái 2 bàn (Trigger sẽ lo việc này)
    -- Giả lập trigger bằng cách cập nhật lại hóa đơn để trigger chạy
    UPDATE HoaDon SET GiamGia = GiamGia WHERE IDHoaDon = @IDHoaDon_Chuyen
    -- Cập nhật thủ công (để chắc chắn)
    UPDATE Ban SET TrangThai = 0 WHERE IDBan = @IDBan_Tu
    UPDATE Ban SET TrangThai = 1 WHERE IDBan = @IDBan_Den

END
GO

-- 5.7. SP Lấy Báo cáo Doanh thu (cho Admin)
CREATE PROCEDURE sp_GetSalesReport
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SELECT 
        CONVERT(date, NgayLap) AS Ngay,
        SUM(TongTien) AS TongDoanhThu,
        SUM(GiamGia) AS TongGiamGia,
        COUNT(IDHoaDon) AS SoLuongHoaDon
    FROM HoaDon
    WHERE 
        TrangThai = 1 -- Chỉ lấy hóa đơn đã thanh toán
        AND NgayLap >= @TuNgay 
        AND NgayLap < DATEADD(day, 1, @DenNgay) -- Lấy đến cuối ngày
    GROUP BY CONVERT(date, NgayLap)
    ORDER BY Ngay;
END
GO

-- Thêm cho admin
-- 1. Lấy danh sách tất cả tài khoản (kèm tên vai trò)
CREATE PROCEDURE sp_Admin_GetAllAccounts
AS
BEGIN
    SELECT 
        t.TenDangNhap,
        t.TenHienThi,
        t.MatKhau,
        t.IDVaiTro,
        v.TenVaiTro
    FROM TaiKhoan t
    JOIN VaiTro v ON t.IDVaiTro = v.IDVaiTro
END
GO

-- 2. Thêm tài khoản mới
CREATE PROCEDURE sp_Admin_InsertAccount
    @TenDangNhap NVARCHAR(100),
    @TenHienThi NVARCHAR(100),
    @MatKhau NVARCHAR(100),
    @IDVaiTro INT
AS
BEGIN
    -- Kiểm tra trùng tên đăng nhập
    IF EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap)
    BEGIN
        RETURN 0; -- Thất bại do trùng
    END

    INSERT INTO TaiKhoan (TenDangNhap, TenHienThi, MatKhau, IDVaiTro)
    VALUES (@TenDangNhap, @TenHienThi, @MatKhau, @IDVaiTro)
    
    RETURN 1; -- Thành công
END
GO

-- 3. Cập nhật tài khoản
CREATE PROCEDURE sp_Admin_UpdateAccount
    @TenDangNhap NVARCHAR(100), -- Khóa chính (không sửa)
    @TenHienThi NVARCHAR(100),
    @MatKhau NVARCHAR(100),
    @IDVaiTro INT
AS
BEGIN
    UPDATE TaiKhoan
    SET 
        TenHienThi = @TenHienThi,
        MatKhau = @MatKhau,
        IDVaiTro = @IDVaiTro
    WHERE TenDangNhap = @TenDangNhap
END
GO

-- 4. Xóa tài khoản
CREATE PROCEDURE sp_Admin_DeleteAccount
    @TenDangNhap NVARCHAR(100)
AS
BEGIN
    DELETE FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap
END
GO

ALTER PROCEDURE sp_Admin_InsertAccount -- Dùng ALTER để sửa cái cũ
    @TenDangNhap NVARCHAR(100),
    @TenHienThi NVARCHAR(100),
    @MatKhau NVARCHAR(100),
    @IDVaiTro INT
AS
BEGIN
    -- 1. Kiểm tra trùng tên đăng nhập
    IF EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap)
    BEGIN
        RETURN 0; -- Lỗi: Trùng tên đăng nhập
    END

    -- 2. Kiểm tra vai trò có tồn tại không (Mới thêm)
    IF NOT EXISTS (SELECT 1 FROM VaiTro WHERE IDVaiTro = @IDVaiTro)
    BEGIN
        RETURN -1; -- Lỗi: Vai trò không hợp lệ
    END

    -- 3. Thêm mới
    INSERT INTO TaiKhoan (TenDangNhap, TenHienThi, MatKhau, IDVaiTro)
    VALUES (@TenDangNhap, @TenHienThi, @MatKhau, @IDVaiTro)
    
    RETURN 1; -- Thành công
END
GO

-- 5.8. SP Lấy Tồn kho (cho Thủ kho)
CREATE PROCEDURE sp_GetInventoryList
AS
BEGIN
    SELECT 
        nl.IDNguyenLieu,
        nl.TenNguyenLieu,
        dvt.TenDVT,
        nl.SoLuongTon,
        nl.TonKhoToiThieu,
        -- Cảnh báo nếu tồn kho thấp
        CASE 
            WHEN nl.SoLuongTon <= nl.TonKhoToiThieu THEN 1 
            ELSE 0 
        END AS CanhBao
    FROM NguyenLieu AS nl
    JOIN DonViTinh AS dvt ON nl.IDDonViTinh = dvt.IDDonViTinh
    ORDER BY CanhBao DESC, nl.TenNguyenLieu;
END
GO

-- 5.9. SP Tạo Phiếu Nhập Kho (cho Thủ kho)
CREATE PROCEDURE sp_CreateStockIn
    @IDNhaCungCap INT,
    @TenDangNhap NVARCHAR(100)
AS
BEGIN
    INSERT INTO PhieuNhap (IDNhaCungCap, TenDangNhap)
    VALUES (@IDNhaCungCap, @TenDangNhap);

    SELECT SCOPE_IDENTITY() AS IDPhieuNhapMoi; -- Trả về ID phiếu vừa tạo
END
GO

-- 5.10. SP Thêm Chi Tiết Phiếu Nhập (cho Thủ kho)
CREATE PROCEDURE sp_AddStockInDetail
    @IDPhieuNhap INT,
    @IDNguyenLieu INT,
    @SoLuongNhap DECIMAL(18, 2),
    @DonGiaNhap DECIMAL(18, 0)
AS
BEGIN
    INSERT INTO ChiTietPhieuNhap (IDPhieuNhap, IDNguyenLieu, SoLuongNhap, DonGiaNhap)
    VALUES (@IDPhieuNhap, @IDNguyenLieu, @SoLuongNhap, @DonGiaNhap);
    
    -- Trigger trg_UpdateInventoryOnStockIn sẽ tự động cộng kho
    -- Trigger trg_UpdateStockInTotal sẽ tự động tính tổng tiền phiếu
END
GO

-- TEST ĐĂNG NHẬP
EXEC sp_Login @tenDangNhap = 'admin', @matKhau = '123'
EXEC sp_Login @tenDangNhap = 'thungan1', @matKhau = '123'
EXEC sp_Login @tenDangNhap = 'thukho1', @matKhau = '123'

-- KIỂM TRA DỮ LIỆU
SELECT TenDangNhap, TenHienThi, MatKhau, IDVaiTro FROM TaiKhoan

INSERT INTO Ban (TenBan, TrangThai) VALUES
(N'Bàn 15', 1),
(N'Bàn 16', 0)
GO

 INSERT INTO SanPham (TenSanPham, IDDanhMuc, DonGia) VALUES
 (N'Trà Đào', 2, 20000)
 GO

 -- 1. CẮT ĐỨT LIÊN KẾT (Xóa khóa ngoại từ bảng Hóa Đơn và Phiếu Nhập)
DECLARE @sql NVARCHAR(MAX) = N'';

SELECT @sql += N'ALTER TABLE ' + QUOTENAME(OBJECT_SCHEMA_NAME(parent_object_id))
    + '.' + QUOTENAME(OBJECT_NAME(parent_object_id)) + 
    ' DROP CONSTRAINT ' + QUOTENAME(name) + ';'
FROM sys.foreign_keys
WHERE referenced_object_id = OBJECT_ID('TaiKhoan');

EXEC sp_executesql @sql;
GO

-- 2. XÓA BẢNG TÀI KHOẢN CŨ
IF OBJECT_ID('TaiKhoan', 'U') IS NOT NULL
    DROP TABLE TaiKhoan
GO

-- 3. TẠO LẠI BẢNG TÀI KHOẢN MỚI (BẢO MẬT)
CREATE TABLE TaiKhoan (
    TenDangNhap NVARCHAR(100) NOT NULL,
    TenHienThi NVARCHAR(100) NOT NULL,
    
    -- LƯU MÃ BĂM (KHÔNG LƯU TEXT THƯỜNG)
    MatKhau VARBINARY(32) NOT NULL, 
    
    IDVaiTro INT NOT NULL,
    
    -- Ràng buộc Khóa chính
    CONSTRAINT PK_TaiKhoan PRIMARY KEY (TenDangNhap),
    
    -- Ràng buộc Khóa ngoại
    CONSTRAINT FK_TaiKhoan_VaiTro FOREIGN KEY (IDVaiTro) REFERENCES VaiTro(IDVaiTro),

    -- Ràng buộc Tên đăng nhập (Không dấu cách, không ký tự lạ, >=5 ký tự)
    CONSTRAINT CK_TaiKhoan_NoSpace CHECK (TenDangNhap NOT LIKE '% %'),
    CONSTRAINT CK_TaiKhoan_Length CHECK (LEN(TenDangNhap) >= 5),
    CONSTRAINT CK_TaiKhoan_ValidChars CHECK (TenDangNhap NOT LIKE '%[^a-zA-Z0-9]%')
)
GO

-- 4. NỐI LẠI LIÊN KẾT (Tạo lại khóa ngoại cho Hóa Đơn và Phiếu Nhập)
ALTER TABLE HoaDon
ADD CONSTRAINT FK_HoaDon_TaiKhoan FOREIGN KEY (TenDangNhap) REFERENCES TaiKhoan(TenDangNhap)
GO

ALTER TABLE PhieuNhap
ADD CONSTRAINT FK_PhieuNhap_TaiKhoan FOREIGN KEY (TenDangNhap) REFERENCES TaiKhoan(TenDangNhap)
GO

-- 1. SP THÊM TÀI KHOẢN (Kiểm tra mạnh mẽ -> Băm -> Lưu)
CREATE OR ALTER PROCEDURE sp_Admin_InsertAccount
    @TenDangNhap NVARCHAR(100),
    @TenHienThi NVARCHAR(100),
    @MatKhau NVARCHAR(100), -- Mật khẩu thô (VD: Cafe@12345)
    @IDVaiTro INT
AS
BEGIN
    -- Check trùng tên & vai trò
    IF EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap) RETURN 0; 
    IF NOT EXISTS (SELECT 1 FROM VaiTro WHERE IDVaiTro = @IDVaiTro) RETURN -1;

    -- === KIỂM TRA ĐỘ MẠNH MẬT KHẨU ===
    IF LEN(@MatKhau) < 9 RETURN -2; -- Quá ngắn
    IF @MatKhau COLLATE Latin1_General_BIN NOT LIKE '%[A-Z]%' RETURN -3; -- Thiếu Hoa
    IF @MatKhau COLLATE Latin1_General_BIN NOT LIKE '%[a-z]%' RETURN -4; -- Thiếu Thường
    IF @MatKhau NOT LIKE '%[0-9]%' RETURN -5; -- Thiếu Số
    IF @MatKhau NOT LIKE '%[^a-zA-Z0-9]%' RETURN -6; -- Thiếu Ký tự đặc biệt

    -- === BĂM VÀ LƯU ===
    INSERT INTO TaiKhoan (TenDangNhap, TenHienThi, MatKhau, IDVaiTro)
    VALUES (@TenDangNhap, @TenHienThi, HASHBYTES('SHA2_256', @MatKhau), @IDVaiTro)
    
    RETURN 1; -- Thành công
END
GO

-- 2. SP CẬP NHẬT TÀI KHOẢN (Logic tương tự khi đổi mật khẩu)
CREATE OR ALTER PROCEDURE sp_Admin_UpdateAccount
    @TenDangNhap NVARCHAR(100),
    @TenHienThi NVARCHAR(100),
    @MatKhau NVARCHAR(100), -- Mật khẩu mới (Để trống = không đổi)
    @IDVaiTro INT
AS
BEGIN
    IF @MatKhau IS NOT NULL AND LEN(@MatKhau) > 0
    BEGIN
        -- Check mật khẩu mới
        IF LEN(@MatKhau) < 9 RETURN -2;
        IF @MatKhau COLLATE Latin1_General_BIN NOT LIKE '%[A-Z]%' RETURN -3;
        IF @MatKhau COLLATE Latin1_General_BIN NOT LIKE '%[a-z]%' RETURN -4;
        IF @MatKhau NOT LIKE '%[0-9]%' RETURN -5;
        IF @MatKhau NOT LIKE '%[^a-zA-Z0-9]%' RETURN -6;

        UPDATE TaiKhoan
        SET TenHienThi = @TenHienThi,
            MatKhau = HASHBYTES('SHA2_256', @MatKhau), -- Băm lại
            IDVaiTro = @IDVaiTro
        WHERE TenDangNhap = @TenDangNhap
    END
    ELSE
    BEGIN
        UPDATE TaiKhoan
        SET TenHienThi = @TenHienThi, IDVaiTro = @IDVaiTro
        WHERE TenDangNhap = @TenDangNhap
    END
    RETURN 1;
END
GO

-- 3. SP ĐĂNG NHẬP (Chỉ Băm để so sánh)
CREATE OR ALTER PROCEDURE sp_Login
    @tenDangNhap NVARCHAR(100),
    @matKhau NVARCHAR(100)
AS
BEGIN
    DECLARE @matKhauHash VARBINARY(32) = HASHBYTES('SHA2_256', @matKhau)

    SELECT TenDangNhap, TenHienThi, IDVaiTro
    FROM TaiKhoan 
    WHERE TenDangNhap = @tenDangNhap AND MatKhau = @matKhauHash
END
GO

-- Tạo tài khoản Admin mặc định (Pass: Admin@12345)
-- Lưu ý: Phải dùng mật khẩu mạnh vì SP đã chặn mật khẩu yếu
DECLARE @result INT;
EXEC @result = sp_Admin_InsertAccount 
    @TenDangNhap = 'admin', 
    @TenHienThi = N'Quản Trị Viên', 
    @MatKhau = 'Admin@12345', 
    @IDVaiTro = 1;

-- Kiểm tra kết quả
SELECT * FROM TaiKhoan;
-- Nếu thấy dòng dữ liệu có cột MatKhau mã hóa (ký tự lạ) là thành công.


-- 1. Thêm lại Thu Ngân (Mật khẩu mới: Staff@12345)
DECLARE @kq1 INT;
EXEC @kq1 = sp_Admin_InsertAccount 
    @TenDangNhap = 'thungan1', 
    @TenHienThi = N'Thu Ngân Ca Sáng', 
    @MatKhau = 'Staff@12345',  -- Đủ 9 ký tự, Hoa, Thường, Số, Đặc biệt
    @IDVaiTro = 2; -- Vai trò Thu ngân
SELECT 'KetQua_ThuNgan' = @kq1;

-- 2. Thêm lại Thủ Kho (Mật khẩu mới: Staff@12345)
DECLARE @kq2 INT;
EXEC @kq2 = sp_Admin_InsertAccount 
    @TenDangNhap = 'thukho1', 
    @TenHienThi = N'Nhân Viên Kho A', 
    @MatKhau = 'Staff@12345', 
    @IDVaiTro = 3; -- Vai trò Thủ kho
SELECT 'KetQua_ThuKho' = @kq2;

USE QLCafe
GO

-- BƯỚC 1: KHÔI PHỤC DỮ LIỆU BẢNG VAI TRÒ (Đây là nguyên nhân gây lỗi -1)
DELETE FROM VaiTro -- Xóa cũ cho sạch (chỉ chạy được khi chưa có user nào)
GO

INSERT INTO VaiTro (IDVaiTro, TenVaiTro) VALUES 
(1, N'Admin'),
(2, N'Thu ngân'),
(3, N'Thủ kho')
GO

-- BƯỚC 2: THÊM LẠI ADMIN (Vì bảng đang trống)
DECLARE @kqAdmin INT;
EXEC @kqAdmin = sp_Admin_InsertAccount 
    @TenDangNhap = 'admin', 
    @TenHienThi = N'Quản Trị Viên', 
    @MatKhau = 'Admin@12345', 
    @IDVaiTro = 1; -- Vai trò 1 đã có ở trên -> Sẽ thành công

-- BƯỚC 3: THÊM LẠI THU NGÂN
DECLARE @kqThuNgan INT;
EXEC @kqThuNgan = sp_Admin_InsertAccount 
    @TenDangNhap = 'thungan1', 
    @TenHienThi = N'Thu Ngân Ca Sáng', 
    @MatKhau = 'Staff@12345', 
    @IDVaiTro = 2; -- Vai trò 2 đã có -> Sẽ thành công

-- BƯỚC 4: THÊM LẠI THỦ KHO
DECLARE @kqThuKho INT;
EXEC @kqThuKho = sp_Admin_InsertAccount 
    @TenDangNhap = 'thukho1', 
    @TenHienThi = N'Nhân Viên Kho A', 
    @MatKhau = 'Staff@12345', 
    @IDVaiTro = 3; -- Vai trò 3 đã có -> Sẽ thành công

-- BƯỚC 5: KIỂM TRA KẾT QUẢ
SELECT 'KetQua_Admin' = @kqAdmin, 'KetQua_ThuNgan' = @kqThuNgan, 'KetQua_ThuKho' = @kqThuKho;
SELECT * FROM TaiKhoan;
CREATE OR ALTER PROCEDURE sp_GetInventoryReport
    @TuNgay DATETIME,
    @DenNgay DATETIME
AS
BEGIN
    SELECT 
        nl.TenNguyenLieu,
        dvt.TenDVT,
        nl.SoLuongTon,
        ISNULL(SUM(ctpn.SoLuongNhap), 0) AS TongNhapTrongKy,
        ISNULL(SUM(ctpn.SoLuongNhap * ctpn.DonGiaNhap), 0) AS TongGiaTriNhap
    FROM NguyenLieu nl
    JOIN DonViTinh dvt ON nl.IDDonViTinh = dvt.IDDonViTinh
    LEFT JOIN ChiTietPhieuNhap ctpn ON nl.IDNguyenLieu = ctpn.IDNguyenLieu
    LEFT JOIN PhieuNhap pn ON ctpn.IDPhieuNhap = pn.IDPhieuNhap
    WHERE pn.NgayNhap BETWEEN @TuNgay AND @DenNgay OR pn.NgayNhap IS NULL
    GROUP BY nl.TenNguyenLieu, dvt.TenDVT, nl.SoLuongTon
END
GO

USE QLCafe
GO

CREATE OR ALTER PROCEDURE sp_GetInventoryDashboard
AS
BEGIN
    -- 1. Lấy số liệu thống kê cho 4 cái thẻ trên cùng
    SELECT 
        (SELECT COUNT(*) FROM NguyenLieu) AS TongNguyenLieu,
        (SELECT COUNT(*) FROM NguyenLieu WHERE SoLuongTon <= TonKhoToiThieu) AS CanNhapGap,
        (SELECT COUNT(*) FROM NguyenLieu WHERE SoLuongTon > TonKhoToiThieu AND SoLuongTon <= TonKhoToiThieu * 1.5) AS SapHet,
        (SELECT COUNT(*) FROM NguyenLieu WHERE SoLuongTon > TonKhoToiThieu * 1.5) AS OnDinh

    -- 2. Lấy danh sách chi tiết cho bảng
    SELECT 
        nl.TenNguyenLieu,
        dvt.TenDVT,
        nl.SoLuongTon,
        nl.TonKhoToiThieu,
        -- Tính % Tồn kho (để vẽ thanh Progress bar)
        CASE 
            WHEN nl.TonKhoToiThieu = 0 THEN 100
            ELSE (nl.SoLuongTon / (nl.TonKhoToiThieu * 2)) * 100 -- Quy ước: Tồn gấp đôi tối thiểu là 100% thanh
        END AS PhanTramTon,
        -- Xác định trạng thái
        CASE 
            WHEN nl.SoLuongTon <= nl.TonKhoToiThieu THEN N'Cần nhập gấp'
            WHEN nl.SoLuongTon <= nl.TonKhoToiThieu * 1.5 THEN N'Sắp hết'
            ELSE N'Ổn định'
        END AS TrangThaiText,
        -- Mã màu (1: Đỏ, 2: Vàng, 3: Xanh)
        CASE 
            WHEN nl.SoLuongTon <= nl.TonKhoToiThieu THEN 1
            WHEN nl.SoLuongTon <= nl.TonKhoToiThieu * 1.5 THEN 2
            ELSE 3
        END AS TrangThaiColor
    FROM NguyenLieu nl
    JOIN DonViTinh dvt ON nl.IDDonViTinh = dvt.IDDonViTinh
    ORDER BY TrangThaiColor ASC -- Ưu tiên hiển thị cái cần nhập trước
END
GO
SELECT*FROM NguyenLieu
SELECT @@SERVERNAME

-- Đảm bảo đang dùng đúng Database
USE QLCafe
GO

-- Xóa SP cũ nếu lỗi
DROP PROCEDURE IF EXISTS sp_GetInventoryDashboard
GO

-- Tạo lại SP chuẩn
CREATE PROCEDURE sp_GetInventoryDashboard
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Trả về Dashboard (Bảng 1)
    SELECT 
        (SELECT COUNT(*) FROM NguyenLieu) AS TongNguyenLieu,
        (SELECT COUNT(*) FROM NguyenLieu WHERE SoLuongTon <= TonKhoToiThieu) AS CanNhapGap,
        (SELECT COUNT(*) FROM NguyenLieu WHERE SoLuongTon > TonKhoToiThieu AND SoLuongTon <= TonKhoToiThieu * 1.5) AS SapHet,
        (SELECT COUNT(*) FROM NguyenLieu WHERE SoLuongTon > TonKhoToiThieu * 1.5) AS OnDinh;

    -- 2. Trả về Danh sách (Bảng 2)
    -- Lưu ý: Phải LEFT JOIN DonViTinh để lấy tên ĐVT
    SELECT 
        nl.TenNguyenLieu,
        dvt.TenDVT,
        nl.SoLuongTon,
        nl.TonKhoToiThieu,
        CASE 
            WHEN nl.SoLuongTon <= nl.TonKhoToiThieu THEN N'Cần nhập gấp'
            WHEN nl.SoLuongTon <= nl.TonKhoToiThieu * 1.5 THEN N'Sắp hết'
            ELSE N'Ổn định'
        END AS TrangThaiText,
        CASE 
            WHEN nl.SoLuongTon <= nl.TonKhoToiThieu THEN 1 -- Đỏ
            WHEN nl.SoLuongTon <= nl.TonKhoToiThieu * 1.5 THEN 2 -- Vàng
            ELSE 3 -- Xanh
        END AS TrangThaiColor,
        -- Tính phần trăm để vẽ thanh bar (tránh chia cho 0)
        CASE 
            WHEN nl.TonKhoToiThieu = 0 THEN 100 
            ELSE (nl.SoLuongTon / (nl.TonKhoToiThieu * 2)) * 100 
        END AS PhanTramTon
    FROM NguyenLieu nl
    LEFT JOIN DonViTinh dvt ON nl.IDDonViTinh = dvt.IDDonViTinh
    ORDER BY TrangThaiColor ASC;
END
GO

USE QLCafe
GO

-- 1. Thêm Danh Mục Món Mới
INSERT INTO DanhMucMon (TenDanhMuc) VALUES (N'Trà sữa & Topping')
GO

-- 2. Thêm Sản Phẩm Mới (Lấy ID danh mục vừa tạo, thường là 4)
DECLARE @IdDmTraSua INT = (SELECT IDDanhMuc FROM DanhMucMon WHERE TenDanhMuc = N'Trà sữa & Topping')

INSERT INTO SanPham (TenSanPham, IDDanhMuc, DonGia) VALUES
(N'Sữa tươi trân châu đường đen', @IdDmTraSua, 40000),
(N'Trà sữa Thái Xanh', @IdDmTraSua, 35000),
(N'Trà sữa Full Topping', @IdDmTraSua, 50000)
GO

-- 3. Thêm Nguyên Liệu Mới (Cài đặt số liệu để Test các màu trạng thái)

-- >>>> TRẠNG THÁI: SẮP HẾT (Màu Vàng) 
-- (Quy tắc: Tồn > Tối thiểu VÀ Tồn <= Tối thiểu * 1.5)
INSERT INTO NguyenLieu (TenNguyenLieu, IDDonViTinh, SoLuongTon, TonKhoToiThieu) VALUES
(N'Trân châu đen', 1, 6, 5),        -- Min 5, Tồn 6 (Trong vùng 5->7.5) -> SẮP HẾT
(N'Sữa tươi Vinamilk', 3, 28, 20),  -- Min 20, Tồn 28 (Trong vùng 20->30) -> SẮP HẾT
(N'Bột béo B-One', 1, 7, 5)         -- Min 5, Tồn 7 (Trong vùng 5->7.5) -> SẮP HẾT
GO

-- >>>> TRẠNG THÁI: ỔN ĐỊNH (Màu Xanh)
-- (Quy tắc: Tồn > Tối thiểu * 1.5)
INSERT INTO NguyenLieu (TenNguyenLieu, IDDonViTinh, SoLuongTon, TonKhoToiThieu) VALUES
(N'Đường đen Hàn Quốc', 1, 20, 5),  -- Min 5, Tồn 20 (Lớn hơn 7.5) -> ỔN ĐỊNH
(N'Bột trà Thái Xanh', 1, 10, 2),   -- Min 2, Tồn 10 (Lớn hơn 3) -> ỔN ĐỊNH
(N'Thạch rau câu', 1, 15, 3),       -- Min 3, Tồn 15 (Lớn hơn 4.5) -> ỔN ĐỊNH
(N'Ly nhựa 500ml', 5, 500, 50)      -- Min 50, Tồn 500 -> ỔN ĐỊNH
GO

-- 4. Thêm Định Lượng (Công thức pha chế) để liên kết món và nguyên liệu
-- Lưu ý: IDNguyenLieu và IDSanPham có thể khác trên máy bạn do tự tăng, 
-- đây là giả định bạn chạy tiếp theo dữ liệu cũ.

-- Lấy ID các món vừa thêm
DECLARE @IdMon_SuaTuoiTC INT = (SELECT IDSanPham FROM SanPham WHERE TenSanPham = N'Sữa tươi trân châu đường đen')
DECLARE @IdMon_ThaiXanh INT = (SELECT IDSanPham FROM SanPham WHERE TenSanPham = N'Trà sữa Thái Xanh')

-- Lấy ID nguyên liệu vừa thêm
DECLARE @IdNL_TranChau INT = (SELECT IDNguyenLieu FROM NguyenLieu WHERE TenNguyenLieu = N'Trân châu đen')
DECLARE @IdNL_SuaTuoi INT = (SELECT IDNguyenLieu FROM NguyenLieu WHERE TenNguyenLieu = N'Sữa tươi Vinamilk')
DECLARE @IdNL_DuongDen INT = (SELECT IDNguyenLieu FROM NguyenLieu WHERE TenNguyenLieu = N'Đường đen Hàn Quốc')
DECLARE @IdNL_BotThai INT = (SELECT IDNguyenLieu FROM NguyenLieu WHERE TenNguyenLieu = N'Bột trà Thái Xanh')
DECLARE @IdNL_BotBeo INT = (SELECT IDNguyenLieu FROM NguyenLieu WHERE TenNguyenLieu = N'Bột béo B-One')

-- Công thức: Sữa tươi TC đường đen = Sữa tươi + Trân châu + Đường đen
INSERT INTO DinhLuong (IDSanPham, IDNguyenLieu, SoLuongCan) VALUES
(@IdMon_SuaTuoiTC, @IdNL_SuaTuoi, 0.2), -- 200ml sữa
(@IdMon_SuaTuoiTC, @IdNL_TranChau, 0.05), -- 50g trân châu
(@IdMon_SuaTuoiTC, @IdNL_DuongDen, 0.03) -- 30g đường đen

-- Công thức: Trà sữa Thái = Bột Thái + Bột Béo + Sữa đặc (lấy ID cũ = 2)
INSERT INTO DinhLuong (IDSanPham, IDNguyenLieu, SoLuongCan) VALUES
(@IdMon_ThaiXanh, @IdNL_BotThai, 0.02),
(@IdMon_ThaiXanh, @IdNL_BotBeo, 0.03),
(@IdMon_ThaiXanh, 2, 30) -- 30ml Sữa đặc ông thọ (nguyên liệu cũ)
GO

-- 5. Xem kết quả Dashboard ngay lập tức để kiểm tra
EXEC sp_GetInventoryDashboard
GO
USE QLCafe
GO

-- 1. SP Tạo Phiếu Nhập
CREATE OR ALTER PROCEDURE sp_CreateStockIn
    @IDNhaCungCap INT,
    @TenDangNhap NVARCHAR(100)
AS
BEGIN
    INSERT INTO PhieuNhap (IDNhaCungCap, TenDangNhap, NgayNhap, TongTienNhap)
    VALUES (@IDNhaCungCap, @TenDangNhap, GETDATE(), 0);

    SELECT SCOPE_IDENTITY() AS IDPhieuNhapMoi; 
END
GO

-- 2. SP Thêm Chi Tiết Phiếu Nhập
CREATE OR ALTER PROCEDURE sp_AddStockInDetail
    @IDPhieuNhap INT,
    @IDNguyenLieu INT,
    @SoLuongNhap DECIMAL(18, 2),
    @DonGiaNhap DECIMAL(18, 0)
AS
BEGIN
    INSERT INTO ChiTietPhieuNhap (IDPhieuNhap, IDNguyenLieu, SoLuongNhap, DonGiaNhap)
    VALUES (@IDPhieuNhap, @IDNguyenLieu, @SoLuongNhap, @DonGiaNhap);
    -- Trigger trong DB của bạn sẽ tự động cộng kho và tính tổng tiền
END
GO

USE QLCafe
GO

-- Kiểm tra và thêm cột PhuongThuc nếu chưa có
IF NOT EXISTS (SELECT * FROM sys.columns 
               WHERE Name = 'PhuongThuc' AND Object_ID = OBJECT_ID('HoaDon'))
BEGIN
    ALTER TABLE HoaDon ADD PhuongThuc NVARCHAR(50) DEFAULT N'Tiền mặt'
END
GO

-- Cập nhật Procedure thanh toán (Dùng CREATE OR ALTER để chạy lại thoải mái)
CREATE OR ALTER PROCEDURE sp_Checkout
    @IDBan INT,
    @GiamGia DECIMAL(18, 0),
    @PhuongThuc NVARCHAR(50)
AS
BEGIN
    UPDATE HoaDon
    SET TrangThai = 1, 
        GiamGia = @GiamGia, 
        PhuongThuc = @PhuongThuc, 
        NgayLap = GETDATE()
    WHERE IDBan = @IDBan AND TrangThai = 0;
END
GO

USE QLCafe
GO

-- Sửa lại Procedure để nhận thêm tên phương thức thanh toán
CREATE OR ALTER PROCEDURE sp_Checkout
    @IDBan INT,
    @GiamGia DECIMAL(18, 0),
    @PhuongThuc NVARCHAR(50) -- <--- THÊM DÒNG NÀY
AS
BEGIN
    UPDATE HoaDon
    SET 
        TrangThai = 1, -- Đã thanh toán
        GiamGia = @GiamGia,
        PhuongThuc = @PhuongThuc, -- <--- LƯU VÀO CỘT NÀY
        NgayLap = GETDATE()
    WHERE IDBan = @IDBan AND TrangThai = 0;
END
GO
USE QLCafe
GO

USE QLCafe
GO

-- Dùng CREATE OR ALTER để ghi đè lên Procedure cũ của bạn
CREATE OR ALTER PROCEDURE sp_Checkout
    @IDBan INT,
    @GiamGia DECIMAL(18, 0),
    @PhuongThuc NVARCHAR(50) -- Thêm tham số này để nhận dữ liệu từ C# gửi xuống
AS
BEGIN
    UPDATE HoaDon
    SET 
        TrangThai = 1,              -- Đổi trạng thái thành "Đã thanh toán"
        GiamGia = @GiamGia,          -- Lưu số tiền giảm
        PhuongThuc = @PhuongThuc,    -- Lưu "Tiền mặt", "Momo" hoặc "Thẻ" vào đây
        NgayLap = GETDATE()          -- Cập nhật giờ thanh toán thực tế
    WHERE IDBan = @IDBan AND TrangThai = 0; -- Chỉ thanh toán hóa đơn đang mở của bàn đó
END
GO

DECLARE @kq INT;

EXEC @kq = sp_Admin_InsertAccount
    @TenDangNhap = 'thungan2',
    @TenHienThi  = N'Thu Ngân Ca Chiều',
    @MatKhau     = 'Staff@12345',
    @IDVaiTro    = 2;  -- 2 = Thu ngân

SELECT 'KetQua' = @kq;
USE QLCafe
GO

-- 1. SP LẤY 4 CHỈ SỐ THỐNG KÊ (Cho 4 cái thẻ trên cùng)
CREATE OR ALTER PROCEDURE sp_Report_GetOverview
    @TuNgay DATETIME,
    @DenNgay DATETIME,
    @NguoiLap NVARCHAR(100) = NULL -- Nếu chọn "Tất cả" thì truyền NULL
AS
BEGIN
    -- Tính toán các chỉ số trong khoảng thời gian
    SELECT 
        ISNULL(SUM(TongTien), 0) AS TongDoanhThu,
        COUNT(IDHoaDon) AS SoHoaDon,
        ISNULL(SUM(GiamGia), 0) AS TongGiamGia,
        CASE 
            WHEN COUNT(IDHoaDon) > 0 THEN ISNULL(SUM(TongTien), 0) / COUNT(IDHoaDon)
            ELSE 0 
        END AS TrungBinhDon
    FROM HoaDon
    WHERE TrangThai = 1 -- Chỉ lấy đơn đã thanh toán
      AND NgayLap BETWEEN @TuNgay AND @DenNgay
      AND (@NguoiLap IS NULL OR TenDangNhap = @NguoiLap)
END
GO

-- 2. SP LẤY DANH SÁCH CHI TIẾT HÓA ĐƠN (Cho bảng ở giữa)
CREATE OR ALTER PROCEDURE sp_Report_GetBillList
    @TuNgay DATETIME,
    @DenNgay DATETIME,
    @NguoiLap NVARCHAR(100) = NULL
AS
BEGIN
    SELECT 
        hd.IDHoaDon AS MaHD,
        hd.NgayLap AS ThoiGian,
        b.TenBan AS Ban,
        (hd.TongTien + hd.GiamGia) AS TongTienGoc, -- Tổng tiền trước giảm
        hd.GiamGia,
        hd.TongTien AS ThanhTien, -- Thực thu
        ISNULL(hd.PhuongThuc, N'Tiền mặt') AS PhuongThuc,
        N'Đã thanh toán' AS TrangThai
    FROM HoaDon hd
    JOIN Ban b ON hd.IDBan = b.IDBan
    WHERE hd.TrangThai = 1
      AND hd.NgayLap BETWEEN @TuNgay AND @DenNgay
      AND (@NguoiLap IS NULL OR hd.TenDangNhap = @NguoiLap)
    ORDER BY hd.NgayLap DESC
END
GO

-- 3. SP LẤY TOP SẢN PHẨM BÁN CHẠY (Cho bảng dưới cùng)
CREATE OR ALTER PROCEDURE sp_Report_GetTopProducts
    @TuNgay DATETIME,
    @DenNgay DATETIME
AS
BEGIN
    SELECT TOP 5
        sp.TenSanPham,
        dm.TenDanhMuc,
        SUM(ct.SoLuong) AS SoLuongBan,
        sp.DonGia,
        SUM(ct.SoLuong * ct.DonGiaTaiThoiDiem) AS DoanhThu
    FROM ChiTietHoaDon ct
    JOIN HoaDon hd ON ct.IDHoaDon = hd.IDHoaDon
    JOIN SanPham sp ON ct.IDSanPham = sp.IDSanPham
    JOIN DanhMucMon dm ON sp.IDDanhMuc = dm.IDDanhMuc
    WHERE hd.TrangThai = 1
      AND hd.NgayLap BETWEEN @TuNgay AND @DenNgay
    GROUP BY sp.TenSanPham, dm.TenDanhMuc, sp.DonGia
    ORDER BY SoLuongBan DESC -- Sắp xếp theo số lượng bán giảm dần
END
GO
CREATE OR ALTER PROCEDURE sp_Report_GetBillList
    @TuNgay DATETIME,
    @DenNgay DATETIME,
    @NguoiLap NVARCHAR(100) = NULL
AS
BEGIN
    SELECT 
        -- SỬA DÒNG NÀY: Ghép chuỗi '#HD' với IDHoaDon
        '#HD' + RIGHT('000' + CAST(hd.IDHoaDon AS VARCHAR(10)), 3) AS MaHD,
        
        hd.NgayLap AS ThoiGian,
        b.TenBan AS Ban,
        (hd.TongTien + hd.GiamGia) AS TongTienGoc,
        hd.GiamGia,
        hd.TongTien AS ThanhTien,
        ISNULL(hd.PhuongThuc, N'Tiền mặt') AS PhuongThuc,
        N'Đã thanh toán' AS TrangThai
    FROM HoaDon hd
    JOIN Ban b ON hd.IDBan = b.IDBan
    WHERE hd.TrangThai = 1
      AND hd.NgayLap BETWEEN @TuNgay AND @DenNgay
      AND (@NguoiLap IS NULL OR hd.TenDangNhap = @NguoiLap)
    ORDER BY hd.NgayLap DESC
END
GO
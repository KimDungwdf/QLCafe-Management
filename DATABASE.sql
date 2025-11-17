CREATE DATABASE QLCafe
GO

USE QLCafe
GO

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

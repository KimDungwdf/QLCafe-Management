-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)-- 1. Tạo cấu trúc Database
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email VARCHAR(100),
    City NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- 2. Chèn dữ liệu mẫu (Dưới đây là phần mô phỏng 300 dòng)

-- Chèn 50 khách hàng
INSERT INTO Customers VALUES (1, 'Nguyen Van A', 'a@mail.com', 'Hanoi');
INSERT INTO Customers VALUES (2, 'Tran Thi B', 'b@mail.com', 'HCM');
-- ... (tiếp tục cho đến ID 50)

-- Chèn 50 sản phẩm
INSERT INTO Products VALUES (101, 'Laptop Dell', 'Electronics', 1500.00);
INSERT INTO Products VALUES (102, 'iPhone 15', 'Electronics', 1200.00);
-- ... (tiếp tục cho đến ID 150)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)

-- Chèn 200 đơn hàng (để đạt tổng cộng >300 dòng SQL)
INSERT INTO Orders VALUES (1001, 1, 101, '2024-01-01', 1);
INSERT INTO Orders VALUES (1002, 2, 102, '2024-01-02', 2);
-- ... (lặp lại cho đến khi đủ số lượng)

CREATE DATABASE PRN_SP2025
GO
USE PRN_SP2025
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    PhoneNumber NVARCHAR(15),
    Role NVARCHAR(50),
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY REFERENCES Users(UserID),
    Address NVARCHAR(255),
    LoyaltyPoints INT DEFAULT 0,
    PreferredPaymentMethod NVARCHAR(50)
);

CREATE TABLE Staff (
    StaffID INT PRIMARY KEY REFERENCES Users(UserID),
    Position NVARCHAR(100),
    Salary DECIMAL(10,2),
    WorkShift NVARCHAR(50)
);

CREATE TABLE StaffManagement (
    StaffID INT PRIMARY KEY REFERENCES Staff(StaffID),
    HireDate DATETIME NOT NULL,
    TerminationDate DATETIME NULL
);

CREATE TABLE Guests (
    GuestID INT IDENTITY(1,1) PRIMARY KEY,
    SessionID UNIQUEIDENTIFIER DEFAULT NEWID(),
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Price DECIMAL(10,2) NOT NULL,
    StockQuantity INT NOT NULL,
    Category NVARCHAR(50),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Toppings (
    ToppingID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Availability BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE ProductDetails (
    BeverageID INT PRIMARY KEY REFERENCES Products(ProductID),
    Size NVARCHAR(50),
    BasePrice DECIMAL(10,2) NOT NULL
);

CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NULL REFERENCES Customers(CustomerID),
    GuestID INT NULL REFERENCES Guests(GuestID),
    TotalAmount DECIMAL(10,2),
    OrderStatus NVARCHAR(50) DEFAULT 'Pending',
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Payments (
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT REFERENCES Orders(OrderID),
    Amount DECIMAL(10,2) NOT NULL,
    PaymentMethod NVARCHAR(50),
    PaymentStatus NVARCHAR(50) DEFAULT 'Pending',
    PaidAt DATETIME NULL
);

CREATE TABLE Discounts (
    DiscountID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    DiscountType NVARCHAR(50),
    DiscountValue DECIMAL(10,2),
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    IsActive BIT DEFAULT 1
);

CREATE TABLE Reviews (
    ReviewID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT REFERENCES Customers(CustomerID),
    ProductID INT REFERENCES Products(ProductID),
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    Comment NVARCHAR(500),
    CreatedAt DATETIME DEFAULT GETDATE()
);
ALTER TABLE Products ADD DiscountID INT NULL;
ALTER TABLE Products ADD CONSTRAINT FK_Products_Discounts FOREIGN KEY (DiscountID) REFERENCES Discounts(DiscountID);

CREATE TABLE ProductToppings (
    ProductID INT NOT NULL,
    ToppingID INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(), -- Thời điểm thêm topping vào sản phẩm
    PRIMARY KEY (ProductID, ToppingID),

    CONSTRAINT FK_ProductToppings_Product FOREIGN KEY (ProductID) 
        REFERENCES ProductDetails(BeverageID) ON DELETE CASCADE ON UPDATE CASCADE,

    CONSTRAINT FK_ProductToppings_Topping FOREIGN KEY (ToppingID) 
        REFERENCES Toppings(ToppingID) ON DELETE CASCADE ON UPDATE CASCADE,

    CONSTRAINT CHK_ProductID CHECK (ProductID > 0),
    CONSTRAINT CHK_ToppingID CHECK (ToppingID > 0)
);

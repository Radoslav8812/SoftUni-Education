CREATE TABLE Cities(
    CityID INT PRIMARY KEY NOT NULL,
    [Name] VARCHAR(50)
)
INSERT INTO Cities VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')


CREATE TABLE Customers(
    CustomerID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    [Name] VARCHAR(50) NOT NULL,
    Birthday DATE,
    CityID INT REFERENCES Cities(CityID)
) 
INSERT INTO Customers VALUES
('Miro', '1990-01-01', 1),
('Kiro', '1992-01-01', 2),
('Spiro', '1991-01-01', 3)


CREATE TABLE Orders
(
OrderID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
CustomerID INT REFERENCES Customers(CustomerID)
)
INSERT INTO Orders VALUES
(1),
(2),
(3)


CREATE TABLE ItemTypes(
    ItemTypeID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    [Name] VARCHAR(50)
)
INSERT INTO ItemTypes VALUES
('MacBook Pro'),
('Macbook Air'),
('Mac Mini')


CREATE TABLE Items(
    ItemID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    [Name] VARCHAR(50),
    ItemTypeID INT REFERENCES ItemTypes(ItemTypeID)
)
INSERT INTO Items VALUES
('Professional Laptop', 1),
('Entry Level Laptop', 2),
('Professional Desk Mac', 3)


CREATE TABLE OrderItems(
    OrderID INT REFERENCES Orders(OrderID),
    ItemID INT REFERENCES Items(ItemID)
    CONSTRAINT PK_Orders_Items PRIMARY KEY (OrderID, ItemID)   
)
INSERT INTO OrderItems VALUES
(1,1),
(2,2),
(3,3)

SELECT * FROM Cities
SELECT * FROM Customers
SELECT * FROM ItemTypes
SELECT * FROM Items
SELECT * From Orders
SELECT * FROM OrderItems
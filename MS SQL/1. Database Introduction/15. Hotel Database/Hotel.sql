--USE Hotel

CREATE TABLE [Employees](
    [Id] INT PRIMARY KEY,
    [FirstName] VARCHAR (90) NOT NULL,
    [LastName] VARCHAR (90) NOT NULL,
    [Title] VARCHAR(50),
    [Notes] VARCHAR(MAX)
)
INSERT INTO [Employees] (Id, FirstName, LastName, Title, Notes)VALUES
(1, 'Spiro', 'Spiridonov', '#', NULL),
(2, 'Kiro', 'Kirov', '##', NULL),
(3, 'Brashlqn', 'Prahan', '####', NULL)


CREATE TABLE [Customers](
    [AccountNumber] INT PRIMARY KEY,
    [FirstName] VARCHAR(90) NOT NULL,
    [LastName] VARCHAR(90) NOT NULL,
    [PhoneNumber] CHAR(10),
    [EmergencyName] NVARCHAR(200),
    [EmergencyNumber] NVARCHAR(50),
    [Notes] VARCHAR(MAX)
)
INSERT INTO [Customers] VALUES
(120, 'Emil', 'Emporuo', '0877112233', '0', '0', NULL),
(222, 'Kiro', 'Spiro', '0877112234', '1', '2', NULL),
(333, 'Mizo', 'Mito', '0877112235', '3', '3', NULL)


CREATE TABLE [RoomStatus](
    [RoomStatus] VARCHAR(20) NOT NULL,
    [Notes] VARCHAR(MAX)
)
INSERT INTO [RoomStatus] VALUES
('FREE', NULL),
('OCCUPIED', NULL),
('MAINTANCE', NULL)


CREATE TABLE [RoomTypes](
    [RoomType] VARCHAR(20) NOT NULL,
    [Notes] VARCHAR(MAX)
)
INSERT INTO [RoomTypes] VALUES
('Single', NULL),
('Double', NULL),
('Apartment', NULL)


CREATE TABLE [BedTypes](
    [BedType] VARCHAR (50) NOT NULL,
    [Notes] VARCHAR(MAX)
)
INSERT INTO [BedTypes] VALUES
('Single bed', NULL),
('Double bed', NULL),
('Two-Floor bed', NULL)


CREATE TABLE [Rooms]](
    [RoomNumber] INT PRIMARY KEY,
    [RoomType] VARCHAR(50),
    [BedType] VARCHAR(50),
    [Rate] INT,
    [RoomStatus] NVARCHAR(50),
    [Notes] VARCHAR(MAX)
)
INSERT INTO [Rooms] VALUES
(123, 'Single', 'Single bed', NULL, 'FREE', NULL),
(1234, 'Triple', 'Double bed', NULL, 'ONHOLD', NULL),
(12345, 'Double', 'Two-Floor bed', NULL, 'OCCUPIED', NULL)


CREATE TABLE [Payments](
    [Id] INT PRIMARY KEY,
    [EmployeeId] INT NOT NULL,
    [PaymentDate] DATETIME NOT NULL,
    [AccountNumber] INT NOT NULL,
    [FirstDateOccupied] DATETIME NOT NULL,
    [TotalDays] INT NOT NULL,
    [AmountCharged] DECIMAL(15, 2),
    [TaxRate] INT,
    [TaxAmount] INT,
    [PaymentTotal] DECIMAL(15, 2),
    [Notes] VARCHAR(MAX)
)
INSERT INTO [Payments] VALUES
(1, 222, '2022-08-02', 120, '2022-08-05', 3, 450.50, NULL, NULL, 450.50, NULL),
(2, 333, '2022-08-02', 120, '2022-08-06', 4, 450.50, NULL, NULL, 450.50, NULL),
(3, 120, '2022-08-02', 120, '2022-08-07', 5, 450.50, NULL, NULL, 450.50, NULL)


CREATE TABLE [Occupancies]
(
	[Id] INT PRIMARY KEY,
	[EmployeeId] INT NOT NULL,
	[DateOccupied] DATETIME,
	[AccountNumber] INT NOT NULL,
	[RoomNumber] INT NOT NULL,
	[RateApplied] INT,
	[PhoneCharge] VARCHAR(20),
	[Notes] NVARCHAR(MAX),
)
INSERT INTO [Occupancies]VALUES
(1, 222, '2022-08-02', 120, 22, NULL, NULL, NULL),
(2, 333, '2022-08-02', 333, 23, NULL, NULL, NULL),
(3, 120, '2022-08-02', 120, 24, NULL, NULL, NULL)


CREATE TABLE [Categories](
    [Id] INT PRIMARY KEY NOT NULL,
    [CategoryName] NVARCHAR (100) NOT NULL,
    [DailyRate] INT,
    [WeeklyRate] INT,
    [MonthlyRate] INT,
    [WeekendRate] INT
)
INSERT INTO [Categories] VALUES
(1, 'A', 1, 2, 20, 4),
(2, 'B', 2, 4, 40, 8),
(3, 'C', 4, 8, 80, 16)


CREATE TABLE [Cars](
    [Id] INT PRIMARY KEY NOT NULL,
    [PlateNumber] NVARCHAR(100),
    [Manufacturer] NVARCHAR (100),
    [Model] NVARCHAR (100),
    [CarYear] DATE,
    [CategoryId] INT NOT NULL,
    [Doors] INT,
    [Pucture] VARBINARY(MAX),
    [Condition] NVARCHAR(100),
    [Available] BIT
)
INSERT INTO [Cars] VALUES
(1, '1q2w3r', 'Honda', 'NSX', '1991-05-05', 1, 3, NULL, 'Good', 1),
(2, '2w3e4r', 'Nissan', 'GTR', '1999-05-05', 1, 3, NULL, 'Good', 1),
(3, '3e4r5t', 'Toyota', 'Supra', '1996-05-05', 1, 3, NULL, 'Good', 1)


CREATE TABLE [Employees](
    Id Int PRIMARY KEY NOT NULL,
    [FirstName] NVARCHAR (100) NOT NULL,
    [LastName] NVARCHAR (100) NOT NULL,
    [Title] NVARCHAR (100),
    [Notes] NVARCHAR (MAX)
)
INSERT INTO [Employees] VALUES
(1, 'Kiro', 'Breika', 'Youtuber', 'From Pavel Village'),
(2, 'Stanislav', 'Canov', 'Youtuber', 'From Sofia City'),
(3, 'Slavi', 'The Clasher', 'Youtuber', 'From Sofia City')


CREATE TABLE [Customers](
    [Id] INT PRIMARY KEY NOT NULL,
    [DriverLicenseNumber] NVARCHAR(100) NOT NULL,
    [FullName] NVARCHAR (200) NOT NULL,
    [Address] NVARCHAR (100),
    [City] NVARCHAR(50),
    [ZipCode] INT,
    [Notes] NVARCHAR(MAX)
)
INSERT INTO [Customers] VALUES
(1, 'a1b2', 'Kiro Breika', 'Veliko Tarnovo, Nadejda', 'Veliko Tarnovo', 100, NULL),
(2, 'a1b3', 'Stanislav Canov', 'Sofia, Center', 'Varna', 1000, NULL),
(3, 'a1b4', 'Spiro Brizenta', 'Krivodol', 'Bourgas', 500, NULL)



CREATE TABLE [RentalOrders](
    [Id] INT PRIMARY KEY NOT NULL,
    [EmployeeId] INT NOT NULL,
    [CustomerId] INT NOT NULL,
    [CarId] INT NOT NULL,
    [TankLevel] INT,
    [KilometrageStart] INT,
    [KilometrageEnd] INT,
    [TotalKilometrage] INT,
    [StartDate] DATE,
    [EndDate] DATE,
    [TotalDays] INT,
    [RateApplied] INT,
    [TaxRate] INT,
    [OrderStatus] NVARCHAR (20),
    [Notes] NVARCHAR(MAX)
)
INSERT INTO [RentalOrders] VALUES
(1, 1, 1, 1, 50, 0, 150, 150, '1991-05-05', '1991-05-05', 1, 10, 250, 'Confirmed', 'An excelent drive experience'),
(2, 2, 2, 2, 60, 0, 500, 500, '1998-05-05', '1999-05-05', 1, 10, 500, 'Confirmed', 'An excelent drive experience'),
(3, 3, 3, 3, 90, 0, 1000, 1000, '1996-05-05', '1999-05-05', 1, 10, 750, 'Confirmed', 'An excelent drive experience')
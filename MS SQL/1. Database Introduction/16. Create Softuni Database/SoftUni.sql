
CREATE DATABASE [SoftUni]

CREATE TABLE [Towns]
(
    [Id] INT IDENTITY PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL
)
CREATE TABLE [Addresses]
(
    [Id] INT IDENTITY PRIMARY KEY,
    [AddressText] NVARCHAR(200) NOT NULL,
    [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id])
)
CREATE TABLE [Departments]
(
    [Id] INT IDENTITY PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL
)
CREATE TABLE [Employees]
(
    [Id] INT IDENTITY PRIMARY KEY,
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [JobTitle] NVARCHAR(200) NOT NULL,
    [DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]),
    [HireDate] DATE,
    [Salary] DECIMAL(15,2) NOT NULL,
    [AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id])
)
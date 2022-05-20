USE [SoftUni]

CREATE TABLE [Towns]
(
    [Id] INT IDENTITY PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL
)
INSERT INTO [Towns] VALUES
('Sofia'),
('Plovdiv'),
('Varna')


CREATE TABLE [Addresses]
(
    [Id] INT IDENTITY PRIMARY KEY,
    [AddressText] NVARCHAR(200) NOT NULL,
    [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id])
)
INSERT INTO [Addresses] VALUES
('Sofia, Nadejda 4', 1),
('Plovdiv, Water base', 2),
('Varna, Street 4', 3)


CREATE TABLE [Departments]
(
    [Id] INT IDENTITY PRIMARY KEY,
    [Name] NVARCHAR(200) NOT NULL
)
INSERT INTO [Departments] VALUES
('Digital Marketing'),
('Software Development'),
('Quality Ensurance')


CREATE TABLE [Employees]
(
    [Id] INT IDENTITY PRIMARY KEY,
    [FirstName] NVARCHAR(MAX) NOT NULL,
    [LastName] NVARCHAR(MAX) NOT NULL,
    [JobTitle] NVARCHAR(MAX) NOT NULL,
    [DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]),
    [HireDate] DATE,
    [Salary] DECIMAL(10,2) NOT NULL,
    [AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id])
)
INSERT INTO [Employees] VALUES
('Svetlin', 'Nakov', 'SoftUni Owner ', 2, '2014-04-04', 30000000.00, 2),
('Niki', 'Kostov', 'SoftUni Master ', 2, '2016-04-04', 20000000.00, 2),
('Ivailo', 'Kenov', 'SoftUni CTO ', 2, '2015-04-04', 25000000.00, 2)
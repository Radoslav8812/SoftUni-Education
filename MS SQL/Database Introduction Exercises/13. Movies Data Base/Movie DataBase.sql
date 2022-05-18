CREATE DATABASE [Movies]

CREATE TABLE [Directors](
    [Id] INT PRIMARY KEY NOT NULL,
    [DirectorName] NVARCHAR(200) NOT NULL,
    [Notes] NVARCHAR(MAX)
)
INSERT INTO [Directors] VALUES
(1, 'Svetlin Nakov' , 'The big dog'),
(2, 'Ivailo Kenov' , 'Machine'),
(3, 'Niki Kostov' , 'Encyclopedy man'),
(4, 'Galin Gospodinov' , 'x => x'),
(5, 'Veronika Vaneva' , 'Only Java')


CREATE TABLE [Genres](
    [Id] INT PRIMARY KEY NOT NULL,
    [GenreName] NVARCHAR(200) NOT NULL,
    [Notes] NVARCHAR(MAX)
)
INSERT INTO [Genres] VALUES
(1, 'Horror', NULL),
(2, 'Action', NULL),
(3, 'Comedy', NULL),
(4, 'Action, Fantasy, Horror', NULL),
(5, 'Drama', NULL)


CREATE TABLE [Categories](
    [Id] INT PRIMARY KEY NOT NULL,
    [CategoryName] NVARCHAR(200) NOT NULL,
    [Notes] NVARCHAR(MAX)
)
INSERT INTO [Categories] VALUES
(1, 'One', NULL),
(2, 'Two', NULL),
(3, 'Three', NULL),
(4, 'Four', NULL),
(5, 'Five', NULL)


CREATE TABLE [Movies](
    [Id] INT PRIMARY KEY NOT NULL,
    [Title] NVARCHAR(200) NOT NULL,
    [DirectorId] INT NOT NULL,
    [CopyrightYear] DATE NOT NULL,
    [Length] TIME NOT NULL,
    [GenreId] INT NOT NULL,
    [CategoryId] INT NOT NULL,
    [Rating] INT,
    [Notes] NVARCHAR(MAX)
)
INSERT INTO [Movies] VALUES
(1, 'Predator', 1, '1987-12-12', '01:55:55', 2, 1, 10, NULL),
(2, 'Fast and Furious', 2, '2001-12-12', '02:32:23', 2, 1, 10, NULL),
(3, 'Fast and Furious 2', 3, '2003-12-12', '01:45:35', 2, 2, 8, NULL),
(4, 'Texas Chainsaw', 4, '2003-11-11', '03:25:45', 1, 4, 10, NULL),
(5, '2012', 5, '2011-12-12', '02:22:22', 5, 5, 7, NULL)

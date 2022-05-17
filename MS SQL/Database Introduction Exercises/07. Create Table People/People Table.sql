CREATE TABLE [People](
    [Id] INT IDENTITY (1,1) PRIMARY KEY,
    [Username] NVARCHAR(200) NOT NULL,
    [Picture] VARBINARY(MAX),
    [Height] DECIMAL(3, 2),
    [Weight] DECIMAL (3, 2),
    [Gender] VARCHAR (10),
    [Birthdate] DATETIME NOT NULL,
    [Biography] NVARCHAR(MAX)
)

INSERT INTO People VALUES
('Spiro', NULL, 1.20, 1.20, 'm', '1977-12-12', '#'),
('Kiro', NULL, 1.80, 7.20, 'm', '1975-12-15', '###'),
('Emba', NULL, 1.75, 8.20, 'm', '1989-05-07', '##'),
('Emporuo', NULL, 1.67, 7.80, 'm', '1985-11-11', '####'),
('Brizent', NULL, 1.50, 8.55, 'm', '1978-12-13', '# Spiridonov')
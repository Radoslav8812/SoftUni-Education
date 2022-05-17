CREATE TABLE [Users](
    [Id] BIGINT IDENTITY (1,1) PRIMARY KEY,
    [Username] VARCHAR(30) NOT NULL,
    [Password] VARCHAR(26) NOT NULL,
    [ProfilePicture] VARCHAR(MAX),
    [LastLoginTime] DATETIME,
    [IsDeleted] BIT
)

INSERT INTO [Users] VALUES
('Spiridon', '12345', 'https://avatars.githubusercontent.com/u/28643520?v=4', '2012-12-12', 0),
('Spiro', '1234', 'https://avatars.githubusercontent.com/u/28643520?v=4', '2012-11-11', 0),
('Miro', '14321', 'https://avatars.githubusercontent.com/u/28643520?v=4', '2012-10-10', 0),
('Kiro', '13425', 'https://avatars.githubusercontent.com/u/28643520?v=4', '2012-09-09', 0),
('Meto', '15243', 'https://avatars.githubusercontent.com/u/28643520?v=4', '2012-01-01', 0)
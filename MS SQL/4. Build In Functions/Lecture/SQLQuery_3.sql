-- First with LEFT
SELECT [FirstName],
        [LastName], 
        [JobTitle], 
        LEFT([JobTitle], 6) AS [CutJobTitle] 
        FROM [Employees]

CREATE VIEW [V_LectureFunctions] AS
SELECT [FirstName],
        [LastName],
        [JobTitle],
        LEFT([JobTitle], 6) + REPLICATE('*', LEN([JobTitle]) - 6) AS [Covered]
        FROM [Employees]

SELECT * FROM [V_LectureFunctions]
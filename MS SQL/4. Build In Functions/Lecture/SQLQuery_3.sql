-- First with LEFT
SELECT [FirstName],
        [LastName], 
        [JobTitle], 
        LEFT([JobTitle], 6) AS [CutJobTitle] 
        FROM [Employees]


SELECT [FirstName],
        [LastName],
        [JobTitle],
        LEFT([JobTitle], 6) + REPLICATE('*', LEN([JobTitle]) - 6) AS [Covered]
        FROM [Employees]
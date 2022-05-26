SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3, 10)
AND HireDate > '1994' AND HireDate < '2006'
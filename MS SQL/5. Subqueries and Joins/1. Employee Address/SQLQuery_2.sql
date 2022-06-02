SELECT TOP(5) EmployeeId, JobTitle, e.AddressId, a.AddressText FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
ORDER BY e.AddressID ASC
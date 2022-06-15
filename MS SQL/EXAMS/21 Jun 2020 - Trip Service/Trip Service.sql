/* Crеate a database called TripService. 
   You need to create 6 tables: */

CREATE TABLE Cities(
    Id INT IDENTITY PRIMARY KEY NOT NULL,
    [Name] NVARCHAR(20),
    CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels(
    Id INT IDENTITY PRIMARY KEY NOT NULL,
    [Name] NVARCHAR(30) NOT NULL,
    CityId INT REFERENCES Cities(Id) NOT NULL,
    EmployeeCount INT NOT NULL,
    BaseRate DECIMAL (18, 2)
)

CREATE TABLE Rooms(
    Id INT IDENTITY PRIMARY KEY NOT NULL,
    Price DECIMAL (18, 2) NOT NULL,
    [Type] NVARCHAR(20) NOT NULL,
    Beds INT NOT NULL,
    HotelId INT REFERENCES Hotels(Id) NOT NULL
)
  
CREATE TABLE Trips(
    Id INT IDENTITY PRIMARY KEY NOT NULL,
    RoomId INT REFERENCES Rooms(Id) NOT NULL,
    BookDate DATE NOT NULL,
    ArrivalDate DATE NOT NULL,
    ReturnDate DATE NOT NULL,
    CancelDate DATE,
    CHECK(BookDate < ArrivalDate),
    CHECK(ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts(
    Id INT IDENTITY PRIMARY KEY NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    MiddleName NVARCHAR(20),
    LastName NVARCHAR(50) NOT NULL,
    CityId INT REFERENCES Cities(Id) NOT NULL,
    BirthDate DATE NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips(
    AccountId INT REFERENCES Accounts(Id) NOT NULL,
    TripId  INT REFERENCES Trips(Id) NOT NULL,
    PRIMARY KEY (AccountId, TripId),
    Luggage INT NOT NULL,
    CHECK(Luggage >= 0)
)


/* 2. Insert
Insert some sample data into the database.
Write a query to add the following records into the corresponding tables. All Ids should be auto-generated.
*/
INSERT INTO Accounts VALUES
('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL,	'Petrov', 11, '1978-05-16',	'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov',	59,	'1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips VALUES
(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)


/* 3. Update
Make all rooms’ prices 14% more expensive where the hotel ID is either 5, 7 or 9.
*/
--SELECT * FROM Rooms
--WHERE HotelId In (5,7,9)
UPDATE Rooms
SET Price *= 1.14
WHERE HotelId IN(5, 7, 9)


/*4. Delete
Delete all of Account ID 47’s account’s trips from the mapping table.
*/
--SELECT * FROM AccountsTrips
--WHERE AccountId = 47
DELETE FROM AccountsTrips
WHERE AccountId = 47

/*5. EEE-Mails
Select accounts whose emails start with the letter “e”. 
Select their first and last name, their birthdate in the format "MM-dd-yyyy", their city name, and their Email.
Order them by city name (ascending)
*/
SELECT 
FirstName,
LastName,
FORMAT(BirthDate, 'MM-dd-yyyy') AS BirthDate,
[Name] AS HomeTown,
Email
FROM Accounts a
JOIN Cities c ON a.CityId = c.Id
WHERE [Email] LIKE 'e%'
ORDER BY c.Name ASC


/*6. City Statistics
Select all cities with the count of hotels in them.
Order them by the hotel count (descending), then by city name. Do not include cities, which have no hotels in them.
*/
-- With GROUP BY
SELECT c.Name AS City, COUNT(*) AS Hotels FROM Hotels h
JOIN Cities c ON h.CityId = c.Id
GROUP BY c.Name
ORDER BY Hotels DESC, c.Name ASC
-- With SELECT
SELECT [Name] AS City, (SELECT COUNT(*) FROM Hotels h WHERE h.CityId = c.Id) AS Hotels
FROM Cities c
WHERE (SELECT COUNT(*) FROM Hotels h WHERE h.CityId = c.Id) > 0
ORDER BY Hotels DESC, City ASC 


/*7. Longest and Shortest Trips
Find the longest and shortest trip for each account, in days. Filter the results to accounts with no middle name and trips, which are not cancelled (CancelDate is null).
Order the results by Longest Trip days (descending), then by Shortest Trip (ascending).
*/

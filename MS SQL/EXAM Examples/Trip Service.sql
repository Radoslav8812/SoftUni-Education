/* Crеate a database called TripService. You need to create 6 tables: */

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
(101, '2015-04-12',	'2015-04-14', '2015-04-20', '2015-02-02'),
(102, '2015-07-07',	'2015-07-15', '2015-07-22',	'2015-04-29'),
(103, '2013-07-17',	'2013-07-23', '2013-07-24',	NULL),
(104, '2012-03-17',	'2012-03-31', '2012-04-01',	'2012-01-10'),
(109, '2017-08-07',	'2017-08-28', '2017-08-29',	NULL)
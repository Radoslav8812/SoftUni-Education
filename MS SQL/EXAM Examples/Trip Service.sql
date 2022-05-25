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
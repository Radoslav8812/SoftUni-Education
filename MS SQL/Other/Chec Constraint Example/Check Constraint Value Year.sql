CREATE TABLE DemoConstraint(
    Id INT IDENTITY PRIMARY KEY NOT NULL,
    [Year] INT,
    CHECK (Year <= 2000)
)
INSERT INTO DemoConstraint VALUES
(1998),
(2000),
(1999),
(2001) --  <-- !!!

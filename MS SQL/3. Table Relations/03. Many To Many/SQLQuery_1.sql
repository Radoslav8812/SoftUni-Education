CREATE TABLE Students(
    StudentID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    [Name] VARCHAR(30)
)
INSERT INTO Students VALUES
('Mila'),
('Toni'),
('Ron')


CREATE TABLE Exams(
    ExamID INT IDENTITY (101, 1) PRIMARY KEY NOT NULL,
    [Name] VARCHAR(50)
)
INSERT INTO Exams VALUES
('MiSpringMVCla'),
('Neo4j'),
('Oracle 11g')


CREATE TABLE StudentsExams(
    StudentID INT,
    ExamID INT,
    CONSTRAINT PK_StudentID_EmaxID PRIMARY KEY (StudentID, ExamID),
    CONSTRAINT FK_StudentID FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    CONSTRAINT FK_ExamID FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
)
INSERT INTO StudentsExams VALUES
(1,101),
(1,102),
(2,101),
(3,103),
(2,102),
(2,103)


SELECT * FROM Students
SELECT * FROM Exams
SELECT * FROM StudentsExams
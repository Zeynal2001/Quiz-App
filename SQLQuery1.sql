use Northwind
SELECT * FROM Orders

SELECT OrderID, CustomerID, EmployeeID, ShipName FROM Orders 


CREATE DATABASE QuizApp

use QuizApp

CREATE TABLE Categories(
	CategoryID int PRIMARY KEY IDENTITY,
	CategoryName nvarchar(100) NOT NULL UNIQUE,
	DescriptionC nvarchar(MAX)
)


--Many teref hemise one terefin id sini saxlamalidir
CREATE TABLE Questions(
	QuestionID int PRIMARY KEY IDENTITY,
	QuestionText nvarchar(MAX),
	CorrectOption bit,
	OptionA nvarchar(120),
	OptionB nvarchar(120),
	OptionC nvarchar(120),
	OptionD nvarchar(120),
	QuizID int,
)


CREATE TABLE Quizzes(
	QuizID int PRIMARY KEY IDENTITY,
	QuizName nvarchar(100) NOT NULL UNIQUE,
	DescriptionQ nvarchar(MAX) NOT NULL,
	StartTime datetime,
	EndTime datetime,
	CategoryID int,
	FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
)




CREATE TABLE Users(
	UserID int PRIMARY KEY IDENTITY,
	FirstName nvarchar(100) NOT NULL UNIQUE,
	LastName nvarchar(100) NOT NULL UNIQUE,
	UserEmail nvarchar(100) NOT NULL UNIQUE,
	UserPassword nvarchar(10) NOT NULL UNIQUE,
	Roles int
)

--ALTER TABLE Quizzes
--ALTER COLUMN [DescriptionQ] nvarchar(MAX) NOT NULL

CREATE TABLE Answers(
	UserChoise nvarchar(1) NOT NULL,
	IsCorrect bit,
	AnswerText nvarchar(120),
	QuestionID int,
	UserID int,
	FOREIGN KEY (QuestionID) REFERENCES Questions(QuestionID),
	FOREIGN KEY (UserID) REFERENCES Users(UserID)
)


CREATE TABLE Score(
	ScoreID int PRIMARY KEY IDENTITY,
	QuizID int,
	UserID int,
	CorrectAnswers int,
	IncorrectAnswers int,
	TotalScore int
	FOREIGN KEY (QuizID) REFERENCES Quizzes(QuizID),
	FOREIGN KEY (UserID) REFERENCES Users(UserID)
)


CREATE TABLE QuizDoers(
	QuizID int,
	UserID int,
	FOREIGN KEY (QuizID) REFERENCES Quizzes(QuizID),
	FOREIGN KEY (UserID) REFERENCES Users(UserID)
)

SELECT * FROM Users

UPDATE Users
Set Roles = 2 Where UserID = 1

SELECT * FROM Quizzes
SELECT * FROM Categories

INSERT INTO Categories
VALUES ('Igilis dili', 'Ingilis dili beynalxalq bir dildir.')

INSERT INTO Categories
Values 
	('Tarix', 'Tarix elmi, elm dunyasýnda boyuk bir oneme sahibdir.'),
	('Proqramlasdirma', 'Programlasdýrma modern dunyanýn en onemli sahelerinden biridir.')

UPDATE Categories
SET CategoryName = 'Ingilis dili'
WHERE CategoryID = 1;


update Quizzes set QuizName = 'test', DescriptionQ = 'testim' where QuizID = 1



ALTER TABLE Quizzes
ALTER COLUMN CategoryID int NOT NULL;

select * from Quizzes
select * from Questions

alter table Questions
alter column QuestionText nvarchar(MAX) NOT NULL

alter table Questions
ALTER COLUMN CorrectOption bit NOT NULL

alter table Questions
ALTER column OptionA nvarchar(130) NOT NULL

alter table Questions
ALTER COLUMN OptionB nvarchar(130) NOT NULL

alter table Questions
ALTER COLUMN OptionC nvarchar(130) NOT NULL

alter table Questions
ALTER COLUMN OptionD nvarchar(130) NOT NULL

alter table Questions
ALTER COLUMN QuizID nvarchar(130) NOT NULL


SELECT 
	s.ScoreID,
	s.QuizID,
	u.UserID,
	CONCAT(u.FirstName, ' ', u.LastName) AS [Istifadeci Adi],
	s.CorrectAnswers,
	s.IncorrectAnswers,
	s.TotalScore
FROM Score AS [s]
JOIN Users u ON s.UserID = u.UserID
where s.UserID = 1



INSERT INTO Score
Values 
	(3, 5, 1, 0, 10)



ALTER TABLE Answers
ADD  AnswerID int PRIMARY KEY IDENTITY

select * from Score
truncate table score

SELECT * FROM Score WHERE QuizID AND UserID 

UPDATE Quizzes
SET EndTime = TRY_CONVERT(int, EndTime)

ALTER TABLE Quizzes
ADD EndTime int

create table ##Quizzes(
	QuizId int,
	QuizName nvarchar(max),
	DescriptionQ nvarchar(max),
	StartTime DateTime,
	EndTime int,
	CategoryID int,
	QuizTitle nvarchar(max)
)

insert into ##Quizzes
select QuizID, QuizName, DescriptionQ, StartTime, CAST(EndTime as int), CategoryId, QuizTitle from Quizzes

delete Quizzes



sp_help Quizzes

select * from ##Quizzes

SET IDENTITY_INSERT Quizzes ON
GO
insert into Quizzes(QuizName, DescriptionQ, StartTime, EndTime, CategoryId, QuizTitle)
select QuizName, DescriptionQ, StartTime, EndTime , CategoryId, QuizTitle  from ##Quizzes
GO
SET IDENTITY_INSERT Quizzes OFF
GO

SELECT * FROM Score
SELECT * FROM Questions
SELECT * FROM Answers
SELECT * FROM Users
SELECT * FROM Quizzes
SELECT * FROM Categories

INSERT INTO Quizzes(EndTime)
VALUES()

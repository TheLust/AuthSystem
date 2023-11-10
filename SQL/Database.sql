-- INIT

USE MASTER;

GO

DROP DATABASE IF EXISTS AuthSystem;

GO

CREATE DATABASE AuthSystem;

GO

USE AuthSystem;

GO

SET DATEFORMAT DMY;

GO

-- TABLES

CREATE TABLE "Role" (
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	"Name" VARCHAR(50) UNIQUE NOT NULL
);

GO

CREATE TABLE Project (
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	"Name" VARCHAR(50) UNIQUE NOT NULL
);

GO

CREATE TABLE Job (
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	"Name" VARCHAR(50) NOT NULL,
	"Rank" VARCHAR(6) NOT NULL
	CHECK ("Rank" IN ('JUNIOR', 'MIDDLE', 'SENIOR')),
	BaseSalary FLOAT NOT NULL,
	CONSTRAINT [UnqNameAndRank] UNIQUE NONCLUSTERED
    (
        "Name", "Rank"
    )
);

GO

CREATE TABLE Account (
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Username VARCHAR(50) UNIQUE NOT NULL,
	"Password" VARCHAR(500) NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Email VARCHAR(500) NOT NULL,
	PhoneNumber VARCHAR(500) NOT NULL,
	RoleId INT FOREIGN KEY 
	REFERENCES "Role"(Id) NOT NULL
);

GO

CREATE TABLE Employee (
	Id INT FOREIGN KEY 
	REFERENCES Account(Id) PRIMARY KEY,
	JobId INT FOREIGN KEY
	REFERENCES Job(Id) NOT NULL
);

GO

CREATE TABLE ExtraPayment (
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Amount FLOAT NOT NULL,
	"Type" VARCHAR(7) NOT NULL 
	CHECK ("Type" IN ('MONTHLY', 'PRIZE')),
	"Month" DATE,
	Achievement VARCHAR(255),
	EmployeeId INT FOREIGN KEY 
	REFERENCES Employee(Id) NOT NULL,
);

GO

CREATE TABLE Wage (
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	JobId INT FOREIGN KEY
	REFERENCES Job(Id) NOT NULL,
	ProjectId INT FOREIGN KEY
	REFERENCES Project(Id),
	Amount FLOAT NOT NULL,
	CONSTRAINT [UnqWageJobAndProject] UNIQUE NONCLUSTERED
    (
        JobId, ProjectId
    )
);

GO

CREATE TABLE Assignment (
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	EmployeeId INT FOREIGN KEY
	REFERENCES Employee(Id) NOT NULL,
	ProjectId INT FOREIGN KEY
	REFERENCES Project(Id) NOT NULL,
);

GO

CREATE TABLE "Session" (
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	AssignmentId INT FOREIGN KEY
	REFERENCES Assignment(Id) NOT NULL,
	"Start" DATETIME NOT NULL,
	"End" DATETIME 
);

GO

-- TRIGGERS

CREATE TRIGGER InsertDefaultWageForJob
ON Job
AFTER INSERT
AS BEGIN

	DECLARE @Id INT;
	SELECT @Id = Id
    FROM INSERTED;
	DECLARE @Rank VARCHAR(6);
	SELECT @Rank = "Rank" 
	FROM INSERTED;

	IF @Rank = 'JUNIOR'
		INSERT INTO Wage(JobId, ProjectId, Amount) VALUES
			(@Id, NULL, 25); 
	ELSE IF @Rank = 'MIDDLE'
		INSERT INTO Wage(JobId, ProjectId, Amount) VALUES
			(@Id, NULL, 37);
	ELSE IF @Rank = 'SENIOR'
		INSERT INTO Wage(JobId, ProjectId, Amount) VALUES
			(@Id, NULL, 50);

	PRINT 'Detected insert into jobs, inserted default amount into wage, feel free to change it'
END;

GO

CREATE TRIGGER BonusAchievementCheck
ON ExtraPayment
AFTER INSERT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE "Type" = 'PRIZE' AND NULLIF(LTRIM(RTRIM(Achievement)), '') IS NULL)
    BEGIN
		PRINT 'Achievement cannot be null';
        ROLLBACK TRANSACTION;
    END;

	IF EXISTS (SELECT 1 FROM inserted WHERE "Type" = 'PRIZE' AND "Month" IS NULL)
    BEGIN
		PRINT 'Month cannot be null';
        ROLLBACK TRANSACTION;
    END;
END;

GO

-- INSERTS

INSERT INTO "Role" VALUES
	('User'),
	('Admin');

GO

INSERT INTO Account VALUES
	('admin', 
	'5IENroLR/Cl95UklQxxxFm6TVIf3WqMRnPGZUrxEO55oQGqsbuFZmm+B+hse0CjiEw3miihi4ydE8i3mtVvnyxGhHR9/JbvI0OKiw6ebCgr9A3TL0BrLS23T79XHoQxt', 
	'Admin', 
	'Admin', 
	'693n0Xxg9px746IAhZyjWEHHfkX0KFU4dcPzBrMdTJ9KGMwf6y9DM+x8Bt1lqillqgEbLPHWro9gSuP++jgtjxcLl/ih8jdIX0EzxU3ELmBxJPUhYKfT1rJtDVW/8kJ0', 
	'AKcO5N6qR5th5gJ8enurJBEbygjIZEFBpdPU91sJXluulf15phTdyQ19gY6cUkmdikKvcK2iGJ4ZH5A3bLCzYR74qFCoMYT58P0E43ykMQ0a7zdmTira6/8Zk+48y3vP', 
	(SELECT Id FROM "Role" WHERE "Name" = 'Admin'));

GO

INSERT INTO Job VALUES 
	('Software Developer', 'JUNIOR', 600);

GO

INSERT INTO Job VALUES 
	('Software Developer', 'MIDDLE', 1500);

GO

INSERT INTO Job VALUES 
	('Software Developer', 'SENIOR', 3000);

GO

INSERT INTO Employee(Id, JobId) VALUES
	((SELECT Id FROM Account WHERE Username = 'admin'), (SELECT Id FROM Job WHERE "Name" = 'Software Developer' AND "Rank" = 'SENIOR'));

GO

INSERT INTO Project VALUES
	('MS SQL And C# Gavno');

GO

INSERT INTO Assignment VALUES
	((SELECT Id FROM Account WHERE Username = 'admin'), (SELECT Id FROM Project WHERE "Name" = 'MS SQL And C# Gavno'));

GO

INSERT INTO "Session" VALUES
	(
		(
			SELECT Id FROM Assignment 
			WHERE EmployeeId = (SELECT Id FROM Account WHERE Username = 'admin') AND 
				  ProjectId = (SELECT Id FROM Project WHERE "Name" = 'MS SQL And C# Gavno')
		),
		'08-11-2023 09:00:00',
		'08-11-2023 18:00:00'
	);

GO

-- SELECTS

SELECT * FROM "Role";

GO

SELECT * FROM Account;

GO

SELECT * FROM Employee;

GO

SELECT * FROM Project;

GO

SELECT * FROM Assignment;

GO

SELECT * FROM Wage;

GO

SELECT * FROM ExtraPayment;

GO

SELECT * FROM "Session";
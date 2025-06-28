--Registration table for users

CREATE TABLE Users (
	UserID INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR (50) NOT NULL,
	Email NVARCHAR(100) NOT NULL UNIQUE,
	Password NVARCHAR (100) NOT NULL,
	DateOfBirth DATE NULL,
	Gender NVARCHAR(10) NULL,
	Country NVARCHAR(50) NULL,
	AcceptTerms BIT DEFAULT 0,
	RegistrationDate DATETIME DEFAULT GETDATE()
);

select * from Users;


select message_id as  ErrorNumber, severity as  Severity, [text] as [Description]
from sys.messages --where message_id=2627
where language_id=1033 and message_id>2600 order by message_id;


CREATE PROCEDURE [dbo].[CreateContact]
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@PhoneNumber NVARCHAR(50)
AS
	
INSERT INTO Contacts (DateCreated, FirstName, LastName, PhoneNumber)
VALUES (SYSUTCDATETIME(), @FirstName, @LastName, @PhoneNumber)

CREATE PROCEDURE [dbo].[UpdateContact]
	@Id INT,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@PhoneNumber NVARCHAR(50)
AS
	
UPDATE Contacts 
	SET DateModified = SYSUTCDATETIME(), 
		FirstName = @FirstName, 
		LastName = @LastName, 
		PhoneNumber = @PhoneNumber
WHERE Id = @Id

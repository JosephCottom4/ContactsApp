CREATE PROCEDURE [dbo].[DeleteContact]
	@Id INT
AS
	
UPDATE Contacts 
	SET DateDeleted = SYSUTCDATETIME(), 
		IsDeleted = 1
FROM Contacts
WHERE Id = @Id

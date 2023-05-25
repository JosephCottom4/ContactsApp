CREATE PROCEDURE [dbo].[GetContact]
	@Id INT
AS
	SELECT * FROM Contacts WHERE @Id = Id AND IsDeleted = 0

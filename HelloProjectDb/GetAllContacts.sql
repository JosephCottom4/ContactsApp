CREATE PROCEDURE [dbo].[GetAllContacts]
AS

SELECT * FROM Contacts WHERE IsDeleted = 0
CREATE TABLE [dbo].[Contacts]
(
	[Id]			INT				NOT NULL IDENTITY (1, 1),
	[DateCreated]	DATETIME2 (7)	NOT NULL,
	[DateModified]	DATETIME2 (7)	NULL,
	[DateDeleted]	DATETIME2 (7)	NULL,
	[IsDeleted]		BIT				NOT NULL DEFAULT 0,
	[FirstName]		NVARCHAR(150)	NULL,
	[LastName]		NVARCHAR(150)	NULL,
	[PhoneNumber]	NVARCHAR(20)	NULL,
)

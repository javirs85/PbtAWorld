﻿CREATE TABLE [dbo].TestChar
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GameID] TINYINT NOT NULL, 
    [CampaignID] UNIQUEIDENTIFIER NOT NULL, 
    [SerializedData] TEXT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [ClassCode] TINYINT NOT NULL, 
    [Guid] UNIQUEIDENTIFIER NOT NULL
)

CREATE TABLE [dbo].[Character]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GameID] TINYINT NOT NULL, 
    [CampaignID] NVARCHAR(50) NOT NULL, 
    [SerializedData] TEXT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [ClassCode] TINYINT NOT NULL, 
    [Guid] NCHAR(50) NOT NULL
)

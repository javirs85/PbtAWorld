CREATE TABLE [dbo].[Character]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GameID] TINYINT NOT NULL, 
    [CampaignID] NCHAR(50) NOT NULL, 
    [SerializedData] TEXT NOT NULL, 
    [Name] NCHAR(30) NOT NULL, 
    [ClassCode] TINYINT NOT NULL
)

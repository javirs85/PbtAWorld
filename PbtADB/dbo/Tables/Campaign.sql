CREATE TABLE [dbo].[Campaign]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(50) NOT NULL, 
    [CampaignGuid] NCHAR(50) NOT NULL, 
    [GameID] TINYINT NOT NULL
)

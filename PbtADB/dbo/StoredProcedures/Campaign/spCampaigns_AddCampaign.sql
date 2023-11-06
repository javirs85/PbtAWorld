CREATE PROCEDURE [dbo].[spCampaigns_AddCampaign]
	@Guid UNIQUEIDENTIFIER,
	@name nvarchar(50),
	@gameid tinyint
AS
begin
	insert into dbo.Campaign (GameID, CampaignGuid, [Name])
	values (@gameid, @Guid, @name)
end

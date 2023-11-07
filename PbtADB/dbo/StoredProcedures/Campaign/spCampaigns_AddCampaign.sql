CREATE PROCEDURE [dbo].[spCampaigns_AddCampaign]
	@CampaignGuid UNIQUEIDENTIFIER,
	@name nvarchar(50),
	@gameid tinyint
AS
begin
	insert into dbo.Campaign (GameID, CampaignGuid, [Name])
	values (@gameid, @CampaignGuid, @name)
end

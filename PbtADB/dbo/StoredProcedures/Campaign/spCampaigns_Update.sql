CREATE PROCEDURE [dbo].[spCampaigns_Update]
	@CampaignGuid UNIQUEIDENTIFIER,
	@name nvarchar(50),
	@gameid tinyint
AS
begin
	update dbo.Campaign
	set [Name] = @name, GameID = @gameid 
	where CampaignGuid = @CampaignGuid;
end

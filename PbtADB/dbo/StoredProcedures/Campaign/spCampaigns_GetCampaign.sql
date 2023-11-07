CREATE PROCEDURE [dbo].[spCampaigns_GetCampaign]
	@SeasonID UNIQUEIDENTIFIER
AS
begin
	select GameID, CampaignGuid, [Name]
	from dbo.Campaign
	where CampaignGuid = @SeasonID
end

CREATE PROCEDURE [dbo].[spCampaigns_GetCampaignsOfGame]
	@GameID tinyint
AS
begin
	select GameID, CampaignGuid, [Name]
	from dbo.Campaign
	where GameID = @GameID
end

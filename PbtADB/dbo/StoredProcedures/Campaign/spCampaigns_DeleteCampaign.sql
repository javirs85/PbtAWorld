CREATE PROCEDURE [dbo].[spCampaigns_DeleteCampaign]
	@Guid UNIQUEIDENTIFIER
AS
begin
	delete
	from dbo.Campaign
	where CampaignGuid = @Guid
end
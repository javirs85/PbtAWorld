CREATE PROCEDURE [dbo].[spCampaigns_DeleteCampaign]
	@Guid nvarchar(50)
AS
begin
	delete
	from dbo.Campaign
	where CampaignGuid = @Guid
end
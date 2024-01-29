CREATE PROCEDURE [dbo].[TestCamp_DeleteCampaign]
	@Guid UNIQUEIDENTIFIER
AS
begin
	delete
	from dbo.TestCamp
	where CampaignGuid = @Guid
end
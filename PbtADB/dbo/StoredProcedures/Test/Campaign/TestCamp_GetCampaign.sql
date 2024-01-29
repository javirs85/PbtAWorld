CREATE PROCEDURE [dbo].[TestCamp_GetCampaign]
	@SeasonID UNIQUEIDENTIFIER
AS
begin
	select GameID, CampaignGuid, [Name]
	from dbo.TestCamp
	where CampaignGuid = @SeasonID
end

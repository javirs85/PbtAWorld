CREATE PROCEDURE [dbo].[TestCamp_GetCampaignsOfGame]
	@GameID tinyint
AS
begin
	select GameID, CampaignGuid, [Name]
	from dbo.TestCamp
	where GameID = @GameID
end

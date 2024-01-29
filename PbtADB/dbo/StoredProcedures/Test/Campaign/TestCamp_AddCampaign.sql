CREATE PROCEDURE [dbo].[TestCamp_AddCampaign]
	@CampaignGuid UNIQUEIDENTIFIER,
	@name nvarchar(50),
	@gameid tinyint
AS
begin
	insert into dbo.TestCamp (GameID, CampaignGuid, [Name])
	values (@gameid, @CampaignGuid, @name)
end

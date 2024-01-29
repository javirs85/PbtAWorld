CREATE PROCEDURE [dbo].[TestCamp_Update]
	@CampaignGuid UNIQUEIDENTIFIER,
	@name nvarchar(50),
	@gameid tinyint
AS
begin
	update dbo.TestCamp
	set [Name] = @name, GameID = @gameid 
	where CampaignGuid = @CampaignGuid;
end

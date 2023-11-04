CREATE PROCEDURE [dbo].[spCampaigns_Update]
	@Guid nvarchar(50),
	@name nvarchar(50),
	@gameid tinyint
AS
begin
	update dbo.Campaign
	set [Name] = @name, GameID = @gameid 
	where CampaignGuid = @guid;
end

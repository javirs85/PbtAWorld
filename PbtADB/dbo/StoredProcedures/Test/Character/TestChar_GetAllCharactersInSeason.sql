CREATE PROCEDURE [dbo].[TestChar_GetAllCharactersInSeason]
	@SesionID UNIQUEIDENTIFIER
AS
begin
	Select GameID, CampaignID,[Name], ClassCode, [Guid]
	from dbo.TestChar
	where CampaignID = @SesionID
end

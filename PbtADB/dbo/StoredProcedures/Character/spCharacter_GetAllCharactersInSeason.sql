CREATE PROCEDURE [dbo].[spCharacter_GetAllCharactersInSeason]
	@SesionID UNIQUEIDENTIFIER
AS
begin
	Select GameID, CampaignID,[Name], ClassCode, [Guid]
	from dbo.Character
	where CampaignID = @SesionID
end

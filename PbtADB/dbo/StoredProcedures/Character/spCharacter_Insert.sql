CREATE PROCEDURE [dbo].[spCharacter_Insert]
	@GameID tinyint,
	@CampaignID nvarchar(50),
	@SerializedData text,
	@Name nvarchar(50),
	@ClassCode tinyint,
	@Guid nvarchar(50)
AS
begin
	insert into dbo.[Character]([Guid], GameID, CampaignID, SerializedData, [Name], ClassCode)
	values (@Guid, @GameID, @CampaignID,@SerializedData,@Name,@ClassCode)
end

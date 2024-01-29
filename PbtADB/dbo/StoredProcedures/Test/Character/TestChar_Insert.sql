CREATE PROCEDURE [dbo].[TestChar_Insert]
	@GameID tinyint,
	@CampaignID UNIQUEIDENTIFIER,
	@SerializedData text,
	@Name nvarchar(50),
	@ClassCode tinyint,
	@Guid UNIQUEIDENTIFIER
AS
begin
	insert into dbo.TestChar([Guid], GameID, CampaignID, SerializedData, [Name], ClassCode)
	values (@Guid, @GameID, @CampaignID,@SerializedData,@Name,@ClassCode)
end

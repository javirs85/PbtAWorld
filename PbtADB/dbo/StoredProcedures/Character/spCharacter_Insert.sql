﻿CREATE PROCEDURE [dbo].[spCharacter_Insert]
	@GameID tinyint,
	@CampaignID UNIQUEIDENTIFIER,
	@SerializedData text,
	@Name nvarchar(50),
	@ClassCode tinyint,
	@Guid UNIQUEIDENTIFIER
AS
begin
	insert into dbo.[Character]([Guid], GameID, CampaignID, SerializedData, [Name], ClassCode)
	values (@Guid, @GameID, @CampaignID,@SerializedData,@Name,@ClassCode)
end

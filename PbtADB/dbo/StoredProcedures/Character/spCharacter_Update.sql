CREATE PROCEDURE [dbo].[spCharacter_Update]
	@Guid UNIQUEIDENTIFIER,
	@newName nvarchar(50),
	@SerializedData text
AS
begin
	update  dbo.[Character]
	set SerializedData=@SerializedData, [Name] = @newName
	where [Guid] = @Guid
end

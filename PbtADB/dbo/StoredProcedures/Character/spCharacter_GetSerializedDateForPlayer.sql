CREATE PROCEDURE [dbo].[spCharacter_GetSerializedDateForPlayer]
	@Guid UNIQUEIDENTIFIER
AS
begin
	select SerializedData
	from dbo.Character
	where [Guid] = @Guid
end
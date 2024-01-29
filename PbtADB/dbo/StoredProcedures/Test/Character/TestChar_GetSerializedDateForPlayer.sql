CREATE PROCEDURE [dbo].[TestChar_GetSerializedDateForPlayer]
	@Guid UNIQUEIDENTIFIER
AS
begin
	select SerializedData
	from dbo.TestChar
	where [Guid] = @Guid
end
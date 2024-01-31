CREATE PROCEDURE [dbo].[TestChar_Update]
	@Guid UNIQUEIDENTIFIER,
	@newName nvarchar(50),
	@SerializedData text
AS
begin
	update  dbo.TestChar
	set SerializedData=@SerializedData, [Name] = @newName
	where [Guid] = @Guid
end

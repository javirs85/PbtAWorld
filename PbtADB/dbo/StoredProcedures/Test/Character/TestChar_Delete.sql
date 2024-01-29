CREATE PROCEDURE [dbo].[TestChar_Delete]
	@Guid nvarchar(50)
AS
begin
	delete
	from dbo.TestChar
	where [Guid] = @Guid
end

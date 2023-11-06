CREATE PROCEDURE [dbo].[spCharacter_Delete]
	@Guid nvarchar(50)
AS
begin
	delete
	from dbo.[Character]
	where [Guid] = @Guid
end

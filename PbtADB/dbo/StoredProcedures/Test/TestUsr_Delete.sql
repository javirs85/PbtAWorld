CREATE PROCEDURE [dbo].[TestUsr_Delete]
	@Id int
AS
begin
	delete
	from dbo.TestUsr
	where Id = @Id
end
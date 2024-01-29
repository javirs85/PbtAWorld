CREATE PROCEDURE [dbo].[TestUsr_Get]
	@Id int
AS
begin
	select Id, FirstName, LastName
	from dbo.TestUsr
	where Id = @Id
end
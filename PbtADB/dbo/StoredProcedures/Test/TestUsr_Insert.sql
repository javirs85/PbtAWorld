CREATE PROCEDURE [dbo].[TestUsr_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS
begin
	insert into dbo.TestUsr (FirstName, LastName)
	values (@FirstName, @LastName);
end
if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (FirstName, LastName)
	values ('Tim', 'Corey'),
	('Sue', 'Storm'),
	('John', 'Smith'),
	('Mery', 'Jones');
end

if not exists (select 1 from dbo.Campaign)
begin
	insert into dbo.Campaign (GameID, CampaignGuid, [Name])
	values ('0', NEWID(), 'Test campaign')
end


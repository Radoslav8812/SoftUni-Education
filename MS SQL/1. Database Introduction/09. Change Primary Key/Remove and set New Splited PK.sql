ALTER TABLE [dbo].[Users] DROP CONSTRAINT [PK__Users__3214EC07ACBBBF44] WITH ( ONLINE = OFF )
GO

ALTER TABLE [dbo].[Users] ADD CONSTRAINT [PK__Id__Username] PRIMARY KEY ([Id], [Username])
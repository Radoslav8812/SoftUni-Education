Use Minions

--Using SQL queries modify table Users. Make the default value of LastLoginTime field to be the current time.

ALTER TABLE [Users]
ADD CONSTRAINT [DF_LastLoginTime] DEFAULT GETDATE() FOR [LastLoginTime]
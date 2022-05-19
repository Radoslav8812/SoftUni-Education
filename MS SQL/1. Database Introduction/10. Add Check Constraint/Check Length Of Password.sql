ALTER TABLE [Users]
ADD CONSTRAINT [CH_PasswordIsAtLeast5Symbols] CHECK (LEN([Password]) > 5)
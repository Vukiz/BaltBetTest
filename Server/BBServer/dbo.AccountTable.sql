﻿CREATE TABLE [dbo].[Account]
(
	[Code] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FIO] TEXT NOT NULL, 
    [Amount] MONEY NOT NULL DEFAULT 0

)

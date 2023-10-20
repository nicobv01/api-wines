/****** Object:  Table [dbo].[Wine]    Script Date: 19/10/2023 9:48:25 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Wine](
	[Id] [int] NOT NULL PRIMARY KEY,
	[Name] [varchar](200) NOT NULL,
	[Description] [varchar](500) NULL,
	[CountryCode] [char](3) NOT NULL,
	[Type] [int] NULL,
	[Year] [Date] NULL
) ON [PRIMARY]
GO

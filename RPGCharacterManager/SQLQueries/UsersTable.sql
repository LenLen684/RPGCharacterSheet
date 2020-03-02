/****** Object:  Table [dbo].[Users]    Script Date: 2/22/2020 12:15:27 AM ******/
--If [dbo].[Users] exists 
--DROP TABLE [dbo].[Users]
--GO

/****** Object:  Table [dbo].[Users]    Script Date: 2/22/2020 12:15:27 AM ******/

CREATE TABLE [dbo].[Users](
	[UserID] [bigint] NOT NULL primary key,
	[Username] [varchar](50) NOT NULL,
	[Email] [varchar](150) NOT NULL,
	[Password] [varchar](150) NOT NULL
) ON [PRIMARY]
GO



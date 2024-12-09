CREATE DATABASE logs;

USE [logs]
GO

/****** Object:  Table [dbo].[LogsMinhaCdn]    Script Date: 05/12/2024 16:43:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
drop table [dbo].[LogsMinhaCdn]
CREATE TABLE [dbo].[LogsMinhaCdn](
	[id] [bigint] NOT NULL IDENTITY primary key,
	[log] [nvarchar](max) NOT NULL,
	[data] [datetime] NULL)

		CREATE TABLE [dbo].[LogsAgoraAntes](
	[id] [bigint] NOT NULL IDENTITY primary key,
	[log] [nvarchar](max) NOT NULL,
	[data] [datetime] NULL,
	[idAgora] [bigint] NOT NULL)

	CREATE TABLE [dbo].[LogsAgora](
	[IdLogAgora] [bigint] NOT NULL IDENTITY primary key,
	[log] [nvarchar](max) NOT NULL,
	[data] [datetime] NULL)
 

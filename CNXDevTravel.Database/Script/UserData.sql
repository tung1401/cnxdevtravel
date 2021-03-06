﻿/*
This script was created by Visual Studio on 19-Jan-20 at 18:59.
Run this script on localhost.TestDB (MFEC\Passakorn_b) to make it the same as localhost.CNXDevTravel-local (MFEC\Passakorn_b).
This script performs its actions in the following order:
1. Disable foreign-key constraints.
2. Perform DELETE commands. 
3. Perform UPDATE commands.
4. Perform INSERT commands.
5. Re-enable foreign-key constraints.
Please back up your target database before running this script.
*/
SET NUMERIC_ROUNDABORT OFF
GO
SET XACT_ABORT, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
/*Pointer used for text / image updates. This might not be needed, but is declared here just in case*/
DECLARE @pv binary(16)
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [dbo].[User] ON
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Name], [ProfileImage], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'patompol.t', N'P@$$w0rd', N'Patompol Taesuji', N'http://www.cnxdevsoft.com/media/1008/patompol-1.jpg', NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Name], [ProfileImage], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'passakorn.b', N'P@$$w0rd', N'Passakorn Buadee', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
COMMIT TRANSACTION

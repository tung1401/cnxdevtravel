CREATE TABLE [dbo].[User] (
    [UserId]       INT            IDENTITY (1, 1) NOT NULL,
    [Username]     NVARCHAR (50)  NULL,
    [Password]     NVARCHAR (50)  NULL,
    [Name]         NVARCHAR (200) NULL,
    [ProfileImage] NVARCHAR (MAX) NULL,
    [CreatedBy]    NVARCHAR (50)  NULL,
    [CreatedDate]  DATETIME       NULL,
    [ModifiedBy]   NVARCHAR (50)  NULL,
    [ModifiedDate] DATETIME       NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);


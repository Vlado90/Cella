CREATE TABLE [dbo].[Cella.UserProfile] (
    [userId]        UNIQUEIDENTIFIER NOT NULL,
    [userIdName]    NVARCHAR (255)   NOT NULL,
    [userIdSurname] NVARCHAR (255)   NOT NULL,
    [userBirthDate] NVARCHAR (50)    NULL,
    [stateCode]     BIT              NOT NULL,
    CONSTRAINT [PK_Cella.UserProfile] PRIMARY KEY CLUSTERED ([userId] ASC)
);


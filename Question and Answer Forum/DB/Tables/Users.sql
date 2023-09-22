CREATE TABLE Users(
    [UserId]              UNIQUEIDENTIFIER      PRIMARY KEY DEFAULT NEWSEQUENTIALID(), 
    [Name]                VARCHAR(100)          NOT NULL,
    [JobTitle]            VARCHAR(100)          NOT NULL,
    [Department]          VARCHAR(100)          NOT NULL,
    [Location]            VARCHAR(100)          NULL,
    [ProfilePicture]      VARBINARY(MAX)        NULL
);
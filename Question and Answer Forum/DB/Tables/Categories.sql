CREATE TABLE Categories (
    [CategoryId]            UNIQUEIDENTIFIER    PRIMARY KEY DEFAULT NEWSEQUENTIALID(), 
    [Name]                  VARCHAR(100)        NOT NULL,
    [Description]           VARCHAR(MAX)        NULL,
);
CREATE TABLE Questions (
    [QuestionId]        UNIQUEIDENTIFIER        PRIMARY KEY DEFAULT NEWSEQUENTIALID(), 
    [Question]          VARCHAR(MAX)            NOT NULL,
    [Description]       VARCHAR(MAX)            NULL,
    [CreatedAt]         DATETIME                DEFAULT GETDATE(),
    [Views]             INT                     DEFAULT 0,
    [Votes]             INT                     DEFAULT 0,
    [IsSolved]          BIT                     DEFAULT 0,
    [CategoryId]        UNIQUEIDENTIFIER        NOT NULL,
    [RaisedBy]          UNIQUEIDENTIFIER        NOT NULL,

    FOREIGN KEY ([CategoryId])    REFERENCES      Categories([CategoryId]),
    FOREIGN KEY ([RaisedBy])      REFERENCES      Users([UserId])
);
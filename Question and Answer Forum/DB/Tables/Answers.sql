CREATE TABLE Answers(
    [AnswerId]            UNIQUEIDENTIFIER    PRIMARY KEY DEFAULT NEWSEQUENTIALID(), 
    [Answer]              VARCHAR(MAX)        NOT NULL,
    [Likes]               INT                 DEFAULT 0,
    [DisLikes]            INT                 DEFAULT 0,
    [AnsweredAt]          DATETIME            DEFAULT GETDATE(),
    [IsBestSolution]      BIT                 DEFAULT 0,
    [QuestionId]          UNIQUEIDENTIFIER    NOT NULL,
    [AnsweredBy]          UNIQUEIDENTIFIER    NOT NULL,

    FOREIGN KEY ([QuestionId]) REFERENCES Questions([QuestionIid]),
    FOREIGN KEY ([AnsweredBy]) REFERENCES Users([UserId])
);
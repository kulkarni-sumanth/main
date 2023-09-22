CREATE TABLE Reports (
    [ReportId]            UNIQUEIDENTIFIER    PRIMARY KEY DEFAULT NEWSEQUENTIALID(), 
    [Description]         VARCHAR(MAX)        NULL,
    [AnswerId]            UNIQUEIDENTIFIER    NOT NULL,
    [ReportedTo]          UNIQUEIDENTIFIER    NOT NULL,
    [ReportedFrom]        UNIQUEIDENTIFIER    NOT NULL,

    FOREIGN KEY ([AnswerId]) REFERENCES Answers([AnswersId]),
    FOREIGN KEY ([ReportedTo]) REFERENCES Users([UserId]),
    FOREIGN KEY ([ReportedFrom]) REFERENCES Users([UserId])
);
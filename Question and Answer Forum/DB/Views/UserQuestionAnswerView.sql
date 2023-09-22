CREATE VIEW UserQuestionAnswerView AS
SELECT Q.QuestionId AS Id, Q.Question AS 'QuestionTitle', Q.Description, Q.Votes, Q.Views, Q.CreatedAt, Q.IsSolved, Q.RaisedBy, Q.CategoryId, COUNT(A.AnswerID) AS 'NumberOfAnswers', U.Name AS 'Username', U.ProfilePicture
FROM Questions Q LEFT JOIN Answers A ON Q.QuestionId = A.QuestionId LEFT JOIN Users U ON Q.RaisedBy = U.UserId
GROUP BY Q.QuestionId, U.Name, Q.Question, Q.Description, Q.Votes, RaisedBy, CategoryId, Name, Q.Views, Q.CreatedAt, Q.IsSolved, U.ProfilePicture;

/*SELECT * FROM UserQuestionAnswerView WHERE Id = @questionId;
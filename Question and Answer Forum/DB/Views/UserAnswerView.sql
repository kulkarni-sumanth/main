CREATE VIEW UserAnswerView AS
SELECT A.QuestionId, A.AnswerId AS Id, U.Name AS 'AnsweredBy', U.ProfilePicture, A.AnsweredAt, A.Likes, A.DisLikes, A.Answer AS 'AnswerDescription', A.IsBestSolution
FROM ANSWERS A JOIN Users U ON A.AnsweredBy = U.UserId ;

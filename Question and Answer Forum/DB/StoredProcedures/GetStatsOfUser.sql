CREATE PROCEDURE GetStatsOfUser
	@UserId UNIQUEIDENTIFIER
AS  
BEGIN  
	DECLARE @Likes INT;
	DECLARE @Dislikes INT;
	DECLARE @QuestionsAnswered INT;
	DECLARE @QuestionsAsked INT;
	DECLARE @QuestionsSolved INT;


	SELECT @Dislikes =
		CASE
			WHEN TotalDislikes is NULL THEN 0
			ELSE TotalDislikes
		END
		FROM (
				SELECT SUM(A.DisLikes) 'TotalDislikes' FROM Answers A
				JOIN Users U ON A.AnsweredBy = U.UserId 
				WHERE U.UserId = @UserId) AS CalculateDislikes;

	SELECT @Likes = 
		CASE
			WHEN TotalLikes is NULL THEN 0
			ELSE TotalLikes
		END
		FROM (
				SELECT SUM(A.Likes) 'TotalLikes' FROM Answers A
				JOIN Users U ON A.AnsweredBy = U.UserId 
				WHERE U.UserId = @UserId) AS CalculateLikes;
				
	SELECT  @QuestionsAnswered = COUNT(*) FROM Answers A
	JOIN Users U ON A.AnsweredBy = U.UserId
	WHERE U.UserId = @UserId;

	SELECT @QuestionsAsked = COUNT(*) FROM Questions Q
	JOIN Users U ON Q.RaisedBy = U.UserId
	WHERE U.UserId = @UserId;

	SELECT @QuestionsSolved = COUNT(*) FROM Answers A
	JOIN Users U ON A.AnsweredBy = U.UserId
	JOIN Questions Q ON Q.QuestionId = A.QuestionId
	WHERE U.UserId = @UserId AND Q.IsSolved = 1;

	SELECT @Likes Likes, @Dislikes DisLikes, @QuestionsAnswered QuestionsAnswered, @QuestionsAsked QuestionsAsked, @QuestionsSolved QuestionsSolved;

END
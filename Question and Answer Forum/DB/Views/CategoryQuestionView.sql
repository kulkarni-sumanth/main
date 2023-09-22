CREATE VIEW CategoryQuestionView AS
SELECT C.CategoryId AS Id, C.NAME, C.Description, COUNT(Q.QuestionId) 'NumberOfQuestions'
FROM Categories C JOIN Questions Q ON Q.CategoryId = C.CategoryId 
GROUP BY C.CategoryId, C.NAME, C.Description; 

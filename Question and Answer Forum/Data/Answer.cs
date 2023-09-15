using Microsoft.VisualBasic;

namespace CorporateQnA.Data
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerDescription { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }
        public bool IsBestSolution { get; set; }
        public DateTime AnsweredAt { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
    }
}
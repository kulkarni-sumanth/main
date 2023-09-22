using Microsoft.VisualBasic;

namespace Question_and_Answer_Forum.Data
{
    public class Answer
    {
        public Guid Id { get; set; }
        public string AnswerDescription { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }
        public bool IsBestSolution { get; set; }
        public DateTime AnsweredAt { get; set; }
        public Guid QuestionId { get; set; }
        public Guid AnsweredBy { get; set; }
    }
}
using Microsoft.VisualBasic;

namespace Question_and_Answer_Forum.Data
{
    public class Answer
    {
        public int Id { get; set; }
        public string Solution { get; set; }
        public int Votes { get; set; }
        public BestSolution BestSolution { get; set; }
        public DateTime AnsweredAt { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
    }
}

//Here is MyGroupCollectionAttribute answer
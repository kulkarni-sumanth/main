namespace CorporateQnA.Data
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionTitle { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Views { get; set; }
        public int Votes { get; set; }
        public Status Status { get; set; }
        public int CategoryId { get; set; }
        public int RaisedBy { get; set; }
    }
}
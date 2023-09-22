namespace Question_and_Answer_Forum.Data
{
    public class Question
    {
        public Guid Id { get; set; }
        public string QuestionTitle { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Views { get; set; }
        public int Votes { get; set; }
        public Status Status { get; set; }
        public Guid CategoryId { get; set; }
        public Guid RaisedBy { get; set; }
    }
}
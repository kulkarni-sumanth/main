namespace Question_and_Answer_Forum.Data
{
    public class Question
    {
        public int Id { get; set; }
        public string Query { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int NunberOfViews { get; set; }
        public int Votes { get; set; }
        public Status Status { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
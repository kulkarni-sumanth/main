namespace Question_and_Answer_Forum.Models
{
    public class QuestionModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string QuestionTitle { get; set; }
        public string Description { get; set; }
        public int Votes { get; set; }
        public int Views { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsSolved { get; set; }
        public int NumberOfAnswers { get; set; }
        public string ProfilePicture { get; set; }
    }
}
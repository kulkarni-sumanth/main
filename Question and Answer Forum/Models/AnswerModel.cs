namespace Question_and_Answer_Forum.Models
{
    public class AnswerModel
    {
        public Guid Id { get; set; }
        public string AnsweredBy { get; set; }
        public string ProfilePicture { get; set; }
        public string AnswerDescription { get; set; }
        public DateTime AnsweredAt { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }
        public bool IsBestSolution { get; set; }
    }
}
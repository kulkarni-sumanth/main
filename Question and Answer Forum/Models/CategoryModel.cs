namespace Question_and_Answer_Forum.Models
{
    public class CategoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfQuestions { get; set; }
    }
}
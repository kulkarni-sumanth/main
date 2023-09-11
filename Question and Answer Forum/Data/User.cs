namespace Question_and_Answer_Forum.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string JobCategory { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Location { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
namespace Question_and_Answer_Forum.Data
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string ProfilePicture { get; set; }
    }
}
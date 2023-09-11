namespace Question_and_Answer_Forum.Data
{
    public class Report
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ReportedTo { get; set; }
        public int ReportedFrom { get; set; }
    }
}
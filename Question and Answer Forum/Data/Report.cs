namespace Question_and_Answer_Forum.Data
{
    public class Report
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid ReportedTo { get; set; }
        public Guid ReportedFrom { get; set; }
        public Guid AnswerId { get; set; }
    }
}
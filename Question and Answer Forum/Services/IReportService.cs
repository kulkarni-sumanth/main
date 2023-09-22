using Question_and_Answer_Forum.Data;

namespace Question_and_Answer_Forum.Services
{
    public interface IReportService
    {
        public Task ReportUserAsync(Report report);
        public Task<Report> GetReportByIdAsync(Guid reportId);
        public Task<List<Report>> GetReportsReportedByUserIdAsync(Guid userId);
        public Task<List<Report>> GetReportsReportedToUserIdAsync(Guid userId);
    }
}
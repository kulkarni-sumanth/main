using Question_and_Answer_Forum.Data;
using Dapper;
using Question_and_Answer_Forum.Services.DbServices;

namespace Question_and_Answer_Forum.Services
{
    public class ReportService : IReportService
    {
        public IDapperContext DapperContext { get; set; }
        public ReportService(IDapperContext dapperContext)
        {
            this.DapperContext = dapperContext;
        }
        public async Task ReportUserAsync(Report report)
        {
            string query = "INSERT INTO Reports (Description, AnswerId, ReportedTo, ReportedFrom) VALUES (@description, @answerId, @reportedTo, @reportedFrom)";
            using (var connection = DapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, report);
            }
        }
        public async Task<Report> GetReportByIdAsync(Guid reportId)
        {
            string query = "SELECT ReportId as Id, Description, ReportedTo, ReportedFrom, AnswerId FROM Reports WHERE ReportId = @reportId";
            using (var connection = DapperContext.CreateConnection())
            {
                Report report = await connection.QuerySingleOrDefaultAsync<Report>(query, new { reportId });
                return report;
            }
        }

        public async Task<List<Report>> GetReportsReportedByUserIdAsync(Guid userId)
        {
            string query = "SELECT ReportId as Id, Description, ReportedTo, ReportedFrom, AnswerId FROM Reports WHERE ReportedFrom = @userId";
            using (var connection = DapperContext.CreateConnection())
            {
                IEnumerable<Report> reports = await connection.QueryAsync<Report>(query, new { userId });
                return reports.ToList();
            }
        }

        public async Task<List<Report>> GetReportsReportedToUserIdAsync(Guid userId)
        {
            string query = "SELECT ReportId as Id, Description, ReportedTo, ReportedFrom, AnswerId FROM Reports WHERE ReportedTo = @userId";
            using (var connection = DapperContext.CreateConnection())
            {
                IEnumerable<Report> reports = await connection.QueryAsync<Report>(query, new { userId });
                return reports.ToList();
            }
        }
    }
}
using Question_and_Answer_Forum.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Question_and_Answer_Forum.Services;

namespace Question_and_Answer_Forum.App
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        public IReportService ReportService { get; set; }
        public ReportController(IReportService reportService)
        {
            this.ReportService = reportService;
        }

        [HttpPost, Route("ReportUser")]
        public async Task<ActionResult<Report>> ReportUser([FromBody] Report report)
        {
            await ReportService.ReportUserAsync(report);
            return Ok();
        }

        [HttpGet, Route("GetReportById/{reportId}")]
        public async Task<ActionResult<Report>> GetReportById(Guid reportId)
        {
            Report report = await ReportService.GetReportByIdAsync(reportId);
            return Ok(report);
        }

        [HttpGet, Route("GetReportsReportedByUserId/{reportId}")]
        public async Task<ActionResult<List<Report>>> GetReportsReportedByUserId(Guid reportId)
        {
            List<Report> reports = await ReportService.GetReportsReportedByUserIdAsync(reportId);
            return Ok(reports);
        }

        [HttpGet, Route("GetReportsReportedToUserId/{reportId}")]
        public async Task<ActionResult<List<Report>>> GetReportsReportedToUserId(Guid reportId)
        {
            List<Report> reports = await ReportService.GetReportsReportedToUserIdAsync(reportId);
            return Ok(reports);
        }
    }
}
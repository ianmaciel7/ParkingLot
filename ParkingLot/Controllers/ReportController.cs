using CarParking.Services;
using CarParking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarParking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IParkingLotService _parkingLotService;

        public ReportController(IParkingLotService parkingLotService)
        {
            _parkingLotService = parkingLotService;

        }

        [HttpGet]
        public async Task<ActionResult<ReportFinancialGainPerDayViewModel>> Get()
        {
            var totalSoldPerDay = _parkingLotService.TotalSoldPerDay();
            if (totalSoldPerDay == null) return NoContent();
            return Ok(totalSoldPerDay);
        }
    }
}

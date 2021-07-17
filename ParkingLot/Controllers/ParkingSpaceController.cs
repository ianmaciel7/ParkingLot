using CarParking.Exceptions;
using CarParking.Models;
using CarParking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace CarParking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingSpaceController : ControllerBase
    {
        private readonly IParkingLotService _parkingLotService;
        private readonly LinkGenerator _linkGenerator;

        public ParkingSpaceController(IParkingLotService parkingLotService, LinkGenerator linkGenerator)
        {
            _parkingLotService = parkingLotService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<ParkingSpace>> Get()
        {
            try
            {
                return Ok(await _parkingLotService.AllParkingSpaces());
            }
            catch (EmptyListException)
            {
                return NoContent();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPatch("{ticketId:int}")]
        public async Task<ActionResult<ParkingSpace>> Patch(int ticketId)
        {
            try
            {
                _parkingLotService.RemoveTicketFromParkingSpace(ticketId);
                return Ok();
            }
            catch (TicketNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }



    }
}

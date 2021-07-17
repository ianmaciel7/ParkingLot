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
    public class TicketController : ControllerBase
    {
        private readonly IParkingLotService _parkingLotService;
        private readonly LinkGenerator _linkGenerator;

        public TicketController(IParkingLotService parkingLotService, LinkGenerator linkGenerator)
        {
            _parkingLotService = parkingLotService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<Ticket>> Get()
        {
            try
            {
                return Ok(_parkingLotService.AllTicket().Result);
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

        [HttpGet("{ticketId:int}")]
        public async Task<ActionResult<Ticket>> Get(int ticketId)
        {
            try
            {
                return Ok(_parkingLotService.GetTicket(ticketId).Result);
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

        [HttpPost]
        public async Task<ActionResult> Post(TicketInputModel model)
        {
            try
            {

                var result = _parkingLotService.InsertTicket(model);
                var uri = _linkGenerator.GetPathByAction("Get",
                    "Ticket",
                    new { ticketId = result.TicketId }
                    );
                return Created(uri, result);

            }
            catch (InsertFieldLessThanZeroException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InsertNullFieldException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InsertInvalidDateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InsertInvalidEnumException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ExceededTheLimitException ex)
            {
                return this.StatusCode(StatusCodes.Status507InsufficientStorage, ex.Message);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPatch("{ticketId:int}")]
        public async Task<ActionResult<Ticket>> Patch(int ticketId)
        {
            try
            {
                var result = _parkingLotService.UpdatePaymentStatusInTicket(ticketId);
                return Ok(result);
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

using AngularTest.Data;
using AngularTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularTest.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsRepository _repository;
        private readonly ILogger _logger;

        public TransactionsController(ITransactionsRepository repository, ILogger<TransactionsController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        [Route("airlines")]
        [HttpGet]
        public async Task<IEnumerable<Airline>> GetAllAirlinesAsync()
        {
            return await _repository.GetAllAirlinesAsync();
        }

        [Route("tickets")]
        [HttpGet]
        public async Task<IEnumerable<AllData>> GetAllTicketsAsync()
        {
            return await _repository.GetAllTicketsAsync();
        }

        [Route("by_doc_number/{docNumber}")]
        [HttpGet]
        public async Task<IActionResult> GetByDocNumberAsync(string docNumber)
        {
            if (docNumber == null) return BadRequest();

            return Ok(await _repository.GetByDocNumAsync(docNumber));
        }

        [Route("by_ticket_number/{ticketNumber}")]
        [HttpGet]
        public async Task<IActionResult> GetByTicketNumberAsync(string ticketNumber)
        {
            if (ticketNumber == null) return BadRequest();

            return Ok(await _repository.GetByTicketNumAsync(ticketNumber));
        }
    }
}

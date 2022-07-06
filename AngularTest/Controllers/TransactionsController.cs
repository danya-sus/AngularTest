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

        [Route("by_doc_number")]
        [HttpPost]
        public async Task<IActionResult> GetByDocNumberAsync([FromBody] InputDocDto dto)
        {
            if (dto.DocNumber == null) return BadRequest();

            return Ok(await _repository.GetByDocNumAsync(dto.DocNumber));
        }

        [Route("by_ticket_number")]
        [HttpPost]
        public async Task<IActionResult> GetByTicketNumberAsync([FromBody] InputTicketDto dto)
        {
            if (dto.IsChecked)
            {
                return Ok(await _repository.GetByTicketNumAsync(dto.TicketNumber));
            }
            return Ok(await _repository.GetByTicketNumAllAsync(dto.TicketNumber));
        }
    }
}

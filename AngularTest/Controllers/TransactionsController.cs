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
        public async Task<IActionResult> GetByDocNumberAsync([FromBody] InputModelDto dto)
        {
            if (dto.Number == null) return BadRequest();

            return Ok(await _repository.GetByDocNumAsync(dto.Number));
        }

        [Route("by_ticket_number")]
        [HttpPost]
        public async Task<IActionResult> GetByTicketNumberAsync([FromBody] InputModelDto dto)
        {
            if (dto.IsChecked)
            {
                return Ok(await _repository.GetByTicketNumAsync(dto.Number));
            }
            return Ok(await _repository.GetByTicketNumAllAsync(dto.Number));
        }
    }
}

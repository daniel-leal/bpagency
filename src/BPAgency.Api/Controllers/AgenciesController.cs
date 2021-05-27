using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using BPAgency.Domain.Entities;
using BPAgency.Domain.Entities.Pagination;
using BPAgency.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BPAgency.Api
{
    [ApiController]
    [Route("/v1/agencies")]
    public class AgenciesController : ControllerBase
    {
        private readonly ILogger _logger;

        public AgenciesController(ILogger<AgenciesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agency>>> GetAll(
            [FromServices] IAgencyRepository repository,
            [FromQuery] AgencyParameters parameters
        )
        {
            var agencies = await repository.GetAll(parameters);

            var metadata = new
            {
                agencies.TotalCount,
                agencies.PageSize,
                agencies.CurrentPage,
                agencies.TotalPages,
                agencies.HasNext,
                agencies.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

            _logger.LogInformation($"Returned {agencies.Count} agencies from database.");

            return Ok(agencies);
        }
    }
}
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
        public async Task<ActionResult<IEnumerable<Agency>>> GetAllAsync(
            [FromServices] IAgencyRepository repository,
            [FromQuery] PagedAgencyParameters pageParameters,
            [FromQuery] bool? isCapital,
            [FromQuery] bool? isStation,
            [FromQuery] bool? isOpen
        )
        {
            var agencies = await repository.GetAll(
                pageParameters,
                isCapital,
                isStation,
                isOpen
            );

            var metadata = new
            {
                agencies.TotalCount,
                agencies.PageSize,
                agencies.CurrentPage,
                agencies.TotalPages,
                agencies.HasNext,
                agencies.HasPrevious
            };
            Response.Headers.Add(
                "X-Pagination",
                JsonSerializer.Serialize(metadata)
            );

            return Ok(agencies);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<IEnumerable<Agency>>> GetByCodeAsync(
            [FromServices] IAgencyRepository repository,
            [FromRoute] string code
        )
        {
            var agency = await repository.GetByCode(code);

            if (agency == null)
            {
                return NotFound();
            }

            return Ok(agency);
        }
    }
}
using System.Collections.Generic;
using BPAgency.Domain.Entities;
using BPAgency.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BPAgency.Api
{
    [ApiController]
    [Route("/v1/agencies")]
    public class AgenciesController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<Agency> GetAll(
            [FromServices] IAgencyRepository repository,
            [FromQuery] bool? isCapital,
            [FromQuery] bool? isInland,
            [FromQuery] bool? isStation
        )
        {
            if (isCapital.HasValue)
                return repository.GetAllFromCapital();
            else if (isInland.HasValue)
                return repository.GetAllFromInland();
            else if (isStation.HasValue)
                return repository.GetAllStations();

            return repository.GetAll();
        }

        [HttpGet("from-city")]
        public IEnumerable<Agency> GetAllFromCity(
            [FromServices] IAgencyRepository repository,
            [FromQuery] string city
        )
        {
            return repository.GetAllFromCity(city);
        }
    }
}
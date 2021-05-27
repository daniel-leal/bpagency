using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BPAgency.Domain.Entities;
using BPAgency.Domain.Entities.Pagination;

namespace BPAgency.Domain.Repositories
{
    public interface IAgencyRepository
    {
        Task<PagedList<Agency>> GetAll(AgencyParameters agencyParameters);
        Task<List<Agency>> GetAllStations();
        Task<List<Agency>> GetAllFromCapital();
        Task<List<Agency>> GetAllFromInland();
        Task<List<Agency>> GetAllFromCity(string city);
        Task<Agency> GetById(Guid id);
    }
}
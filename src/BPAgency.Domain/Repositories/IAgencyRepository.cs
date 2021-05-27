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
        Task<PagedList<Agency>> GetAllStations(AgencyParameters agencyParameters);
        Task<PagedList<Agency>> GetAllFromCapital(AgencyParameters agencyParameters);
        Task<PagedList<Agency>> GetAllFromInland(AgencyParameters agencyParameters);
        Task<PagedList<Agency>> GetAllFromCity(string city, AgencyParameters agencyParameters);
        Task<Agency> GetById(Guid id);
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BPAgency.Domain.Entities;
using BPAgency.Domain.Entities.Pagination;

namespace BPAgency.Domain.Repositories
{
    public interface IAgencyRepository
    {
        Task<PagedList<Agency>> GetAll(
            PagedAgencyParameters pagedParameters,
            bool? isCapital,
            bool? isStation
        );

        Task<Agency> GetByCode(string code);
    }
}
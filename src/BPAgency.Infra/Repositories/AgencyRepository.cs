using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPAgency.Domain.Entities;
using BPAgency.Domain.Entities.Pagination;
using BPAgency.Domain.Repositories;
using BPAgency.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BPAgency.Infra.Repositories
{
    public class AgencyRepository : IAgencyRepository
    {
        private readonly BPAgencyContext _context;

        public AgencyRepository(BPAgencyContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Agency>> GetAll(
            PagedAgencyParameters pagedParameters,
            bool? isCapital,
            bool? isStation,
            bool? isOpen
        )
        {
            var dbQuery = _context.Agencies
                .AsNoTracking()
                .AsQueryable();

            if (isCapital.HasValue)
                dbQuery = dbQuery.Where(a => a.IsCapital == isCapital);

            if (isStation.HasValue)
                dbQuery = dbQuery.Where(a => a.IsStation == isStation);

            var localQuery = await dbQuery.ToListAsync<Agency>();

            if (isOpen.HasValue)
                localQuery = localQuery
                .Where(a => a.IsOpen == isOpen)
                .OrderBy(a => a.DistanceInKm)
                .ToList();
            else
                localQuery = localQuery
                .OrderBy(a => a.DistanceInKm)
                .ToList();

            var pagedAgencies = PagedList<Agency>.ToPagedList(
                localQuery,
                pagedParameters.PageNumber,
                pagedParameters.PageSize);

            return pagedAgencies;
        }

        public async Task<Agency> GetByCode(string code)
        {
            return await _context.Agencies
                .Where(a => a.Code.Equals(code))
                .FirstOrDefaultAsync();
        }
    }
}
using System;
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
            bool? isStation
        )
        {
            var query = _context.Agencies
                .AsNoTracking()
                .AsQueryable();

            if (isCapital.HasValue)
                query = query.Where(a => a.IsCapital == isCapital);

            if (isStation.HasValue)
                query = query.Where(a => a.IsStation == isStation);

            var agencies = await query.ToListAsync();

            var pagedAgencies = PagedList<Agency>.ToPagedList(
                agencies.OrderBy(a => a.DistanceInKm).ToList(),
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
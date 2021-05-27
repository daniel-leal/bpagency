using System;
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

        public async Task<PagedList<Agency>> GetAll(AgencyParameters agencyParameters)
        {
            var agencies = await _context.Agencies
                .AsQueryable()
                .AsNoTracking()
                .OrderBy(a => a.Name)
                .ToListAsync();

            var pagedAgencies = PagedList<Agency>.ToPagedList(
                agencies.AsQueryable(),
                agencyParameters.PageNumber,
                agencyParameters.PageSize);

            return pagedAgencies;
        }

        public async Task<List<Agency>> GetAllFromCapital()
        {
            var agencies = await _context.Agencies
                .AsNoTracking()
                .Where(x => x.IsCapital)
                .OrderBy(x => x.Name).ToListAsync();

            return agencies;
        }

        public async Task<List<Agency>> GetAllFromCity(string city)
        {
            var agencies = await _context.Agencies
                .AsNoTracking()
                .Where(x => x.City.Contains(city))
                .OrderBy(x => x.Name)
                .ToListAsync();

            return agencies;
        }

        public async Task<List<Agency>> GetAllFromInland()
        {
            var agencies = await _context.Agencies
                .AsNoTracking()
                .Where(x => !x.IsCapital)
                .OrderBy(x => x.Name)
                .ToListAsync();

            return agencies;
        }

        public async Task<List<Agency>> GetAllStations()
        {
            var agencies = await _context.Agencies
                .AsNoTracking()
                .Where(x => x.IsStation)
                .OrderBy(x => x.Name)
                .ToListAsync();

            return agencies;
        }


        public async Task<Agency> GetById(Guid id)
        {
            var agency = await _context.Agencies.FindAsync(id);

            return agency;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using BPAgency.Domain.Entities;
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

        public IEnumerable<Agency> GetAll()
        {
            return _context.Agencies
                .AsNoTracking()
                .OrderBy(x => x.Name).ToList().OrderBy(x => x.MyDistance);
        }

        public IEnumerable<Agency> GetAllFromCapital()
        {
            return _context.Agencies
                .AsNoTracking()
                .Where(x => x.IsCapital)
                .OrderBy(x => x.Name);
        }

        public IEnumerable<Agency> GetAllFromCity(string city)
        {
            return _context.Agencies
                .AsNoTracking()
                .Where(x => x.City.Contains(city))
                .OrderBy(x => x.Name);
        }

        public IEnumerable<Agency> GetAllFromInland()
        {
            return _context.Agencies
                .AsNoTracking()
                .Where(x => !x.IsCapital)
                .OrderBy(x => x.Name);
        }

        public IEnumerable<Agency> GetAllStations()
        {
            return _context.Agencies
                .AsNoTracking()
                .Where(x => x.IsStation)
                .OrderBy(x => x.Name);
        }

        public Agency GetById(Guid id)
        {
            return _context.Agencies.Find(id);
        }
    }
}
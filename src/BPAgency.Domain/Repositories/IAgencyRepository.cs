using System;
using System.Collections.Generic;
using BPAgency.Domain.Entities;

namespace BPAgency.Domain.Repositories
{
    public interface IAgencyRepository
    {
        IEnumerable<Agency> GetAll();
        IEnumerable<Agency> GetAllStations();
        IEnumerable<Agency> GetAllFromCapital();
        IEnumerable<Agency> GetAllFromInland();
        IEnumerable<Agency> GetAllFromCity(string city);
        Agency GetById(Guid id);
    }
}
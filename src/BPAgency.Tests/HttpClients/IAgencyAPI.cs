using System.Collections.Generic;
using System.Threading.Tasks;
using BPAgency.Tests.Models;
using Refit;

namespace BPAgency.Tests.HttpClients
{
    public interface IAgencyAPI
    {
        [Get("/v1/agencies")]
        Task<ApiResponse<List<Response>>> GetAllAsync();
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using BPAgency.Tests.Models;
using Refit;

namespace BPAgency.Tests.HttpClients
{
    public interface IAgencyAPI
    {
        [Get("/v1/agencies?pageSize=200")]
        Task<ApiResponse<List<Response>>> GetAllAsync();

        [Get("/v1/agencies?pageSize=10")]
        Task<ApiResponse<List<Response>>> GetOnyTenRecordsAsync();

        [Get("/v1/agencies?pageSize=200&isCapital=true")]
        Task<ApiResponse<List<Response>>> GetAllFromCapitalAsync();

        [Get("/v1/agencies?pageSize=200&isCapital=false")]
        Task<ApiResponse<List<Response>>> GetAllFromInlandAsync();

        [Get("/v1/agencies?pageSize=200&isStation=true")]
        Task<ApiResponse<List<Response>>> GetAllStationAsync();

        [Get("/v1/agencies?pageSize=200&isStation=false")]
        Task<ApiResponse<List<Response>>> GetAllAgenciesAsync();

        [Get("/v1/agencies/{code}")]
        Task<ApiResponse<Response>> GetByCode(string code);
    }
}
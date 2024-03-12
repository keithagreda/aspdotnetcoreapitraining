using TrainingApi.ApiResponse;
using TrainingApi.Models;

namespace TrainingApi.Services
{
    public interface ISalesHeaderServices
    {
        Task<ApiResponse<string>> CreateHeaderDetails(SalesHeaderDetailsDto input);
        Task<List<SalesHeaderDetailsV2Dto>> GetAllSalesHeaderDetails();
        Task<string> UpdateHeaderDetails(SalesHeaderDetailsV2Dto input);

        Task<string> InsertTemp(long salesId, long createdBy);
        Task<string> DeleteHeader(long id);
    }
}
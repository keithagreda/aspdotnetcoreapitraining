using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.Auth;
using TrainingApi.ApiResponse;
using TrainingApi.Models;
using TrainingApi.Services;

namespace Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesHeaderController : ControllerBase
    {
        private readonly ISalesHeaderServices _salesHeaderServices;

        public SalesHeaderController(ISalesHeaderServices salesHeaderServices)
        {
            _salesHeaderServices = salesHeaderServices;
        }
        [HttpPost("InsertHeaderDetails")]
        public async Task<ActionResult<ApiResponse<string>>> InsertHeaderDetails(SalesHeaderDetailsDto input)
        {
            var result = await _salesHeaderServices.CreateHeaderDetails(input);
            return result;
        }
        [Authorize(Roles = UserRole.Admin)]
        [HttpGet("GetAllSalesHeaderDetails")]
        public async Task<ActionResult<ApiResponse<List<SalesHeaderDetailsV2Dto>>>> GetAllSalesHeaderDetails()
        {
            
            var result = await _salesHeaderServices.GetAllSalesHeaderDetails();
            var res = new ApiResponse<List<SalesHeaderDetailsV2Dto>>
            {
                Data = result,
                isSuccess = true,
                ErrorMessage = ""
            };

            return res;
        }

        [HttpPost("UpdateHeaderDetails")]
        public async Task<ActionResult<ApiResponse<string>>> UpdateHeaderDetails(SalesHeaderDetailsV2Dto input)
        {

            var result = await _salesHeaderServices.UpdateHeaderDetails(input);
            var res = new ApiResponse<string>
            {
                Data = "Updated!",
                isSuccess = true,
                ErrorMessage = ""
            };

            return res;
        }

        [HttpPost("InsertTemp")]
        public async Task<ActionResult<ApiResponse<string>>> InsertTemp(long salesId, long createdBy)
        {

            var result = await _salesHeaderServices.InsertTemp(salesId, createdBy);
            var res = new ApiResponse<string>
            {
                Data = result,
                isSuccess = true,
                ErrorMessage = ""
            };

            return res;
        }

        [HttpDelete("DeleteHeader")]
        public async Task<ActionResult<ApiResponse<string>>> DeleteHeader(long salesId)
        {

            var result = await _salesHeaderServices.DeleteHeader(salesId);
            var res = new ApiResponse<string>
            {
                Data = result,
                isSuccess = true,
                ErrorMessage = ""
            };

            return res;
        }
    }
}

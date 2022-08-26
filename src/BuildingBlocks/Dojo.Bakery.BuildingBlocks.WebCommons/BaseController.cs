using Dojo.Bakery.BuildingBlocks.WebCommons.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dojo.Bakery.BuildingBlocks.WebCommons
{
    [Authorize]
    public abstract class BaseController : ControllerBase
    {
        public async Task<SuccessResponse> Result<T>(Task<T> data)
        {
            return new SuccessResponse()
            {
                Data = await data
            };
        }

        protected SuccessResponse Result<T>(T data)
        {
            return new SuccessResponse()
            {
                Data = data
            };
        }

        protected ErrorDetail BadRequestResponse<T>(T data, string message)
        {
            return new ErrorDetail()
            {
                Data = data,
                Message = message
            };
        }

        protected ErrorDetail BadRequestResponse(string message)
        {
            return new ErrorDetail()
            {
                Message = message
            };
        }
    }
}
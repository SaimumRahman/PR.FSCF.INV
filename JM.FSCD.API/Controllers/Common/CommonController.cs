using JM.Application.Services;
using JM.Application.Services.Common_S;
using JM.Application.Services.Supplier_S;
using JM.Domain.CommonDTO;
using JM.Infrastructure.Models;
using JM.Middleware.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JM.FSCD.API.Controllers.Supplier
{
    [Route("FSCD/Common/")]
    public class CommonController : BaseAPINoAuthController
    {

        [HttpGet("drop-down")]
        public async Task<IEnumerable<CommonComboDto>> GetComboBox([FromQuery] GetCommonComboQuery query)
        {
            return await Task.Run(() => Mediator.Send(query).Result.AsEnumerable());
        }
        [HttpPost("delete")]
        public async Task<ResponseResult> Delete([FromBody] CommonDeleteCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}

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

namespace JM.FSCD.API.Controllers.Supplier
{
    [Route("FSCD/Supplier/")]
    public class SupplierController : BaseAPINoAuthController
    {

        [HttpPost("insert-update")]
        public async Task<ResponseResult> Creates([FromBody] CreateUpdateSupplierCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet("get-all")]
        public async Task<ResponseResult> GetAll([FromQuery] GetSupplierAllQuery query)
        {
            return await Mediator.Send(query);
        }
        [HttpGet("get-by-id")]
        public async Task<ResponseResult> GetById([FromQuery] GetSupplierByIdQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}

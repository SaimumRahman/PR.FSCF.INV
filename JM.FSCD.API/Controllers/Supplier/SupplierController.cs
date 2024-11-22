using JM.Application.Services;
using JM.Application.Services.Common_S;
using JM.Application.Services.Supplier_S;
using JM.Domain.CommonDTO;
using JM.Infrastructure.Models;
using JM.Middleware.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        //[HttpGet("drop-down")]
        //public async Task<IEnumerable<CommonComboDto>> GetComboBox([FromQuery] BaseQuery baseQuery)
        //{
        //    GetCommonComboQuery query = new GetCommonComboQuery()
        //    {
        //        CascadingField = "IS_DELETED",
        //        CascadingValue = "0",
        //        TableName = "BANKDETAILS",
        //        TextField = "BANK_NAME",
        //        ValueField = "BANK_ID"
        //    };
        //    return await Task.Run(() => Mediator.Send(query).Result.AsEnumerable());
        //}
        //[HttpPost("delete")]
        //public async Task<ResponseResult> Delete([FromBody] DeleteDTO deleteDTO)
        //{
        //    CommonDeleteCommand query = new CommonDeleteCommand()
        //    {
        //        TableName = "BANKDETAILS",
        //        ColumnName = "BANK_ID",
        //        PrimaryKey = deleteDTO.PrimaryKey,
        //        LoggedUserId = deleteDTO.LoggedUserId,
        //    };
        //    return await Task.Run(() => Mediator.Send(query).Result);
        //}
    }
}

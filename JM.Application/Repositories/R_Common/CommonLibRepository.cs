using Microsoft.Extensions.Logging;
using JM.Application.Interfaces.I_Common;
using JM.Domain.CommonDTO;
using JM.Domain.DTOs;
using JM.Infrastructure.Base;
using JM.Infrastructure.Common;
using JM.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using JM.Middleware.Converters;

namespace JM.Application.Repositories.R_Common
{
    public class CommonLibRepository : BaseRepository<CommonComboDto>, ICommonLibRepository
    {
        public readonly ILogger<CommonComboDto> _logger;
        public CommonLibRepository(ILogger<CommonComboDto> logger, IConnectionFactory connectionFactory) : base(logger, connectionFactory)
        {
            _logger = logger;
        }

        public async Task<int> DeleteData(string TableName, int UserId, string deletedpc, string columnname,int primarykey,int companyid)
        {
            try
            {
                string query = string.Format(@"UPDATE {0} SET isdeleted = 1, deleteby = {1},
 deleteon = NOW(), deletepc = '{2}' WHERE {3} = {4} and companyid={5}", TableName, UserId, deletedpc, columnname, primarykey, companyid);
                var t= await base.ExecuteAsync(query);
                return t;


            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<IEnumerable<CommonComboDto>> GetCommonComboData(string peram,int companyid)
        {
            // CommonLibDataService dataService = new CommonLibDataService();
            var objPeram = peram.Split(',');
            var condition = "";
            string orderBy = "";
            if (objPeram.Length > 3)
            {
                if (objPeram[3] != "")
                {
                    condition = $"Where {objPeram[3]}={objPeram[4]} and companyid={companyid}";
                }
            }
            orderBy = " Order by " + objPeram[1];
            string query = string.Format(@"Select {0} as Id, {1} as Text from {2} {3} {4}", objPeram[0], objPeram[1], objPeram[2], condition, orderBy);
            return await Query<CommonComboDto>(query);
        }
       
    }
}

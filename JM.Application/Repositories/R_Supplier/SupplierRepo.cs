using JM.Application.Common.Generic;
using JM.Application.Interfaces;
using JM.Application.Interfaces.I_Supplier;
using JM.Domain.DTOs;
using JM.Domain.Entities;
using JM.Infrastructure.Base;
using JM.Infrastructure.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM.Application.Repositories.R_Supplier
{
    public class SupplierRepo : BaseRepository<Supplier>, ISupplierRepo
    {
        public readonly ILogger<SupplierRepo> _logger;

        public SupplierRepo(ILogger<SupplierRepo> logger, IConnectionFactory connectionFactory, IDbContextCore dbContext) : base(logger, connectionFactory, dbContext.Instance)
        {
            _logger = logger;

        }

        public async Task<SupplierDTO> GetSupplierById(int supplierId)
        {
            try
            {
                string query = $@"SELECT 
    sp.supplierid,
    sp.suppliername,
    sp.supplierlocation,
    sp.contactpersonname,
    sp.contactpersonnumber,
    sp.contactpersonemail,
    sp.remarks,
    sp.companyid,
    cm.CompanyName,
    sp.createby,
    fu.UserName,
    sp.createon,
    sp.createpc,
    sp.updateby,
    sp.updateon,
    sp.updatepc,
    sp.isdeleted,
    sp.deleteby,
    sp.deleteon,
    sp.deletepc
FROM 
    supplier sp
LEFT JOIN fscd_users fu ON fu.EmpId=sp.createby
LEFT JOIN company cm ON cm.CompanyID=sp.companyid
where sp.supplierid=@supplierid;
";
                var result = await base.QuerySingleOrDefaultAsync<SupplierDTO>(query,new { supplierid= supplierId });
                return result;  
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> UpdateSupplierById(Supplier supplier)
        {
            try
            {
                string query = $@"UPDATE supplier
SET 
    suppliername = @suppliername,
    supplierlocation = @supplierlocation,
    contactpersonname = @contactpersonname,
    contactpersonnumber = @contactpersonnumber,
    contactpersonemail = @contactpersonemail,
    remarks = @remarks,
    updateby = @updateby,
    UpdateOn = @UpdateOn,
    UpdatePc = @UpdatePc
WHERE supplierid = @supplierid;
";
                var result = await base.ExecuteAsync(query,supplier);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

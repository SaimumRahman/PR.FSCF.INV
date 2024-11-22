using JM.Domain.DTOs;
using JM.Domain.Entities;
using JM.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM.Application.Interfaces.I_Supplier
{
    public interface ISupplierRepo : IBaseDapperRepository, IGenericRepository<Supplier>
    {
        Task<SupplierDTO> GetSupplierById(int supplierId);
        Task<int> UpdateSupplierById(Supplier supplier);
    }
}

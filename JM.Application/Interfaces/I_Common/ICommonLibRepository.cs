using JM.Domain.CommonDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM.Application.Interfaces.I_Common
{
    public interface ICommonLibRepository
    {
        Task<IEnumerable<CommonComboDto>> GetCommonComboData(string peram);
        Task<int> DeleteData(string TableName, int UserId, string deletedpc, string columnname, int primarykey);
    }
}

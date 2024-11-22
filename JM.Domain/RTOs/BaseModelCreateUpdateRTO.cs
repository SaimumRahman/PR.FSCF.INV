using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM.Domain.RTOs
{
    public class BaseModelCreateUpdateRTO
    {
        public int CompanyId { get; set; } = 0;
        public int CreateBy { get; set; } = 0;
        public DateTime? CreateOn { get; set; } = null;
        public string CreatePc { get; set; } = string.Empty;
        public int UpdateBy { get; set; } = 0;
        public DateTime? UpdateOn { get; set; } = null;
        public string UpdatePc { get; set; } = string.Empty;
    }
}

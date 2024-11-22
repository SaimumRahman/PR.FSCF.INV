using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM.Domain.Entities
{
    public class BaseModel
    {
        public int CompanyId { get; set; }
        public int CreateBy { get; set; }
        public DateTime? CreateOn { get; set; }
        public string CreatePc { get; set; }
        public int UpdateBy { get; set; }
        public DateTime? UpdateOn { get; set; }
        public string UpdatePc { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int DeleteBy { get; set; }
        public DateTime? DeleteOn { get; set; }
        public string DeletePc { get; set; }
    }
}

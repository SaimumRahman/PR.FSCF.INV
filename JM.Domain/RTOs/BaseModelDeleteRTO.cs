using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM.Domain.RTOs
{
    public class BaseModelDeleteRTO
    {
        public bool IsDeleted { get; set; } = false;
        public int DeleteBy { get; set; }
        public DateTime DeleteOn { get; set; }
        public string DeletePc { get; set; }
    }
}

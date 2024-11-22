using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM.Domain.Entities
{
    [Table("supplier")]
    public class Supplier: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierLocation { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonNumber { get; set; }
        public string ContactPersonEmail { get; set; }
        public string Remarks { get; set; }
    }
}

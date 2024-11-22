using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace JM.AuthServer.API.Models
{
    [Table("fscd_users")]
    public class User : IdentityUser
    {
        public int EmpId { get; set; }
    }
}

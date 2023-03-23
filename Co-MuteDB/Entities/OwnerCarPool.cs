using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Co_MuteDB.Entities
{
    public class OwnerCarPool
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CarPoolId { get; set; }
        public DateTime JoinDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Active"; 
        public User? comuteUser { get; set; }
        public CarPool? carPool { get; set; }

    }
}

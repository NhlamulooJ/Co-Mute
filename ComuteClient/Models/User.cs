using System.ComponentModel.DataAnnotations;

namespace ComuteClient.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
        public ICollection<Carpool> carPools { get; set; }
        public ICollection<OwnerCarpool> ownerCarPools { get; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ComuteClient.Models
{
    public class Carpool
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        //[Required]
        public DateTime? DepartureTime { get; set; }
        //[Required]
        public DateTime? ExpectedArrival { get; set; }
        [Required]
        public string DepartureOrigin { get; set; }
        [Required]
        public int DaysAvailable { get; set; }
        [Required]
        public int TotalSeats { get; set; }
        [Required]
        public int AvailableSeats { get; set; }
        [Required]
        public string Destination { get; set; }
        public string Notes { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
        public User? comuteUser { get; set; }
        public ICollection<OwnerCarpool>? ownerCarpools { get; set; }
    }
}

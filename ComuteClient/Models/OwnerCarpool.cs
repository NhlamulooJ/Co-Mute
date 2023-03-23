namespace ComuteClient.Models
{
    public class OwnerCarpool
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarPoolId { get; set; }
        public DateTime JoinDate { get; set; }
        public string Status { get; set; } = "Active";
        public User comuteUser { get; set; }
        public Carpool carPool { get; set; }
    }
}

namespace Benihime.Models
{
    public class AppUser
    {
        public Address? Address { get; set; }
        public int? Pace { get; set; }
        public int? Mileage { get; set; }
        public ICollection<Club> Clubs { get; set; }
        public ICollection<Race> Races { get; set; }
    }
}

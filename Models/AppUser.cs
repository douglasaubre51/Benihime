﻿using System.ComponentModel.DataAnnotations;

namespace Benihime.Models
{
    public class AppUser
    {
        [Key]
        public string Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public Address? Address { get; set; }
        public int? Pace { get; set; }
        public int? Mileage { get; set; }
        public ICollection<Club> Clubs { get; set; }
        public ICollection<Race> Races { get; set; }
    }
}

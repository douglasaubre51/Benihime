using System.ComponentModel.DataAnnotations;
namespace Benihime.Models
{
    public class Address
    {
        [Key]
        int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int State { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace SystemMidterm_19070006058.Model
{
    public class House
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int MaxCustomerCount { get; set; }
        [Required]
        public string City { get; set; }

        public bool IsAvaiable { get; set; }
        public ICollection<Amenity> Amenities { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace SystemMidterm_19070006058.Model
{
    public class AmenityHouse
    {
        public int Id { get; set; }
        [ForeignKey("Amenity")]
        public int AmenityId { get; set; }
        [ForeignKey("House")]
        public int HouseId { get; set; }
    }
}

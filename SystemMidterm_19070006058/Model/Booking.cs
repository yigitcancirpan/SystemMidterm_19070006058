using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemMidterm_19070006058.Model
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("House")]
        public int HouseId { get; set; }
        public int CustomerCount { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }
        
    }
}

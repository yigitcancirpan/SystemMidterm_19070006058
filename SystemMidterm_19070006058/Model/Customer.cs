using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemMidterm_19070006058.Model
{
    [Table("Customers")]
    [Index(nameof(Email), IsUnique = true)]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        
        [MaxLength(10)]
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        
        [MaxLength(50)]
        public string? City { get; set; }
        [Required]
        public bool CustomerStatus { get; set; }
        

    }
}

using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Employer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public String password { get; set; }    
        public string Role { get; set; }

    }
}

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HalisPeynir.Models
{
    public class Servicee
    {
        [Key]

        public int ServiceeID { get; set; }
        [Required(ErrorMessage = "{0} Needs to fill"), Display(Name = "Service name "), StringLength(30, MinimumLength = 2, ErrorMessage = "{0} needs to include {2} - {1} ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} Needs to fill"), Display(Name = "Service price"), Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
    }
}

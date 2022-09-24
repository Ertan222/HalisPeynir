using System.ComponentModel.DataAnnotations;

namespace HalisPeynir.Models
{
    public class Gender
    {
        [Key]

        public int GenderID { get; set; }

        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "Gender name"), StringLength(40, MinimumLength = 5, ErrorMessage = "{0} {2} - {1} must be in rage.")]
        public string GenderName { get; set; }
    

    }
}

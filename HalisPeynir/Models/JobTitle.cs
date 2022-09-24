using System.ComponentModel.DataAnnotations;

namespace HalisPeynir.Models
{
    public class JobTitle
    {
        [Key]
        public int JobTitleID { get; set; }

        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "JobTitle"), StringLength(30, MinimumLength = 10, ErrorMessage = "{0} {2} - {1} needs to be in range.")]
        public string JobTitleName { get; set; }
    }
}
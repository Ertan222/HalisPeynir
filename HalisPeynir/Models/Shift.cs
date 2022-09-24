using System.ComponentModel.DataAnnotations;
namespace HalisPeynir.Models
{
    public class Shift
    {
        [Key]
        public int ShiftID { get; set; }

        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "Shift"), StringLength(30, MinimumLength = 10, ErrorMessage = "{0} {2} - {1} needs to be in range.")]

        public string ShiftName { get; set; }
    }
}

using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
namespace HalisPeynir.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }



        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "First and second name"), StringLength(40, MinimumLength = 3, ErrorMessage = "{0} {2} - {1} needs to be in range .")]
        public string NameAndSecName { get; set; }



        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "Surname"), StringLength(30, MinimumLength = 2, ErrorMessage = "{0} {2} - {1} needs to be in range.")]
        public string Surname { get; set; }



        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "Date of birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Date is not in corect form")]

        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "Gender"),Range(1,99,ErrorMessage ="{0} must be chosen")]
        public int GenderID { get; set; }

        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "JobTitle"),Range(1,99,ErrorMessage ="{0} must be chosen")]
        public int JobTitleID { get; set; }

        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "Shift"), Range(1, 99, ErrorMessage = "{0} must be chosen")]
        public int ShiftID { get; set; } 
        public bool WorkStatus { get; set; }



        public Gender Gender { get; set; }
        
        public JobTitle JobTitle { get; set; }

        public Shift Shift { get; set; }
    }
}

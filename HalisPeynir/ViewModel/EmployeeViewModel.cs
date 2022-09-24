using HalisPeynir.Models;

namespace HalisPeynir.ViewModel
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public List<Gender> GenderList { get; set; }
        public List<JobTitle> JobTitleList { get; set; }

        public List<Shift> ShiftList { get; set; }
    }
}

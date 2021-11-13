using ManagementPlus.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManagementPlus.ViewModels
{
    public class IndividualContributorVM
    {
        public Guid Id { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Band and Level")]
        public string Level { get; set; }
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public int BaseSalary { get; set; }
        [Display(Name = "Hiring Date")]
        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }
        public ProvinceEnum Province { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;
    }
}

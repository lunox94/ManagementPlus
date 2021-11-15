using ManagementPlus.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManagementPlus.ViewModels
{
    public class IndividualContributorToEditVM
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public int Level { get; set; }
        [Display(Name = "Base Salary")]
        public int BaseSalary { get; set; }
        [Display(Name = "Hiring Date")]
        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }
        public ProvinceEnum Province { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;
    }
}

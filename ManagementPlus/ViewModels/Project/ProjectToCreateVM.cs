using System;
using System.ComponentModel.DataAnnotations;

namespace ManagementPlus.ViewModels
{
    public class ProjectToCreateVM
    {        
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        public string Overview { get; set; }
        [Required]
        [RegularExpression(@"^([1-9][0-9]*)(:[0-5][0-9])?$")]
        [Display(Name = "Hours Limit")]
        public string HoursLimit { get; set; }
    }
}

using ManagementPlus.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementPlus.Models
{
    public class IndividualContributor
    {
        public Guid Id { get; set; }
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

        public List<Assignment> Assignments { get; set; }

        public static string GetBandFromLevel(int level)
        {
            return level switch
            {
                1 => "STAFF",
                2 => "INTERN",
                3 or 4 => "SDE",
                5 or 6 => "SDE II",
                7 or 8 => "SENIOR SDE",
                9 => "PRINCIPAL SDE",
                _ => throw new Exception("Could not get band name from level."),
            } + $" (L{level})";
        }
    }
}

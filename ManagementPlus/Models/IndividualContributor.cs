using ManagementPlus.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementPlus.Models
{
    public class IndividualContributor
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public int Level { get; set; }
        public int BaseSalary { get; set; }
        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }
        public ProvinceEnum Province { get; set; }
        public bool IsActive { get; set; }

        public List<Assignment> Assignments { get; set; }
    }
}

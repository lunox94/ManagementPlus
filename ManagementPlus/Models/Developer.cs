using ManagementPlus.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementPlus.Models
{
    public class Developer
    {
        public string FullName { get; set; }
        public int Level { get; set; }
        public int BaseSalary { get; set; }
        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }
        public ProvinceEnum Province { get; set; }
        public bool IsActive { get; set; }

    }
}

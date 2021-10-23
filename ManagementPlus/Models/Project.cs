using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementPlus.Models
{
    public class Project
    {
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        public string Overview { get; set; }
        public TimeSpan HoursLimit { get; set; }
    }
}

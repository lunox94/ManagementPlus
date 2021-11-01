using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementPlus.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        public string Overview { get; set; }
        public long HoursLimit { get; set; }

        public List<Assignment> Assignments { get; set; }
    }
}

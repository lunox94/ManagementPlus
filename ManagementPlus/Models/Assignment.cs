using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementPlus.Models
{
    public class Assignment
    {
        public Guid IndividualContributorId { get; set; }
        public Guid ProjectId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfFirstAssignment { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfLastAssignment { get; set; }
        public bool IsActive { get; set; }

        public IndividualContributor IndividualContributor { get; set; }
        public Project Project { get; set; }
        public List<Report> Reports { get; set; }
    }
}

﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ManagementPlus.ViewModels
{
    public class ProjectVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        public string Overview { get; set; }
        [Required]
        [Display(Name = "Hours Limit")]
        public string HoursLimit { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagerUI.ViewModels
{
    public class TaskViewModel
    {

        [Key]
        public int TaskId { get; set; }
        [StringLength(100)]
        [Required]
        [Display(Name ="Enter Task Name")]
        public string TaskName { get; set; }
        [StringLength(300)]
        [Display(Name = "Enter Task Description(optional)")]
        public string TaskDescription { get; set; }
        [Required]
        [Display(Name = "Select Start Date")]
        public DateTime TaskStartDate { get; set; }
        [Required]
        [Display(Name = "Select End Date")]
        public DateTime TaskEndDate { get; set; }
        [Required]
        [Display(Name = "Select task Priority[1-5]")]
        public int TaskPriority { get; set; }

        [Required]
        [Display(Name = "Select task status")]
        public string TaskStatus { get; set; }

        public int ProjectId { get; set; }
        [Display(Name = "Select Employees")]
        public int EmployeeId { get; set; }
        public SelectList Employees { get; set; }

    }
}
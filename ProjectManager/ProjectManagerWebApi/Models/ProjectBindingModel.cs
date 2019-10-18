using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerWebApi.Models
{
    public class ProjectBindingModel
    {
        public int ProjectId { get; set; }
        
        public string ProjectTitle { get; set; }
        
        public DateTime ProjectStartDate { get; set; }
        
        public DateTime ProjectEndDate { get; set; }
        
        public int EmployeeId { get; set; }
       
    }
}
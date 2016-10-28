using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystem.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please enter a unique department code.")]
        [Remote("IsCodeExists", "Department", ErrorMessage = "Department code already exists.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please enter a unique department name.")]
        [Remote("IsNameExists", "Department", ErrorMessage = "Department name already exists.")]
        public string Name { get; set; }
    }
}
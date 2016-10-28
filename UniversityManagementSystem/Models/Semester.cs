using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystem.Models
{
    public class Semester
    {
        public int SemesterId { get; set; }

        [Required(ErrorMessage = "Please enter a unique semester name.")]
        [Remote("IsNameExists", "Semester", ErrorMessage = "Semester name already exists.")]
        public string Name { get; set; }
    }
}
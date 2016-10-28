using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Please enter a valid Email Address")]
        [Remote("IsEmailExists", "Teacher", ErrorMessage = "Email address already exists.")]
        public string Email { get; set; }

        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Please enter a valid date.")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public string Address { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual string RegistrationId { get; set; }
    }
}
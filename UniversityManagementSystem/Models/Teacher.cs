using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystem.Models
{
    public class Teacher
    {
        public Teacher()
        {
            this.TeachersCourses = new Collection<Course>();
        }

        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        public string Address { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Please enter a valid Email Address")]
        [Remote("IsEmailExists", "Teacher", ErrorMessage = "Email address already exists.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        public string ContactNo { get; set; }

        public int DesignationId { get; set; }
        public virtual Designation Designation { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [Range(typeof(double), "0.5", "36.0", ErrorMessage = "Credit must be between 0.5 and 36.0")]
        public double CreditTaken { get; set; }

        public virtual ICollection<Course> TeachersCourses { get; set; }
    }
}
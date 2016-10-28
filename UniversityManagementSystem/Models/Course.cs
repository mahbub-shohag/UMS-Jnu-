using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystem.Models
{
    public class Course
    {
        public Course()
        {
            this.CourseTeacher = new Collection<Teacher>();
        }

        public int CourseId { get; set; }

        [Required(ErrorMessage = "Please enter a unique course code.")]
        [Remote("IsCodeExists", "Course", ErrorMessage = "Course code already exists.")]
        public string Code { get; set; }

        [Range(typeof(double), "0.5", "12.0", ErrorMessage = "Course credit must be between 0.5 and 12.0")]
        public double Credit { get; set; }

        [Required(ErrorMessage = "Please enter a unique course name.")]
        [Remote("IsNameExists", "Course", ErrorMessage = "Course name already exists.")]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual Semester CourseSemister { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public int SemesterId { get; set; }
        public virtual Semester Semester { get; set; }

        public virtual String AssignTo { get; set; }

        public virtual ICollection<Teacher> CourseTeacher { get; set; }

        public virtual ICollection<RoomAllocation> RoomAllocationList { get; set; }
    }
}
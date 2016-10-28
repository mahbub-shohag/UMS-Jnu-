using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class RoomAllocation
    {
        public int Id { set; get; }

        [Required(ErrorMessage = "Please enter a Department")]
        public int DepartmentId { set; get; }
        public virtual Department Department { set; get; }

        [Required(ErrorMessage = "Please enter a Couse")]
        public int CourseId { set; get; }
        public virtual Course Course { set; get; }

        [Required(ErrorMessage = "Please enter a Room")]
        public int RoomId { set; get; }
        public virtual Room Room { set; get; }

        [Required(ErrorMessage = "Please enter a Day")]
        public int DayId { set; get; }
        public virtual Day Day { set; get; }

        [Required(ErrorMessage = "Please enter a valid time")]
        [Display(Name = "Start time")]
        public string StartTime { set; get; }

        [Required(ErrorMessage = "Pleae enter a valid time")]
        [Display(Name = "End time ")]
        public string EndTime { set; get; }
    }
}
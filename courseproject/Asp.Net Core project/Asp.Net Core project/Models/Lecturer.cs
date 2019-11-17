using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Core_project.Models
{

    public class Lecturer
    {
        [Required(AllowEmptyStrings = false)] 
        public string Name { get; set; }

        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/2/2004", "3/4/3004",
            ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime BirthDate { get; set; }

        public List<Course> Courses { get; set; }
    }
}

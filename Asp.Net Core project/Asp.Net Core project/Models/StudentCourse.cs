﻿using System;

namespace Asp.Net_Core_project.Models
{

    public class StudentCourse
    {
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public Student Student { get; set; }
    }
}

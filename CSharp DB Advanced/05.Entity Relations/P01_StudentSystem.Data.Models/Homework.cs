﻿namespace P01_StudentSystem.Data.Models
{
    using Enums;
    using System;

    public class Homework
    {
        public int HomeworkId { get; set; }

        public int MyProperty { get; set; }

        public string Content { get; set; }

        public ContentType ContentType { get; set; }

        public DateTime SubmissionTime { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}

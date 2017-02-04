namespace BangaloreUniversity.Models
{
    using System;
    using System.Collections.Generic;

    using BangaloreUniversity.Interfaces;

    public class Course
    {
        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.Lectures = new List<Lecture>();
            this.Students = new List<IUser>();
        }

        public string Name {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(
                        "The course name must be at least 5 symbols long.");
                }

                this.name = value;
            }
        }

        public IList<Lecture> Lectures { get; private set; }

        public IList<IUser> Students { get; private set; }

        public void AddLecture(Lecture lecture)
        {
            this.Lectures.Add(lecture);
        }

        public void AddStudent(IUser student)
        {
            this.Students.Add(student);
            student.Courses.Add(this);
        }
    }
}
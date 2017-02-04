namespace BangaloreUniversity.Controllers
{
    using System;
    using System.Linq;

    using BangaloreUniversity.Interfaces;
    using BangaloreUniversity.Models;
    
    class CoursesController : Controller
    {
        public CoursesController(IDataBase data, IUser user)
            : base(data, user)
        {
        }

        public IView All()
        {
            var result = this.View(Data.Courses.GetAll()
                   .OrderBy(c => c.Name)
                   .ThenByDescending(c => c.Students.Count));
            return result;
        }

        public IView Details(int courseId)
        {
            var course = this.Data.Courses.Get(courseId);
            return this.View(course);
        }

        public IView Enroll(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var course = this.Data.Courses.Get(courseId);
            this.VerifeCourse(course, courseId);
            this.EnsureUserDoseNotContainCourse(course);
            course.AddStudent(this.User);
            return this.View(course);
        }

        public IView Create(string name)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var course = new Course(name);
            this.Data.Courses.Add(course);
            return this.View(course);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            Course course = CourseById(courseId);
            course.AddLecture(new Lecture(lectureName));
            return this.View(course);
        }


        private Course CourseById(int id)
        {
            var course = this.Data.Courses.Get(id);
            if (course == null)
            {
                throw new ArgumentException(string.Format(
                    "There is no course with ID {0}.", id));
            }

            return course;
        }
        
        private void EnsureUserDoseNotContainCourse(Course course)
        {
            if (this.User.Courses.Contains(course))
            {
                throw new ArgumentException("You are already enrolled in this course.");
            }
        }

        private void VerifeCourse(Course course, int id)
        {
            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", id));
            }
        }
    }
}

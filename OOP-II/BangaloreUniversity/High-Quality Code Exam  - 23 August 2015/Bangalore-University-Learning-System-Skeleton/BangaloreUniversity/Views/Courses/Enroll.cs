namespace BangaloreUniversity.Views.Courses
{
    using System.Text;
    using BangaloreUniversity.Models;
    using BangaloreUniversity.Views.Abstract;

    public class Enroll : View
    {
        public Enroll(Course course) : base(course)
        {
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat("Student successfully enrolled in course {0}.",
                course.Name).AppendLine();
        }
    }
}
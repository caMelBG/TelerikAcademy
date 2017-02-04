namespace BangaloreUniversity.Views.Courses
{
    using System.Text;
    using BangaloreUniversity.Models;
    using BangaloreUniversity.Views.Abstract;

    public class AddLecture : View
    {
        public AddLecture(Course course) : base(course)
        {
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat("Lecture successfully added to course {0}.", course.Name).AppendLine();
        }
    }
}
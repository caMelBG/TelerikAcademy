namespace BangaloreUniversity.Views.Abstract
{
    using System.Text;
    using Interfaces;

    public abstract class View : IView
    {
        public View(object model)
        {
            this.Model = model;
        }

        public object Model { get; private set; }

        public string Display()
        {
            var viewResult = new StringBuilder();
            this.BuildViewResult(viewResult);
            return viewResult.ToString().Trim();
        }

        public virtual void BuildViewResult(StringBuilder viewResult)
        {
        }
    }
}
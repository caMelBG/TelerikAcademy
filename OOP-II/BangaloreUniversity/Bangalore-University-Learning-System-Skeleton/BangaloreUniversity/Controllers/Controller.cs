namespace BangaloreUniversity.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Linq;

    using BangaloreUniversity.Interfaces;
    using BangaloreUniversity.Models;

    public abstract class Controller
    {
        protected Controller(IDataBase data, IUser user)
        {
            this.Data = data;
            this.User = user;
        }

        public IDataBase Data { get; private set; }

        public IUser User { get; protected set; }

        public bool HasCurrentUser
        {
            get
            {
                return User != null;
            }
        }

        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(".");
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            string controllerName = this.GetType().Name.Replace("Controller", "");
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            string fullPath = baseNamespace + ".Views." + controllerName + "." + actionName;
            var viewType = Assembly.GetExecutingAssembly().GetType(fullPath);
            var viewInstase = Activator.CreateInstance(viewType, model) as IView;
            return viewInstase;
        }

        protected void EnsureAuthorization(params Role[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            foreach (var user in Data.Users.GetAll())
            {
                if (!roles.Any(role => this.User.IsInRole(role)))
                {
                    throw new DivideByZeroException(
                        "The current user is not authorized to perform this operation.");
                }
            }
        }
    }
}

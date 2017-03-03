namespace BangaloreUniversity.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Data;
    using Interfaces;
    using Models;
    using Controllers;

    public class Engine : IEngine
    {
        public void Start()
        {
            var dataBase = new DataBase();
            IUser user = null;
            while (true)
            {
                string currentLine = Console.ReadLine();
                if (string.IsNullOrEmpty(currentLine))
                {
                    break;
                }

                var route = new Route(currentLine);
                var controllerType = Assembly
                    .GetExecutingAssembly().GetTypes()
                    .FirstOrDefault(type => type.Name == route.ControllerName);
                var controller = Activator.CreateInstance(controllerType, dataBase, user) as Controller;
                var action = controllerType.GetMethod(route.ActionName);
                object[] parameters = MapParameters(route, action);
                try
                {
                    var view = action.Invoke(controller, parameters) as IView;

                    Console.WriteLine(view.Display());

                    user = controller.User;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private static object[] MapParameters(Route route, MethodInfo action)
        {
            return action.GetParameters()
                .Select<ParameterInfo, object>(p =>
                {
                    if (p.ParameterType == typeof(int))
                    {
                        return int.Parse(route.Parameters[p.Name]);
                    }
                    else
                    {
                        return route.Parameters[p.Name];
                    }
                }).ToArray();
        }
    }
}


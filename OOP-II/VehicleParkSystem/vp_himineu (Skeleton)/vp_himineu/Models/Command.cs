namespace VehicleParkSystem
{
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    using VehicleParkSystem.Interfaces;

    public class Command : ICommand
    {
        public string Name { get; set; }
        public IDictionary<string, string> Parametars { get; set; }

        public Command(string str)
        {
            Name = str.Substring(0, str.IndexOf(' '));
            Parametars = new JavaScriptSerializer()
                .Deserialize<Dictionary<string, string>>
                (str.Substring(str.IndexOf(' ') + 1));
        }
    }
}

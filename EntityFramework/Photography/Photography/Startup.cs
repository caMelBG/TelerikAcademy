namespace Photography
{
    using System;
    using System.Linq;
    class Startup
    {
        static void Main()
        {
            new GenerateRandomEquipment().ParseXML();
        }

        private static void ListAllCameras()
        {
            using (var db = new PhotographyEntities())
            {
                var cameras = db.Cameras.Select(c => new
                {
                    Manufacture = c.Manufacturer.Name,
                    Model = c.Model
                })
                .OrderBy(c => c.Manufacture)
                .ThenBy(c => c.Model)
                .AsEnumerable();
                foreach (var camera in cameras)
                {
                    Console.WriteLine($"{camera.Manufacture} {camera.Model}");
                }
            }
        }
    }
}

namespace Photography
{
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    public class ExportManufacturesAndCamerasAsJSON
    {
        private const string JsonFilePath = "../../manufactureres-and-cameras.json";

        public void Export()
        {
            using (var db = new PhotographyEntities())
            {
                var manufactures = db.Manufacturers
                    .OrderBy(m => m.Name)
                    .Select(m => new
                    {
                        manufacture = m.Name,
                        cameras = m.Cameras
                        .OrderBy(c => c.Model)
                        .Select(c => new
                        {
                            model = c.Model,
                            price = c.Price
                        })
                        .AsEnumerable()
                    })
                    .AsEnumerable();

                var jsonResult = JsonConvert.SerializeObject(manufactures, Formatting.Indented);
                File.WriteAllText(JsonFilePath, jsonResult);
            }
        }
    }
}
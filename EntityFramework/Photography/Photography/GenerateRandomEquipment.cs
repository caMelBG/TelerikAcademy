namespace Photography
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class GenerateRandomEquipment
    {
        private const string XmlFilsPath = "../../generate-equipments.xml";

        public void ParseXML()
        {
            int index = 0;
            var xmldoc = XDocument.Load(XmlFilsPath);
            var elements = xmldoc.Descendants("generate");
            foreach (var element in elements)
            {
                Console.WriteLine("Processing request #{0} ...", ++index);
                int generateCount = 10;
                string manufacturerName = "Nikon";
                var manufacturerNameElement = element.Element("manufacturer");
                if (manufacturerNameElement != null)
                {
                    manufacturerName = manufacturerNameElement.Value;
                }
                
                var generateCountElement = element.Attribute("generate-count");
                if (generateCountElement != null)
                {
                    generateCount = int.Parse(generateCountElement.Value);
                }

                for (int i = 0; i < generateCount; i++)
                {
                    this.AddEquipment(manufacturerName);
                }

                Console.WriteLine();
            }
        }

        private void AddEquipment(string manufacturerName)
        {
            using (var db = new PhotographyEntities())
            {
                var camera = this.GetRandomCamera(db);
                var lens = this.GetRandomLens(db);
                var equipment = new Equipment()
                {
                    Camera = camera,
                    Lens = lens
                };
                db.Equipments.Add(equipment);
                db.SaveChanges();

                Console.WriteLine("Equipment added: {0} (Camera: {1} - Lens: {2})", 
                    manufacturerName, camera.Model, lens.Model);
            }
        }

        private Lens GetRandomLens(PhotographyEntities db)
        {
            Lens lens = null;
            while (lens == null)
            {
                int maxId = db.Lenses.Max(l => l.Id);
                int randId = new Random().Next(maxId);
                lens = db.Lenses.FirstOrDefault(l => l.Id == randId);
            }

            return lens;
        }

        private Camera GetRandomCamera(PhotographyEntities db)
        {
            Camera camera = null;
            while (camera == null)
            {
                int maxId = db.Cameras.Max(c => c.Id);
                int randId = new Random().Next(maxId);
                camera = db.Cameras.FirstOrDefault(c => c.Id == randId);
            }

            return camera;
        }
    }
}

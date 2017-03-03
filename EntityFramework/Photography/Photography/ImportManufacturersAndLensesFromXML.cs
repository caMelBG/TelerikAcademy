using System;
using System.Linq;
using System.Xml.Linq;

namespace Photography
{
    public class ImportManufacturersAndLensesFromXML
    {
        private const string XmlFilePath = "../../manufacturers-and-lenses.xml";

        public void ParseXML()
        {
            int index = 0;
            var xmlDoc = XDocument.Load(XmlFilePath);
            var manufactures = xmlDoc.Descendants("manufacturer");
            foreach (var manufacture in manufactures)
            {
                Console.WriteLine("Processing manufacturer #{0} ...", ++index);
                var manufacturerName = manufacture.Element("manufacturer-name");
                var manufacturer = this.FindManufactureByName(manufacturerName.Value);
                var lenses = manufacture.Descendants("lens");
                foreach (var lens in lenses)
                {
                    var lenModel = lens.Attribute("model");
                    var lensType = lens.Attribute("type");
                    var lensPrice = lens.Attribute("price");
                    this.ImportLensIfNotExists(manufacturer, lenModel, lensType, lensPrice);
                }

                Console.WriteLine();
            }
        }

        private void ImportLensIfNotExists(Manufacturer manufacturer, XAttribute lensModelElement, XAttribute lensTypeElement, XAttribute lenPriceElement)
        {
            using (var db = new PhotographyEntities())
            {
                var lensModel = lensModelElement.Value;
                if (db.Lenses.Any(l => l.Model == lensModel))
                {
                    Console.WriteLine($"Existing lens: {lensModel}");
                }
                else
                {
                    Console.WriteLine($"Created lens: {lensModel}");
                    var lens = new Lens();
                    lens.Manufacturer = manufacturer;
                    lens.Model = lensModel;
                    lens.Type = lensTypeElement.Value;
                    if (lenPriceElement != null)
                    {
                        lens.Price = decimal.Parse(lenPriceElement.Value);
                    }
                    
                    db.Lenses.Add(lens);
                    db.SaveChanges();
                }
            }
        }

        private Manufacturer FindManufactureByName(string name)
        {
            using (var db = new PhotographyEntities())
            {
                var manufacture = db.Manufacturers.FirstOrDefault(m => m.Name == name);
                if (manufacture == null)
                {
                    Console.WriteLine($"Created manufacturer: {name}");
                    manufacture = new Manufacturer()
                    {
                        Name = name
                    };

                    db.Manufacturers.Add(manufacture);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"Existing manufacturer: {name}");
                }

                return manufacture;
            }
        }
    }
}

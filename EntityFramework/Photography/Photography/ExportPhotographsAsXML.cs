namespace Photography
{
    using System.Linq;
    using System.Xml.Linq;

    public class ExportPhotographsAsXML
    {
        private const string XmlFilePath = "../../photographs.xml";

        public void Export()
        {
            using (var db = new PhotographyEntities())
            {
                var photographs = db.Photographs
                    .OrderBy(p => p.Title)
                    .Select(p => new
                    {
                        title = p.Title,
                        category = p.Category.Name,
                        link = p.Link,
                        equipment = new
                        {
                            camera = new
                            {
                                name = p.Equipment.Camera.Manufacturer.Name + p.Equipment.Camera.Model,
                                megapixels = p.Equipment.Camera.Megapixels
                            },
                            lens = new
                            {
                                name = p.Equipment.Lens.Manufacturer.Name + p.Equipment.Lens.Model,
                                price = p.Equipment.Lens.Price
                            }
                        }
                    })
                    .AsEnumerable();

                var xmlDoc = new XElement("photographs");
                foreach (var photo in photographs)
                {
                    var photographElement = new XElement("photograph");
                    var titleAttribute = new XAttribute("title", photo.title);
                    photographElement.Add(titleAttribute);

                    var categoryElement = new XElement("category");
                    categoryElement.Value = photo.category;
                    photographElement.Add(categoryElement);

                    var linkElement = new XElement("link");
                    linkElement.Value = photo.link;
                    photographElement.Add(linkElement);

                    var equipmentElement = new XElement("equipment");
                    var cameraElement = new XElement("camera");
                    var megapixelsAttribute = new XAttribute("megapixels", photo.equipment.camera.megapixels);
                    cameraElement.Value = photo.equipment.camera.name;
                    cameraElement.Add(megapixelsAttribute);

                    var lensElement = new XElement("lens");
                    lensElement.Value = photo.equipment.lens.name;
                    if (photo.equipment.lens.price != null)
                    {
                        var priceAttribute = new XAttribute("price", photo.equipment.lens.price);
                        lensElement.Add(priceAttribute);
                    }

                    equipmentElement.Add(cameraElement, lensElement);
                    photographElement.Add(equipmentElement);
                    xmlDoc.Add(photographElement);
                }


                new XDocument(xmlDoc).Save(XmlFilePath);
            }
        }
    }
}

using System.Xml.Serialization;

namespace Modelo.DTO
{
    //[XmlRoot(ElementName = "partes")]
    public class partesDTO
    {

        public override string ToString()
        {
            
            return "id: " + id + " nombre parte " + nombre + " descripcion " + descripcion;

        }



        //[XmlElement(ElementName = "id")]
        public string id { get; set; }
        //[XmlElement(ElementName = "nombre")]
        public string nombre { get; set; }
        //[XmlElement(ElementName = "descripcion")]
        public string descripcion { get; set; }




    }
}

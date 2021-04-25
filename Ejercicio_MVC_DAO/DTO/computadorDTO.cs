using System.Collections.Generic;
using System.Xml.Serialization;

namespace Modelo.DTO
{
    //[XmlRoot(ElementName = "element")]

    public class computadorDTO
    {
        public override string ToString()

        {
            string _parte = "";
            foreach (var parte in partes)
            {
                _parte += parte;
            }
            return "id: " + id + " nombre Computador " + nombreComputador + " descripcion " + descripcion + " Parte: " + _parte;


        }


        //[XmlElement(ElementName = "id")]
        public string id { get; set; }
        //[XmlElement(ElementName = "nombreComputador")]
        public string nombreComputador { get; set; }
        //[XmlElement(ElementName = "descripcion")]
        public string descripcion { get; set; }
        //[XmlElement(ElementName = "partes")]
        public List<partesDTO> partes;


    }


}



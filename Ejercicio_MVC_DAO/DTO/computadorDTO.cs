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
            return "---------- \n id: " + id + "\n nombre Computador  " + nombreComputador + "\n descripcion " + descripcion + "\n-----compontes: \n Parte: " + _parte;


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



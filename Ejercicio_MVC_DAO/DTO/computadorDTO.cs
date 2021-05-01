using System.Collections.Generic;
using System.Xml.Serialization;

namespace Modelo.DTO
{
    public class computadorDTO
    {
         
        public string id { get; set; }
        public string nombreComputador { get; set; }
        public string descripcion { get; set; }

        public List<partesDTO> partes;

    }


}



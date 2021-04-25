using Modelo.DTO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Modelo.DAO
{
    public partial class DAOjson : DAO
    {
        public List<computadorDTO> leerArchvio()
        {
            string rutaArchivo = @"..\..\ArchivosDatos\Computadores_json.json";
 
            using (StreamReader jsonStream = File.OpenText(rutaArchivo))
            {
                var json = jsonStream.ReadToEnd();
                return JsonConvert.DeserializeObject<List<computadorDTO>>(json);
            }

           
        }

      
    }
}

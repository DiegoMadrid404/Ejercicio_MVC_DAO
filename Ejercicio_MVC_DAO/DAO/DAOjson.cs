using Modelo.DTO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public computadorDTO BuscarPc(string idCompuntador)
        {
            List<computadorDTO> computadores = leerArchvio();
            computadorDTO computador = computadores.Where(n => n.id == idCompuntador).FirstOrDefault();
            return computador;
        }
        public computadorDTO BuscarPcPorNombre(string nombrePc)
        {
            List<computadorDTO> computadores = leerArchvio();
            computadores = computadores.Where(n => (n.nombreComputador).ToLower().Trim().Contains(nombrePc.ToLower().Trim())).ToList();
            computadorDTO computador = computadores.Where(n => n.nombreComputador.Contains(nombrePc)).FirstOrDefault();

            return computador;
        }
        public partesDTO BuscarParte(string idParte)
        {
            List<partesDTO> partes = BuscarTodasLasPartes();
            partesDTO parte = partes.Where(n => n.id == idParte).FirstOrDefault();
            return parte;
        }

        public List<partesDTO> BuscarTodasLasPartes()
        {
            List<computadorDTO> computadores = leerArchvio();
            List<partesDTO> partes = new List<partesDTO>();
            foreach (var pc in computadores)
            {
                partes.AddRange(pc.partes);

            }
            return partes;
        }

        public List<computadorDTO> BuscarPcPorIdParte(string idparte)
        {
            List<computadorDTO> computadores = leerArchvio();
            List<computadorDTO> Computadorpartes = new List<computadorDTO>();
            foreach (var pc in computadores)
            {
                foreach (var parte in pc.partes)
                {
                    if (parte.id == idparte)
                    {
                        Computadorpartes.Add(pc);
                    }

                }
            }
            return Computadorpartes;
        }
    }
}

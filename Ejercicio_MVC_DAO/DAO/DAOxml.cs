using Modelo.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Modelo.DAO
{
    public partial class DAOxml : FABRICADAO
    {
        public computadorDTO BuscarPc(string idCompuntador)
        {
            List<computadorDTO> computadores = leerArchvio();
            computadorDTO computador = computadores.Where(n => n.id == idCompuntador).FirstOrDefault();
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

        public List<computadorDTO> leerArchvio()
        {                         
            string rutaArchivo = @"..\..\ArchivosDatos\Computadores_xml.xml";

            List<computadorDTO> _computadorDTOList = new List<computadorDTO>();
            XmlDocument archivo = new XmlDocument();
            archivo.Load(rutaArchivo);

            XmlNodeList computadores = archivo.GetElementsByTagName("computadores");
            XmlNodeList computador = ((XmlElement)computadores[0]).GetElementsByTagName("computador");
            int cont = 0;
            foreach (XmlElement nodo in computador)
            {
                computadorDTO _computadorDTO = new computadorDTO();

                _computadorDTO.id = nodo.GetAttribute("id");
                _computadorDTO.nombreComputador = nodo.GetAttribute("nombreComputador");
                _computadorDTO.descripcion = nodo.GetAttribute("descripcion");

                List<partesDTO> _partesDTOList = new List<partesDTO>();
                XmlNodeList xListax = ((XmlElement)computador[cont]).GetElementsByTagName("componente");
                foreach (XmlElement nodo2 in xListax)
                 {
                    partesDTO _partesDTO = new partesDTO();

                    _partesDTO.id = nodo2.GetAttribute("id");
                    _partesDTO.nombre = nodo2.GetAttribute("nombre");
                    _partesDTO.descripcion = nodo2.GetAttribute("descripcion");
                    _partesDTOList.Add(_partesDTO);
                }
                _computadorDTO.partes = _partesDTOList;
                _computadorDTOList.Add(_computadorDTO);
                cont++;
            }

            return _computadorDTOList;

        }

        public computadorDTO BuscarPcPorNombre(string nombrePc)
        {
            List<computadorDTO> computadores = leerArchvio();
            computadorDTO computador = computadores.Where(n => ((n.nombreComputador).ToLower().Replace(" ", "")).Equals(nombrePc.ToLower().Replace(" ", ""))).FirstOrDefault();

            return computador;
        }
    }


}

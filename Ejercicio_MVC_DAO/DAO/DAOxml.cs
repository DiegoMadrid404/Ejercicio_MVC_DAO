using Modelo.DTO;
using System.Collections.Generic;
using System.Xml;

namespace Modelo.DAO
{
    public partial class DAOxml : DAO
    {
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
    }


}

using Modelo.DTO;
using System.Collections.Generic;

namespace Modelo.DAO
{
    public interface FABRICADAO
    {
        List<computadorDTO> leerArchvio();
        computadorDTO BuscarPc(string idCompuntador);
        computadorDTO BuscarPcPorNombre(string nombrePc);

        List<partesDTO> BuscarTodasLasPartes();
        partesDTO BuscarParte(string idParte);

        List<computadorDTO> BuscarPcPorIdParte(string idpartePorPc);
    }
}

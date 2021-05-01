using Modelo.DTO;
using System.Collections.Generic;

namespace Modelo.DAO
{
    public interface DAO
    {
        List<computadorDTO> leerArchvio();
        computadorDTO BuscarPc(string idCompuntador);
        computadorDTO BuscarPcPorNombre(string idCompuntador);

        List<partesDTO> BuscarTodasLasPartes();
        partesDTO BuscarParte(string idParte);

        List<computadorDTO> BuscarPcPorIdParte(string idpartePorPc);
    }
}

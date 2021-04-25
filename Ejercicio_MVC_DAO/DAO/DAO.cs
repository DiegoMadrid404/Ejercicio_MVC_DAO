using Modelo.DTO;
using System.Collections.Generic;

namespace Modelo.DAO
{
    public interface DAO
    {
        List<computadorDTO> leerArchvio();
    }
}

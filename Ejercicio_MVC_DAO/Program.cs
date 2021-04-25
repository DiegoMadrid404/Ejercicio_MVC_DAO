using Modelo.DTO;
using System;
using System.Collections.Generic;
namespace Modelo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<computadorDTO> listaComputador = new List<computadorDTO>();

            DAO.DAO dao = null;
            while (true)
            {

                Console.WriteLine("Ingrese tipo de archivo que desar 1.json 2.xml");

                string tipoArchivo = Console.ReadLine();

                switch (tipoArchivo)
                {
                    case "1":
                        Console.WriteLine("ARCHIVO JSON");

                        dao = new DAO.DAOjson();
                        break;
                    case "2":
                        Console.WriteLine("ARCHIVO XML");

                        dao = new DAO.DAOxml();
                        break;
                    default:
                        Console.WriteLine("ingrese un numero valido");
                        break;
                }
                listaComputador = dao.leerArchvio();

                foreach (var pc in listaComputador)
                {
                    Console.WriteLine(pc);
                }

                Console.ReadKey();
            }

         

        }
    }
}

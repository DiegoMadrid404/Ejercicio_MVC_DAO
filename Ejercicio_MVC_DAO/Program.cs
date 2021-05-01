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
            List<partesDTO> listaParte = new List<partesDTO>();

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

                Console.WriteLine("Que accion desea: \n 1. consultar todo \n 2. consultar solo computadores. \n 3. consultar por id un computador \n 4. Consultar todas las partes \n 5. Consultar una parte por id \n 6. Consultar pc por id de una parte");

                string accion = Console.ReadLine();

                switch (accion)
                {
                    case "1":
                        listaComputador = dao.leerArchvio();
                        foreach (var pc in listaComputador)
                        {
                            Console.WriteLine("\n-----COMPUTADOR-----");
                            Console.WriteLine($"id: {pc.id}");
                            Console.WriteLine($"nombre: {pc.nombreComputador}");
                            Console.WriteLine($"descripcion: {pc.descripcion}");
                            Console.WriteLine("-----PARTES-----");
                            foreach (var partes in pc.partes)
                            {
                                Console.WriteLine("----------");
                                Console.WriteLine($"id: {partes.id}");
                                Console.WriteLine($"nombre: {partes.nombre}");
                                Console.WriteLine($"descripcion: {partes.descripcion}");
                            }
                        }
                        break;
                    case "2":
                        listaComputador = dao.leerArchvio();
                        foreach (var pc in listaComputador)
                        {
                            Console.WriteLine("\n-----COMPUTADOR-----");
                            Console.WriteLine($"id: {pc.id}");
                            Console.WriteLine($"nombre: {pc.nombreComputador}");
                            Console.WriteLine($"descripcion: {pc.descripcion}");

                        }
                        break;
                    case "3":

                        Console.WriteLine("ingrese el id  del computador");
                        string idPc = Console.ReadLine();
                        computadorDTO computador = dao.BuscarPc(idPc);
                        Console.WriteLine("\n-----COMPUTADOR-----");
                        Console.WriteLine($"id: {computador.id}");
                        Console.WriteLine($"nombre: {computador.nombreComputador}");
                        Console.WriteLine($"descripcion: {computador.descripcion}");
                        Console.WriteLine("-----PARTES-----");
                        foreach (var partes in computador.partes)
                        {
                            Console.WriteLine("----------");
                            Console.WriteLine($"id: {partes.id}");
                            Console.WriteLine($"nombre: {partes.nombre}");
                            Console.WriteLine($"descripcion: {partes.descripcion}");
                        }
                        Console.WriteLine(computador);
                        break;
                    case "4":


                        listaParte = dao.BuscarTodasLasPartes();
                        foreach (var partes in listaParte)
                        {
                            Console.WriteLine("----------");
                            Console.WriteLine($"id: {partes.id}");
                            Console.WriteLine($"nombre: {partes.nombre}");
                            Console.WriteLine($"descripcion: {partes.descripcion}");
                        }
                        break;
                    case "5":
                        Console.WriteLine("ingrese el id de la parte");
                        string idparte = Console.ReadLine();
                        partesDTO parte = dao.BuscarParte(idparte);

                        Console.WriteLine("----------");
                        Console.WriteLine($"id: {parte.id}");
                        Console.WriteLine($"nombre: {parte.nombre}");
                        Console.WriteLine($"descripcion: {parte.descripcion}");

                        break;

                    case "6":
                        Console.WriteLine("ingrese el id de la parte");
                        string idpartePorPc = Console.ReadLine();
                        listaComputador = dao.BuscarPcPorIdParte(idpartePorPc);
                        foreach (var pc in listaComputador)
                        {
                            Console.WriteLine("\n-----COMPUTADOR-----");
                            Console.WriteLine($"id: {pc.id}");
                            Console.WriteLine($"nombre: {pc.nombreComputador}");
                            Console.WriteLine($"descripcion: {pc.descripcion}");
                            Console.WriteLine("-----PARTES-----");
                            foreach (var partes in pc.partes)
                            {
                                Console.WriteLine("----------");
                                Console.WriteLine($"id: {partes.id}");
                                Console.WriteLine($"nombre: {partes.nombre}");
                                Console.WriteLine($"descripcion: {partes.descripcion}");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("ingrese una acción valida");
                        break;
                }


                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}

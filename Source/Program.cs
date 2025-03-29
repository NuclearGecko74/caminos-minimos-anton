using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CaminosMinimosGrafos.Source.DataStructures;

namespace CaminosMinimosGrafos
{
    class Program
    {
        static void Main(string[] args)
        {
            //WeightedGraph graph = new WeightedGraph();
            //graph.AddVertex("A");
            //graph.AddVertex("B");
            //graph.AddVertex("C");
            //graph.AddVertex("D");
            //graph.AddVertex("E");
            //graph.AddVertex("F");

            //graph.AddUndirectedEdge("A", "B", 2);
            //graph.AddUndirectedEdge("A", "D", 8);
            //graph.AddUndirectedEdge("B", "E", 6);
            //graph.AddUndirectedEdge("B", "D", 5);
            //graph.AddUndirectedEdge("C", "E", 9);
            //graph.AddUndirectedEdge("C", "F", 3);
            //graph.AddUndirectedEdge("D", "E", 3);
            //graph.AddUndirectedEdge("D", "F", 2);
            //graph.AddUndirectedEdge("F", "E", 1);

            //graph.PrintTable("A");

            WeightedGraph graph = new WeightedGraph();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nMenú:");
                Console.WriteLine("1. Agregar vértice");
                Console.WriteLine("2. Agregar arista dirigida");
                Console.WriteLine("3. Agregar arista no dirigida");
                Console.WriteLine("4. Mostrar lista de adyacencia");
                Console.WriteLine("5. Mostrar tabla de distancias desde un vértice");
                Console.WriteLine("6. Mostrar distancia mínima entre dos vértices");
                Console.WriteLine("7. Salir");
                Console.Write("Elija una opción: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Ingrese el nombre del vértice: ");
                        string vertex = Console.ReadLine();
                        if (graph.AddVertex(vertex))
                            Console.WriteLine("Vértice agregado correctamente.");
                        else
                            Console.WriteLine("El vértice ya existe.");
                        break;

                    case "2":
                        Console.Write("Ingrese el vértice de origen: ");
                        string origen = Console.ReadLine();
                        Console.Write("Ingrese el vértice de destino: ");
                        string destino = Console.ReadLine();
                        Console.Write("Ingrese el peso de la arista: ");
                        if (UInt32.TryParse(Console.ReadLine(), out UInt32 peso))
                        {
                            if (graph.AddEdge(origen, destino, peso, true))
                                Console.WriteLine("Arista dirigida agregada correctamente.");
                            else
                                Console.WriteLine("Error al agregar la arista. Verifique que ambos vértices existan.");
                        }
                        else
                        {
                            Console.WriteLine("Peso inválido.");
                        }
                        break;

                    case "3":
                        Console.Write("Ingrese el vértice de origen: ");
                        origen = Console.ReadLine();
                        Console.Write("Ingrese el vértice de destino: ");
                        destino = Console.ReadLine();
                        Console.Write("Ingrese el peso de la arista: ");
                        if (UInt32.TryParse(Console.ReadLine(), out peso))
                        {
                            if (graph.AddUndirectedEdge(origen, destino, peso))
                                Console.WriteLine("Arista no dirigida agregada correctamente.");
                            else
                                Console.WriteLine("Error al agregar la arista. Verifique que ambos vértices existan.");
                        }
                        else
                        {
                            Console.WriteLine("Peso inválido.");
                        }
                        break;

                    case "4":
                        graph.PrintAdjList();
                        break;

                    case "5":
                        Console.Write("Ingrese el vértice fuente: ");
                        string fuente = Console.ReadLine();
                        graph.PrintTable(fuente);
                        break;

                    case "6":
                        Console.Write("Ingrese el vértice de origen: ");
                        origen = Console.ReadLine();
                        Console.Write("Ingrese el vértice de destino: ");
                        destino = Console.ReadLine();
                        graph.PrintDistance(origen, destino);
                        break;

                    case "7":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }
            }
        }
    }
}

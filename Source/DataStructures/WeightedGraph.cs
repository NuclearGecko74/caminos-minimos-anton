using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaminosMinimosGrafos.Source.DataStructures
{
    class WeightedGraph
    {
        // Diccionario que representa la lista de adyacencia:
        // Cada vértice (clave) tiene asociado otro diccionario con sus vecinos y el peso de la arista.
        private Dictionary<string, Dictionary<string, UInt32>> adjList;

        public WeightedGraph()
        {
            adjList = new Dictionary<string, Dictionary<string, UInt32>>();
        }

        public bool AddVertex(string vertex)
        {
            if (!adjList.ContainsKey(vertex))
            {
                adjList[vertex] = new Dictionary<string, UInt32>();
                return true;
            }
            return false;
        }

        public bool AddEdge(string vertex1, string vertex2, UInt32 weight = 0, bool bDirected = true)
        {
            if (adjList.ContainsKey(vertex1) && adjList.ContainsKey(vertex2))
            {
                adjList[vertex1][vertex2] = weight;
                // Si la arista no es dirigida, se agrega la conexión inversa.
                if (!bDirected)
                {
                    adjList[vertex2][vertex1] = weight;
                }
                return true;
            }
            return false;
        }

        // Método auxiliar que crea una arista no dirigida reutilizando AddEdge con el parámetro bDirected en false.
        public bool AddUndirectedEdge(string vertex1, string vertex2, UInt32 weight = 0)
        {
            return AddEdge(vertex1, vertex2, weight, false);
        }

        // Implementación del algoritmo de Dijkstra para calcular distancias mínimas.
        // Retorna un diccionario con cada vértice, su distancia mínima desde la fuente y el vértice previo en el camino.
        private Dictionary<string, (UInt32 distance, string prev)> Dijkstra(string source)
        {
            List<string> visited = new List<string>();
            List<string> unvisited = new List<string>();
            Dictionary<string, (UInt32 distance, string prev)> table = new Dictionary<string, (UInt32, string)>();

            // Se inicializa la tabla con todas las distancias en "infinito" y se marca cada nodo como no visitado.
            foreach (var entry in adjList)
            {
                unvisited.Add(entry.Key);
                table[entry.Key] = (UInt32.MaxValue, null); // UInt32.MaxValue representa "infinito"
            }

            // La distancia del nodo fuente a sí mismo es 0.
            table[source] = (0, null);

            while (unvisited.Count > 0)
            {
                // Se busca el nodo no visitado con la distancia mínima.
                string currentVertex = null;
                UInt32 shortestDistance = UInt32.MaxValue;

                foreach (var vertex in unvisited)
                {
                    if (table[vertex].distance < shortestDistance)
                    {
                        shortestDistance = table[vertex].distance;
                        currentVertex = vertex;
                    }
                }

                // Si no se encuentra un nodo alcanzable, se termina el algoritmo.
                if (currentVertex == null || shortestDistance == UInt32.MaxValue)
                    break;

                // Se actualizan las distancias de los vecinos del nodo actual.
                foreach (var neighbor in adjList[currentVertex])
                {
                    // Se omite el vecino si ya fue visitado.
                    if (visited.Contains(neighbor.Key)) continue;

                    // Se calcula la nueva distancia potencial a través del nodo actual.
                    UInt32 newDist = table[currentVertex].distance + neighbor.Value;

                    // Se actualiza la tabla si se encuentra una ruta más corta.
                    if (newDist < table[neighbor.Key].distance)
                    {
                        table[neighbor.Key] = (newDist, currentVertex);
                    }
                }

                // Se marca el nodo actual como visitado y se elimina de la lista de no visitados.
                visited.Add(currentVertex);
                unvisited.Remove(currentVertex);
            }

            return table;
        }

        public void PrintTable(string source)
        {
            if (!adjList.ContainsKey(source))
            {
                Console.WriteLine("El nodo " + source + " no existe en el grafo.");
                return;
            }

            var table = Dijkstra(source);

            Console.WriteLine("Tabla de distancias desde " + source);
            Console.WriteLine("--------------------------------");

            foreach (var entry in table)
            {
                // Si la distancia es UInt32.MaxValue, se interpreta como "Infinito".
                string distanceText = (entry.Value.distance == UInt32.MaxValue) ? "Infinito" : entry.Value.distance.ToString();
                string prevText = entry.Value.prev == null ? "Ninguno" : entry.Value.prev;

                Console.WriteLine("Nodo: " + entry.Key + " | Distancia: " + distanceText + " | Previo: " + prevText);
            }
        }

        public void PrintDistance(string source, string destination)
        {
            if (!adjList.ContainsKey(source))
            {
                Console.WriteLine("El nodo " + source + " no existe en el grafo.");
                return;
            }

            var table = Dijkstra(source);

            // Se verifica si el destino es alcanzable (distancia distinta de "infinito").
            if (!table.ContainsKey(destination) || table[destination].distance == UInt32.MaxValue)
            {
                Console.WriteLine("No hay ruta desde " + source + " hasta " + destination);
                return;
            }

            Console.WriteLine("La distancia mínima desde " + source + " hasta " + destination + " es: " + table[destination].distance);
        }

        public void PrintAdjList()
        {
            Console.WriteLine("Adjacency List:");
            foreach (var vertex in adjList)
            {
                Console.Write(vertex.Key + " -> { ");
                foreach (var neighbour in vertex.Value)
                {
                    Console.Write("[" + neighbour.Key + ", " + neighbour.Value + "] ");
                }
                Console.WriteLine("}");
            }
        }
    }
}

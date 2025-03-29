# Implementación de Algoritmos de Caminos Mínimos en Grafos con C#

Este proyecto consiste en la implementación en C# de un **grafo dirigido y ponderado** para ilustrar el funcionamiento de algoritmos de **caminos mínimos**, particularmente el **algoritmo de Dijkstra**, que permite encontrar rutas de costo mínimo entre nodos. El programa se ejecuta desde la consola y ofrece un menú para interactuar con el grafo, permitiendo agregar vértices, aristas, y mostrar resultados como la lista de adyacencia y distancias mínimas calculadas.

---

## Descripción General

1. **Estructura de Datos Principal**  
   - Se utiliza un `Dictionary<string, Dictionary<string, uint>>` para representar la **lista de adyacencia**.  
     - La **clave** de primer nivel representa el vértice.  
     - El **diccionario interno** asocia cada vértice adyacente con el peso de la arista que los conecta.

2. **Algoritmo Implementado**  
   - **Dijkstra**: Calcula la distancia mínima desde un vértice fuente a todos los demás en un grafo dirigido y ponderado.  
     - Retorna la distancia acumulada y el vértice previo para cada uno, de manera que se pueda reconstruir el camino mínimo.

3. **Resultados**  
   - Se pueden imprimir:  
     - **Tabla de distancias** desde un vértice fuente (incluye la distancia y el vértice previo).  
     - **Distancia mínima** entre dos vértices específicos.  
     - **Lista de Adyacencia** para verificar la estructura del grafo.

---

## Instrucciones de Uso

1. **Clonar o Descargar el Repositorio**  
   - Clona este repositorio en tu máquina local o descárgalo como archivo ZIP y extrae su contenido.

2. **Abrir en Visual Studio / .NET CLI**  
   - Abre la carpeta del proyecto en Visual Studio, o  
   - Navega a la carpeta raíz del proyecto con la terminal/CLI.

3. **Compilar el Proyecto**  
   - En Visual Studio, presiona `F5` o selecciona *Build* -> *Build Solution*.  
   - Desde la terminal con .NET CLI:  
     ```bash
     dotnet build
     ```

4. **Ejecutar el Programa**  
   - En Visual Studio, presiona `F5` para iniciar el programa.  
   - Con .NET CLI:  
     ```bash
     dotnet run
     ```

5. **Interactuar con el Menú**  
   - El programa mostrará un menú de opciones en consola, por ejemplo:  
     1. Agregar vértice  
     2. Agregar arista dirigida  
     3. Agregar arista no dirigida  
     4. Mostrar lista de adyacencia  
     5. Mostrar tabla de distancias desde un vértice  
     6. Mostrar distancia mínima entre dos vértices  
     7. Salir  

   - Selecciona la opción deseada ingresando el número correspondiente.

---

## Estructura del Código

- **`WeightedGraph.cs`**  
  - Clase que contiene la lógica para manejar el grafo dirigido y ponderado:  
    - **Lista de Adyacencia** (`adjList`).  
    - Métodos para agregar vértices y aristas (`AddVertex`, `AddEdge`, `AddUndirectedEdge`).  
    - **Algoritmo de Dijkstra** para calcular distancias mínimas.  
    - Métodos de impresión: `PrintTable`, `PrintDistance`, `PrintAdjList`.

- **`Program.cs`**  
  - Clase principal que contiene el **menú de interacción** en consola.  
  - Crea una instancia de `WeightedGraph` y llama a los métodos correspondientes según la opción seleccionada por el usuario.

---

## Ejemplo de Ejecución

A continuación, se muestra un ejemplo de cómo podría lucir la interacción con el menú:

```
Menú:
1. Agregar vértice
2. Agregar arista dirigida
3. Agregar arista no dirigida
4. Mostrar lista de adyacencia
5. Mostrar tabla de distancias desde un vértice
6. Mostrar distancia mínima entre dos vértices
7. Salir
Elija una opción: 1

Ingrese el nombre del vértice: A
Vértice agregado correctamente.
```

El usuario puede continuar agregando vértices, aristas y posteriormente visualizar la lista de adyacencia o las distancias calculadas con Dijkstra.

---

## Requisitos y Dependencias

- **Lenguaje**: C#  
- **Framework**: .NET (versión 5.0 o superior recomendada)  
- **IDE**: Visual Studio, Visual Studio Code o cualquier editor compatible con .NET CLI.

---


## Autor

- **Anton Emir Olguin Cabrales**  
- Materia: *Estructuras de Datos*  
- Universidad: *Universidad Autonoma de Guadalajara Campus Tabasco*  

// public class Graph
// {
//     public Dictionary<string, List<Edge>> AdjacencyList { get; set; }

//     public Graph()
//     {
//         AdjacencyList = new Dictionary<string, List<Edge>>();
//     }

//     public void AddEdge(string source, string destination, int weight = 1)
//     {
//         if (!AdjacencyList.ContainsKey(source))
//         {
//             AdjacencyList[source] = new List<Edge>();
//         }

//         AdjacencyList[source].Add(new Edge(destination, weight));
//     }

//     public void Display()
//     {
//         foreach (var node in AdjacencyList)
//         {
//             Console.WriteLine(node.Key + "->");
//             foreach (var edge in node.Value)
//             {
//                 Console.WriteLine($"{edge.Destination}, {edge.Weight}");
//             }
//         }
//     }
// }

// public class Edge
// {
//     public string Destination { get; set; }
//     public int Weight { get; set; }

//     public Edge(string Destination, int Weight)
//     {
//         this.Destination = Destination;
//         this.Weight = Weight;
//     }
// }
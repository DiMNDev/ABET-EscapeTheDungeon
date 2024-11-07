using DungeonGraph;
Console.WriteLine("Hello, World!");

Graph graph = new();

graph.AddEdge("A", "B", 2, DangerLevel.Low, 0);
// graph.AddEdge("B", "A", 2, DangerLevel.Low, 0);
graph.AddEdge("A", "C", 4, DangerLevel.Medium, 0);
// graph.AddEdge("C", "A", 4, DangerLevel.Medium, 0);
graph.AddEdge("B", "D", 1, DangerLevel.Low, 0);
// graph.AddEdge("D", "B", 1, DangerLevel.Low, 0);
graph.AddEdge("C", "D", 2, DangerLevel.High, 3);
// graph.AddEdge("D", "C", 2, DangerLevel.High, 3);
graph.AddEdge("C", "E", 3, DangerLevel.Medium, 0);
// graph.AddEdge("E", "C", 3, DangerLevel.Medium, 0);
graph.AddEdge("D", "F", 5, DangerLevel.Medium, 0);
// graph.AddEdge("F", "D", 5, DangerLevel.Medium, 0);
graph.AddEdge("E", "F", 1, DangerLevel.Low, 0);
// graph.AddEdge("F", "E", 1, DangerLevel.Low, 0);

List<Edge> shortestPath = graph.FindShortestPath("A", "F");
// List<Edge> shortestPath = graph.DijkstrasShortestPath("A", "F");

foreach (var node in shortestPath)
{
    Console.WriteLine(node.Destination);
}
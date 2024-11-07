namespace DungeonGraph;

public class Graph
{
    public static string filePath = "path_weights.txt";

    // List<string> list = new List<string>(File.ReadAllLines(filePath));

    public Dictionary<string, List<Edge>> AdjacencyList;
    public Graph()
    {
        AdjacencyList = new Dictionary<string, List<Edge>>();
    }

    public void AddEdge(string source, string destination, int distance, DangerLevel dangerLevel, int energyCost)
    {
        if (!AdjacencyList.ContainsKey(source))
        {
            AdjacencyList[source] = new List<Edge>();
        }
        Edge newEdge = new Edge(destination, distance, dangerLevel, energyCost);
        AdjacencyList[source].Add(newEdge);
    }
    public List<Edge> FindShortestPath(string start, string destination)
    {
        List<Edge> shortestPath = [];
        return FindShortestPath(start, destination, start, shortestPath);
    }
    public List<Edge> FindShortestPath(string start, string destination, string current, List<Edge> shortestPath)
    {
        if (current == destination)
        {
            return shortestPath;
        }
        if (AdjacencyList[current].Count() > 1)
        {
            for (int i = 0; i < AdjacencyList[current].Count() - 1; i++)
            {
                Edge shorter = AdjacencyList[current].ElementAt(i).Distance > AdjacencyList[current].ElementAt(i + 1).Distance ? AdjacencyList[current].ElementAt(i + 1) : AdjacencyList[current].ElementAt(i);
                shortestPath.Add(shorter);
                continue;
            }
        }
        else
        {
            shortestPath.Add(AdjacencyList[current].ElementAt(0));
        }
        string next = shortestPath.ElementAt(shortestPath.Count() - 1).Destination;
        return FindShortestPath(start, destination, next, shortestPath);
    }

    public List<Edge> DijkstrasShortestPath(string start, string destination)
    {
        // Dictionary to store the shortest path distance to each node
        var distances = AdjacencyList.Keys.ToDictionary(node => node, node => int.MaxValue);
        distances[start] = 0;

        // Dictionary to store the path (previous node) for each node
        var previousNodes = new Dictionary<string, string>();

        // Priority queue to process nodes by shortest distance
        var priorityQueue = new SortedSet<(int Distance, string Node)>();
        priorityQueue.Add((0, start));

        while (priorityQueue.Count > 0)
        {
            var (currentDistance, currentNode) = priorityQueue.Min;
            priorityQueue.Remove(priorityQueue.Min);

            // Stop if we've reached the destination
            if (currentNode == destination)
            {
                break;
            }

            // Process each neighbor of the current node
            foreach (var edge in AdjacencyList[currentNode])
            {
                var neighbor = edge.Destination;
                var newDistance = currentDistance + edge.Distance;

                // If a shorter path to the neighbor is found
                if (newDistance < distances[neighbor])
                {
                    // Update the distance and previous node
                    distances[neighbor] = newDistance;
                    previousNodes[neighbor] = currentNode;

                    // Update the priority queue with the new distance
                    priorityQueue.Remove((distances[neighbor], neighbor)); // Remove old distance
                    priorityQueue.Add((newDistance, neighbor));
                }
            }
        }

        // Reconstruct the path from start to destination
        var path = new List<Edge>();
        var current = destination;

        while (current != start)
        {
            if (!previousNodes.ContainsKey(current))
            {
                Console.WriteLine("No path found.");
                return new List<Edge>();  // No path found
            }

            var previous = previousNodes[current];
            var edge = AdjacencyList[previous].First(e => e.Destination == current);
            path.Add(edge);

            current = previous;
        }

        path.Reverse(); // Reverse the path to get it from start to destination
        return path;
    }

}


public class Edge
{
    public string Destination { get; set; }
    public int Distance { get; set; }
    public DangerLevel Danger { get; set; }
    public int EnergyCost { get; set; }

    public Edge(string destination, int distance, DangerLevel danger, int energyCost)
    {
        Destination = destination;
        Distance = distance;
        Danger = danger;
        EnergyCost = energyCost;
    }

}

public enum DangerLevel
{
    Low,
    Medium,
    High
}
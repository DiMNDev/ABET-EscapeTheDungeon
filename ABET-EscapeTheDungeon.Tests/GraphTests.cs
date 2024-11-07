namespace ABET_EscapeTheDungeon.Tests;
using DungeonGraph;
using FluentAssertions;

public class GraphTests
{
    [Fact]
    public void ShouldAddNewEdgeToTheGraph()
    {
        var graph = new Graph();

        graph.AddEdge("A", "B", 2, DangerLevel.Low, 0);
        graph.AddEdge("A", "C", 4, DangerLevel.Medium, 0);
        graph.AddEdge("B", "D", 1, DangerLevel.Low, 0);
        graph.AddEdge("C", "D", 2, DangerLevel.High, 3);
        graph.AddEdge("C", "E", 3, DangerLevel.Medium, 0);
        graph.AddEdge("D", "F", 5, DangerLevel.Medium, 0);
        graph.AddEdge("E", "F", 1, DangerLevel.Low, 0);


        graph.AdjacencyList["A"].ElementAt(1).Destination.Should().Be("C");

    }
}
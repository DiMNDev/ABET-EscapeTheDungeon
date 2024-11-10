namespace IntoTheMatrix;

public class MatrixGraph
{
    public int[,] Matrix { get; set; }
    public Dictionary<string, int> Coordinate;
    public int numVertices;

    public MatrixGraph(int numVerticies)
    {
        this.numVertices = numVerticies;
        Matrix = new int[numVerticies, numVerticies];

        for (int i = 0; i < numVerticies; i++)
        {
            for (int j = 0; j < numVerticies; j++)
            {
                Matrix[i, j] = 0;
            }
        }
    }

    public void AddEdge(NodeLetter from, NodeLetter to)
    {
        int f = (int)from;
        int t = (int)to;
        if (f >= 0 && f < numVertices && t >= 0 && t < numVertices)
        {
            Matrix[f, t] = 1;
            Matrix[t, f] = 1;
        }
    }

    public void FindShortestPath(NodeLetter from, NodeLetter to)
    {

    }

    public void PrintMatrix()
    {
        for (int i = 0; i < numVertices; i++)
        {
            for (int j = 0; j < numVertices; j++)
            {
                Console.Write(Matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

}

public class MatrixEdge
{
    public int To { get; set; }
    public int From { get; set; }
}

public enum NodeLetter
{
    A,
    B,
    C,
    D,
    E,
    F
}
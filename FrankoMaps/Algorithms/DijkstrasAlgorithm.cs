using System.Collections.Generic;

namespace FrankoMaps.Algorithms
{
    public class DijkstrasAlgorithm
    {
        private readonly int nVertices;
        private readonly double[,] graph;
        private double[] shortestDistances;
        public DijkstrasAlgorithm(double[,] _graph)
        {
            nVertices = _graph.GetLength(0);
            graph = _graph;
        }

        public void DijkstraAlgo(int indexOfStartVertex)
        {
            shortestDistances = new double[nVertices];
            bool[] shortestPathTreeSet = new bool[nVertices];

            for (int i = 0; i < nVertices; i++)
            {
                shortestDistances[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            shortestDistances[indexOfStartVertex] = 0;

            // Find shortest path for all vertices 
            for (int count = 0; count < nVertices - 1; count++)
            {
                double minDistance = int.MaxValue;
                int nearestVertex = -1;

                for (int v = 0; v < nVertices; v++)
                {
                    if (shortestPathTreeSet[v] == false && shortestDistances[v] <= minDistance)
                    {
                        minDistance = shortestDistances[v];
                        nearestVertex = v;
                    }
                }

                shortestPathTreeSet[nearestVertex] = true;

                for (int v = 0; v < nVertices; v++)
                {
                    if (!shortestPathTreeSet[v] && graph[nearestVertex, v] != 0 && minDistance != int.MaxValue
                        && shortestDistances[nearestVertex] + graph[nearestVertex, v] < shortestDistances[v])
                    {
                        shortestDistances[v] = shortestDistances[nearestVertex] + graph[nearestVertex, v];
                    }
                }
            }
        }
    }
}
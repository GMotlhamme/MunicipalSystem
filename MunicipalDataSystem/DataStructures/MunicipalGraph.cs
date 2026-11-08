using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalDataSystem.DataStructures
{
    public class MunicipalGraph
    {
        // Each location stores its directly connected locations.
        private readonly Dictionary<string, List<string>> adjacencyList = new(StringComparer.OrdinalIgnoreCase);

        private readonly List<WeightedConnection> weightedConnections = new();

        // Add a municipal service location.
        public void AddLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("Location is required.");

            location = location.Trim();

            if (!adjacencyList.ContainsKey(location))
                adjacencyList[location] = new List<string>();
        }

        // Connect two locations in both directions.
        public void AddConnection(string locationA, string locationB)
        {
            AddLocation(locationA);
            AddLocation(locationB);

            locationA = locationA.Trim();
            locationB = locationB.Trim();

            if (string.Equals(locationA, locationB, StringComparison.OrdinalIgnoreCase))
                return;

            if (!adjacencyList[locationA].Contains(locationB, StringComparer.OrdinalIgnoreCase))
            {
                adjacencyList[locationA].Add(locationB);
            }

            if (!adjacencyList[locationB].Contains(locationA, StringComparer.OrdinalIgnoreCase))
            {
                adjacencyList[locationB].Add(locationA);
            }
        }

        // Breadth-First Search uses a queue.
        public List<string> BreadthFirstSearch(string startLocation)
        {
            List<string> result = new();

            if (string.IsNullOrWhiteSpace(startLocation) || !adjacencyList.ContainsKey(startLocation.Trim()))
                return result;

            Queue<string> queue = new();
            HashSet<string> visited = new(StringComparer.OrdinalIgnoreCase);

            string start = startLocation.Trim();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                result.Add(current);

                foreach (string neighbour in adjacencyList[current])
                {
                    if (visited.Add(neighbour))
                        queue.Enqueue(neighbour);
                }
            }

            return result;
        }

        // Depth-First Search uses recursion.
        public List<string> DepthFirstSearch(string startLocation)
        {
            List<string> result = new();
            HashSet<string> visited = new(StringComparer.OrdinalIgnoreCase);

            if (string.IsNullOrWhiteSpace(startLocation) || !adjacencyList.ContainsKey(startLocation.Trim()))
                return result;

            TraverseDepthFirst(startLocation.Trim(), visited, result);

            return result;
        }

        private void TraverseDepthFirst(string current, HashSet<string> visited, List<string> result)
        {
            if (!visited.Add(current))
                return;

            result.Add(current);

            foreach (string neighbour in adjacencyList[current])
            {
                TraverseDepthFirst(neighbour, visited, result);
            }
        }

        public List<string> GetLocations()
        {
            return adjacencyList.Keys.OrderBy(x => x).ToList();
        }

        public void AddWeightedConnection(string locationA, string locationB, int weight)
        {
            if (weight <= 0)
                throw new ArgumentException("Weight must be positive.");

            if (string.IsNullOrWhiteSpace(locationA) || string.IsNullOrWhiteSpace(locationB))
                throw new ArgumentException("Both locations are required.");

            locationA = locationA.Trim();
            locationB = locationB.Trim();

            if (string.Equals(locationA, locationB, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("A location cannot connect to itself.");

            // Avoid duplicate undirected connections.
            bool exists = weightedConnections.Any(connection =>
                (string.Equals(connection.LocationA, locationA,
                    StringComparison.OrdinalIgnoreCase) &&
                 string.Equals(connection.LocationB, locationB,
                    StringComparison.OrdinalIgnoreCase)) ||
                (string.Equals(connection.LocationA, locationB,
                    StringComparison.OrdinalIgnoreCase) &&
                 string.Equals(connection.LocationB, locationA,
                    StringComparison.OrdinalIgnoreCase)));

            if (exists)
                throw new InvalidOperationException("This weighted connection already exists.");

            AddConnection(locationA, locationB);

            weightedConnections.Add(new WeightedConnection(locationA, locationB, weight));
        }

        public List<WeightedConnection> GetMinimumSpanningTree()
        {
            List<WeightedConnection> result = new();

            // Each location initially belongs to its own group.
            Dictionary<string, string> parent = new(StringComparer.OrdinalIgnoreCase);

            foreach (string location in adjacencyList.Keys)
                parent[location] = location;

            // Find the representative of a location's group.
            string Find(string location)
            {
                if (!string.Equals(parent[location], location, StringComparison.OrdinalIgnoreCase))
                {
                    parent[location] = Find(parent[location]);
                }

                return parent[location];
            }

            // Join two groups if they are not already connected.
            bool Union(string locationA, string locationB)
            {
                string rootA = Find(locationA);
                string rootB = Find(locationB);

                if (string.Equals(rootA, rootB, StringComparison.OrdinalIgnoreCase))
                    return false;

                parent[rootB] = rootA;
                return true;
            }

            // Process the cheapest connections first.
            foreach (WeightedConnection connection in weightedConnections.OrderBy(c => c.Weight))
            {
                if (Union(connection.LocationA, connection.LocationB))
                {
                    result.Add(connection);
                }
            }

            return result;
        }
    }
}

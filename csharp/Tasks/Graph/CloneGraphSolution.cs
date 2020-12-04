using System.Collections.Generic;

namespace Tasks.Graph
{
    public class Node 
    {
        public int val { get; }
        public IList<Node> neighbors { get; }

        public Node() 
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int val)
        {
            this.val = val;
            neighbors = new List<Node>();
        }

        public Node(int val, IList<Node> neighbors)
        {
            this.val = val;
            this.neighbors = neighbors;
        }
    }
    
    public class CloneGraphSolution
    {
        public Node CloneGraph(Node node) 
        {
            var visited = new Dictionary<int, Node>();

            return FormGraph(node, visited);
        }

        private Node FormGraph(Node node, Dictionary<int, Node> visited)
        {
            if (node == null)
                return null;

            if (visited.TryGetValue(node.val, out var existingNode))
                return existingNode;
            
            var newNode = new Node(node.val);
            
            visited.Add(newNode.val, newNode);

            foreach (var neighbor in node.neighbors)
            {
                newNode.neighbors.Add(FormGraph(neighbor, visited));
            }

            return newNode;
        }
        
        public Node CloneGraph2(Node node) 
        {
            var visited = new Dictionary<int, Node>();
            // visited[node.val] = new Node(node.val);
            
            var stack = new Stack<Node>();
            stack.Push(node);

            while (stack.Count != 0)
            {
                var current = stack.Pop();
                
                var newNode = new Node(current.val);
                visited[newNode.val] = newNode;

                foreach (var neighbor in current.neighbors)
                {
                    if (!visited.ContainsKey(neighbor.val))
                    {
                        visited[neighbor.val] = new Node(neighbor.val);
                        stack.Push(neighbor);
                    }
                    visited[newNode.val].neighbors.Add(visited[neighbor.val]);
                }

            }
            
            return visited[node.val];
        }
    }
}
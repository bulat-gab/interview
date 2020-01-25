import sys
import collections


class Graph:
    def __init__(self, n):
        
        # number of vertices
        self.V = n

        # adjacency list of graph.
        # We store a dictionary where key is a vertex and 
        # value is a set of adjacent vertices
        self._g = {} 
        for i in range(n):
            self._g[i] = set()
        
    def connect(self, src, dst, w):
        self._g[src].add((dst, w))
        self._g[dst].add((src, w))

    def print(self):
        print(self._g)

    def find_all_distances(self, start):
        """
            Builds shortest path from start vertex to all other vertices.
        """
        # array of distances. 
        # Initially all the distances set to -1 and starting vertex is 0.
        distances = [-1] * self.V
        distances[start] = 0

        visited = set()

        queue = collections.deque([start])
        while queue:
            current = queue.popleft()
            for vertex, weight in self._g[current]:
                if vertex not in visited:
                    queue.append(vertex)
                    visited.add(vertex)
                    distances[vertex] = distances[current] + weight
        
        distances.pop(start)
        return distances


graph = Graph(4)
graph.connect(0, 1, 6)
graph.connect(0, 2, 6)
# graph.print()

print(graph.find_all_distances(0))

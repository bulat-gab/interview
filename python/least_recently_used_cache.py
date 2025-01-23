from typing import Any, Optional

# TODO: found bug when over capacity. Need to fix

class Node:
    def __init__(self, key: str, value: Any):
        self.key: str = key
        self.value: Any = value
        self.next: Optional[Node] = None
        self.prev: Optional[Node] = None

class LRUCache:
    def __init__(self, capacity: int = 16):
        if capacity < 4:
            raise ValueError("Capacity must be greater or equal than 4.")
        self._cache: dict[str, Node] = {}
        self.capacity: int = capacity
        self._head: Node = Node("#", 0)
        self._tail: Node = Node("-", 0)
        self._head.next = self._tail
        self._tail.prev = self._head

    def get(self, key: str) -> Any:
        if key not in self._cache:
            return None
        node = self._cache[key]
        self._move_to_head(node)
        return node.value

    def put(self, key: str, value: Any) -> None:
        if key in self._cache:
            node = self._cache[key]
            node.value = value
            self._move_to_head(node)
            return

        # Check if capacity exceeded
        if len(self._cache) >= self.capacity:
            self._remove_last_node()

        # Adding new node
        new_node = Node(key, value)
        if not self._head:  # First node added
            self._head = self._tail = new_node
        else:
            new_node.next = self._head
            self._head.prev = new_node
            self._head = new_node
        
        self._cache[key] = new_node

    def _move_to_head(self, node: Node):
        if node == self._head:
            return
        
        # Disconnect the node from its current position
        if node.prev:
            node.prev.next = node.next
        if node.next:
            node.next.prev = node.prev
        
        # If the node was the tail, update the tail
        if node == self._tail:
            self._tail = node.prev
        
        # Move node to the front
        node.next = self._head
        node.prev = None
        if self._head:
            self._head.prev = node
        self._head = node

    def _remove_last_node(self):
        if not self._tail:
            return
        
        # Remove from cache
        del self._cache[self._tail.key]
        
        # Update tail pointer
        if self._tail.prev:
            self._tail = self._tail.prev
            self._tail.next = None
        else:  # If only one node remains
            self._head = self._tail = None


c = LRUCache(capacity=4)

print(c.get("a")) # None
c.put("a", 1)
print(c.get("a")) # 1

c.put("b", 2)
c.put("c", 3)
c.put("d", 4)
print(c.get("d"))
print(c.get("a")) # 1
c.put("x", 16)
c.put("y", 18)
print(c.get("a")) # None, value ejected

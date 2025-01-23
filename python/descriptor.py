class Circle:
    def __init__(self, radius):
        self._radius = radius

    def get_radius(self):
        return self._radius

    def set_radius(self, value):
        if value <= 0:
            raise ValueError("Radius must be positive")
        self._radius = value

    radius = property(get_radius, set_radius)

c = Circle(5)
print(c.radius)  # 5
c.radius = 10    # Works
print(c.radius)  # 10
# c.radius = -2  # Raises ValueError


## Another Example
print("\nAnother Example\n")

class Typed:
    def __init__(self, name, expected_type):
        self.name = name
        self.expected_type = expected_type

    def __get__(self, instance, owner):
        return instance.__dict__.get(self.name)

    def __set__(self, instance, value):
        if not isinstance(value, self.expected_type):
            raise TypeError(f"Expected {self.expected_type}")
        instance.__dict__[self.name] = value

class Person:
    name = Typed("name", str)
    age = Typed("age", int)
    
    def __str__(self):
        return f"Name: {self.name}; Age: {self.age}"

p = Person()
p.name = "Alice"  # Works
p.age = 30        # Works
print(p)
# p.age = "30"    # Raises TypeError
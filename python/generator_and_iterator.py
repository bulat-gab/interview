import sys
nums_list = [x for x in range(1000000)]  # List comprehension
nums_gen = (x for x in range(1000000))   # Generator

print(f"Iterator. Size in MB: {sys.getsizeof(nums_list) // (1024 * 1024)}")  # Large memory usage
print(f"Generator. Size in bytes: {sys.getsizeof(nums_gen)}")   
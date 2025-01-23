import time


def decorator(func):
    def wrapper(*args, **kwargs):
        start_time = time.time()
        result = func(*args, **kwargs)
        end_time = time.time()
        execution_time = end_time - start_time
        print(f"Function {func.__name__} | Execution time: {execution_time} seconds.")
        return result

    return wrapper

@decorator
def my_function(sleep_time: int) -> str:
    if sleep_time < 0:
        sleep_time = 1
    time.sleep(sleep_time)
    
    return f"Slept for {sleep_time} seconds."

r = my_function(2)
print(r)
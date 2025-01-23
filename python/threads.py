import threading

counter = 0

def increment():
    global counter
    for _ in range(100000):
        counter += 1

threads = [threading.Thread(target=increment) for _ in range(100)]
for thread in threads:
    thread.start()
for thread in threads:
    thread.join()

print(counter)  # 1 million


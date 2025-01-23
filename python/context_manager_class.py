import time

class MyTimerContextManager(object):
    def __enter__(self):
        print(f"Entering {self.__class__.__name__}.")
        self.start_time = time.time()
        return self
    
    def __exit__(self, exception_type, exception_value, exception_traceback):
        print(f"Exiting {self.__class__.__name__}.")
        self.end_time = time.time()
    
    def __float__(self):
        return self.end_time - self.start_time


with MyTimerContextManager() as t1:
    time.sleep(2)

print(f"Time: {t1}")
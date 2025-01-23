try:
    raise ValueError("first")
except Exception as e:
    print(e)
    raise ValueError("second")
finally:
    print("finally")


print("After exception")
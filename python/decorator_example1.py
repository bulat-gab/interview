def hello(func):                                                                                            
    def inner():                                                                                            
        print("Hello ")                                                                                     
        func()                                                                                              
    return inner                                                                                            
                                                                                                            
def name():                                                                                                 
    print("Alice")
    
obj = hello(name)
obj()
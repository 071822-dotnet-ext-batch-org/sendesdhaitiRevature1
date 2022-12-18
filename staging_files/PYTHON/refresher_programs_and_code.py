import math
import time
def logFunc(number, count):
    """this is a logarithmic function"""
    
    count = count + 1
    print("starting with ", number, count)
    
    if(number == 0):
        return "DONE"
    else:
        number = math.floor(number/2)
        """
        time.sleep(.05)
        print("| ")
        time.sleep(.05)
        print("/ ")
        time.sleep(.05)
        print("- ")
        time.sleep(.05)
        print("\ ")
        """
        return logFunc(number, count)

    
"""logFunc(5)"""
print(logFunc(5788 , 0))
strings = ['hello', "world", "this", "is", "my",
           "list", 'hello', "world", "this", "is", "my", "list"]
stringtofind = "my"
count = 0;
def logthroughListFunc(strings,stringtofind, count):
    """A log function to search through a list of strings"""
    print("Round ", count, " has ", len(strings), " left to find ", stringtofind)
    if(len(strings) == 1):
        return strings[0]
    else:
        count = count+ 1
        midpoint =  math.floor(len(strings)/2)
        print(math.floor(midpoint), "the midpoint")
        halfedlistleft = strings[0:midpoint]
        halfedlistright = strings[midpoint:]

        if( stringtofind in  halfedlistleft):
            return logthroughListFunc(halfedlistleft, stringtofind, count)
        else:
            return logthroughListFunc(halfedlistright, stringtofind, count)
        
print(logthroughListFunc(strings,stringtofind, count))

print(reversed(stringtofind))

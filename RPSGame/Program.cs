// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World! Welcome to the 'ROCK, PAPER, SCISSORS' Game!");
//Console.WriteLine("My Age:", 24);
//string cannot start with int but can contain them
//string exString = "This is the String data";
int exInt = 1;
//Console.WriteLine(exInt.GetType());
int myInt1 = 1 + 2;
long myLong = 12345678911;
Console.WriteLine($"The Value is => {myInt1*myLong%1000}");
int a, b, c;
a = 1;
b = 2;
c = 3;



/**Flow Control */
//THIS IS LIKE AN IF STATEMENT
int x, y, z;
x = 11;
y =2;
z=3;

if(y >x)//If True
{
    Console.WriteLine($"y is greater than x");
}
else if(y > z){
    Console.WriteLine($"y is greater than z");

}
else if(z > x){
    Console.WriteLine($"z is greater than x");
}
else if(z > y){
    Console.WriteLine($"z is greater than y");
}
else if(x > y){
    Console.WriteLine($"x is greater than y");
}
else if(x > z){
    Console.WriteLine($"x is greater than z");
}
else{//Otherwise do this
    Console.WriteLine($"Else For what though?");
}

c = a >= 100 ? b:c /10; //this is a ternary/ Also a shorthand for if statement
a = (int)Math.Sqrt(b * c + c * c);
string s = "String Literal";
char l = s[s.Length - 1];

var numbers = new List<int>(new[] {1, 2, 3});
 //Arrays
 char[] myCharArr = new char[]{'1'/** Element 0*/, 'S'/** Element 1*/, 'Q'/** Element 2*/, 'T'/** Element 3*/};
Console.WriteLine($"Element 1 value is ==> {myCharArr[1]}, While Elements 0 & 3 are ==> {myCharArr[0]} and {myCharArr[3]}");

//If you Get Tracebacks or Exception Errors
//You can load the error could in a try catch block
try{
    Console.WriteLine($"Last Element value is ==> {myCharArr[5]}");
}
catch(IndexOutOfRangeException msg){//The msg obj is declared to represent the Exception message
    Console.WriteLine($"Last Element Threw an Error stating: '{msg.Message}'");

}
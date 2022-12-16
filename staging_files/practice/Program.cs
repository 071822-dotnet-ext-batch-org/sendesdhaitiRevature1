// See https://aka.ms/new-console-template for more information
// using System;
Console.WriteLine("Hello, World!");

//average of a list of numbers
int[] numbers = new int[5]{
    1,4,5,6,7
};

int result = 0;
Array.Sort(numbers);
foreach(int num in numbers)
{
    result = result + num;
}

// return result;
Console.WriteLine( (float )result/numbers.Count());

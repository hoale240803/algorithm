using algorithm.MathAndGeography;


PlusOneClass plusOneClass = new PlusOneClass();
var res = plusOneClass.PlusOne(new int[] { 1, 2, 3 });
// print the result
Console.WriteLine(string.Join(", ", res));

var res1 = plusOneClass.PlusOne(new int[] { 9, 9, 9 });
// print the result
Console.WriteLine(string.Join(", ", res1));

using algorithm.ArrayAndHashing;

PlusOneClass plusOne = new PlusOneClass();

var res = plusOne.PlusOne(new int[] { 1, 2, 3 });
Console.WriteLine(string.Join(", ", res));

var res2 = plusOne.PlusOne(new int[] { 9 });
Console.WriteLine(string.Join(", ", res2));

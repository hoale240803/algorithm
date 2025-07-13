using algorithm.MathAndGeography;


CountSquares countSquares = new CountSquares();
countSquares.Add([1, 1]);
countSquares.Add([2, 2]);
countSquares.Add([1, 2]);

System.Console.WriteLine(countSquares.Count([2, 1]));   // return 1.
System.Console.WriteLine(countSquares.Count([3, 3]));
countSquares.Add([2, 2]);     // Duplicate points are allowed.
System.Console.WriteLine(countSquares.Count([2, 1]));

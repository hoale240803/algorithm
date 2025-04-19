using Algorithm.ArrayAndHashing;
using Algorithm.Stack;
using Algorithm.TwoPointers;

CarFleetStack carFleet = new CarFleetStack();

int[] position = new int[] { 10, 8, 0, 5, 3 };
int[] speed = new int[] { 2, 4, 1, 1, 3 };
int target = 12;

// 1 1 12 7 3


// output: 3
Console.WriteLine(carFleet.CarFleet(target, position, speed));  


int[] position2 = new int[] { 1, 2, 3, 4, 5, 6 };
int[] speed2 = new int[] { 1, 1, 1, 1, 1, 1 };
int target2 = 10;

// 9 8 7 6 5 4
// output: 6
Console.WriteLine(carFleet.CarFleet(target2, position2, speed2));


int[] position3 = new int[] { 4, 1, 0, 7 };
int[] speed3 = new int[] { 2, 2, 1, 1 };
int target3 = 10;

// output: 3
Console.WriteLine(carFleet.CarFleet(target3, position3, speed3));










namespace Algorithm.Stack;

public class CarFleetStack
{
    // public int CarFleet(int target, int[] position, int[] speed)
    // {

    //     // There are n cars traveling to the same destination on a one-lane highway.

    //     // You are given two arrays of integers position and speed, both of length n.

    //     // position[i] is the position of the ith car (in miles)
    //     // speed[i] is the speed of the ith car (in miles per hour)
    //     // The destination is at position target miles.

    //     // A car can not pass another car ahead of it. It can only catch up to another car and then drive at the same speed as the car ahead of it.
    //     // A car fleet is a non-empty set of cars driving at the same position and same speed. A single car is also considered a car fleet.
    //     // If a car catches up to a car fleet the moment the fleet reaches the destination, then the car is considered to be part of the fleet.
    //     // Return the number of different car fleets that will arrive at the destination.


    //     // Input: target = 10, position = [1,4], speed = [3,2]
    //     // Output: 1

    //     // apply greedy algorithm
    //     // sort the cars by position
    //     // calculate the time it takes for each car to reach the destination
    //     // if the time it takes for a car to reach the destination is less than the time it takes for the next car to reach the destination, then the car is part of the fleet

    //     int[][] pairs = new int[position.Length][];
    //     for (int i = 0; i < position.Length; i++)
    //     {
    //         pairs[i] = new int[] { position[i], speed[i] };
    //     }

    //     Array.Sort(pairs, (a, b) => b[0].CompareTo(a[0]));   
    
    //     Stack<double> stack = new Stack<double>();

    //     for (int i = 0; i < pairs.Length; i++)
    //     {
    //         stack.Push((double)(target - pairs[i][0]) / pairs[i][1]);
    //         if (stack.Count >= 2 && stack.Peek() <= stack.ElementAt(1))
    //         {
    //             stack.Pop();
    //         }
    //     }   

    //     return stack.Count;
    // }

    public int CarFleet(int target, int[] position, int[] speed) {
        int n = position.Length;
        if (n == 0) return 0;
        
        // Create and sort cars by position in descending order
        int[] indices = Enumerable.Range(0, n).ToArray();
        Array.Sort(indices, (a, b) => position[b].CompareTo(position[a]));
        
        int fleets = 0;
        double prevTime = -1;
        
        foreach (int i in indices) {
            double time = (double)(target - position[i]) / speed[i];
            if (time > prevTime) {
                fleets++;
                prevTime = time;
            }
        }
        
        return fleets;
    }
}

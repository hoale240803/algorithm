namespace Algorithm.BinarySeach;



public class SearchA2DMatrix
{
    public bool SearchMatrix(int[][] matrix, int target)
    {

        // You are given an m x n 2-D integer array matrix and an integer target.
        // Each row in matrix is sorted in non-decreasing order.
        // The first integer of every row is greater than the last integer of the previous row.
        // Return true if target exists within matrix or false otherwise.

        // Can you write a solution that runs in O(log(m * n)) time?

        // input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
        // output: true


        // apply binary search
        // find the row containing the target
        // literate that row and find the target

        // find the row containing the target 
        // ex: 3x3 matrix
        // 1 2 3
        // 4 5 6
        // 7 8 9
        // target = 5
        // row = 1
        // col = 1

        int row = 0;
        int col = matrix[0].Length - 1;

        while (row < matrix.Length && col >= 0)
        {
            if (matrix[row][col] == target)
            {
                return true;
            }
            else if (matrix[row][col] < target)
            {
                row++;
            }
            else
            {
                col--;
            }
        }
        return false;
    }
}

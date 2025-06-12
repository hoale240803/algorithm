namespace algorithm.Greedy;

public class GasStation
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        if (gas.Sum() < cost.Sum())
        {
            return -1;
        }

        int total = 0;
        int res = 0;

        for (int i = 0; i < gas.Length; i++)
        {
            total += (gas[i] - cost[i]);

            if (total < 0)
            {
                total = 0;
                res = i + 1;
            }
        }

        return res;
    }
}
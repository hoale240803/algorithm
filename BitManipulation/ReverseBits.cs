namespace algorithm.BitManipulation;

public class ReverseBitsClass
{
    public uint ReverseBits(uint n)
    {
        uint res = 0;
        for (int i = 0; i < 32; i++)
        {
            uint bit = (n >> i) & 1;
            res += (bit << (31 - i));
        }

        return res;
    }

    public uint Reversebits1(uint n)
    {
        uint ret = n;
        ret = (ret >> 16) | (ret << 16);
        ret = ((ret & 0xff00ff00) >> 8) | ((ret & 0x00ff00ff) << 8);
        ret = ((ret & 0xff00ff00) >> 4) | ((ret & 0x00ff00ff) << 4);
        ret = ((ret & 0xcccccccc) >> 2) | ((ret & 0x33333333) << 2);
        ret = ((ret & 0xaaaaaaaa) >> 1) | ((ret & 0x55555555) << 1);

        return ret;
    }
}
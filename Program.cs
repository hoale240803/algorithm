
using System.Text.RegularExpressions;
using algorithm.ArrayAndHashing;

GroupAnagram groupAnagram = new GroupAnagram();
string[] strs = { "act", "pots", "tops", "cat", "stop", "hat" };
List<List<string>> result = groupAnagram.GroupAnagrams(strs);
foreach (var group in result)
{
    foreach (var word in group)
    {
        Console.Write(word + " ");
    }
}
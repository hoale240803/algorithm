
using algorithm.Tries;

WordSearch wordSearchII = new WordSearch();

string[] words = { "bat", "cat", "back", "backend", "stack" };
char[][] board = new char[][]
{
  ['a','b','c','d'],
  ['s','a','a','t'],
  ['a','c','k','e'],
  ['a','c','d','n']
};

List<string> result = wordSearchII.FindWords(board, words);
wordSearchII.PrintResult(result);
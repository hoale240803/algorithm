
using algorithm.Backtracking;

LetterCombinationsOfAPhoneNumber letterCombinationsOfAPhoneNumber = new LetterCombinationsOfAPhoneNumber();
var res = letterCombinationsOfAPhoneNumber.LetterCombinations("23");
var res1 = letterCombinationsOfAPhoneNumber.LetterCombinations1("23");

foreach (var item in res1)
{
    Console.WriteLine(item);
}


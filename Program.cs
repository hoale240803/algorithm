
WordDictionary wordDictionary = new WordDictionary();
wordDictionary.AddWord("day");
wordDictionary.AddWord("bay");
wordDictionary.AddWord("may");
Console.WriteLine(wordDictionary.Search("say")); // false
Console.WriteLine(wordDictionary.Search("dat")); // false
Console.WriteLine(wordDictionary.Search("day")); // True
Console.WriteLine(wordDictionary.Search(".ay")); // True
Console.WriteLine(wordDictionary.Search("b..")); // True




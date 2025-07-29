using algorithm.Graph;


WordLadder wordLadder = new WordLadder();


// print the result
Console.WriteLine("Word Ladder Length: " + wordLadder.LadderLength("cat", "sag", new List<string> { "bat", "bag", "sag", "dag", "dot" }));

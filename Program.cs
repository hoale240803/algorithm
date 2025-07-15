using algorithm.Graph;

CloneGraphClass cloneGraph = new CloneGraphClass();
Node originalGraph = new Node(1);
Node neighbor1 = new Node(2);
Node neighbor2 = new Node(3);
originalGraph.neighbors.Add(neighbor1);
originalGraph.neighbors.Add(neighbor2);

// print before cloning ex: [[2,3],[1],[1]]
var nodeBeforeStr = originalGraph.ToString();
Console.WriteLine($"Original graph: {nodeBeforeStr}");

// print after cloning ex: [[2],[1,3],[2]]
var nodeAfterStr = cloneGraph.CloneGraph(originalGraph);
Console.WriteLine($"Cloned graph: {nodeAfterStr}");






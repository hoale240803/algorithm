using algorithm.DP;

List<List<string>> tickets = [["HOU", "JFK"], ["SEA", "JFK"], ["JFK", "SEA"], ["JFK", "HOU"]];
ReconstructionFlightPath reconstructionFlightPath = new ReconstructionFlightPath();
var res = reconstructionFlightPath.FindItinerary(tickets);

List<List<string>> tickets2 = [["BUF", "HOU"], ["HOU", "SEA"], ["JFK", "BUF"]];
var res2 = reconstructionFlightPath.FindItinerary2(tickets2);


List<List<string>> tickets3 = [["JFK", "SFO"], ["JFK", "ATL"], ["SFO", "ATL"], ["ATL", "JFK"], ["ATL", "SFO"]];
var res3 = reconstructionFlightPath.FindItinerary3(tickets3);


Console.WriteLine(reconstructionFlightPath.ToString(res));
Console.WriteLine(reconstructionFlightPath.ToString(res2));
Console.WriteLine(reconstructionFlightPath.ToString(res3));







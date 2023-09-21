//Program.cs
//Voting Contest
//Given a string of votes and find the winner based on highest number of votes
//Sample Input : aaABBcd Sample Output : a or A
using static System.Console;

///<summary>VOTING CONTEST</summary>

Write ("Enter the Vote String : ");
string vote = ReadLine ().ToLower ().Replace (" ", "");
if (vote != null && vote.Length > 0 && vote.All (char.IsLetter)) {
   var winner = GetWinner (vote);
   WriteLine ($"The winner is {winner.Letter} with {winner.Lettercount} votes");
} else Write ("Enter Valid Input");

///<summary>GetWinner : Returns the winner having highest number of votes</summary>
///<summary>If 2 contestant have same number of votes, First contestant who got vote is winner</summary>
///<param name="vote">String of votes</param>
///<return>Returns a tuple (multiple return Values) containg the highest occuring character and the number of occurences</return>

(char Letter, int Lettercount) GetWinner (string vote) {
   var result = vote.GroupBy (x => x)
                    .Select (x => new { letter = x.First (), lettercount = x.Count () })
                    .OrderByDescending (x => x.lettercount)
                    .FirstOrDefault ();
   return (result.letter, result.lettercount);
}


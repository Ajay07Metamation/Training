using static System.Console;

Write ("Enter the Vote String : ");
string vote = ReadLine ().ToLower().Replace(" ","");
if (vote != null && vote.Length > 0 && vote.All (char.IsLetter)) {
   var winner = GetWinner (vote);
   WriteLine ($"The winner is {winner.Letter} with {winner.Lettercount} votes");
} else Write ("Enter Valid Input");

(char Letter,int Lettercount) GetWinner (string vote) {
   var result = vote.GroupBy (x => x)
                    .Select (x => new { letter = x.First (), lettercount = x.Count () })
                    .OrderByDescending (x => x.lettercount)
                    .FirstOrDefault ();
   return (result.letter, result.lettercount);
}


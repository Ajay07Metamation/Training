//Digital root
Console.Write ("Enter a Number : ");
int.TryParse (Console.ReadLine (), out int num);
while ((num.ToString ().Length) != 1) {
   var elem = num.ToString ().ToCharArray ();
   num = 0;
   foreach (char ch in elem) {
      num += int.Parse (ch.ToString ());
   }
   Array.Clear (elem, 0, elem.Length);
}
Console.WriteLine ($"Digital root : {num}");
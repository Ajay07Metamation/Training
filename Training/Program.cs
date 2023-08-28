//Digital root
Console.Write ("Enter a Number : ");
int.TryParse (Console.ReadLine (), out int num);
while (num.ToString().Length!= 1) {
   var digroot = num;
   num = 0;
   foreach (var ch in digroot.ToString())
      num += int.Parse(ch.ToString());
}Console.WriteLine ($"Digital root : {num}");
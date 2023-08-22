string words = File.ReadAllText ("D:\\OneDrive - Trumpf Metamation Pvt Ltd\\Desktop\\ASSIGNMENTS\\words.txt");
Dictionary<char, int> freq = new ();
for (char ch = 'A'; ch <= 'Z'; ch++) freq[ch] = 0;
foreach (var ch in words) {
   if (ch is >= 'A' and <= 'Z')
      freq[ch] = freq[ch] + 1;
}
foreach (var item in freq.OrderByDescending (a => a.Value).Take (7)) {
   Console.WriteLine (item);
}

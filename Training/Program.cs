using static System.Console;

var integralList = new List<int> ();
var fractionalList = new List<int> ();
Write ("Enter a Number : ");
string decimalNum = ReadLine () ?? "";
if (decimal.TryParse (decimalNum, out decimal Num)) {
   string[] decimalArr = decimalNum.Split ('.');
   Write ("The Integral part is : ");
   PrintIntListFromInt (decimalArr);
   if (decimalNum.Contains (".")) {
      Write ("The Fractional part is : ");
      PrinttFracListFromFrac (decimalArr);
   } else WriteLine ("No Fractional Part");
} else WriteLine ("Enter Valid Number");

void PrintIntListFromInt (string[] decimalArr) {
   int.TryParse (decimalArr[0], out int integralNum);
   if (integralNum == 0) foreach (var ch in decimalArr[0]) Write (ch + " ");
   while (integralNum != 0) {
      integralList.Add (integralNum % 10);
      integralNum /= 10;
   }
   integralList.Reverse ();
   integralList.ForEach (x => Write (Math.Abs (x) + " "));
   WriteLine ();
}

void PrinttFracListFromFrac (string[] decimalArr) {
   int.TryParse (decimalArr[1], out int fractionalNum);
   int fracLength = fractionalNum.ToString ().Length;
   if (fractionalNum == 0) {
      for (int i = 0; i < decimalArr[1].Length; i++) fractionalList.Add (0);
      fractionalList.ForEach (x => Write (x + " "));
      return;
   }
   while (fractionalNum != 0) {
      fractionalList.Add (fractionalNum % 10);
      fractionalNum /= 10;
   }
   if (decimalArr[1].Length > fracLength) for (int i = 0; i < decimalArr[1].Length - fracLength; i++) fractionalList.Add (0);
   fractionalList.Reverse ();
   fractionalList.ForEach (x => Write (x + " "));
}

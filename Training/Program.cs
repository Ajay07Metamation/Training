﻿//Program to Interchange 2 Indexes of a number
using static System.Console;
double num = new Random ().Next (10, 10000000);
WriteLine ($"The Original Number is : {num}");
GetInterchanged (num);
void GetInterchanged (double num) {
   int numLength = num.ToString ().Length;
   WriteLine ($"Enter 2 Indexes to be Interchanged within 0 to {numLength - 1}");
   if (!int.TryParse (ReadLine (), out int index1) || !(index1 >= 0 && index1 < numLength) ||
       !int.TryParse (ReadLine (), out int index2) || !(index2 >= 0 && index2 < numLength))
      WriteLine ($"Enter Valid Index between 0 and {numLength}");
   else {
      var numword = num.ToString ().ToArray ();
      (numword[index1], numword[index2]) = (numword[index2], numword[index1]);
      WriteLine ($"The Interchanged Number is : {string.Join ("", numword)}");
   }
}
// Test cases for wordle game

using Training;

namespace TestWordle {
   [TestClass]
   public class TestWordle {

      // Tests the backspace key input
      [TestMethod]
      public void TestBackspace () =>
         TestFiles (new string[] { "AFTER" }, ConsoleKey.Backspace, "Refdata/ReferenceBackspace.txt");

      // Tests the game at a random point
      [TestMethod]
      public void TestRandom () =>
         TestFiles (new string[] { "AFTER", "ABOVE", "ABO" }, ConsoleKey.Enter, "Refdata/ReferenceRandom.txt");

      // Tests the game by giving a invalid word
      [TestMethod]
      public void TestWrongWord () =>
         TestFiles (new string[] { "AFTER", "ABSDF" }, ConsoleKey.Enter, "Refdata/ReferenceWrongWord.txt");

      // Tests the game by giving the correct word
      [TestMethod]
      public void Testsucceeded () =>
         TestFiles (new string[] { "AFTER", "ABOUT", "APPLE" }, ConsoleKey.Enter, "Refdata/ReferenceSucceeded.txt");

      /// <summary>Run the game and tests different key inputs</summary>
      /// <param name="input">Input words to the game</param>
      /// <param name="key">Key to be entered after entering each word</param>
      /// <param name="refFile">Reference file for different game states</param>
      public void TestFiles (string[] input, ConsoleKey key, string refFile) {
         var testFile = "C:/etc/TestFile.txt";
         var writer = new StreamWriter (testFile);
         Wordle mGame = new Wordle (writer);
         using (writer) {
            mGame.SecretWord = "APPLE";
            mGame.IsTesting = true;
            foreach (var word in input) {
               foreach (var ch in word)
                  mGame.UpdateGameState ((ConsoleKey)ch);
               mGame.UpdateGameState (key);
            }
            mGame.DisplayBoard ();
            if (mGame.GameOver) mGame.PrintResult ();
         }
         Assert.IsTrue (CheckTextFilesEqual (refFile, testFile));

         // Returns true if the files match else shows the difference in winMerge 
         bool CheckTextFilesEqual (string f1, string f2) {
            var file1 = File.ReadAllText (f1);
            var file2 = File.ReadAllText (f2);
            if (file1.Equals (file2)) return true;
            var p = System.Diagnostics.Process.Start ("C:/Program Files/WinMerge/WinMergeU.exe", $"\"{f1}\" \"{f2}\"");
            p.WaitForExit ();
            return false;
         }
      }
   }
}
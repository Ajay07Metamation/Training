// Test cases for wordle game

using Training;

namespace TestWordle {
   [TestClass]
   public class TestWordle {

      // Test the backspace key input
      [TestMethod]
      public void TestBackspace () =>
         TestFiles (new string[] { "AFTER" }, ConsoleKey.Backspace, "Refdata/ReferenceBackspace.txt");

      // Test the game at a random point
      [TestMethod]
      public void TestRandom () =>
         TestFiles (new string[] { "AFTER", "ABOVE", "ABO" }, ConsoleKey.Enter, "Refdata/ReferenceRandom.txt");

      // Test the game by giving a invalid wordt
      [TestMethod]
      public void TestWrongWord () =>
         TestFiles (new string[] { "AFTER", "ABSDF" }, ConsoleKey.Enter, "Refdata/ReferenceWrongWord.txt");

      // Test the game by giving the correct word
      [TestMethod]
      public void Testsucceeded () =>
         TestFiles (new string[] { "AFTER", "ABOUT", "APPLE" }, ConsoleKey.Enter, "Refdata/ReferenceSucceeded.txt");

      /// <summary>Run the game and tests different key inputs</summary>
      /// <param name="mInput">Input words to the game</param>
      /// <param name="Key">Key to be entered after entering each word</param>
      /// <param name="mRefFile">Reference file for different game states</param>
      public void TestFiles (string[] mInput, ConsoleKey Key, string mRefFile) {
         var mTestFile = "C:/etc/TestFile.txt";
         var writer = new StreamWriter (mTestFile);
         Wordle mGame = new Wordle (writer);
         mGame.SelectWord ();
         mGame.SecretWord = "APPLE";
         mGame.IsTesting = true;
         foreach (var word in mInput) {
            foreach (var ch in word)
               mGame.UpdateGameState ((ConsoleKey)ch);
            mGame.UpdateGameState (Key);
         }
         mGame.DisplayBoard ();
         if (mGame.GameOver) mGame.PrintResult ();
         writer.Close ();
         Assert.IsTrue (mGame.CheckTextFilesEqual (mRefFile, mTestFile));
      }
   }
}
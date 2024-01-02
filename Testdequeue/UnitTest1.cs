using Training;
namespace Testdequeue {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void Enqueue () {
         for (int i = 1; i <= 5; i++) myDQueue.FEnqueue (i);
         Assert.AreEqual (5, myDQueue.Count);
         Assert.AreEqual (8, myDQueue.Capacity);
         for (int i = 6; i <= 9; i++) myDQueue.FEnqueue (i);
         Assert.AreEqual (9, myDQueue.Count);
         Assert.AreEqual (16, myDQueue.Capacity);
      }

      [TestMethod]
      public void Dequeue () {
         Assert.ThrowsException<InvalidOperationException> (() => myDQueue.FDequeue ());
         Assert.ThrowsException<InvalidOperationException> (() => myDQueue.RDequeue ());
         for (int i = 1; i <= 4; i++) myDQueue.FEnqueue (i);
         Assert.AreEqual (4, myDQueue.FDequeue ());
         Assert.AreEqual (3, myDQueue.FDequeue ());
         Assert.AreEqual (1, myDQueue.RDequeue ());
         Assert.AreEqual (1, myDQueue.Count);
         for (int i = 5; i <= 9; i++) myDQueue.REnqueue (i);
         myDQueue.FEnqueue (10);
         Assert.AreEqual (10, myDQueue.FDequeue ());
         for (int i = 1; i <= 3; i++) {
            myDQueue.FDequeue ();
            myDQueue.RDequeue ();
         }
         myDQueue.FEnqueue (10);
         myDQueue.RDequeue ();
      }


      [TestMethod]
      public void Peek () {
         Assert.ThrowsException<InvalidOperationException> (() => myDQueue.FPeek ());
         Assert.ThrowsException<InvalidOperationException> (() => myDQueue.RPeek ());
         for (int i = 1; i <= 4; i++) myDQueue.FEnqueue (i);
         Assert.AreEqual (4, myDQueue.FPeek ());
         Assert.AreEqual (1, myDQueue.RPeek ());
         myDQueue.REnqueue (5);
         myDQueue.REnqueue (6);
         Assert.AreEqual (4, myDQueue.FPeek ());
         Assert.AreEqual (6, myDQueue.RPeek ());
      }
      MyDeQueue<int> myDQueue = new ();
   }
}
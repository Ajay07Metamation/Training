using Training;
namespace Testdequeue {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void Enqueue () {
         MyDeQueue<int> myDQueue = new MyDeQueue<int> ();
         myDQueue.FEnqueue (1);
         myDQueue.FEnqueue (2);
         myDQueue.FEnqueue (3);
         myDQueue.FEnqueue (4);
         Assert.AreEqual (4, myDQueue.Count);
         Assert.AreEqual (4, myDQueue.Capacity);
         myDQueue.REnqueue (5);
         myDQueue.REnqueue (6);
         Assert.AreEqual (8, myDQueue.Capacity);
         Assert.AreEqual (6, myDQueue.Count);
         myDQueue.REnqueue (7);
         myDQueue.REnqueue (8);
         myDQueue.FEnqueue (9);
         Assert.AreEqual(16,myDQueue.Capacity);
      }

      [TestMethod]
      public void Dequeue () {
         MyDeQueue<int> myDQueue = new MyDeQueue<int> ();
         Assert.ThrowsException<InvalidOperationException> (() => myDQueue.FDequeue ());
         Assert.ThrowsException<InvalidOperationException> (() => myDQueue.RDequeue ());
         myDQueue.FEnqueue (1);
         myDQueue.FEnqueue (2);
         myDQueue.FEnqueue (3);
         myDQueue.FEnqueue (4);
         Assert.AreEqual (4, myDQueue.FDequeue ());
         Assert.AreEqual (3, myDQueue.FDequeue ());
         Assert.AreEqual (1, myDQueue.RDequeue ());
         Assert.AreEqual (1, myDQueue.Count);
         myDQueue.REnqueue (5);
         myDQueue.REnqueue (6);
         myDQueue.REnqueue (7);
         myDQueue.REnqueue (8);
         myDQueue.REnqueue (9);
         myDQueue.FEnqueue (10);
         Assert.AreEqual (10, myDQueue.FDequeue ());
         myDQueue.FDequeue ();
         myDQueue.RDequeue ();
         myDQueue.RDequeue ();
         myDQueue.FDequeue ();
         myDQueue.FDequeue ();
         myDQueue.FDequeue ();
         myDQueue.FEnqueue (10);
         myDQueue.RDequeue ();
      }


      [TestMethod]
      public void Peek () {
         MyDeQueue<int> myDQueue = new MyDeQueue<int> ();
         Assert.ThrowsException<InvalidOperationException> (() => myDQueue.FPeek ());
         Assert.ThrowsException<InvalidOperationException> (() => myDQueue.RPeek ());
         myDQueue.FEnqueue (1);
         myDQueue.FEnqueue (2);
         myDQueue.FEnqueue (3);
         myDQueue.FEnqueue (4);
         Assert.AreEqual (4, myDQueue.FPeek ());
         Assert.AreEqual (1, myDQueue.RPeek ());
         myDQueue.REnqueue (5);
         myDQueue.REnqueue (6);
         Assert.AreEqual (4, myDQueue.FPeek ());
         Assert.AreEqual (6, myDQueue.RPeek ());
      }
   }
}
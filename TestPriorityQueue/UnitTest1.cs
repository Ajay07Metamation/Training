// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// UnitTest1.cs
// Test for PriorityQueue<T>.
// ------------------------------------------------------------------------------------------------

using Training;

namespace TestPriorityQueue {

   [TestClass]
   public class TestPriorityQueue {
      [TestMethod]
      // Test enqueue method of priority queue
      public void TestEnqueue () {
         var (expResult, input) = (new[] { 0, 1, 1, 2, 1, 3, 4, 5, 5 }, new[] { 5, 4, 1, 3, 1, 2, 5, 1 });
         foreach (var ele in input)
            mTestPQ.Enqueue (ele);
         Assert.IsTrue (expResult.SequenceEqual (mTestPQ.ToArray ()));
      }

      [TestMethod]
      // Test dequeue method of priority queue
      public void TestDequeue () {
         AddElements ();
         var result = mTestData.Order ().ToArray ();
         for (int i = 0; i < result.Count (); i++)
            Assert.AreEqual (result[i], mTestPQ.Dequeue ());
         Assert.ThrowsException<InvalidOperationException> (() => mTestPQ.Dequeue ());
      }

      /// <summary>Add elements</summary>
      /// Add elements to the test array and priority queue
      void AddElements () {
         Random random = new ();
         for (int i = 0; i < 10; i++) {
            var element = random.Next (1, 100);
            mTestData[i] = element;
            mTestPQ.Enqueue (element);
         }
      }

      PriorityQueue<int> mTestPQ = new ();
      int[] mTestData = new int[10];
   }
}
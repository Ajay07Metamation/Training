// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// TestQueue
// Create a test for testing the created MyQueue<T> with underlying structure as array using property,methods and private variables
// ----------------------------------------------------------------------------------------

using Training;
namespace TestQueue {
    [TestClass]
    public class TestQueue {
        TQueue<int> mQueue = new ();

        [TestMethod]
        public void TestEnqueue () {
            mQueue.Enqueue (1);
            mQueue.Enqueue (2);
            mQueue.Enqueue (3);
            mQueue.Enqueue (4);
            Assert.AreEqual (4, mQueue.Count);
            Assert.AreEqual (4, mQueue.Capacity);
            mQueue.Enqueue (5);
            Assert.AreEqual (5, mQueue.Count);
            Assert.AreEqual (8, mQueue.Capacity);
        }

        [TestMethod]
        public void TestDequeue () {
            Assert.IsTrue (mQueue.IsEmpty);
            Assert.ThrowsException<InvalidOperationException> (() => mQueue.Dequeue ());
            mQueue.Enqueue (1);
            mQueue.Enqueue (2);
            mQueue.Enqueue (3);
            mQueue.Enqueue (4);
            Assert.AreEqual (1, mQueue.Dequeue ());
            Assert.AreEqual (2, mQueue.Dequeue ());
            mQueue.Dequeue ();
            mQueue.Dequeue ();
        }

        [TestMethod]
        public void TestPeek () {
            Assert.IsTrue (mQueue.IsEmpty); 
            Assert.ThrowsException<InvalidOperationException> (() => mQueue.Peek ());
            mQueue.Enqueue (1);
            mQueue.Enqueue (2);
            mQueue.Enqueue (3);
            mQueue.Enqueue (4);
            Assert.AreEqual (1, mQueue.Peek ());
        }

        [TestMethod]
        public void TestDisplay () {
            mQueue.Display();
            mQueue.Enqueue (1);
            mQueue.Enqueue (2);
            mQueue.Enqueue (3);
            mQueue.Enqueue (4);
            mQueue.Display();
        }
    }
}
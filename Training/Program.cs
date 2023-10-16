//TQueue
//Test Case
using static System.Console;

TQueue<int> queue = new TQueue<int> ();
queue.Enqueue (1);
queue.Enqueue (2);
queue.Enqueue (3);
queue.Enqueue (4);
queue.Enqueue (5);
queue.Enqueue (6);
queue.Display ();
WriteLine ("The Dequeued element is : " + queue.Dequeue ());
queue.Display ();
WriteLine ("The Peek element is : " + queue.Peek ());

/// <summary>Represent a first in first out principle collection of objects</summary>

class TQueue<T> {
   // Private variable for initialising array and count
   T[] mArrayQueue;
   int mCount;


   // Constructor for initializing the array and count
   public TQueue () {
      mArrayQueue = new T[4];
      mCount = 0;
   }

   // Property for getting count of elements in the queue
   public int Count => mCount;

   // Property for getting Capacity of queue 
   public int Capacity => mArrayQueue.Length;

   /// <summary>Add/Enqueue an element to the queue</summary>
   /// <param name="a">Element to be added</param>
   public void Enqueue (T a) {
      if (mCount == Capacity) Array.Resize (ref mArrayQueue, Capacity * 2);
      mArrayQueue[mCount] = a;
      mCount++;
   }

   /// <summary>Delete/Dequeue the first inserted element</summary>
   /// <returns>The deleted element </returns>
   /// <exception cref="InvalidOperationException"></exception>
   public T Dequeue () {
      if (IsEmpty) throw new InvalidOperationException ();
      var dequeuedElement = mArrayQueue[0];
      for (int i = 1; i < mCount; i++)
         mArrayQueue[i - 1] = mArrayQueue[i];
      mCount--;
      return dequeuedElement;
   }

   /// <summary>Returns the peek element in the queue </summary>
   /// <returns>The first element of the queue</returns>
   /// <exception cref="InvalidOperationException"></exception>
   public T Peek () {
      if (IsEmpty) throw new InvalidOperationException ();
      return mArrayQueue[0];
   }

   // Property to check if the queue is empty
   public bool IsEmpty => mCount == 0;

   /// <summary>Print the elements of the queue</summary>
   public void Display () {
      if (IsEmpty) return;
      Write ("QUEUE : ");
      for (int i = 0; i < mCount; i++) Write (mArrayQueue[i] + " ");
      WriteLine ();
   }

}


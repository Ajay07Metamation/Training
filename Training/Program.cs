// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// MyQueue<T>
// Create a Queue (MyQueue<T>) with underlying structure as array using property,methods and private variables
// ----------------------------------------------------------------------------------------

namespace Training {
   using static System.Console;

   #region Program ----------------------------------------------------------------------
   internal class Program {
      private static void Main (string[] args) {
      }
   }
   #endregion

   #region Class MyQueue ---------------------------------------------------------------------
   /// <summary>Represent a first in first out principle collection of objects</summary>
   public class TQueue<T> {

      #region Constructor -------------------------------------------
      // Constructor for initializing the array and count
      public TQueue () {
         mArrayQueue = new T[4];
         mCount = 0;
         mFront = -1;
         mRear = -1;

      }
      #endregion

      #region Properties --------------------------------------------
      /// <summary>Returns the number of elements in the queue</summary>
      public int Count => mCount;

      /// <summary>Returns the capacity of the queue</summary>
      public int Capacity => mArrayQueue.Length;

      /// <summary>Returns true or false after checking the Queue is empty or not</summary>
      public bool IsEmpty => mCount == 0;
      #endregion

      #region Implementation ----------------------------------------
      /// <summary>Add/Enqueue an element to the queue</summary>
      /// <param name="a">Element to be added</param>
      public void Enqueue (T a) {
         if (mFront == -1) mFront = 0;
         if (mCount == Capacity) {
            ArrayResize ();
         }
         mRear = (mRear + 1) % Capacity;
         mArrayQueue[mRear] = a;
         mCount++;
      }

      /// <summary>Delete/Dequeue the first inserted element</summary>
      /// <returns>Returns the deleted element </returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T Dequeue () {
         if (IsEmpty) throw new InvalidOperationException ();
         var dequeuedElement = mArrayQueue[mFront];
         if (mFront == mRear) {
            mRear = -1;
            mFront = -1;
         }
         mFront = (mFront + 1) % Capacity;
         mCount--;
         return dequeuedElement;
      }

      /// <summary>Returns the peek element in the queue</summary>
      /// <returns>Returns the first element of the queue</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T Peek () {
         if (IsEmpty) throw new InvalidOperationException ();
         return mArrayQueue[mFront];
      }

      /// <summary>Print the elements of the queue</summary>
      public void Display () {
         if (IsEmpty) return;
         Write ("QUEUE : ");
         int i = mFront;
         for (; i != mRear; i = (i + 1) % Capacity) Write (mArrayQueue[i] + " ");
         Write (mArrayQueue[i]);
         WriteLine ();
      }

      /// <summary>Resizes the array</summary>
      void ArrayResize () {
         T[] newArray = new T[Capacity*2];
         int j = 0;
         do {
            newArray[j] = mArrayQueue[mFront];
            mFront = (mFront + 1) % Capacity;
            j++;
         } while (mFront != (mRear + 1) % Capacity);
         mArrayQueue = newArray;
         mFront = 0;
         mRear = Capacity - 1;
      }
      #endregion

      #region Private Data ------------------------------------------
      // Private variable for initialising array and count
      T[] mArrayQueue;
      int mCount, mFront, mRear;
      #endregion
   }
   #endregion
}
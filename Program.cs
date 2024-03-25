// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Priority Queue
// Program to implement a PriorityQueue<T> using a list.
// ------------------------------------------------------------------------------------------------

using static System.Console;

namespace Training {
   internal class Program {
      static void Main (string[] args) {
      }
   }

   #region Class Prioirity Queue -------------------------------------------------------------------------
   public class PriorityQueue<T> where T : IComparable<T> {

      #region Constructor --------------------------------------------------------------------------
      public PriorityQueue () { mHeapList.Add (default); }
      #endregion

      #region Implementation------------------------------------------------------------------------

      /// <summary>Enqueue element into the priority queue</summary>
      /// <param name="value">Element to be enqueued</param>
      public void Enqueue (T value) {
         mHeapList.Add (value);
         SiftUp (Count - 1);
      }

      /// <summary>Sift up the element</summary>
      /// Sift up the element during enqueue to maintain the order and shape of the priority queue
      /// <param name="index"></param>
      private void SiftUp (int index) {
         while (index > 1) {
            int parentIndex = index / 2;
            if (mHeapList[index].CompareTo (mHeapList[parentIndex]) >= 0) break;
            Swap (index, parentIndex);
            index = parentIndex;
         }
      }

      /// <summary>Dequeue the smallest element in the priority queue</summary>
      /// <returns>Returns the dequeued element</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T Dequeue () {
         if (IsEmpty) throw new InvalidOperationException ("PriorityQueue is empty");
         (T dequeuedItem, int last) = (mHeapList[1], Count - 1);
         mHeapList[1] = mHeapList[last];
         mHeapList.RemoveAt (last);
         SiftDown (1);
         return dequeuedItem;
      }

      /// <summary>Sift down the element</summary>
      /// Sift down the element during dequeue to maintain the order and shape of the priority queue
      /// <param name="index">Index of element to be sifted down</param>
      private void SiftDown (int index) {
         while (true) {
            var (lIndex, rIndex, sIndex) = (2 * index, 2 * index + 1, index);
            if (lIndex < Count && mHeapList[lIndex].CompareTo (mHeapList[sIndex]) < 0)
               sIndex = lIndex;
            if (rIndex < Count && mHeapList[rIndex].CompareTo (mHeapList[sIndex]) < 0)
               sIndex = rIndex;
            if (sIndex == index) break;
            Swap (index, sIndex);
            index = sIndex;
         }
      }

      /// <summary>Gets the array representation of the priority queue</summary>
      /// <returns>Returns an array</returns>
      public T[] ToArray () => mHeapList.ToArray ();

      /// <summary>Swap elements in the priority queue</summary>
      /// <param name="i">Index of element to be swapped</param>
      /// <param name="j">Index of element to be swapped</param>
      void Swap (int i, int j) => (mHeapList[i], mHeapList[j]) = (mHeapList[j], mHeapList[i]);

      /// <summary>Display the priority queue</summary>
      public void Display () { for (int i = 1; i < mHeapList.Count; i++) WriteLine (mHeapList[i]); }
      #endregion

      #region Properties ---------------------------------------------------------------------------

      // Gets the count of the priority queue
      public int Count => mHeapList.Count;

      // Returns true if the priority queue is empty else returns false
      public bool IsEmpty => mHeapList.Count == 1;
      #endregion

      #region Private Field ------------------------------------------------------------------------
      readonly List<T> mHeapList = new ();
      #endregion
   }
   #endregion
}
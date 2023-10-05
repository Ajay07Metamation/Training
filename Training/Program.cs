//TQueue

//Test Case

TQueue<int> queue = new TQueue<int> ();
queue.Enqueue (1);
queue.Enqueue (2);
queue.Enqueue (3);
queue.Enqueue (4);
queue.Enqueue (5);
queue.Enqueue (6);
queue.Display ();
Console.WriteLine ("The Dequeued element is : " + queue.Dequeue ());
queue.Display ();
Console.WriteLine ("The Peek element is : " + queue.Peek ());

/// <summary>Class TQueue implemented with array as underlying structure </summary>

class TQueue<T> {
   //Private variable for initialising array and count
   T[] arrayqueue;
   int count;


   //Constructor for initializing the array and count
   public TQueue () {
      arrayqueue = new T[4];
      count = 0;
   }

   //Property for getting count of elements in the queue
   public int Count => count;

   //Property for getting Capacity of queue 
   public int Capacity => arrayqueue.Length;

   /// <summary>Method to add an element to the queue</summary>
   /// <param name="a">element to be added</param>
   public void Enqueue (T a) {
      if (count == Capacity) Array.Resize (ref arrayqueue, Capacity * 2);
      arrayqueue[count] = a;
      count++;
   }

   /// <summary>Method to delete the first inserted element </summary>
   /// <returns>The deleted element </returns>
   /// <exception cref="InvalidOperationException"></exception>
   public T Dequeue () {
      if (IsEmpty) throw new InvalidOperationException ();
      var dequeuedElement = arrayqueue[0];
      for (int i = 1; i < count; i++)
         arrayqueue[i - 1] = arrayqueue[i];
      count--;
      return dequeuedElement;
   }

   /// <summary>Method to find the peek element in the queue </summary>
   /// <returns>The first element of the queue</returns>
   /// <exception cref="InvalidOperationException"></exception>
   public T Peek () {
      if (IsEmpty) throw new InvalidOperationException ();
      return arrayqueue[0];
   }

   //Property to check if the queue is empty
   public bool IsEmpty => count == 0;

   /// <summary>Method to print the elements of the queue </summary>
   public void Display () {
      if (IsEmpty) return;
      Console.Write ("QUEUE : ");
      for (int i = 0; i < count; i++) Console.Write (arrayqueue[i] + " ");
      Console.WriteLine ();
   }

}
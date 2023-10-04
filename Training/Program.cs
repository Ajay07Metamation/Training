//MyList<T>
//Create a list (MyList<T>) with underlying structure as array using property,methods and private variables

//TEST CASE

MyList<int> list = new ();
list.Add (1);
list.Add (2);
list.Add (3);
list.Add (4);
list.Add (5);
list.Add (6);
list.Add (7);
list.Add (8);
list.PrintList ();
list.Insert (4, 9);
list.Remove (4);
list.PrintList (); ;
list.RemoveAt (2);
list.PrintList ();
list.Clear ();
list.PrintList ();

/// <summary>
/// Creating a class MyList with underlying structure as array
/// </summary>
class MyList<T> {
   //Private variables for creating array and int variable for count
   T[] arrayList;
   int count;
   public MyList () {
      arrayList = new T[4];
      count = 0;
   }

   /// <summary>
   /// Creating property for getting count and capacity
   /// <property name = "Count"> Gets the count of element in the list</property>
   /// <property name = "Capacity"> Get the capacity of the underlying array structure</property>
   /// </summary>
   public int Count => count;
   public int Capacity => arrayList.Length;

   /// <summary>
   /// public T this[int index] is a property used to get a element at a index or set it
   /// </summary>
   /// <returns>returns the element at the specified index</returns>
   /// <exception cref="IndexOutOfRangeException"></exception>
   public T this[int index] {
      get {
         if (index < 0 || index > Capacity) throw new IndexOutOfRangeException ();
         return arrayList[index];
      }
      set {
         if (index < 0 || index > Capacity) throw new IndexOutOfRangeException ();
         arrayList[index] = value;
      }
   }

   /// <summary>
   /// Method Add to add an element in the list at the end  
   /// </summary>
   /// <param name="a">It is the element to be added to the list</param>
   public void Add (T a) {
      if (a == null) throw new ArgumentNullException ();
      if (count == Capacity) Array.Resize (ref arrayList, Capacity * 2);
      arrayList[count++] = a;
   }

   /// <summary>
   /// Method remove to remove a particular element 
   /// </summary>
   /// <param name="a">The element in the list to be removed</param>
   /// <exception cref="InvalidOperationException"></exception>
   public bool Remove (T a) {
      if (!arrayList.Contains (a)) throw new InvalidOperationException ();
      int index = Array.IndexOf (arrayList, a, 0, count);
      for (int i = index; i < count; i++) arrayList[i] = arrayList[i + 1];
      count--;
      return true;
   }

   /// <summary>
   /// Method clear to clear the list
   /// </summary>
   /// <exception cref="InvalidOperationException"></exception>
   public void Clear () {
      if (arrayList.Length <= 0) throw new InvalidOperationException ();
      Array.Clear (arrayList, 0, count);
      count = 0;
   }

   /// <summary>
   /// Method Insert to insert a specified element at a specified index
   /// </summary>
   /// <param name="index">The index where the element should be inserted</param>
   /// <param name="a">The element to be inserted</param>
   /// <exception cref="IndexOutOfRangeException"></exception>
   public void Insert (int index, T a) {
      if (a == null) throw new ArgumentNullException ();
      else if (index < 0 || index > count) throw new IndexOutOfRangeException ();
      else if (count == arrayList.Length) Array.Resize (ref arrayList, Capacity * 2);
      for (int i = count; i > index; i--) arrayList[i] = arrayList[i - 1];
      arrayList[index] = a;
      count++;
   }

   /// <summary>
   /// Method RemoveAt to remove the element at a particular index
   /// </summary>
   /// <param name="index">The index at which the element is to be removed</param>
   /// <exception cref="IndexOutOfRangeException"></exception>
   public void RemoveAt (int index) {
      if (index < 0 || index > count) throw new IndexOutOfRangeException ();
      if (count == arrayList.Length) Array.Resize (ref arrayList, Capacity * 2);
      for (int i = index; i < count; i++) arrayList[i] = arrayList[i + 1];
      count--;
   }

   /// <summary>
   /// Method to print the list
   /// </summary>
   public void PrintList () {
      Console.Write ("List : ");
      for (int i = 0; i < count; i++) {
         Console.Write (arrayList[i] + " ");
      }
      Console.WriteLine ();
   }

}

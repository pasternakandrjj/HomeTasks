using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class Program
    {
        //class MyList<T> : IEnumerable<T>, IEnumerator<T>
        //{
        //    private T[] mylist = new T[0];
        //    int position = -1;
        //    public object Current => mylist[position];
        //    T IEnumerator<T>.Current => mylist[position];
        //    public MyList()
        //    {
        //        mylist = new T[0];
        //    }
        //    public MyList(T element)
        //    {
        //        T[] newlist = new T[mylist.Length + 1];
        //        mylist.CopyTo(newlist, 0);
        //        newlist[mylist.Length] = element;
        //        mylist = newlist;
        //    }
        //    public bool MoveNext()
        //    {
        //        if (mylist.Length - 1 > position)
        //        {
        //            position++;
        //            return true;
        //        }
        //        else //if (mylist == null || mylist.Length == position)
        //            return false;
        //    }
        //    public void Add(T element)
        //    {
        //        if (mylist == null)
        //        {
        //            mylist = new T[] { element };
        //            return;
        //        }
        //        T[] newlist = new T[this.mylist.Length + 1];
        //        mylist.CopyTo(newlist, 0);
        //        newlist[mylist.Length] = element;
        //        mylist = newlist;
        //    }
        //    public void Remove(int index)
        //    {
        //        T[] newlist = new T[mylist.Length - 1];
        //        for (int i = 0; i < index; i++)
        //            newlist[i] = mylist[i];
        //        for (int i = index; i < mylist.Length - 1; i++)
        //            newlist[i] = mylist[i + 1];

        //        mylist = newlist;
        //    }
        //    public IEnumerator GetEnumerator()
        //    {
        //        position = -1;
        //        return this;
        //    }
        //    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        //    {
        //        position = -1;
        //        return this;
        //    }
        //    public void Dispose()
        //    {
        //        //Console.WriteLine(("hi"));
        //    }
        //    public void Reset()
        //    {

        //    }
        //}

        public class Node<T>
        {
            private T data;
            private Node<T> next;
            public Node() { }
            public Node(T data_)
            {
                data = data_;
                next = this.next.next;
            }
            public Node(T data_, Node<T> next_)
            {
                data = data_;
                next = next_;
            }
            public T Data
            {
                get
                {
                    return data;
                }
                set
                {
                    data = value;
                }
            }
            public Node<T> Next
            {
                get
                {
                    return next;
                }
                set
                {
                    next = value;
                }
            }

        }
        public class MyLinkedList<T> where T : class
        {
            private Node<T> head;
            private int capacity;
            public T this[int index]
            {
                get { return this.Get(index); }
            }
            public MyLinkedList()
            {
                head = null;
                capacity = 0;
            }
            public bool Empty()
            {
                return this.capacity == 0;
            }
            public int Count()
            {
                return this.capacity;
            }
            public T Add(int index, T element)
            {
                if (index < 0)
                    index = 0;
                if (index > capacity)
                {
                    index = capacity;
                }
                Node<T> current = this.head;
                if (this.Empty() || index == 0)
                {
                    this.head = new Node<T>(element, this.head);
                }
                else
                {
                    for (int i = 0; i < index - 1; i++)
                    {
                        current = current.Next;
                    }
                    current.Next = new Node<T>(element, current.Next);
                }
                capacity++;
                return element;
            }
            public T Remove(int index)
            {
                T result;
                Node<T> current = this.head;
                //if (index < 0)
                //    throw new Exception("index < 0");
                if (index > capacity)
                    index = capacity;
                if (index <= 0)
                {
                    index = 0;
                    result = current.Data;
                    this.head = current.Next;
                }
                else
                {
                    for (int i = 0; i < index - 1; i++)
                        current = current.Next;
                    result = current.Next.Data;
                    current.Next = current.Next.Next;
                }
                capacity--;
                return result;
            }
            public void Clear()
            {
                this.head = null;
                this.capacity = 0;
            }
            public bool Contains(T element)
            {
                Node<T> current = this.head;
                bool flag = false;
                for (int i = 0; i < capacity; i++)
                {
                    if (current.Data == element)
                        flag = true;
                    else current = current.Next;
                }
                return true;
            }
            public int IndexOf(T element)
            {
                Node<T> current = this.head;
                for (int i = 0; i < capacity; i++)
                    if (current.Data.Equals(element))
                        return i;
                    else
                        current = current.Next;
                return -1;
            }
            public T Get(int index)
            {
                if (index <= 0)
                    index = 0;
                if (index >= capacity)
                    index = capacity;
                Node<T> current = this.head;
                for (int i = 0; i < index; i++)
                    current = current.Next;
                return current.Data;
            }

        }

        static void Main(string[] args)
        {
            //MyList<int> myList = new MyList<int>();
            //List<int> ts = new List<int>();
            //ts.Add(2);
            //ts.Add(5);
            //foreach (var item in ts)
            //{
            //    Console.WriteLine(item);
            //}

            MyLinkedList<ValueType> myLinkedList = new MyLinkedList<ValueType>();

            myLinkedList.Add(0, 4);
            myLinkedList.Add(1, 2);
            myLinkedList.Add(2, 19);

            //Console.WriteLine(myLinkedList.Get(2));
            //Console.WriteLine(myLinkedList.Contains(2));
            //Console.WriteLine(myLinkedList.IndexOf(2));
            //Console.WriteLine(myLinkedList.Count());
            //Console.WriteLine(myLinkedList.IndexOf(20));
            //Console.WriteLine(myLinkedList.Get(1));
            Console.ReadLine();
        }
    }
}
using System;

namespace C1
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class List<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public Node<T> Head { get; set; }
        public List()
        {
            head = tail = null;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void A1(Action<T> action)
        {
            Node<T> t = head;
            while (t != null)
            {
                action(t.Data);
                t = t.Next;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[5] { 4, 8, 5, 6, 3 };
            List<int> MyList = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                MyList.Add(a[i]);
            }
            Action<int> action = delegate (int item)
            {
                Console.Write(item + " ");
            };
            MyList.A1(action);
            Console.WriteLine();//换行
            int sum = 0, max = int.MinValue, min = int.MaxValue;
            MyList.A1(x => sum += x);//求和
            MyList.A1(x => { if (x > max) max = x; });//求最大值
            MyList.A1(x => { if (x < min) min = x; });//求最小值
            Console.WriteLine("最大值为 {0}\n最小值为 {1}\n和为 {2}\n", max, min, sum);
            Console.ReadKey();
        }
    }
}

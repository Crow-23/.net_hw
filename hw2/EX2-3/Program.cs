using System;
using System.Collections.Generic;
using System.Linq;

//为本讲示例中的泛型链表类添加ForEach(Action<T> action)方法。类似于List<T>类的ForEach方法，通过调用这个方法打印链表元素，求最大值、最小值和求和（使用lambda表达式实现）
namespace EX3
{
    //链表
    public class Node<T>
    {
        public Node(T t)
        {
            Next = null;
            Data = t;
        }

        public Node<T> Next { get; set; }
        public T Data { get; set; }
    }
    public class MyList<T>
    {
        private Node<T> tail;

        public MyList()
        {
            tail = Head = null;
        }

        public Node<T> Head { get; private set; }

        public void Add(T t)
        {
            var n = new Node<T>(t);
            if (tail == null)
            {
                Head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        public void ForEach(Action<T> action)
        {
            var node = Head;
            while (node != null)
            {
                action(node.Data);
                node = node.Next;
            }
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var list = new MyList<int>();
            list.Add(5);
            list.Add(4);
            list.Add(2);
            list.Add(7);

            var max = int.MinValue;
            var min = int.MaxValue;
            var sum = 0;

            list.ForEach(m => max = Math.Max(max, m));
            list.ForEach(m => min = Math.Min(min, m));
            list.ForEach(s => sum = sum += s);
            Console.WriteLine($"Max = {max}\nMin = {min}\nSum = {sum}\n");
        }
    }
}

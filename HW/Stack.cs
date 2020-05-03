using System;
using System.Collections.Generic;
using System.Text;

namespace HW
{
    public class Stack<T>
    {
        public Stack()
        {
            this.arr = new T[5];
            this.t = -1;
        }

        private T[] arr;
        public int t;

        public void Push(T v)
        {
            if (t == arr.Length - 1)
            {
                T[] temp = new T[arr.Length * 2];
                for (int i = 0; i < this.arr.Length; i++)
                {
                    temp[i] = arr[i];
                }
                this.arr = temp;
            }
            t++;
            arr[t] = v;

        }
        public T Top()
        {
            T v = arr[t];
            return v;
        }
        public T Pop()
        {
            T v = arr[t];
            t--;
            return v;
        }
        public bool IsEmpty()
        {
            return t == -1 ? true : false;
        }
        public override string ToString()
        {
            if (IsEmpty())
                return "[]";
            string s = "[";
            for (int i = 0; i <= t; i++)
            {
                s = s + arr[i] + ",";
            }
            return s.Substring(0, s.Length - 1) + "]";
        }
    }

    public class Node<T>
    {
        private T value;
        private Node<T> next;

        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }

        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }

        public T GetValue()
        {
            return value;
        }

        public Node<T> GetNext()
        {
            return next;
        }

        public void SetValue(T value)
        {
            this.value = value;
        }

        public void SetNext(Node<T> next)
        {
            this.next = next;
        }



        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}

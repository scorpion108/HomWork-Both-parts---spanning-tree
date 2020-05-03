using System;
using System.Collections.Generic;
using System.Text;

namespace HW
{
    public class BinTreeNode<T>
    {
        private T value;
        private BinTreeNode<T> left;
        private BinTreeNode<T> right;

        public BinTreeNode(T value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }
        public BinTreeNode(BinTreeNode<T> left, T value, BinTreeNode<T> right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }
        public T GetValue()
        {
            return value;
        }
        public BinTreeNode<T> GetLeft()
        {
            return left;
        }
        public BinTreeNode<T> GetRight()
        {
            return right;
        }
        public void SetValue(T value)
        {
            this.value = value;
        }
        public void SetLeft(BinTreeNode<T> left)
        {
            this.left = left;
        }
        public void SetRight(BinTreeNode<T> right)
        {
            this.right = right;
        }
        public override string ToString()
        {
            return " ( " + left + " " + value + " " + right + " ) ";
        }
    }
}

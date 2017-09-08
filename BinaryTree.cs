using System;
using System.Collections;
using System.Reflection;

namespace BinaryTree
{
    public abstract class BinaryTree<T> 
    {
        private BinaryTreeNode<T> _root;

        protected BinaryTree()
        {
            _root = null;
        }

        public void Add(T value)
        {
           BinaryTreeNode<T> binaryNode = SearchIfNotFoundLastNodeReturn(value, null);
            if(binaryNode.Value.Equals(value))
                throw new Exception("Value Already exists exception");
            BinaryTreeNode<T> node = new BinaryTreeNode<T>(value, null, null);
            if (binaryNode.Value < (dynamic)value)
                binaryNode.Right = node;
            if (binaryNode.Value > (dynamic)value)
                binaryNode.Left = node;
        }

        // temp optional parameter pls pass null as temp.
        public  BinaryTreeNode<T> SearchIfNotFoundLastNodeReturn(T value, BinaryTreeNode<T> temp)
        {
            if (temp == null && _root != null)
                temp = _root;
            if (temp.Value.Equals(value))
                return temp;
            if (temp.Left == null && temp.Right == null)
                return temp;

            if (value != null)
            {
                if (LesserThan(value, temp.Value))
                    return SearchIfNotFoundLastNodeReturn(value, temp.Left);
                if (GreaterThan(value, temp.Value))
                    return SearchIfNotFoundLastNodeReturn(value, temp.Right);
            }
            return null;
        }

        public abstract bool GreaterThan(T value, T temp);
        public abstract bool LesserThan(T value, T temp);



        public virtual void Clear()
        {
            _root = null;
        }

        public BinaryTreeNode<T> Root
        {
            set => _root = value;
            get => _root;
        }


    }
}
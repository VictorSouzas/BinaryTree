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
        public abstract BinaryTreeNode<T> SearchIfNotFoundLastNodeReturn(T value, BinaryTreeNode<T> temp);
        
        
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
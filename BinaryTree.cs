using System;
using System.Collections;

namespace BinaryTree
{
    public class BinaryTree<T>
    {
        private BinaryTreeNode<int> _root;

        public BinaryTree()
        {
            _root = null;
        }

        
        // temp optional parameter pls pass null as temp.
        public BinaryTreeNode<T> Search(T value, BinaryTreeNode<T> temp)
        {
            if (temp == null && _root != null)
                temp = _root as BinaryTreeNode<T>;
            if (temp.Value.Equals(value))
                return temp;
            if (value > 0)
            {
                if (value <  temp.Value)
                    return Search(value, temp.Left);
                if (value >  temp.Value)
                    return Search(value, temp.Right);
            }
            return null;
        }
        
        public virtual void Clear()
        {
            _root = null;
        }

        public BinaryTreeNode<int> Root
        {
            set => _root = value;
            get => _root;
        }
    }
}
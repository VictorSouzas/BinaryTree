using System;

namespace BinaryTree
{
    public class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode(T value, BinaryTreeNode<T> parent, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            Value = value;
            NodeList<T> children = new NodeList<T>(2);
            children[0] = left;
            children[1] = right;
            Neighbors = children;
            Parent = parent;
        }
        
        public BinaryTreeNode<T> Parent { get; set; }

        public BinaryTreeNode<T> Left
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                return base.Neighbors[0];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);
                base.Neighbors[0] = value;
            }
        }
        
        public BinaryTreeNode<T> Right
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                return base.Neighbors[1];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);
                base.Neighbors[1] = value;
            }
        }

    }
}
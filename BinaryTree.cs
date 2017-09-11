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

        public BinaryTreeNode<T> Add(T value)
        {
            if (_root == null)
            {
                CreateRoot(value);
                return _root;
            }
            BinaryTreeNode<T> binaryNode = SearchIfNotFoundLastNodeReturn(value, null);
            if(binaryNode.Value.Equals(value))
                throw new Exception("Value Already exists exception");
            BinaryTreeNode<T> node = new BinaryTreeNode<T>(value, binaryNode, null, null);

            if (LesserThan(binaryNode.Value, value))
                binaryNode.Right = node;
            if (GreaterThan(binaryNode.Value, value))
                binaryNode.Left = node;
            return node;
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
                if (LesserThan(value, temp.Value) && temp.Left != null)
                    return SearchIfNotFoundLastNodeReturn(value, temp.Left);
                if (GreaterThan(value, temp.Value) && temp.Right != null)
                    return SearchIfNotFoundLastNodeReturn(value, temp.Right);
            }
            return temp;
        }

        public BinaryTreeNode<T> Remove(T value)
        {
            BinaryTreeNode<T> searched = SearchIfNotFoundLastNodeReturn(value, null);
            if (!searched.Value.Equals(value))
                throw new Exception("The is no node to remove");
            if (searched.Left == null && searched.Right == null)
                return NoChildRemove(searched);
            if (searched.Left == null)
                return OneChildRemove(searched.Right);
            if (searched.Right == null)
                return OneChildRemove(searched.Left);
            return TwoChildrenRemove(searched);


        }

        private BinaryTreeNode<T> NoChildRemove(BinaryTreeNode<T> remove)
        {
            if (remove.Parent.Left.Value.Equals(remove.Value))
                remove.Parent.Left = null;
            if (remove.Parent.Right.Value.Equals(remove.Value))
                remove.Parent.Right = null;
            return remove;
        }

        private BinaryTreeNode<T> OneChildRemove(BinaryTreeNode<T> newparent)
        {
            BinaryTreeNode<T> returnValue = newparent.Parent;
            RepleaceNode(newparent.Parent, newparent);
            return returnValue;
        }

        private BinaryTreeNode<T> TwoChildrenRemove(BinaryTreeNode<T> remove)
        {
            BinaryTreeNode<T> smallerNode = SearchSmallerNode(remove.Right);
            RepleaceNode(remove, smallerNode);
            smallerNode.Left = remove.Left;
            return remove;


        }

        private void RepleaceNode(BinaryTreeNode<T> remove, BinaryTreeNode<T> repleacement)
        {
            if (remove.Parent.Left.Equals(remove))
                remove.Parent.Left = repleacement;

            if (remove.Parent.Right.Equals(remove))
                remove.Parent.Right = repleacement;
        }

        private BinaryTreeNode<T> SearchSmallerNode(BinaryTreeNode<T> _root)
        {
            if (_root.Left == null)
                return _root;
            return SearchSmallerNode(_root.Left);
        }
        private void CreateRoot(T value)
        {
            BinaryTreeNode<T> node = new BinaryTreeNode<T>(value, null, null, null);
            _root = node;
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
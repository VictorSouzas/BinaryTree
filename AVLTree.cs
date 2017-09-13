using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public abstract class AvlTree<T> : BinaryTree<T>
    {
        public void Add(T value)
        {
            Transverse(base.Add(value));
        }

        private void Transverse(BinaryTreeNode<T> currentNode)
        {
            var flag = currentNode.Left == null && currentNode.Right == null;
            if (currentNode.Height == 0 && flag && currentNode.Parent != null)
            {
                Transverse(currentNode.Parent);
                return;
            }
            if (currentNode.Left != null && currentNode.Right != null)
            {
                currentNode.Height = currentNode.Left.Height - currentNode.Right.Height == 0 ? 1 : currentNode.Left.Height - currentNode.Right.Height;
            }
            else
            {
                if (currentNode.Left != null)
                    currentNode.Height = -1 - currentNode.Left.Height;

                if (currentNode.Right != null)
                    currentNode.Height = currentNode.Right.Height - -1;
            }
            
            if (currentNode.Height < -1 || currentNode.Height > 1)
            {
                Transverse(Rebalance(currentNode));
                return;
            }
            if (currentNode.Parent == null)
                return;
            Transverse(currentNode.Parent);
            return;

        }

        private BinaryTreeNode<T> Rebalance(BinaryTreeNode<T> unbalancedTree)
        {
            Rotations<T> rotation = new Rotations<T>(unbalancedTree);
            if (unbalancedTree.Height == 2)
            {
                if (unbalancedTree.Right.Left != null && unbalancedTree.Right.Left.Height == 1)
                    return rotation.LeftRightRotation();
                return rotation.LeftRotation();
            }
            if (unbalancedTree.Left.Right != null && unbalancedTree.Left.Right.Height == 1)
                return rotation.RightLeftRotation();
            return rotation.RightRotation();
        }   
    }
}

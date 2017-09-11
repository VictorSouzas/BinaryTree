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
         
        }

        private int CalcHeigth(int hl, int hr)
        {
          return (hl) - (hr);
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
            if (unbalancedTree.Height == -2)
            {
                if (unbalancedTree.Left.Right != null && unbalancedTree.Left.Right.Height == 1)
                    return rotation.RightLeftRotation();
                return rotation.RightRotation();
                
            }
            return null;
        }   
    }
}

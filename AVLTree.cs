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
            if (currentNode.Left != null && currentNode.Right != null)
            {
                int heigth = CalcHeigth(currentNode.Left.Height, currentNode.Right.Height);
                currentNode.Height = (heigth == 0) ? 1 : heigth;
            }
            else
            {
                var flag = currentNode.Left == null && currentNode.Right == null;
                if (currentNode.Height == 0 && currentNode.Parent != null && flag)
                    Transverse(currentNode.Parent);

                if (currentNode.Left != null)
                    currentNode.Height = CalcHeigth(currentNode.Left.Height, -1);

                if (currentNode.Right != null)
                    currentNode.Height = CalcHeigth(currentNode.Right.Height, -1);
            }
           
            
            
            if (currentNode.Height < -1  || currentNode.Height > 1)
                Transverse(Rebalance(currentNode));
            if (currentNode.Parent == null)
                return;
           Transverse(currentNode.Parent);
        }

        private int CalcHeigth(int hl, int hr)
        {
          return (hl) - (hr);
        }

        private BinaryTreeNode<T> Rebalance(BinaryTreeNode<T> unbalancedTree)
        {
            if (unbalancedTree.Height == 2)
            {
                if (unbalancedTree.Left != null && unbalancedTree.Left.Height == 1)
                {
                    BinaryTreeNode<T> node = Rotation(unbalancedTree.Left, unbalancedTree, unbalancedTree.Left.Left, unbalancedTree.Parent);
                    return Rotation(node.Left, node, node.Right, node.Parent);
                }
                if(unbalancedTree.Right != null && unbalancedTree.Right.Height == 1)
                    return Rotation(unbalancedTree.Right, unbalancedTree, unbalancedTree.Right.Left, unbalancedTree.Parent);
            }
            if (unbalancedTree.Right.Height == 1)
            {
                BinaryTreeNode<T> node = Rotation(unbalancedTree.Right, unbalancedTree, unbalancedTree.Right.Right, unbalancedTree.Parent);
                return Rotation(node.Right, node, node.Left, node.Parent);
            }
            return Rotation(unbalancedTree.Left, unbalancedTree, unbalancedTree.Left.Left, unbalancedTree.Parent);


        }

        private BinaryTreeNode<T> Rotation(BinaryTreeNode<T> newRoot, BinaryTreeNode<T> left,
            BinaryTreeNode<T> right, BinaryTreeNode<T> parent)
        {
            newRoot.Left = left;
            newRoot.Right = right;
            newRoot.Parent = parent;
            left.Parent = newRoot;
            right.Parent = newRoot;
            return newRoot;

        }
        
        
    }
}

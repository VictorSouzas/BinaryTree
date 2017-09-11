﻿using System;
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
                    currentNode.Height = CalcHeigth(-1, currentNode.Right.Height);
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
            return null;

        }   
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class BinaryTreeInt32 : BinaryTree<int>
    {
        public override BinaryTreeNode<int> SearchIfNotFoundLastNodeReturn(int value, BinaryTreeNode<int> temp)
        {
            if (temp == null && base.Root != null)
                temp = base.Root;
            if (temp.Value.Equals(value))
                return temp;
            if (temp.Left == null && temp.Right == null)
                return temp;

            if (value > 0)
            {
                if (value < temp.Value)
                    return SearchIfNotFoundLastNodeReturn(value, temp.Left);
                if (value > temp.Value)
                    return SearchIfNotFoundLastNodeReturn(value, temp.Right);
            }
            return null;
        }
    }



    
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class BinaryTreeInt32 : BinaryTree<int>
    {
        public override bool GreaterThan(int value, int temp)
        {
            return value > temp;
        }

        public override bool LesserThan(int value, int temp)
        {
            return value < temp;
        }
    }



    
}



using System;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection;

namespace BinaryTree
{
    public class Start
    {
        static int Main(string[] args)
        {
            BinaryTreeInt32 binaryTree = new BinaryTreeInt32();
            binaryTree.Root = new BinaryTreeNode<int>(15, null, null);
            binaryTree.Add(55);
            binaryTree.Add(32);
            binaryTree.Add(45);
            return 1;
        }
    }

    
}
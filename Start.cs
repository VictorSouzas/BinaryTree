

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
            binaryTree.Add(45);
            binaryTree.Add(32);
            binaryTree.Add(21);
            binaryTree.Add(65);
            binaryTree.Add(75);

            binaryTree.Remove(55);


            return 1;
        }
    }

    
}
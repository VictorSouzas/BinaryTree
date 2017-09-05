

using System.Reflection.Metadata;

namespace BinaryTree
{
    public class Start
    {
        static int Main(string[] args)
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Root = new BinaryTreeNode<int>(15, null, null);
            return 1;
        }
    }

    
}
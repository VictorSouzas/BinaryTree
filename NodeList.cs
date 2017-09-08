using System.Collections.ObjectModel;
using System.IO;

namespace BinaryTree
{
    public class NodeList<T> : Collection<BinaryTreeNode<T>>
    {
        public NodeList() { }

        public NodeList(int initialSize)
        {
            for (int i = 0; i < initialSize; i++)
                base.Items.Add(default(BinaryTreeNode<T>));
        }

        public Node<T> FindByValue(T value)
        {
            foreach (Node<T> node in Items)
                if (node.Value.Equals(value))
                    return node;
            return null;
        }
    }
}
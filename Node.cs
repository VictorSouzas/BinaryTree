using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;

namespace BinaryTree
{
    public class Node<T>
    {
        public T Value
        {
            get => Value;
            set => this.Value = value;
        }

        public Node(){}
        
        public Node(T value)
        {
            this.Value = value;
        }

        public Node(T value, NodeList<T> neighbors)
        {
            this.Value = value;
            this.Neighbors = neighbors;
        }

        protected NodeList<T> Neighbors { get; set; } = null;
    }
}
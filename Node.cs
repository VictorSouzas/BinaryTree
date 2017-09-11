using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;

namespace BinaryTree
{
    public class Node<T>
    {
       

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

        public T Value { get; set; }
        public int Height { get; set; } = 0;

        protected NodeList<T> Neighbors { get; set; } = null;
    }
}
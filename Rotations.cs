namespace BinaryTree
{
    public class Rotations<T>
    {
        private BinaryTreeNode<T> Node;
        
        public Rotations(BinaryTreeNode<T> node)
        {
            Node = node;
        }

        public BinaryTreeNode<T> LeftRotation()
        {
            BinaryTreeNode<T> newNode = Node.Left;
            newNode.Left = Node;
            newNode.Parent = newNode.Left.Parent;
            Node.Parent = newNode;
            Node = newNode;
            return Node;
        }
        
        public BinaryTreeNode<T> RightRotation()
        {
            BinaryTreeNode<T> newNode = Node.Right;
            Node.Right = Node;
            newNode.Parent = newNode.Right.Parent;
            Node.Parent = newNode;
            Node = newNode;
            return Node;
        }

        public BinaryTreeNode<T> LeftRightRotation()
        {
            Rotations<T> newRotation = new Rotations<T>(Node.Right);
            newRotation.RightRotation();
            return LeftRotation();
        }
        public BinaryTreeNode<T> RightLeftRotation()
        {
            Rotations<T> newRotation = new Rotations<T>(Node.Left);
            newRotation.LeftRotation();
            return RightRotation();
        }
    }
}
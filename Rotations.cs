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
            BinaryTreeNode<T> newNode = Node.Right;
            newNode.Left = Node;
            newNode.Parent = newNode.Left.Parent;
            Node.Parent = newNode;
            Node = newNode;

            if (Node.Right != null)
                Node.Right.Height = 0;
            if (Node.Left != null)
                Node.Left.Height = 0;
            Node.Height = Node.Left.Height - Node.Right.Height == 0 ? 1 : Node.Left.Height - Node.Right.Height;
            return Node;
        }
        
        public BinaryTreeNode<T> RightRotation()
        {
            BinaryTreeNode<T> newNode = Node.Left;
            Node.Right = Node;
            newNode.Parent = newNode.Right.Parent;
            Node.Parent = newNode;
            Node = newNode;

            if (Node.Right != null)
                Node.Right.Height = 0;
            if (Node.Left != null)
                Node.Left.Height = 0;
            Node.Height = Node.Left.Height - Node.Right.Height == 0 ? 1 : Node.Left.Height - Node.Right.Height;
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
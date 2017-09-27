using System.Threading;

namespace BinaryTree
{
    public class BinaryTreeThread : AvlTree<Thread>
    {
        protected void Transverse(BinaryTreeNode<Thread> currentNode)
        {
            base.Transverse(currentNode);
        }
        
        public override bool GreaterThan(Thread value, Thread temp)
        {
            return value.ManagedThreadId > temp.ManagedThreadId;
        }

        public override bool LesserThan(Thread value, Thread temp)
        {
            return value.ManagedThreadId < temp.ManagedThreadId;
        }
    }
}
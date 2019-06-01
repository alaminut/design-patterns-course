using System.Linq;
using System.Collections.Generic;

namespace Iterator
{
    /*
     * This is a simple Node class to represent a binary tree in this example.
     * We will implement a pre-order iterator (we'll use c# features and implement it
     * as a property instead of another iterator class / object like in c++)
     */

    public class Node<T>
    {
        public Node<T> Left, Right;
        public Node<T> Parent;
        public T Value;

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Right = right;
            Left = left;
            left.Parent = right.Parent = this;
        }

        public IEnumerable<T> PreOrder
        {
            get { return TraversePreOrder(this).Select(node => node.Value); }
        }

        private static IEnumerable<Node<T>> TraversePreOrder(Node<T> current)
        {
            while (true)
            {
                // yield the root
                yield return current;

                // yield left subtree
                if (current.Left != null)
                    foreach (var left in TraversePreOrder(current.Left))
                        yield return left;

                if (current.Right == null) yield break;

                // yield right subtree (avoid double recursion, use iteration)
                current = current.Right;
            }
        }
    }
}

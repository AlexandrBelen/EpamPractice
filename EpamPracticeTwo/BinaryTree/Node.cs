using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class Node<TNode>
    {
        public delegate int Comparator(TNode other);
        private Comparator comparator;

        public TNode Value { get; private set; }
        public Node(TNode Value)
        {

        }
    }
}

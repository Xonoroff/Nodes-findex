using System;
using System.Diagnostics;

namespace Helpers
{
    public class ContainerWrapper : Container, IContainer
    {
        private readonly object[] nodes;
        
        public object this[int i]
        {
            get { return nodes[i]; }
        }
        
        public int Count { get; private set; }
        
        public ContainerWrapper(int count = 0) : base(count)
        {
            Count = count;
            nodes = new object[count];
            FillNodes();
        }

        private void FillNodes()
        {
            var currentNode = this.GetCurrentNode();
            var nextNode = this.GetNextNode(currentNode);
            var indexer = 0;
            nodes[indexer] = currentNode;
            while (nodes[0] != nextNode)
            {
                nodes[++indexer] = nextNode;
                nextNode = this.GetNextNode(nextNode);
            }
        }
    }
}

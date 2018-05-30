using System;
using Helpers;
using Infrastucture;

namespace Entities
{
    public class ContainerWrapper : Container, IContainer
    {
        private readonly NodeWrapper[] nodes;
        
        public NodeWrapper this[int i]
        {
            get { return nodes[i]; }
        }
        
        public int Count { get; private set; }
        
        public ContainerWrapper(int count = 0) : base(count)
        {
            Count = count;
            nodes = new NodeWrapper[count];
            FillNodes();
        }

        private void FillNodes()
        {
            var mapper = new Mapper<object, NodeWrapper>();
            var currentNode = this.GetCurrentNode();
            var nextNode = this.GetNextNode(currentNode);
            var indexer = 0;
            nodes[indexer] = mapper.Map(currentNode, new NodeWrapper());
            while (currentNode != nextNode)
            {
                nodes[++indexer] = mapper.Map(nextNode, new NodeWrapper());
                nextNode = this.GetNextNode(nextNode);
            }
        }
    }
}

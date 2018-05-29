using System.Reflection;
using Helpers;

public class ContainerNodesReflectionCalculator<T> : ICalculator<int, T> where T : Container {

	public int Calculate(T container)
	{
		var startNode = container.GetCurrentNode();
		var nextNode = container.GetNextNode(startNode);
		
		var count = 1;
		while (startNode != nextNode)
		{
			nextNode = container.GetNextNode(nextNode);
			count++;
		}
		
		return count;
	}


}

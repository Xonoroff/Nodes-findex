using Infrastucture;

namespace Helpers
{
	/// <summary>
	/// Calculator for container <see cref="Container"/> classes
	/// </summary>
	/// <typeparam name="T"></typeparam>
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
}

using System.Reflection;

namespace Helpers
{
	/// <summary>
	/// Helps to get nodes from container class <see cref="Container"/>
	/// </summary>
	public static class ContaierHelper
	{
		public static object GetNextNode(this Container contaier, object node)
		{
			var nextNodeFieldInfo = node.GetType().GetField("Next");
			var nextNode = nextNodeFieldInfo.GetValue(node);
			return nextNode;
		}

		public static object GetCurrentNode(this Container container)
		{
			var filedInfo = typeof(Container).GetField("current", BindingFlags.Instance | BindingFlags.NonPublic);
			return filedInfo.GetValue(container); 
		}
	}
}

using System.Reflection;

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


using Entities;
using Helpers;
using Infrastucture;
using NUnit.Framework;
using Assert = UnityEngine.Assertions.Assert;


public class ContainerNodesReflectionCalculatorTests
{
    [Test]
    public void Test_CalculateMethod_Contaier()
    {
        int itemsCount = 1000000;
        ICalculator<int, Container> calculator = new ContainerNodesReflectionCalculator<Container>();
        Container container = new Container(itemsCount);
        
        Assert.AreEqual(itemsCount, calculator.Calculate(container));
    }
    
    [Test]
    public void Test_CalculateMethod_ContaierWrapper()
    {
        int itemsCount = 1000000;
        ICalculator<int, ContainerWrapper> calculator = new ContainerNodesReflectionCalculator<ContainerWrapper>();
        ContainerWrapper container = new ContainerWrapper(itemsCount);
        
        Assert.AreEqual(itemsCount, calculator.Calculate(container));
    }

    [Test]
    public void Test_CheckCurrentNodeAfterCalculateMethod_Contaier()
    {
        int itemsCount = 1000000;
        ICalculator<int, Container> calculator = new ContainerNodesReflectionCalculator<Container>();
        Container container = new Container(itemsCount);
        var currentNode = container.GetCurrentNode();
        
        calculator.Calculate(new Container(itemsCount));
        var isEquals = ReferenceEquals(currentNode, container.GetCurrentNode());
        Assert.AreEqual(isEquals, true);
    }
    
    [Test]
    public void Test_CheckCurrentNodeAfterCalculateMethod_ContainerWrapper()
    {
        int itemsCount = 1000000;
        ICalculator<int, ContainerWrapper> calculator = new ContainerNodesReflectionCalculator<ContainerWrapper>();
        Container container = new Container(itemsCount);
        var currentNode = container.GetCurrentNode();
        
        calculator.Calculate(new ContainerWrapper(itemsCount));
        var isEquals = ReferenceEquals(currentNode, container.GetCurrentNode());
        Assert.AreEqual(isEquals, true);
    }
}

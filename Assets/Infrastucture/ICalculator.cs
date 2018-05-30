namespace Infrastucture
{
    public interface ICalculator<T, U>
    {
        T Calculate(U u);
    }
}

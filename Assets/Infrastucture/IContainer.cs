namespace Infrastucture
{
    public interface IContainer
    {
        int Count { get; }
    
        bool Value { get; set; }
    
        void MoveForward();

        void MoveBackward();
    }
}

namespace P01._FileStream_Before
{
    public interface IProgresser
    {
        int Length { get; }
        int Sent { get; }
    }
}

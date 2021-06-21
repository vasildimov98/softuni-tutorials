namespace P01.Stream_Progress.Contracts
{
    public interface IStreamer
    {
       int Length { get; }

       int BytesSent { get; }
    }
}

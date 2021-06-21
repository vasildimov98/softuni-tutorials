namespace P01.Stream_Progress
{
    using Contracts;
    using System;

    public class StreamProgressInfo
    {
        private IStreamer stream;

        public StreamProgressInfo(IStreamer stream)
        {
            this.Stream = stream;
        }

        public IStreamer Stream
        {
            get => this.stream;
            private set
            {
                this.stream = value ?? throw new ArgumentNullException(nameof(value), "Parameter cannot be null!");
            }
        }

        public int CalculateCurrentPercent()
        {
            return (this.Stream.BytesSent * 100) / this.Stream.Length;
        }
    }
}

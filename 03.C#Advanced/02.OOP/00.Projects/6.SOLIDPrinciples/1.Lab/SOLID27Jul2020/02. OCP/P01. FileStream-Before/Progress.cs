namespace P01._FileStream_Before
{
    public class Progress
    {
        private readonly IProgresser progresser;

        public Progress(IProgresser progresser)
        {
            this.progresser = progresser;
        }

        public int CurrentPercent()
        {
                return this.progresser.Sent * 100 / this.progresser.Length;
        }
    }
}

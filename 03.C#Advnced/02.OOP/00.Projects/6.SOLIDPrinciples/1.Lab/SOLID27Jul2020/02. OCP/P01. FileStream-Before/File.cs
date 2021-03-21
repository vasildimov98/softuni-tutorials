namespace P01._FileStream_Before
{
    public class File : IProgresser
    {
        public string Name { get; set; }

        public int Length { get; set; }

        public int Sent { get; set; }
    }
}

namespace P01._Square_Before
{
    public class Square : Shape
    {
        public double Side { get; set; }

        public override double Area
            => 2 * this.Side;
    }
}

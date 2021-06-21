namespace P01.ClassBoxData
{
    using System;
    using System.Text;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                }

                this.length = value;
            }
        }
        public double Width
        {
            get => this.width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                }

                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine($"Surface Area - {this.SurfaceArea():F2}")
                .AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():F2}")
                .AppendLine($"Volume - {this.Volume():F2}");

            return sb.ToString().TrimEnd();
        }
        public double Volume()
        {
            var l = this.Length;
            var w = this.Width;
            var h = this.Height;

            var volume = l * w * h;

            return volume;
        }
        public double LateralSurfaceArea()
        {
            var l = this.Length;
            var w = this.Width;
            var h = this.Height;

            var surfaceArea = 2 * (l * h + w * h);

            return surfaceArea;
        }
        public double SurfaceArea()
        {
            var l = this.Length;
            var w = this.Width;
            var h = this.Height;

            var surfaceArea = 2 * (l * w + l * h + w * h);

            return surfaceArea;
        }
    }
}

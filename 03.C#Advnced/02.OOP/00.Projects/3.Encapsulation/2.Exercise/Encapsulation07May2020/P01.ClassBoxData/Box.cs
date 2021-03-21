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
            get
            {
                return this.length;
            }
            private set
            {
                this.ValidateSide(value, nameof(this.Length));
                this.length = value;
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                this.ValidateSide(value, nameof(this.Width));
                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                this.ValidateSide(value, nameof(this.Height));
                this.height = value;
            }
        }

        public double Volume => this.Length * this.Width * this.Height;
        public double LateralSurfaceArea => 2 * this.Length * this.height + 2 * this.Width * this.Height;
        public double SurfaceArea => 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine($"Surface Area - {this.SurfaceArea:F2}")
                .AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea:F2}")
                .AppendLine($"Volume - {this.Volume:F2}");

            return sb.ToString().TrimEnd();
        }
        private void ValidateSide(double value, string sideName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{sideName} cannot be zero or negative.");
            }
        }
    }
}

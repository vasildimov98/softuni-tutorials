namespace P02.PointinRectangle
{
    public class Rectangle
    {
        public Rectangle(Point topLeftPoint, Point topRightPoint)
        {
            this.TopLeftPoint = topLeftPoint;
            this.TopRightPoint = topRightPoint;
        }

        public Point TopLeftPoint { get; set; }
        public Point TopRightPoint { get; set; }

        public bool Contains(Point point)
        {
            var xIsInside = this.TopLeftPoint.X <= point.X && point.X <= this.TopRightPoint.X;
            var yIsInside = this.TopLeftPoint.Y <= point.Y && point.Y <= this.TopRightPoint.Y;

            if (xIsInside && yIsInside)
            {
                return true;
            }

            return false;
        }
    }
}

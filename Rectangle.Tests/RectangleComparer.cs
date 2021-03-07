using System.Collections.Generic;

namespace Rectangle.Tests
{
    public class RectangleComparer : IEqualityComparer<Impl.Rectangle>
    {
        public bool Equals(Impl.Rectangle x, Impl.Rectangle y)
        {
            return x.X == y.X && x.Y == y.Y && x.Height == y.Height && x.Width == y.Width;
        }

        public int GetHashCode(Impl.Rectangle obj)
        {
            return obj.GetHashCode();
        }
    }
}

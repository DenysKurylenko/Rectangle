    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace Rectangle.Impl
{
	public static class Service
	{
		/// <summary>
		/// See TODO.txt file for task details.
		/// Do not change contracts: input and output arguments, method name and access modifiers
		/// </summary>
		/// <param name="points"></param>
		/// <returns></returns>
		public static Rectangle FindRectangle(List<Point> points)
		{
			if(points == null) throw new ArgumentNullException(nameof(points));
			if(points.Count < 2) throw new ArgumentException("List must contains more then one point",nameof(points));
            if (points.GroupBy(point => new {point.X, point.Y}).Any(g => g.Count() > 1)) throw new ArgumentException("List has duplicates");
            //wwda
            
            var length = points.Count;
            var xAxis = points.Select(p => p.X).OrderBy(x => x).ToArray();
            var yAxis = points.Select(p => p.Y).OrderBy(y => y).ToArray();

            //Select area for rectangle 

            var minX = xAxis[0];
            var maxX = xAxis[length - 1];
            var minY = yAxis[0];
            var maxY = yAxis[length - 1];

            //Check every side for point, that can be taken out of area
            //If point is only one, that lays on current borderline,
            //move border to nearest point and finish

            if (Compare(xAxis[1], minX, out minX)) return CreateRectangle(minX, maxX, minY, maxY);
            if (Compare(xAxis[length - 2], maxX, out maxX)) return CreateRectangle(minX, maxX, minY, maxY);
            if (Compare(yAxis[1], minY, out minY)) return CreateRectangle(minX, maxX, minY, maxY);
            if (Compare(yAxis[length - 2], maxY, out maxY)) return CreateRectangle(minX, maxX, minY, maxY);

            throw new ArgumentException("Cannot create rectangle!");
        }

        private static bool Compare( int a, int b, out int result)
        {
            if (a == b)
            {
                result = b;
                return false;
            }
            result = a;
            return true;

        }

        private static Rectangle CreateRectangle(int minX, int maxX, int minY, int maxY)
        {
            //In my implementation height and width can be 0, because technically it's still rectangle,
            //add there's nothing about it in task

            var height = maxY - minY;
            var width = maxX - minX;

            //I picked left bottom point as base of rectangle

            return new Rectangle()
            {
                X = minX, Y = minY, Height = height, Width = width
            };
            
        }
	}
}

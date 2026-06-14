using System;

namespace PracticeC_
{
    internal class LineSegment
    {
        private double x;
        private double y;

        public LineSegment()
        {
            x = 0;
            y = 1;
        }

        public LineSegment(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public LineSegment(LineSegment other)
        {
            this.x = other.x;
            this.y = other.y;
        }

        public double X
        {
            get 
            {
                return x;
            }
            set 
            { 
                x = value;
            }
        }

        public double Y
        {
            get 
            { 
                return y;
            }
            set 
            { 
                y = value; }
        }

        public bool Contains(double value)
        {
            double minX = Math.Min(x, y);
            double maxX = Math.Max(x, y);
            return value >= minX && value <= maxX;
        }

        public static double operator !(LineSegment segment)
        {
            return Math.Abs(segment.y - segment.x);
        }

        public static LineSegment operator ++(LineSegment segment)
        {
            return new LineSegment(segment.x + 1, segment.y + 1);
        }

        public static explicit operator int(LineSegment segment)
        {
            return (int)segment.x;
        }

        public static implicit operator double(LineSegment segment)
        {
            return segment.y;
        }

        public static LineSegment operator +(LineSegment segment, int d)
        {
            return new LineSegment(segment.x + d, segment.y + d);
        }

        public static LineSegment operator +(int d, LineSegment segment)
        {
            return new LineSegment(segment.x + d, segment.y + d);
        }

        public static bool operator <(LineSegment segment, int value)
        {
            return segment.Contains(value);
        }

        public static bool operator >(LineSegment segment, int value)
        {
            return segment.Contains(value);
        }

        public override string ToString()
        {
            return $"[{x:F2}, {y:F2}]";
        }
    }
}
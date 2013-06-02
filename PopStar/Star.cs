using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PopStar
{
    public class Star
    {
        private Color color;
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        private int x;
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Star(Color color, int x, int y)
        {
            this.color = color;
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Star))
            {
                return false;
            }
            else
            {
                Star other = obj as Star;
                return other.Color == color && other.X == x && other.Y == y;
            }
        }

        public override int GetHashCode()
        {
            return color.GetHashCode() ^ x.GetHashCode() ^ y.GetHashCode();
        }
    }
}

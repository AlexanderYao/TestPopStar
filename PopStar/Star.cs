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

        public Star(Color color)
        {
            this.color = color;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PopStar
{
    public class Game
    {
        private static Color[] colors = new[] { 
            Color.Crimson, Color.Gold, Color.RoyalBlue, Color.LimeGreen, Color.Purple
        };
        private static Random rand = new Random();

        private int size;
        public int Size
        {
            get { return size; }
        }

        private Star[,] source;
        public Star[,] Source
        {
            get { return source; }
            set { source = value; }
        }
        
        public Game()
        {
            size = 10;
            source = new Star[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    source[i, j] = new Star(colors[rand.Next(colors.Length)]);
                }
            }
        }
    }
}

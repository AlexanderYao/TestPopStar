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

        private int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public Game()
        {
            score = 0;
            size = 10;
            source = new Star[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    source[i, j] = new Star(colors[rand.Next(colors.Length)], i, j);
                }
            }
        }

        public List<Star> FindNeighbour(Star star)
        {
            List<Star> result = new List<Star>();
            Stack<Star> stack = new Stack<Star>();
            List<Star> tracked = new List<Star>();

            stack.Push(star);
            while (stack.Count > 0)
            {
                Star item = stack.Pop();
                if (!result.Contains(item))
                {
                    result.Add(item);
                }
                if (!tracked.Contains(item))
                {
                    tracked.Add(item);
                }                

                //上
                if (item.X > 0)
	            {
                    Star up = source[item.X - 1, item.Y];
                    if (up != null && !tracked.Contains(up) && up.Color == item.Color)
	                {
		                stack.Push(up);
	                }
	            }
                //下
                if (item.X < size - 1)
                {
                    Star down = source[item.X + 1, item.Y];
                    if (down != null && !tracked.Contains(down) && down.Color == item.Color)
                    {
                        stack.Push(down);
                    }
                }
                //左
                if (item.Y > 0)
                {
                    Star left = source[item.X, item.Y - 1];
                    if (left != null && !tracked.Contains(left) && left.Color == item.Color)
                    {
                        stack.Push(left);
                    }
                }
                //右
                if (item.Y < size - 1)
                {
                    Star right = source[item.X, item.Y + 1];
                    if (right != null && !tracked.Contains(right) && right.Color == item.Color)
                    {
                        stack.Push(right);
                    }
                }
            }
            return result;
        }

        public int CalculateScore(int selected)
        {
            if (selected <= 1)
            {
                return 0;
            }
            else
            {
                int multi = 10 + 5 * (selected - 2);
                return multi * selected;
            }            
        }

        public void Remove(List<Star> neighbour)
        {
            score += CalculateScore(neighbour.Count);
            foreach (Star star in neighbour)
            {
                source[star.X, star.Y] = null;
            }
        }
    }
}

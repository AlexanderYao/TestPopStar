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

        private List<Star> source;
        public List<Star> Source
        {
            get { return source; }
        }

        private int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        private int num;
        public int Num
        {
            get { return num; }
            set { num = value; }
        }

        public Game()
        {
            score = 0;
            size = 10;
            num = size * size;
            source = new List<Star>(num);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    source.Add(new Star(colors[rand.Next(colors.Length)], i, j));
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

                foreach (Direction dir in Enum.GetValues(typeof(Direction)))
                {
                    Star s = FindByDirection(source, item, dir);
                    if (s != null && s.Color == item.Color && !tracked.Contains(s))
                    {
                        stack.Push(s);
                    }
                }
            }
            return result;
        }

        private Star FindByDirection(List<Star> source, Star item, Direction dir)
        {
            int x = item.X;
            int y = item.Y;
            switch (dir)
            {
                case Direction.Up:
                    x -= 1;
                    break;
                case Direction.Down:
                    x += 1;
                    break;
                case Direction.Left:
                    y -= 1;
                    break;
                case Direction.Right:
                    y += 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return source.Locate(x, y);
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
            num -= neighbour.Count;
            score += CalculateScore(neighbour.Count);

            List<int> fallingDown = new List<int>();
            foreach (Star star in neighbour)
            {
                source.Remove(star);
                if (!fallingDown.Contains(star.Y))
                {
                    fallingDown.Add(star.Y);
                }
            }

            List<int> columnToBeRemove = new List<int>();
            foreach (int y in fallingDown)
            {
                IEnumerable<Star> column = source.FindAll(s => s.Y == y).OrderBy(s => s.X);
                if (column.Count() == 0)
                {
                    columnToBeRemove.Add(y);
                }
                else
                {
                    int i = size - column.Count();
                    foreach (var item in column)
                    {
                        item.X = i++;
                    }
                }
            }

            if (columnToBeRemove.Count > 0)
            {
                List<int> columnMovingLeft = new List<int>();
                columnToBeRemove.Sort();
                int start = columnToBeRemove[0];

                var linq = from s in source
                           where s.X == size - 1 && s.Y > start
                           orderby s.Y
                           select s.Y;

                columnMovingLeft = linq.ToList();
                for (int i = 0; i < columnMovingLeft.Count; i++)
                {
                    MoveColumn(columnMovingLeft[i], start++);
                }
            }

            EndOrNot();
        }

        private void EndOrNot()
        {
            bool end = true;
            foreach (var item in source)
            {
                if (FindNeighbour(item).Count >= 2)
                {
                    end = false;
                    break;
                }
            }

            if (end)
            {

            }
        }

        private void MoveColumn(int colFrom, int colTo)
        {
            source.FindAll(s => s.Y == colFrom).ForEach(s => s.Y = colTo);
        }
    }

    static class ListExt
    {
        internal static Star Locate(this List<Star> list, int x, int y)
        {
            return list.Find(s => s.X == x && s.Y == y);
        }
    }

    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}

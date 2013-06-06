using System;
using System.Windows.Forms;
using PopStar;
using System.Collections.Generic;
using System.Drawing;

namespace TestPopStar
{
    public partial class Form1 : Form
    {
        private Game game;
        private Button[,] buttons;
        private int height;
        private int border;
        private int size;

        public Form1()
        {
            InitializeComponent();
            height = 40;
            border = 1;
            size = 10;
        }

        private void startTsmi_Click(object sender, EventArgs e)
        {
            game = new Game();
            size = game.Size;
            buttons = new Button[size, size];
            panel1.Controls.Clear();

            Star[,] stars = game.Source;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Button b = new ButtonEx();
                    b.BackColor = stars[i, j].Color;
                    b.FlatAppearance.BorderColor = Color.White;
                    b.FlatAppearance.BorderSize = 2;
                    b.Parent = panel1;
                    b.Tag = stars[i, j];
                    b.Click += new EventHandler(b_Click);
                    b.DoubleClick += new EventHandler(b_DoubleClick);
                    buttons[i, j] = b;
                }
            }

            JustifySize();
            statusToolStrip.Text = "新的一局~~好运！";
        }

        private void b_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (buttons[i, j] == null)
                    {
                        continue;
                    }
                    buttons[i, j].FlatStyle = FlatStyle.Standard;
                }
            }
            Button current = sender as Button;
            List<Star> neighbour = game.FindNeighbour(current.Tag as Star);
            foreach (Star star in neighbour)
            {
                if (buttons[star.X, star.Y] == null)
                {
                    throw new ArgumentException("FindNeighbour中返回的数据与界面不匹配");
                }
                buttons[star.X, star.Y].FlatStyle = FlatStyle.Flat;
            }
            int score = game.CalculateScore(neighbour.Count);
            statusToolStrip.Text = string.Format("选中{0}个,{1}分", neighbour.Count, score);
        }

        private void b_DoubleClick(object sender, EventArgs e)
        {
            Button current = sender as Button;
            List<Star> neighbour = game.FindNeighbour(current.Tag as Star);
            if (neighbour.Count < 2)
            {
                return;
            }
            game.Remove(neighbour);
            foreach (Star star in neighbour)
            {
                if (buttons[star.X, star.Y] == null)
                {
                    throw new ArgumentException("FindNeighbour中返回的数据与界面不匹配");
                }
                panel1.Controls.Remove(buttons[star.X, star.Y]);
                buttons[star.X, star.Y] = null;
            }
            scoreToolStrip.Text = string.Format("总分：{0}", game.Score);
        }

        private void JustifySize()
        {
            this.ClientSize = new Size(size * height + 2 * border,
                size * height + menuStrip1.Height + statusStrip1.Height + 2 * border);

            if (buttons == null)
            {
                return;
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (buttons[i, j] == null)
                    {
                        continue;
                    }
                    buttons[i, j].Size = new Size(height, height);
                    buttons[i, j].Location = new Point(j * height, i * height);
                }
            }
        }

        private void exitTsmi_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sizeTsmi_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem current = sender as ToolStripMenuItem;
            string name = current.Name.TrimEnd("Tsmi".ToCharArray()).ToLower();
            switch (name)
            {
                case "small":
                    height = 20;
                    break;
                case "middle":
                    height = 40;
                    break;
                case "large":
                    height = 60;
                    break;
                default:
                    // else do nothing
                    break;
            }
            ClearChecked();
            (sender as ToolStripMenuItem).Checked = true;
            JustifySize();
        }

        private void ClearChecked()
        {
            smallTsmi.Checked = false;
            middleTsmi.Checked = false;
            largeTsmi.Checked = false;
        }
    }
}
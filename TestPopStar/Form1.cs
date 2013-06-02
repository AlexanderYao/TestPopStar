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
                    Button b = new Button();
                    b.BackColor = stars[i, j].Color;
                    b.Parent = panel1;
                    b.Tag = stars[i, j];
                    buttons[i, j] = b;
                }
            }

            JustifySize();
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
                    if (buttons[i,j] == null)
                    {
                        continue;
                    }
                    buttons[i, j].Size = new Size(height, height);
                    buttons[i, j].Location = new Point(i * height, j * height);
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
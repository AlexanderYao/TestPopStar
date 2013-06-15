using System;
using System.Windows.Forms;
using PopStar;
using System.Collections.Generic;
using System.Drawing;
using TestPopStar.Properties;
using System.Media;

namespace TestPopStar
{
    public partial class Form1 : Form
    {
        private Game game;
        private List<Button> buttons;
        private int height;
        private int border;
        private int size;

        private bool alreadyWin = false;
        private static string POP = "pop";
        private static string WIN = "win";
        private Dictionary<string, SoundPlayer> sounds;

        public Form1()
        {
            InitializeComponent();
            height = 40;
            border = 1;
            size = 10;

            sounds = new Dictionary<string, SoundPlayer>();
            sounds.Add(POP, InitialSound(POP));
            sounds.Add(WIN, InitialSound(WIN));
        }

        private SoundPlayer InitialSound(string name)
        {
            SoundPlayer sound = new SoundPlayer();
            sound.SoundLocation = name + ".wav";
            sound.Load();
            return sound;
        }

        private void startTsmi_Click(object sender, EventArgs e)
        {
            game = new Game();
            size = game.Size;
            buttons = new List<Button>(game.StarCount);

            game.NextStage += new EventHandler(game_NextStage);
            game.GameOver += new EventHandler(game_GameOver);
            game_NextStage(null, null);
        }

        void game_GameOver(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("娟子，游戏结束咯！这次你玩到了第{0}关，休息一下吧？", 
                game.Stage));
        }

        void game_NextStage(object sender, EventArgs e)
        {
            alreadyWin = false;
            buttons.Clear();
            panel1.Controls.Clear();
            foreach (Star star in game.Source)
            {
                Button b = new ButtonEx();
                b.BackColor = star.Color;
                b.FlatAppearance.BorderColor = Color.White;
                b.FlatAppearance.BorderSize = 2;
                b.Parent = panel1;
                b.Tag = star;
                b.Click += new EventHandler(b_Click);
                b.DoubleClick += new EventHandler(b_DoubleClick);
                buttons.Add(b);
            }
            JustifySize();
            stageToolStrip.Text = string.Format("第{0}关:{1}分", game.Stage, game.ScoreTarget);
            statusToolStrip.Text = game.Stage == 1?"新的一局~~好运！":string.Empty;
            scoreToolStrip.Text = string.Format("总分：{0}", game.Score);
        }

        private void b_Click(object sender, EventArgs e)
        {
            foreach (var item in buttons)
            {
                item.FlatStyle = FlatStyle.Standard;
            }

            Button current = sender as Button;
            List<Star> neighbour = game.FindNeighbour(current.Tag as Star);
            foreach (Star star in neighbour)
            {
                Button b = FindButton(star);
                if (b == null)
                {
                    throw new ArgumentException(Resources.FindWrongNeighbour);
                }
                b.FlatStyle = FlatStyle.Flat;
            }
            int score = game.CalculateScore(neighbour.Count);
            statusToolStrip.Text = string.Format("选中{0}个,{1}分", neighbour.Count, score);
        }

        private Button FindButton(Star star)
        {
            return buttons.Find(b => star.Equals(b.Tag));
        }

        private void b_DoubleClick(object sender, EventArgs e)
        {
            Button current = sender as Button;
            List<Star> neighbour = game.FindNeighbour(current.Tag as Star);
            if (neighbour.Count < 2)
            {
                return;
            }
            foreach (Star star in neighbour)
            {
                Button b = FindButton(star);
                if (b == null)
                {
                    throw new ArgumentException(Resources.FindWrongNeighbour);
                }
                panel1.Controls.Remove(b);
                buttons.Remove(b);
            }
            game.Remove(neighbour);
            JustifyLocation();
            if (game.Score > game.ScoreTarget && alreadyWin == false)
            {
                alreadyWin = true;
                statusToolStrip.Text = "恭喜，过关啦！";
                sounds[WIN].Play();
            }
            else
            {
                sounds[POP].Play();
            }            
            scoreToolStrip.Text = string.Format("总分：{0}", game.Score);
        }

        private void JustifyLocation()
        {
            foreach (var item in buttons)
            {
                Star s = item.Tag as Star;
                item.Location = new Point(s.Y * height, s.X * height);
            }
        }

        private void JustifySize()
        {
            this.ClientSize = new Size(size * height + 2 * border,
                size * height + menuStrip1.Height + statusStrip1.Height + 2 * border);

            if (buttons == null)
            {
                return;
            }

            foreach (var item in buttons)
            {
                if (item == null)
                {
                    continue;
                }
                item.Size = new Size(height, height);
                Star s = item.Tag as Star;
                item.Location = new Point(s.Y * height, s.X * height);
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
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TestGame
{
    public partial class Form1 : Form
    {
        int X;
        int Y;
        int amount;
        int ground;
        bool jump;
        int Fall;

        public Form1()
        {
            InitializeComponent();

            ground = pictureBox1.Location.Y - pictureBox2.Height;
            X = 0;
            Y = ground;
            amount = 0;
            jump = false;
            Fall = 999;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           if (pictureBox1.Width + pictureBox1.Location.X < X || pictureBox1.Location.X > X)
            {
                ground = Fall;
                if (Y == Fall)
                {
                    ground = pictureBox1.Location.Y - pictureBox2.Height;
                    Y = ground;
                    X = 0;
                }
            }
        }

        private void Gravity()
        {
            if ((ground - 2) >= Y)
            {
                Y = Y + 2;
            }
            else
            {
                if (ground >= Y)
                {
                    Y = ground;
                }
            }
        }

        private void Updater_Tick(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(X, Y);

            Gravity();
            Jump();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                MoveLeft();
            }

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                MoveRight();
            }

            if (e.KeyCode == Keys.Space)
            {
                if (Y == ground)
                {
                    jump = true;
                }
            }
        }

        private void MoveLeft()
        {
            X = X - 10;
        }

        private void MoveRight()
        {
            X = X + 10;
        }

        private void Jump()
        {
            if (jump == true)
            {
                if (amount == 7)
                {
                    jump = false;
                    amount = 0;
                }
                else
                {
                    Y = Y - 10;
                    amount = amount + 1;
                }
            }
        }
    }
}

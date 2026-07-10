using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
        bool isPlayer1Turn = true;
        int moveCount = 0;
        List<PictureBox> Boxes;

        public Form1()
        {
            InitializeComponent();

            pictureBox1.Click += pictureBox_Click;
            pictureBox2.Click += pictureBox_Click;
            pictureBox3.Click += pictureBox_Click;
            pictureBox4.Click += pictureBox_Click;
            pictureBox5.Click += pictureBox_Click;
            pictureBox6.Click += pictureBox_Click;
            pictureBox7.Click += pictureBox_Click;
            pictureBox8.Click += pictureBox_Click;
            pictureBox9.Click += pictureBox_Click;

            Boxes = new List<PictureBox>(){
                pictureBox1 , pictureBox2 , pictureBox3 , 
                pictureBox4 , pictureBox5 ,pictureBox6 , 
                pictureBox7 , pictureBox8 , pictureBox9
            };
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.FromArgb(255, 255, 255, 255);

            Pen pen = new Pen(White);
            pen.Width = 10;

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(pen, 550, 100, 550, 430);
            e.Graphics.DrawLine(pen, 660, 100, 660, 430);
            e.Graphics.DrawLine(pen, 420, 210, 790, 210);
            e.Graphics.DrawLine(pen, 420, 320, 790, 320);

            pen.Dispose();
        }

        private void EndGame()
        {

            foreach (var box in Boxes)
            {
                box.Enabled = false;
            }
            
            lblTurn.Text = "Game Over";
            MessageBox.Show("Game Over", "End Game");
        }

        private bool CheckValues(PictureBox pb1, PictureBox pb2, PictureBox pb3)
        {
            if (pb1.Tag.ToString() != "?" && pb1.Tag.ToString() == pb2.Tag.ToString() &&
                pb1.Tag.ToString() == pb3.Tag.ToString())
            {
                pb1.BackColor = pb2.BackColor = pb3.BackColor = Color.Green;

                if (pb1.Tag.ToString() == "X")
                {
                    lblWinner.Text = "Player1";
                    EndGame();
                    return true;
                }
                else
                {
                    lblWinner.Text = "Player2";
                    EndGame();
                    return true;
                }
            }

            return false;
        }

        private void WhoIsTheWinner()
        {
            if (CheckValues(pictureBox1, pictureBox2, pictureBox3))
                return;

            if (CheckValues(pictureBox4, pictureBox5, pictureBox6))
                return;

            if (CheckValues(pictureBox7, pictureBox8, pictureBox9))
                return;

            if (CheckValues(pictureBox1, pictureBox6, pictureBox9))
                return;

            if (CheckValues(pictureBox2, pictureBox5, pictureBox8))
                return;

            if (CheckValues(pictureBox3, pictureBox4, pictureBox7))
                return;

            if (CheckValues(pictureBox1, pictureBox5, pictureBox7))
                return;

            if (CheckValues(pictureBox3, pictureBox5, pictureBox9))
                return;

            if (moveCount == 9)
            {
                lblWinner.Text = "Draw";
                EndGame();
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;

            if (pb.Tag.ToString() == "X" || pb.Tag.ToString() == "O")
                return;

            if (isPlayer1Turn)
            {
                pb.Image = Resources.X;
                pb.Tag = "X";
                lblTurn.Text = "Player2";
                isPlayer1Turn = false;
                moveCount++;
            }
            else
            {
                pb.Image = Resources.O;
                pb.Tag = "O";
                lblTurn.Text = "Player1";
                isPlayer1Turn = true;
                moveCount++;
            }

            WhoIsTheWinner();
        }

        private void RestartGame()
        {
            lblWinner.Text = "In Progress";
            lblTurn.Text = "Player1";
            isPlayer1Turn = true;
            moveCount = 0;

            foreach (var Box in Boxes)
            {
                Box.Enabled = true;
                Box.Image = Resources.question_mark_96;
                Box.Tag = "?";
                Box.BackColor = Color.Black;
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
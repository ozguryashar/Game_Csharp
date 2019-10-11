using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Last_Code
{
    public partial class Form1 : Form
    {
        public int speed_left = 4;  // speed of ball
        public int speed_top = 4;   
        public int points = 0;       //Scored Point

        public Form1()
        {
            InitializeComponent();

            timer1.Enabled = true;
            Cursor.Hide();                                      //Hide the Cursor
            this.FormBorderStyle = FormBorderStyle.None;        //Remove any border
            this.TopMost = true;                                //Bring form to the front
            this.Bounds = Screen.PrimaryScreen.Bounds;          //make it full screen

            racket.Top =  playground.Bottom - (playground.Bottom / 10);  //Set the position of the racket

            gameover_lbl.Visible = false;  // Hide The Game Over Text


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            racket.Left = Cursor.Position.X - (racket.Width /2);  // SEt the  center of the racket  to the position  of the cursor
            ball.Left += speed_left;   // Move the ball
            ball.Top += speed_top; 
            if (ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left  && ball.Right <= racket.Right ) 
                // racket collision
            {
                speed_top += 2;
                speed_left += 2;
                speed_top = -speed_top;  // Change Direction
                points += 1;
                points_lbl.Text = points.ToString();

                Random r = new Random();
                playground.BackColor = Color.FromArgb(r.Next(150, 255), r.Next(150, 255), r.Next(150, 255));

            }

            if (ball.Left <= playground.Left)
            {
                speed_left = -speed_left;
            }
            if (ball.Right  >= playground.Right)
            {
                speed_left = -speed_left;
            }
            if(ball.Top <= playground.Top)
            {
                speed_top = -speed_top;
            }
            if(ball.Bottom  >=  playground.Bottom)
            {
                timer1.Enabled = false;  // Ball is out. Stop The game
                gameover_lbl.Visible = true; 
            }







        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { this.Close(); } // Press Escape to Quit
            if(e.KeyCode == Keys.Space)
            {
                ball.Top = 50;
                ball.Left = 50;
                speed_left = 4;
                speed_top = 4;
                points = 0;
                points_lbl.Text = "0";
                timer1.Enabled = true;
                gameover_lbl.Visible = false;
                playground.BackColor = Color.White;

            }
        }




    }
}

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySnake
{
    public partial class Form1 : Form
    {
        //Snake is object creted from circles
        private List<Circle> Snake = new List<Circle>();
        //also food is created from circles
        private Circle food = new Circle();

        public Form1()
        {
            InitializeComponent();

            //settings to default
            new Settings();

            //set game speed and start timer
            GameTimer.Interval = 1000 / Settings.Speed;
            GameTimer.Tick += UpdateScreen;
            GameTimer.Start();

            //Start New Game
            StartGame();
        }

        private void StartGame()
        {
            GAmeOverLabel.Visible = false;

            //set settings to default
            new Settings();

            //create snake object
            Snake.Clear();
            Circle head = new Circle();
            head.X = 10;
            head.Y = 5;
            Snake.Add(head);

            ActualScoreLabel.Text = Settings.Score.ToString();

            GenerateFood();
        }

        //Place random food
        private void GenerateFood()
        {
            int maxXposition = SnakeBackgroundPictureBox.Size.Width/Settings.Width;
            int maxYposition = SnakeBackgroundPictureBox.Size.Height/Settings.Height;

            Random random = new Random();
            food = new Circle();
            food.X = random.Next(0, maxXposition);
            food.Y = random.Next(0, maxYposition);
                
        }

        private void UpdateScreen(object sender, EventArgs e)
        { 
            //Check for game over
            if(Settings.GameOver == true)
            {
                //Check if enter is pressed
                if(Input.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }

            }
            else
            {
                if(Input.KeyPressed(Keys.Right)&& Settings.direction != Direction.Left)
                {
                    Settings.direction = Direction.Right;
                }
                else if(Input.KeyPressed(Keys.Left) && Settings.direction != Direction.Right)
                {
                    Settings.direction = Direction.Left;
                }
                else if (Input.KeyPressed(Keys.Up) && Settings.direction != Direction.Down)
                {
                    Settings.direction = Direction.Up;
                }
                else if (Input.KeyPressed(Keys.Down) && Settings.direction != Direction.Up)
                {
                    Settings.direction = Direction.Down;
                }


                MovePlayer();

            }
            SnakeBackgroundPictureBox.Invalidate();

        }

        private void SnakeBackgroundPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics background = e.Graphics;

            if(!Settings.GameOver)
            {
                Brush snakeColour;

                for(int i =0; i< Snake.Count; i++)
                {

                    if(i==0)
                    {
                        snakeColour = Brushes.Black; //Draw head
                    }
                    else
                    {
                        snakeColour = Brushes.Green;
                    }

                    //draw snake
                    background.FillEllipse(snakeColour, new Rectangle(Snake[i].X * Settings.Width, Snake[i].Y * Settings.Height, Settings.Width, Settings.Height));

                    background.FillEllipse(Brushes.Red, new Rectangle(food.X * Settings.Width, food.Y * Settings.Height, Settings.Width, Settings.Height));


                }
            }
            else
            {
                string gameOver = "Game Over \nYour final score is: " + Settings.Score + "\nPress Enter t try again";
                GAmeOverLabel.Text = gameOver;
                GAmeOverLabel.Visible = true;
            }
              
        }
    
        private void MovePlayer()
        {
            for(int i = Snake.Count - 1 ; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Direction.Right:
                            Snake[i].X++;
                            break;
                        case Direction.Left:
                            Snake[i].X--;
                            break;
                        case Direction.Up:
                            Snake[i].Y--;
                            break;
                        case Direction.Down:
                            Snake[i].Y++;
                            break;
                    }
                }
                else
                {
                    //Move body
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }
    }
}

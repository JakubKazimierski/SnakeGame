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
    public partial class MainWindow : Form
    {
        //Snake is object creted from circles
        private List<Circle> Snake = new List<Circle>();
        //also food is created from circles
        private Circle food = new Circle();

        public MainWindow()
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
            
            //bool flag to check if food won't generate on snake
            bool freeSpaceFlag = false;

            //while loop to prevent loading food on snake
            while (freeSpaceFlag != true)
            {

                Random random = new Random();

                int Xrandom = random.Next(0, maxXposition);
                int Yrandom = random.Next(0, maxYposition);

                for (int i = 0; i <= Snake.Count - 1; i++)
                {
                    if (Xrandom == Snake[i].X && Yrandom == Snake[i].Y)
                    {
                        break;
                    }
                    else
                    {

                        food = new Circle();
                        food.X = Xrandom;
                        food.Y = Yrandom;
                        freeSpaceFlag = true;
                    }


                }
            }

            freeSpaceFlag = false;
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
                        snakeColour = Brushes.Lime;
                    }

                    //draw snake
                    background.FillEllipse(snakeColour, new Rectangle(Snake[i].X * Settings.Width, Snake[i].Y * Settings.Height, Settings.Width, Settings.Height));

                    background.FillEllipse(Brushes.Red, new Rectangle(food.X * Settings.Width, food.Y * Settings.Height, Settings.Width, Settings.Height));


                }
            }
            else
            {
                string gameOver = "Game Over \nYour final score is: " + Settings.Score + "\nPress Enter to try again";
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

                    //get max X and Y position
                    int maxXposition = SnakeBackgroundPictureBox.Size.Width / Settings.Width;
                    int maxYposition = SnakeBackgroundPictureBox.Size.Height / Settings.Height;

                    //detect collision with borders
                    if( Snake[i].X < 0 || Snake[i].Y < 0 || Snake[i].X > maxXposition || Snake[i].Y > maxYposition)
                    {
                        Die();
                    }

                    //detect body snake collision
                    for(int j= 1; j< Snake.Count; j++)
                    {
                        if(Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            Die();
                        }
                    }

                    if(Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        Eat();
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

        private void Die()
        {
            Settings.GameOver = true;
        }

        private void Eat()
        {
            Circle food = new Circle();
            food.X = Snake[Snake.Count - 1].X;
            food.Y = Snake[Snake.Count - 1].Y;

            Snake.Add(food);

            //add score
            //refresh labelscore
            Settings.Score += Settings.Points;
            ActualScoreLabel.Text = Settings.Score.ToString();

            GenerateFood();
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging;

namespace SnakeBiteGame
{
    public partial class SnakeGame : Form
    {
        // List that will contain position of snake
        private List<circle> snake = new List<circle>();
        // instance of circle class that will create food for snake both snake and food has similar propeerty as both are instances of circle class
        private circle food = new circle();

        //maxwidth of the snake Game Board
        int maxwidth;
        //maxheight of the snake game Board
        int maxheight;


        int score;
        int highscore;

        Random rand = new Random();

        bool goleft, goright, godown, goup;



        public SnakeGame()
        {
            InitializeComponent();

            //initialise the setting class in constructor of the class so that our basic information of
            // snake can be initialise
            new setting();

        }

        private void StartButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This function takes care when keydown is pressed or entered by the end user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            // initialise values to our bool varible based on the arrow key that is pressed by the end user
            //based on the key entered we are setting up true to that varible
            if (e.KeyCode == Keys.Left && setting.directtions != "right")
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right && setting.directtions != "left")
            {
                goright = true;
            }
            if (e.KeyCode == Keys.Up && setting.directtions != "down")
            {
                goup = true;
            }
            if (e.KeyCode == Keys.Down && setting.directtions != "up")
            {
                godown = true;
            }

        }
        /// <summary>
        /// This Method will take care of the snake movement direction when Key is not down
        /// it will set up the bool value as false to make assure that without end user instruction the snake will follow he same path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyIsUP(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }



        }
        /// <summary>
        /// Method come into existance when start button is clicked
        /// function class a static method restrtthegame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartTheGame(object sender, EventArgs e)
        {
            RestarttoGame();
        }

        /// <summary>
        /// Method come into existance when snap button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Takesnapshot(object sender, EventArgs e)
        {
            // setting up the caption for gamecanvas as we have to store it into a jpg file.
            Label caption = new Label();
            caption.Text = "I scored: " + score + " and my  Highscore is "+highscore+" on the snake game";
            caption.Font = new Font("Ariel", 12, FontStyle.Bold);
            caption.ForeColor = Color.AliceBlue;
            caption.AutoSize = false;
            caption.Height = 30;
            caption.TextAlign = ContentAlignment.MiddleCenter;
            //end of setting up caption
            //add the caption to the controls of game canvas Board
            PictureGameCanvas.Controls.Add(caption);

            // create an instance if savefiledialog(it is a class the is available into system.drawing.imaging namespace )
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "Snake Bite Game";//providing the filename
            dialog.DefaultExt = "jpg";//providing the extension type of the file
            dialog.Filter = "Jpg Image File | *.jpg";//setting up the format of the file
            dialog.ValidateNames = true; //call for validate names on di

            //if user press enter on the save file dialog box created after clicking on snap button of the game
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(PictureGameCanvas.Width);
                int height = Convert.ToInt32(PictureGameCanvas.Height);
                //creating an instance of bitmap class and provide width and height to the constructor of it
                //Bitmap is class which will use to deal with images based on the pixel data
                Bitmap map = new Bitmap(width, height);
                PictureGameCanvas.DrawToBitmap(map, new Rectangle(0, 0, width, height));
                //finally save the image
                map.Save(dialog.FileName, ImageFormat.Jpeg);
                //remove the caption as we only need it in snapshot.
                PictureGameCanvas.Controls.Remove(caption);
            }

        }

        /// <summary>
        /// This event is or main Method for game we will bind all functions here that will handle the 
        /// flow of our snake bite game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gametimerevent(object sender, EventArgs e)
        {
            //setting the directions

            if(goleft)
            {
                setting.directtions = "left";
            }
            if(goright)
            {
                setting.directtions = "right";
            }
            if(godown)
            {
                setting.directtions = "down";
            }
            if(goup)
            {
                setting.directtions = "up";
            }
            //end of directions

            //this for loop takes care of all the movement of snake  and its part
            //and action we have to take on specific condition
            //we will start traversing from length of snake and end endup with head of snake
            for (int i = snake.Count - 1; i >= 0; i--)
            {
                //head position of snake 
                if (i == 0)
                {

                    //setting up the actions based on specific direction of head movment
                    //this cases defines the direction of body part of snake based on the direction of the head of the snake
                    switch (setting.directtions)
                    {
                        case "left":
                            snake[i].x--;// for left direction we have to decrease the x
                            break;
                        case "right":
                            snake[i].x++;//for right direction we have to increase the x
                            break;
                        case "down"://for down increase the y
                            snake[i].y++;
                            break;
                        case "up":
                            snake[i].y--;// for up decrease the y
                            break;



                    }
                    // this cases will take care of scenerio where snake crosses the maxwidth and maxheight of the canvas 
                    // if horizontal(x) of snake becomes less than 0 we set it to maxwidth and if becomes greater than maxwidth than we restart the snake from 0
                    //if vertical(y) of snake become less than 0 we set it to maxheight and if it becomes greater than maxheight we restart the snake from 0
                    if (snake[i].x < 0) 
                    {
                        snake[i].x = maxwidth;
                    }
                    if (snake[i].x > maxwidth)
                    {
                        snake[i].x = 0;
                    }
                    if (snake[i].y < 0)
                    {
                        snake[i].y = maxheight;
                    }
                    if (snake[i].y > maxheight)
                    {
                        snake[i].y = 0;
                    }

                    //checking for colloison of head of snake and food .
                    
                    if(snake[i].x == food.x && snake[i].y==food.y)
                    {
                        Eatfood();
                    }

                    //traverse for body of the snake
                    for(int j = 1;j<snake.Count;j++)
                    {
                        //checking for condition where snake head position becomes same as snake body position
                        // which means snake head and body collide and its time for game over
                        if(snake[i].x == snake[j].x && snake[i].y == snake[j].y)
                        {
                            gameover();
                        }
                    }

                }
                else
                {
                    //moving other parts of snake body along with head
                    snake[i].x = snake[i - 1].x;
                    snake[i].y = snake[i - 1].y;
                }
            }
            //reinitialise the game canvas board
            PictureGameCanvas.Invalidate();
        }

        /// <summary>
        /// this is where we see snake head and body parts moving
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdatePictureBoxGrphics(object sender, PaintEventArgs e)
        {
            //setting up the new instance canvas of graphics class and initialise it with paint event
            Graphics canvas = e.Graphics;

            Brush snakecolour; //create a new brush for snakecolor

            //traverse for snake 
            for (int i = 0; i < snake.Count; i++)
            {
                if (i == 0)
                {
                    //color the head of the snake black
                    snakecolour = Brushes.Black;
                }
                else
                {
                    //color the rest body of the snake
                    snakecolour = Brushes.DarkGreen;
                }

                //draw snake heads and other parts
                canvas.FillEllipse(snakecolour, new Rectangle
                {
                    X = snake[i].x * setting.width,
                    Y=snake[i].y * setting.height,
                    Width=setting.width,
                    Height=setting.height



                }) ;
            }
            //draw food for snake
            canvas.FillEllipse(Brushes.Chocolate, new Rectangle
            {
                X = food.x * setting.width,
                Y = food.y * setting.height,
                Width = setting.width,
                Height = setting.height



            });




        }

        private void GameScoreLabel_Click(object sender, EventArgs e)
        {

        }

        private void PictureGameCanvas_Click(object sender, EventArgs e)
        {

        }

        private void RestarttoGame()
        {
            //set up the maxwidth and maxheight that will restrict the snake to be always under canvas width and canvas height
            maxwidth = PictureGameCanvas.Width / setting.width - 1;
            maxheight = PictureGameCanvas.Height / setting.height - 1;

            //clear the snake list  to start with a fresh
            snake.Clear();

            // disable the buttons as we do not want that at the time of play someone hit enter on those button
            StartButton.Enabled = false;
            SnapButton.Enabled = false;
            score = 0;//set up the initial score
            GameScore.Text = "Score" + score;

            //create the head of the snake and put it inthe middle of the screen
            circle head = new circle { x = 10, y = 5 };
            snake.Add(head);

            //add proper length of the snake which meand body of the snake
            for(int i =0; i<10; i++)
            {
                circle body = new circle();
                snake.Add(body);
            }
            // randomly create food at differnt position 
            food = new circle { x = rand.Next(2, maxwidth), y = rand.Next(rand.Next(2, maxheight)) };

            //start the timer as from now end user is ready to play the game
            GameTimer.Start();


        }
        /// <summary>
        /// This function will take care of snake whenever it eat food
        /// </summary>
        private void Eatfood()
        {
            //increse the score by 1.
            score += 1;
            //display the increse score
            GameScore.Text = "Score : " + score;
            //add one more position in the snake 
            circle body = new circle
            {
                x = snake[snake.Count - 1].x,
                y = snake[snake.Count - 1].y
            };
            snake.Add(body);

            //initilase the new position for the snake food
            food = new circle { x = rand.Next(2, maxwidth), y = rand.Next(2, maxheight) };
        }

        /// <summary>
        /// This function comes into play when snake head collide with snake body
        /// </summary>
        private void gameover()
        {
            // stop the gametimer
            GameTimer.Stop();
            //enabled the buttons for the end user
            StartButton.Enabled = true;
            SnapButton.Enabled = true;

            // if game score is greater than highscore than replace the highscore with newly created record
            if(score > highscore )
            {
                highscore = score;
                GamesHighScore.Text = "High Score : " + Environment.NewLine + highscore;
                GamesHighScore.ForeColor = Color.Blue;
                GamesHighScore.TextAlign = ContentAlignment.MiddleCenter;
            }
        }
    }
    
}




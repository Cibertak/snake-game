using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        
        string s_Direction; 
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        string[] s_TopScore;
        Boolean bol_Rainbow = false; 
        string s_TopscoreKeeper, s_TopScoreNameKeeper, s_NameNew = "AAA";
        public static int i_scorePosition;
        int i_score = 1;
        Graphics g;
        List<Point> snake = new List<Point>();
        List<Point> apple = new List<Point>();
        int i_applex, i_appley;
        Random r_apple = new Random();
        int i_SnakeLengthGrowth;
        Boolean bol_IsAGameAlreadyBeingPlayed = false;
        TopScoreVewing frm = new TopScoreVewing();
        int i_SnakeColorIdentafier;
        public static int i_speed = 0;
        public static bool bol_justshowscores = false;


        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }
        
        private void gamestart()
        {
            if (!bol_IsAGameAlreadyBeingPlayed) //This is placed here to make sure that another game is not started while one game is alrady happening.
            {
                myTimer = new Timer();
                myTimer.Tick += new EventHandler(SnakeMove);
                myTimer.Tick += new EventHandler(checkCollision);
                i_SnakeColorIdentafier = 1;
                s_Direction = "null"; // you dont start moving at the start untill you have selected a direction to move.
                i_SnakeLengthGrowth = 0;
                i_score = 1;
                lbl_score.Text = "Score: 1";
                i_applex = 0;
                i_appley = 0;
                g.Clear(Color.White);
                g.FillRectangle(Brushes.White, 0, 0, 401, 401);
                g.DrawRectangle(Pens.Blue, 0, 0, 401, 401);
                snake.Clear();
                snake.Add(new Point(201, 201));
                Point start = snake[0];
                g.FillRectangle(Brushes.Black, start.X, start.Y, 10, 10);
                apple_spawn();
                bol_IsAGameAlreadyBeingPlayed = true;
                Timetick();
            }
        }

        private void Timetick()
        {
            // Sets the timer interval to whichever you selected when you started.
            myTimer.Interval = i_speed;
            myTimer.Start();
            Application.DoEvents();
        }

        private void apple_spawn()
        {
            if (i_applex == 0 && i_appley == 0) //not using a point list system means that only one apple is in play at a time.
            {
                StartPosition:
                i_applex = r_apple.Next(0, 40);
                i_appley = r_apple.Next(0, 40);
                i_applex = (i_applex * 10) + 1;
                i_appley = (i_appley * 10) + 1;
                for (int i_count = 0; i_count <= snake.Count - 1; i_count++)
                {
                    Point check = snake[i_count];
                    if (i_applex == check.X && i_appley == check.Y) { goto StartPosition; } //if the selected x and y match a point in the snake a new point is found.
                }
                g.FillRectangle(Brushes.DarkRed, i_applex, i_appley, 10, 10); // show the apple
            }
        }

        private void SnakeMove(Object myObject,EventArgs myEventArgs)
        {
            switch (s_Direction)
            {

                case "up":

                    Point currentHead = snake[snake.Count - 1];
                    if (currentHead.Y - 10 > -1) //checks if the next point will be outside the border and if not fills it in.
                    {
                        snake.Add(new Point(currentHead.X, currentHead.Y - 10));
                        SnakeColorFill(currentHead.X, currentHead.Y - 10); // moves to diffrent class to fill the actuall next point in. 
                        if (i_SnakeLengthGrowth == 0) { Remove(); } //if the snake dosent need to grow, it removes the last point.
                        else { i_SnakeLengthGrowth -= 1; } //otherwise it will wont remove the last point then take 1 off its grow count.
                    }
                    else { gameover(); } //if its outside the border then gameover.
                    break;

                case "down":
                    
                    currentHead = snake[snake.Count - 1];
                    if (currentHead.Y + 10 < 400) //checks if the next point will be outside the border and if not fills it in
                    {
                        snake.Add(new Point(currentHead.X, currentHead.Y + 10));
                        SnakeColorFill(currentHead.X, currentHead.Y + 10); // moves to diffrent class to fill the actuall next point in. 
                        if (i_SnakeLengthGrowth == 0) { Remove(); } //if the snake dosent need to grow, it removes the last point.
                        else { i_SnakeLengthGrowth -= 1; } //otherwise it will wont remove the last point then take 1 off its grow count.
                    }
                    else { gameover(); } //if its outside the border then gameover.
                    break;
                case "left":
                    
                    currentHead = snake[snake.Count - 1];
                    if (currentHead.X - 10 > -1) //checks if the next point will be outside the border and if not fills it in
                    {
                        snake.Add(new Point(currentHead.X - 10, currentHead.Y));
                        SnakeColorFill(currentHead.X - 10, currentHead.Y); // moves to diffrent class to fill the actuall next point in. 
                        if (i_SnakeLengthGrowth == 0) { Remove(); } //if the snake dosent need to grow, it removes the last point.
                        else { i_SnakeLengthGrowth -= 1; } //otherwise it will wont remove the last point then take 1 off its grow count.
                    }
                        else { gameover(); } //if its outside the border then gameover.
                    break;
                case "right":
                    
                    currentHead = snake[snake.Count - 1];
                    if (currentHead.X + 10 < 400) //checks if the next point will be outside the border and if not fills it in
                    {
                        snake.Add(new Point(currentHead.X + 10, currentHead.Y));
                        SnakeColorFill(currentHead.X + 10, currentHead.Y); // moves to diffrent class to fill the actuall next point in. 
                        if (i_SnakeLengthGrowth == 0) { Remove(); } //if the snake dosent need to grow, it removes the last point.
                        else { i_SnakeLengthGrowth -= 1; } //otherwise it will wont remove the last point then take 1 off its grow count.
                    }
                    else { gameover(); } //if its outside the border then gameover.
                    break;
            }
        }

        private void SnakeColorFill(int PaintX, int PaintY)
        {
            switch(i_SnakeColorIdentafier) //used to chang the color of the snake
            {
                case 1:
                    //black
                    g.FillRectangle(Brushes.Black, PaintX, PaintY, 10, 10);
                    if (bol_Rainbow) { i_SnakeColorIdentafier += 1; }
                    break;
                case 2:
                    //Red
                    g.FillRectangle(Brushes.Red, PaintX, PaintY, 10, 10);
                    if (bol_Rainbow){i_SnakeColorIdentafier += 1;}
                    break;
                case 3:
                    //orange
                    g.FillRectangle(Brushes.Orange, PaintX, PaintY, 10, 10);
                    if (bol_Rainbow) { i_SnakeColorIdentafier += 1; }
                    break;
                case 4:
                    //yellow
                    g.FillRectangle(Brushes.Yellow, PaintX, PaintY, 10, 10);
                    if (bol_Rainbow) { i_SnakeColorIdentafier += 1; }
                    break;
                case 5:
                    //green
                    g.FillRectangle(Brushes.Green, PaintX, PaintY, 10, 10);
                    if (bol_Rainbow) { i_SnakeColorIdentafier += 1; }
                    break;
                case 6:
                    //blue
                    g.FillRectangle(Brushes.Blue, PaintX, PaintY, 10, 10);
                    if (bol_Rainbow) { i_SnakeColorIdentafier += 1; }
                    break;
                case 7:
                    //indigo
                    g.FillRectangle(Brushes.Indigo, PaintX, PaintY, 10, 10);
                    if (bol_Rainbow) { i_SnakeColorIdentafier += 1; }
                    break;
                case 8:
                    //violet
                    g.FillRectangle(Brushes.Violet, PaintX, PaintY, 10, 10);
                    if (bol_Rainbow) { i_SnakeColorIdentafier = 2; } // used to return to the begging of the color rotation, ignoring black to make the snake more colorfull.
                    break;
            }




        }

        private void Remove()
        {
            //removes last point of snake when appropeate
            Point end = snake[0];
            g.FillRectangle(Brushes.White, end.X, end.Y, 10, 10);
            snake.RemoveAt(0);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up: { if (s_Direction != "down") { s_Direction = "up";  } break; }
                case Keys.Down: { if (s_Direction != "up") { s_Direction = "down"; } break; }
                case Keys.Left: { if (s_Direction != "right") { s_Direction = "left"; } break; }
                case Keys.Right: { if (s_Direction != "left") { s_Direction = "right"; } break; }
            }
            return true;
        }

        private void btn_Slow_Click(object sender, EventArgs e)
        {
            //starts the game with the selected speed
            i_speed = 100;
            gamestart();
        }

        private void btn_average_Click(object sender, EventArgs e)
        {
            //starts the game with the selected speed
            i_speed = 75;
            gamestart();
        }

        private void btn_fast_Click(object sender, EventArgs e)
        {
            //starts the game with the selected speed
            i_speed = 50;
            gamestart();
        }
        
        private void btn_showscoreslow_Click(object sender, EventArgs e)
        {
            //shows the scores for the slow speed games
            i_speed = 100;
            bol_justshowscores = true;
            TopScoreVewing frm = new TopScoreVewing();
            frm.Show();
        }

        private void btn_showscoreaverage_Click(object sender, EventArgs e)
        {
            //shows the scores for the average speed games
            i_speed = 75;
            bol_justshowscores = true;
            TopScoreVewing frm = new TopScoreVewing();
            frm.Show();
        }

        private void btn_showscorefast_Click(object sender, EventArgs e)
        {
            //shows the scores for the fast speed games
            i_speed = 50;
            bol_justshowscores = true;
            TopScoreVewing frm = new TopScoreVewing();
            frm.Show();
        }

        private void checkCollision(Object myObject, EventArgs myEventArgs)
        { 
                //used to check that the head of the snake is not hit any othe part of itself.
                Point head = snake[snake.Count - 1];
                for (int i_count = 0; i_count < snake.Count - 1; i_count++)
                {
                    Point check = snake[i_count];
                    if (head.X == check.X && head.Y == check.Y) { gameover(); }
                    else { }
                }
                //used to check if the snake has hit the apple.
                if (head.X == i_applex && head.Y == i_appley)
                {
                    i_SnakeColorIdentafier += 1; // switch the color of the snake.
                    if (bol_Rainbow) { bol_Rainbow = false; i_SnakeColorIdentafier = 2; } //gose from rainbow snake to full color snakes starting with red. ignoring black.
                    if (i_SnakeColorIdentafier == 9 && !bol_Rainbow) { bol_Rainbow = true; i_SnakeColorIdentafier = 2; } //when you have cicled through once it switches to rainbow
                    i_appley = 0;
                    i_applex = 0;
                    i_SnakeLengthGrowth = 5; // identafier to allow snake to grow.
                    apple_spawn();
                    i_score += 5; // adds 5 to score(1 point for each park of the snake body added)
                    lbl_score.Text = "Score: " + Convert.ToString(i_score); // shows score
                    for (int i_count = 0; i_count <= snake.Count - 1; i_count++)
                    {
                        //fills the rest of the snake with the same color 
                        Point current = snake[i_count];
                        SnakeColorFill(current.X, current.Y);
                    }
                }                  
        }

        private void gameover()
        {
            myTimer.Stop();
            MessageBox.Show("Game Over","Game Over");
            bol_IsAGameAlreadyBeingPlayed = false;
            SaveScore();
        }

        private void SaveScore()
        {
            //saves score
            int i_countname = 2;
            //opens the score bord file depending on the speed.
            if(i_speed == 100) { s_TopScore = System.IO.File.ReadAllLines("Top Scores(slow).Txt"); }
            if (i_speed == 75) { s_TopScore = System.IO.File.ReadAllLines("Top Scores(average).Txt"); }
            if (i_speed == 50) { s_TopScore = System.IO.File.ReadAllLines("Top Scores(fast).Txt"); }

            for (int i_count = 3; i_count <= 30; i_count += 3, i_countname += 3)
            {
                //checks to see if your score is grater than any in the top score list.(starting at #1) (note: th scores are recorded on every 3rd line in the file starting from line 3 as line 0 is the name of file.)
                if(i_score > Convert.ToUInt16(s_TopScore[i_count]))
                {
                    MessageBox.Show("congrats you got the #" + Convert.ToString(i_count/3) + " score"); //sas whitch top score place you got was
                    i_scorePosition = i_count / 3;
                    while (i_count <= 30) // dosent reset i_count so you dont mess with the other scores above where it currently is.
                    {
                        //used to move the scores down to make room for the new one( getting rig of the old #10 one)
                        s_TopscoreKeeper = s_TopScore[i_count]; //stores the old score
                        s_TopScore[i_count] = Convert.ToString(i_score); //puts in the new score
                        i_score = Convert.ToInt16(s_TopscoreKeeper); //then reuse i_score to keep the old name insteed of using a new veriable.
                        
                        //used to move the names associated with the scores down to make room for the new one( getting rig of the old #10 one)
                        s_TopScoreNameKeeper = s_TopScore[i_countname]; // stored the old name.
                        s_TopScore[i_countname] = s_NameNew; //s_name new is to set the name spot to defult witch is AAA.
                        s_NameNew = s_TopScoreNameKeeper; //then reuse s_newname to keep the old name insteed of using a new veriable.
                        
                        //moves to net score point
                        i_count += 3;
                        i_countname += 3;
                    }
                    if (i_speed == 100) { System.IO.File.WriteAllLines("Top Scores(slow).Txt", s_TopScore); }
                    if (i_speed == 75) { System.IO.File.WriteAllLines("Top Scores(average).Txt", s_TopScore); }
                    if (i_speed == 50) { System.IO.File.WriteAllLines("Top Scores(fast).Txt", s_TopScore); }
                    bol_justshowscores = false;
                    frm.Show();
                    this.Hide();
                    i_countname -= 10;
                }
            }
            if (i_countname > 30) //if you dont place in the top scores you are told so
            {
                DialogResult dialogResult = MessageBox.Show("sorry but you didnt get a top score this time, would you like to try again", "game over", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No) { Application.Exit(); }
            }
        }

    }

}

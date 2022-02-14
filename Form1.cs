using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Tennis
{



    public partial class Form1 : Form
    {
        System.Media.SoundPlayer _ballRebound, _racketHit, _crowdMissed, _cheer, _applause;
        int _totalPoints = 0;
        int _totalMisses = 0;
        int MAXMISSES = 10; // The number of misses you are allowed before losing game
        int BONUS = 10; // When you get a multiple of this many points your misses are reduced
        int _gameSpeed = 20; // The default speed is the slowest speed.  100 is the max
        bool _gameStarted = false;
        static Random _random = new Random((int)(DateTime.Now.Ticks));
        double _angle;
        double _ballSpeed = 1.0;
        double _maxBallSpeed = 4.0;
        int Ballfirsthit = 1;
        int _englishOnBall = 0;  // -1 for English to the left.  +1 for English to the right
        bool _racketStrikeOnPreviousPass = false;
        double _airResistance = 0.0; // 0.001;
      //  double _windX=1.3, _windY=0.4;
        bool _pauseState = false;
        struct BallPosition
        {
            public double Left;
            public double Top;
        }

        BallPosition _preciseBall; // This holds the precise location of the ball with double values, instead of int values

        public Form1()
        {
            InitializeComponent();

            picBoxTennisBall.Left = 25;
            picBoxTennisBall.Top = 25;
            timer1.Enabled = true;
            // System.Media.SoundPlayer 
            _ballRebound = new System.Media.SoundPlayer(@"..\..\resources\ball_against_wall.wav");
            _racketHit = new System.Media.SoundPlayer(@"..\..\resources\tennisserve.wav");
            _crowdMissed = new System.Media.SoundPlayer(@"..\..\resources\missed.wav");
            _cheer = new System.Media.SoundPlayer(@"..\..\resources\cheer.wav");
            _applause = new System.Media.SoundPlayer(@"..\..\resources\applause7.wav");
            lblMessage.Text = "Press Start To Play a Game";
            picBoxTennisBall.Visible = false;
            btnPause.BackColor = Color.Yellow;
        }

        // Return true if x, y are in the box around the racket defined by the radius of the ball surrounding
        // the racket
        bool boxIntersection(int x, int y, int radius, int centerX,int centerY, int width, int height, ref int sideStruck )
        {
            int boxTop, boxBottom, boxLeft, boxRight;

            boxTop = centerY - radius;
            boxBottom = centerY + height / 2; // + radius;
            boxLeft = centerX - width / 2 - radius;
            boxRight = centerX + width / 2 + radius;
            sideStruck = 0;           

            if (y >= boxTop && y <= boxBottom && x >= boxLeft && x <= boxRight)
            {
                //Did it hit the Left or right edge ?
                if (x <= boxLeft + radius)
                {
                    if (y > centerY)
                    {
                        sideStruck = -1; // left side of racket struck, hit bottom part
                    }
                    else
                    {
                        sideStruck = 1;  // left side of racket struck, top part
                    }
                }
                else if (x >= boxRight - radius)
                {

                    if (y > centerY)
                    {
                        sideStruck = -2;  // the right side of racket hit, bottom part
                    }
                    else
                    {
                        sideStruck = 2; // the right side struck, top part
                    }
                }
                return true;
            }
            return false;    
        }

        private void serveBall()
        {
            int deltaTime;
            //Add a random delay to create uncertainty about when the serve is given
            deltaTime = _random.Next(250, 1000);        
            System.Threading.Thread.Sleep(deltaTime);
            _preciseBall.Left = _random.Next(150, 600);
            _preciseBall.Top = 10;
            _angle = (Math.PI / 2) * _random.NextDouble() + Math.PI / 4;
            _ballSpeed = getCurrentBallSpeed(); // Back to initial ball speed            
            picBoxTennisBall.Visible = true;
            picBoxTennisBall.Left = (int)(_preciseBall.Left);
            picBoxTennisBall.Top = (int)(_preciseBall.Top);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_gameStarted == false)
            {
                _gameStarted = true;
                //Initialize Game Values
                _totalPoints = 0;
                _totalMisses = 0;
                MAXMISSES = 10;
                updatePoints();
                updateMisses();                
                lblMessage.Text = "Let's play tennis!";
                btnStart.Text = "Serve";
            }
            if (Ballfirsthit > _totalPoints)
            {
                _ballRebound.Play();
               
            }
            serveBall();  
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool racketStruckBall = false;
            double dt = 5;
            int value;
            double enteringX, enteringY;
            double dx, dy;
            int ballWidth = picBoxTennisBall.Width;
            int ballHeight = picBoxTennisBall.Height;
            int racketWidth = picBoxRacket.Width;
            int racketHeight = picBoxRacket.Height;

            if(_gameStarted == false || _pauseState == true)
            {
                return;
            }
            // subract the effect of air resistance on the ball speed
            _ballSpeed -= _airResistance;
            if(_ballSpeed <= 0.4)
            {  
                serveBall();
                return;
            }

            enteringX = _preciseBall.Left; // picBoxTennisBall.Left;
            enteringY = _preciseBall.Top; // picBoxTennisBall.Top;
            dx = _ballSpeed * Math.Cos(_angle) * dt;
            dy = _ballSpeed * Math.Sin(_angle) * dt;

 
            _preciseBall.Left += dx;
            _preciseBall.Top += dy;


            var relativePoint = this.PointToClient(Cursor.Position);
   
            //racket location
            picBoxRacket.Left = relativePoint.X - picBoxRacket.Width/2;
            int sideStruck = 0;
            //Did ball hit racket?          
            if (boxIntersection(picBoxTennisBall.Left + ballWidth / 2, picBoxTennisBall.Top + ballHeight / 2, ballWidth/2, picBoxRacket.Left + racketWidth / 2,
                                picBoxRacket.Top + racketHeight / 2, racketWidth, racketHeight, ref sideStruck) && dy > 0) {
  
                double tang;
            

                if (_englishOnBall == 1) // Give it a little kick to the right
                {                                   
                    _angle = (Math.PI / 2) * _random.NextDouble() + 3.0 * Math.PI / 2.0;
                }
                else if (_englishOnBall == -1) //Give it a little kick to the left
                {                    
                    _angle = (Math.PI / 2) * _random.NextDouble() + Math.PI;
                }
                else
                {
                    tang = Math.Acos(Math.Abs(dx / Math.Sqrt(dy * dy + dx * dx)));
                    if (sideStruck == 0) // Ball Struck the top of the racket
                    {
                        
                        if (dx >= 0)
                        {
                            _angle = 2 * Math.PI - tang;
                        }
                        else
                        {
                            _angle = Math.PI + tang;
                        }
                    }else if(sideStruck == 1) // struck the left side top of the racket
                    { 
                        _angle = Math.PI + Math.PI / 8.0;
                    }else if(sideStruck == -1)  //struck the left side bottom of the racket
                    {
                        _angle = Math.PI - Math.PI / 8.0;
                    }
                    else if(sideStruck == 2) // struck the right side top of the racket
                    { 
                        _angle = 2.0*Math.PI - Math.PI / 8.0;
                    }
                    else if (sideStruck == 2) // struck the right side bottom of the racket
                    {
                        _angle = Math.PI / 8.0;
                    }

                }
                _ballSpeed = getCurrentBallSpeed();
                enteringX += _ballSpeed * Math.Cos(_angle) * dt;
                enteringY += _ballSpeed * Math.Sin(_angle) * dt;
                _preciseBall.Left = enteringX;
                _preciseBall.Top = enteringY;
                _englishOnBall = 0;
                lblAddEnglish.Text = "L/R Mouse to Add English";
                if(_racketStrikeOnPreviousPass == false)
                    _totalPoints++;

                updatePoints();
 
                racketStruckBall = true;

                //Player has reached another BONUS number of points, your MAXMISSES increases
                if(_totalPoints % BONUS == 0 && _racketStrikeOnPreviousPass == false)
                {
                    MAXMISSES++;
                    updateMisses();
                    lblMessage.Text = "Bonus: You received a point and an Extra Miss!";
                    _cheer.Play();
                }
                else if (_racketStrikeOnPreviousPass == false)
                {
                    value = _random.Next(1, 4);
                    if(_totalPoints == 1)
                    {
                        value = 4;
                    }
                    if (value == 1)
                    {
                        lblMessage.Text = "Well Done. One more point.";
                    }else if(value == 2)
                    {
                        lblMessage.Text = "Yet another point.";
                    }
                    else if (value == 3)
                    {
                        lblMessage.Text = "Your points are increasing.";
                    }
                    else
                    {
                        lblMessage.Text = "Point...";
                    }
                    _racketHit.Play();
                }
                _racketStrikeOnPreviousPass = true;
            }
            else
            {
                _racketStrikeOnPreviousPass = false;
            }  
           
            // Did ball strike the right wall?
            if (_preciseBall.Left >= 760 && dx >= 0)
            {
                double tang;      
                tang = Math.Acos(Math.Abs(dx / Math.Sqrt(dy * dy + dx * dx)));
                if ( dy > 0.0)
                {
                    _angle = Math.PI - tang;
                }
                else
                {                  
                    _angle = Math.PI + tang;
                }
                enteringX += _ballSpeed * Math.Cos(_angle) * dt;
                enteringY += _ballSpeed * Math.Sin(_angle) * dt;
                _preciseBall.Left = enteringX;
                _preciseBall.Top  = enteringY;
                _ballRebound.Play();

            }  //Did ball strike the left wall?
            else if(_preciseBall.Left <= -10 && dx < 0)
            {
                double tang;
                tang = Math.Acos(Math.Abs(dx / Math.Sqrt(dy * dy + dx * dx)));
                if (dy > 0.0)
                {
                    _angle = tang;
                }
                else
                {
                    _angle = 2*Math.PI - tang;
                }
                enteringX += _ballSpeed * Math.Cos(_angle) * dt;
                enteringY += _ballSpeed * Math.Sin(_angle) * dt;
                _preciseBall.Left = enteringX;
                _preciseBall.Top = enteringY;
                _ballRebound.Play();
            }

            if (racketStruckBall == false)
            {
                // Ball is behind the racket, at the bottom, out of play
                if (_preciseBall.Top >= 550 && dy >= 0)
                {                    
                    double tang;     
                    tang = Math.Acos(Math.Abs(dx / Math.Sqrt(dy * dy + dx * dx)));
                    if (dx >= 0)
                    {
                        _angle = 2 * Math.PI - tang;
                    }
                    else
                    {
                        _angle = Math.PI + tang;
                    }
                    enteringX += _ballSpeed * Math.Cos(_angle) * dt;
                    enteringY += _ballSpeed * Math.Sin(_angle) * dt;
                    _preciseBall.Left = enteringX;
                    _preciseBall.Top = enteringY;

                    _totalMisses++;
                    updateMisses();
                    _preciseBall.Top = 0;                    
                    
                    value = _random.Next(1, 5);
                    if (value == 1)
                    {
                        lblMessage.Text = "Oops, missed.";
                    }
                    else if (value == 2)
                    {
                        lblMessage.Text = "Not good, a miss.";
                    }
                    else if (value == 3)
                    {
                        lblMessage.Text = "Ball got past you, a miss.";
                    }
                    else if(value == 4)
                    {
                        lblMessage.Text = "A miss.";
                    }
                    else
                    {
                        lblMessage.Text = "Oh no... you wiffed.";
                    }

                    // Game over
                    if(_totalMisses == MAXMISSES)
                    {
                        _gameStarted = false;
                        lblMessage.Text = "Game Over. Press Start to Play Again.";
                        _applause.PlaySync();                        
                        btnStart.Text = "Start";
                        picBoxTennisBall.Visible = false;
                    }
                    else
                    {
                        //_crowdMissed.PlaySync();
                        _crowdMissed.Play();
                        serveBall();
                    }

                } //Did ball strike the top wall?
                else if (_preciseBall.Top <= -10 && dy < 0)
                {
                    double tang;
     
                    tang = Math.Acos(Math.Abs(dx / Math.Sqrt(dy * dy + dx * dx)));
                    if (dx >= 0)
                    {
                        _angle = tang;
                    }
                    else
                    {
                        _angle = Math.PI - tang;
                    }
                    enteringX += _ballSpeed * Math.Cos(_angle) * dt;
                    enteringY += _ballSpeed * Math.Sin(_angle) * dt;
                    _preciseBall.Left = enteringX;
                    _preciseBall.Top = enteringY;
                    _ballRebound.Play();
                }
            }
            picBoxTennisBall.Left = (int)(_preciseBall.Left);
            picBoxTennisBall.Top = (int)(_preciseBall.Top);
            panelTennisCourt.Invalidate();
        }

        private double getCurrentBallSpeed()
        {
            double min, max, dvalue;
            _gameSpeed = trackBarSpeed.Value;
            min = (double)(trackBarSpeed.Minimum);
            max = (double)(trackBarSpeed.Maximum);
            dvalue = (double)(trackBarSpeed.Value) - min;
            max -= min;
            _ballSpeed = (dvalue / max) * (_maxBallSpeed - 1) + 1.0;
            return _ballSpeed;
        }

        private void trackBarSpeed_ValueChanged(object sender, EventArgs e)
        {
            double min, max, dvalue;
            _gameSpeed = trackBarSpeed.Value;
            min = (double)(trackBarSpeed.Minimum);
            max = (double)(trackBarSpeed.Maximum);
            dvalue = (double)(trackBarSpeed.Value) - min;
            max -= min;
            _ballSpeed = (dvalue / max)* (_maxBallSpeed-1) + 1.0;
            lblSpeed.Text = "Speed: " + _gameSpeed.ToString();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if(_pauseState == true)
            {
                _pauseState = false;
                btnPause.Text = "Pause";
                btnPause.BackColor = Color.Yellow;
            }
            else
            {
                btnPause.Text = "Go";
                btnPause.BackColor = Color.Green;
                _pauseState = true;
            }
        }

        private void panelTennisCourt_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _englishOnBall = -1;
                lblAddEnglish.Text = "add left English to ball";
            }
            else if (e.Button == MouseButtons.Right)
            {
                _englishOnBall = 1;
                lblAddEnglish.Text = "add right English to ball";
            }
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "Do You Want To Exit The Game?";
            string caption = "Tennis Game";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            bool freeze = true;
            freeze = _gameStarted;
            _gameStarted = false;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
            _gameStarted = freeze;
        }

        private void updateMisses()
        {
            lblMisses.Text = "Misses: " + _totalMisses.ToString() + "/" + MAXMISSES.ToString();
        }

        private void updatePoints()
        {
            lblTotalPoints.Text = "Points: " + _totalPoints.ToString();
        }
    }
}



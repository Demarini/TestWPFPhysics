using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using TestPhysics.Model;

namespace TestPhysics.Controller
{
    public class MainWindowController
    {
        public string direction = "";
        private MainWindowModel _m;
        private bool isMouseDown = false;
        private bool playerisMouseDown = false;
        private double oldX;
        private double oldY;
        private double newX;
        private double newY;
        private double playeroldX;
        private double playeroldY;
        private double playernewX;
        private double playernewY;
        private double xDif;
        private double yDif;
        private double playeryDif;
        private double currentAngle;
        private bool up;
        private bool down;
        private bool left;
        private bool right;
        public MainWindowController(MainWindowModel m)
        {
            _m = m;
        }

        public void SetMouseDown(double x, double y)
        {
            newX = x;
            newY = y;
            oldX = x;
            oldY = y;
            xDif = oldX - _m.X;
            yDif = oldY - _m.Y;
            isMouseDown = true;
        }
        public void StartBallMove()
        {
            double initialCurrentAngle = new Random().Next(150) - 75;
            double test = Math.Sin(initialCurrentAngle * Math.PI / 180);
            double test2 = Math.Cos(initialCurrentAngle * Math.PI / 180);
            DispatcherTimer timer = new DispatcherTimer();
            int counter = 0;
            double interval = 1;
            bool bounceOnce = false;
            double distance = 5;
            int modX = -1;
            int modY = -1;
            double bounceMod = 1.1;
            timer.Tick += delegate
            {
                if (interval >= .5)
                {
                    interval -= .1;
                }
                else
                {
                    bounceMod = 1.1;
                }
                counter++;
                _m.X += distance * modX * test2;
                _m.Y += distance * modY * test;

                if (_m.X + _m.CircleWidth >= _m.Width)
                {
                    _m.Score1++;
                    _m.X = _m.Width / 2 - _m.CircleWidth / 2;
                    _m.Y = _m.Height / 2 - _m.CircleHeight / 2;
                    initialCurrentAngle = new Random().Next(150) - 75;
                    test = Math.Sin(initialCurrentAngle * Math.PI / 180);
                    test2 = Math.Cos(initialCurrentAngle * Math.PI / 180);
                    timer = new DispatcherTimer();
                    counter = 0;
                    interval = 1;
                    bounceOnce = false;
                    distance = 5;
                    modX = -1;
                    modY = -1;
                    bounceMod = 1.1;
                    //if (!bounceOnce)
                    //{
                    //    distance = distance * (bounceMod);
                    //    if (modX == -1)
                    //    {
                    //        modX = 1;
                    //    }
                    //    else
                    //    {
                    //        modX = -1;
                    //    }
                    //}
                    //bounceOnce = true;
                }
                else if (_m.X <= 0)
                {
                    //if (!bounceOnce)
                    //{
                    //    distance = distance * (bounceMod);
                    //    if (modX == -1)
                    //    {
                    //        modX = 1;
                    //    }
                    //    else
                    //    {
                    //        modX = -1;
                    //    }
                    //}
                    //bounceOnce = true;
                    //counter = 0;
                    _m.Score2++;
                    _m.X = _m.Width / 2 - _m.CircleWidth / 2;
                    _m.Y = _m.Height / 2 - _m.CircleHeight / 2;
                    initialCurrentAngle = new Random().Next(150) - 75;
                    test = Math.Sin(initialCurrentAngle * Math.PI / 180);
                    test2 = Math.Cos(initialCurrentAngle * Math.PI / 180);
                    timer = new DispatcherTimer();
                    counter = 0;
                    interval = 1;
                    bounceOnce = false;
                    distance = 5;
                    modX = -1;
                    modY = -1;
                    bounceMod = 1.1;
                }
                else if (_m.Y + _m.CircleHeight >= _m.Height)
                {
                    if (!bounceOnce)
                    {
                        distance = distance * (bounceMod);
                        if (modY == -1)
                        {
                            modY = 1;
                        }
                        else
                        {
                            modY = -1;
                        }
                    }
                    bounceOnce = true;

                }
                else if (_m.Y <= 0)
                {
                    if (!bounceOnce)
                    {
                        distance = distance * (bounceMod);
                        if (modY == -1)
                        {
                            modY = 1;
                        }
                        else
                        {
                            modY = -1;
                        }
                    }
                    bounceOnce = true;
                }
                else if (_m.X <= 40 && (_m.Y >= _m.PlayerY && _m.Y <= _m.PlayerY + 100))
                {
                    if (!bounceOnce)
                    {
                        distance = distance * (bounceMod);
                        if (modX == -1)
                        {
                            modX = 1;
                        }
                        else
                        {
                            modX = -1;
                        }
                    }
                    bounceOnce = true;
                }
                else if (_m.X + _m.CircleWidth >= _m.Width - 10 - 30 && (_m.Y >= _m.ComputerY && _m.Y <= _m.ComputerY + 100))
                {
                    if (!bounceOnce)
                    {
                        distance = distance * (bounceMod);
                        if (modX == -1)
                        {
                            modX = 1;
                        }
                        else
                        {
                            modX = -1;
                        }
                    }
                    bounceOnce = true;
                }
                else
                {
                    bounceOnce = false;
                }
            };
            timer.Interval = TimeSpan.FromMilliseconds(interval);
            timer.Start();
        }
        public void SetMouseUp()
        {
            double test = Math.Sin(currentAngle * Math.PI/180);
            double test2 = Math.Cos(currentAngle * Math.PI / 180);
            DispatcherTimer timer = new DispatcherTimer();
            int counter = 0;
            bool bounceOnce = false;
            double distance = Math.Sqrt(Math.Pow((oldX - newX), 2) + Math.Pow((oldY - newY), 2));
            int modX = -1;
            int modY = -1;
            double bounceMod = .75;
            timer.Tick += delegate
            {
                counter++;
                _m.X += distance * modX * test2;
                _m.Y += distance * modY * test;
                
                if (_m.X + _m.CircleWidth >= _m.Width)
                {
                    if (!bounceOnce)
                    {
                        distance = distance * (bounceMod);
                        if (modX == -1)
                        {
                            modX = 1;
                        }
                        else
                        {
                            modX = -1;
                        }
                    }
                    bounceOnce = true;
                }
                else if (_m.X <= 0)
                {
                    if (!bounceOnce)
                    {
                        distance = distance * (bounceMod);
                        if (modX == -1)
                        {
                            modX = 1;
                        }
                        else
                        {
                            modX = -1;
                        }
                    }
                    bounceOnce = true;
                    counter = 0;
                }
                else if (_m.Y + _m.CircleHeight >= _m.Height)
                {
                    if (!bounceOnce)
                    {
                        distance = distance * (bounceMod);
                        if (modY == -1)
                        {
                            modY = 1;
                        }
                        else
                        {
                            modY = -1;
                        }
                    }
                    bounceOnce = true;
                    
                }
                else if (_m.Y <= 0)
                {
                    if (!bounceOnce)
                    {
                        distance = distance * (bounceMod);
                        if (modY == -1)
                        {
                            modY = 1;
                        }
                        else
                        {
                            modY = -1;
                        }
                    }
                    bounceOnce = true; 
                }
                else
                {
                    bounceOnce = false;
                }
            };
            timer.Interval = TimeSpan.FromMilliseconds(.5);
            timer.Start();
            //new Thread(() =>
            //{
            //    Thread.CurrentThread.IsBackground = true;
            //    /* run your code here */
                
            //}).Start();
            
            isMouseDown = false;
        }
        public void MouseMoved(double x, double y)
        {
            if (isMouseDown)
            {
                oldX = newX;
                oldY = newY;
                newX = x;
                newY = y;
                currentAngle = CalculateAngle(oldX, newX, oldY, newY);
                _m.X = x - xDif;
                _m.Y = y - yDif;
            }
            _m.PlayerY = y - 50;
            _m.ComputerY = y - 50;
        }
        public void KeyDownEvent(KeyEventArgs e)
        {
            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Tick += delegate
            //{
                if (e.Key == Key.Down)
                {
                    down = true;

                }
                if (e.Key == Key.Up)
                {
                    up = true;

                }
                if (e.Key == Key.Left)
                {
                    left = true;


                }
                if (e.Key == Key.Right)
                {
                    right = true;
                }

                if (down)
                {
                    if (_m.Y < _m.Height - _m.CircleHeight)
                    {
                        _m.Y+=5;
                    }
                }
                if (up)
                {
                    if (_m.Y > 0)
                    {
                        _m.Y-=5;
                    }
                }
                if (left)
                {
                    if (_m.X > 0)
                    {
                        _m.X-=5;
                    }
                }
                if (right)
                {
                    if (_m.X < _m.Width - _m.CircleWidth)
                    {
                        _m.X+=5;
                    }
                }

            //};
            //timer.Interval = TimeSpan.FromMilliseconds(1);
            //timer.Start();
        }
        public void KeyUpEvent(KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                down = false;
            }
            if (e.Key == Key.Up)
            {
                up = false;
            }
            if (e.Key == Key.Left)
            {
                left = false;
            }
            if (e.Key == Key.Right)
            {
                right = false;
            }
        }
        public void PlayerSetMouseDown(double x, double y)
        {
            playeryDif = y - _m.PlayerY;
            playerisMouseDown = true;
        }
        public void PlayerSetMouseUp()
        {
            playerisMouseDown = false;
        }
        public double CalculateAngle(double x1, double x2, double y1, double y2)
        {
            return Math.Atan2(y1 - y2, x1 - x2) * 180.0 / Math.PI; ;
        }
    }
}

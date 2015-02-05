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
        private double oldX;
        private double oldY;
        private double newX;
        private double newY;
        private double xDif;
        private double yDif;
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
            timer.Interval = TimeSpan.FromMilliseconds(1);
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
        public double CalculateAngle(double x1, double x2, double y1, double y2)
        {
            return Math.Atan2(y1 - y2, x1 - x2) * 180.0 / Math.PI; ;
        }
    }
}

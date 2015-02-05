using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TestPhysics.Controller;
using TestPhysics.Model;

namespace TestPhysics.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double playerY;
        private double computerY;
        private double width;
        private double height;
        private double circleWidth;
        private double circleHeight;
        MainWindowModel m;
        MainWindowController mC;
        public int score1;
        public int score2;
        public MainWindowViewModel()
        {
            m = new MainWindowModel(this);
            mC = new MainWindowController(m);
            mC.StartBallMove();
        }
        public int Score1
        {
            get
            {
                return score1;
            }
            set
            {
                score1 = value;
                OnPropertyChanged("Score1");
            }
        }
        public int Score2
        {
            get
            {
                return score2;
            }
            set
            {
                score2 = value;
                OnPropertyChanged("Score2");
            }
        }
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
                OnPropertyChanged("X");
            }
        }
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
                OnPropertyChanged("Y");
            }
        }
        public double PlayerY
        {
            get
            {
                return playerY;
            }
            set
            {
                playerY = value;
                OnPropertyChanged("PlayerY");
            }
        }
        public double ComputerY
        {
            get
            {
                return computerY;
            }
            set
            {
                computerY = value;
                OnPropertyChanged("ComputerY");
            }
        }
        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
                OnPropertyChanged("Width");
            }
        }
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
                OnPropertyChanged("Height");
            }
        }
        public double CircleWidth
        {
            get
            {
                return circleWidth;
            }
            set
            {
                circleWidth = value;
                OnPropertyChanged("CircleWidth");
            }
        }
        public double CircleHeight
        {
            get
            {
                return circleHeight;
            }
            set
            {
                circleHeight = value;
                OnPropertyChanged("CircleHeight");
            }
        }
        public ICommand MouseDownCommand
        {
            get
            {
                return new RelayCommand<MouseButtonEventArgs>(e =>
                {
                    mC.SetMouseDown(e.GetPosition(MainWindowReference.MainWindowRef.canvas).X, e.GetPosition(MainWindowReference.MainWindowRef.canvas).Y);
                });
            }
        }
        public ICommand MouseUpCommand
        {
            get
            {
                return new RelayCommand<MouseButtonEventArgs>(e =>
                {
                    mC.SetMouseUp();
                });
            }
        }
        public ICommand PlayerMouseDownCommand
        {
            get
            {
                return new RelayCommand<MouseButtonEventArgs>(e =>
                {
                    mC.PlayerSetMouseDown(e.GetPosition(MainWindowReference.MainWindowRef.canvas).X, e.GetPosition(MainWindowReference.MainWindowRef.canvas).Y);
                });
            }
        }
        public ICommand PlayerMouseUpCommand
        {
            get
            {
                return new RelayCommand<MouseButtonEventArgs>(e =>
                {
                    mC.PlayerSetMouseUp();
                });
            }
        }
        public ICommand MouseMovedCommand
        {
            get
            {
                return new RelayCommand<MouseEventArgs>(e =>
                {
                    mC.MouseMoved(e.GetPosition(MainWindowReference.MainWindowRef.canvas).X, e.GetPosition(MainWindowReference.MainWindowRef.canvas).Y);
                });
            }
        }

        public ICommand KeyDownCommand
        {
            get
            {
                return new RelayCommand<KeyEventArgs>(e =>
                {
                    mC.KeyDownEvent(e);
                });
            }
        }
        public ICommand KeyUpCommand
        {
            get
            {
                return new RelayCommand<KeyEventArgs>(e =>
                {
                    mC.KeyUpEvent(e);
                });
            }
        }
        #region PropertyChangedEvent
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}

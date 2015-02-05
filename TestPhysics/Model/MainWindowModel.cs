using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPhysics.ViewModel;

namespace TestPhysics.Model
{

    public class MainWindowModel : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double width;
        private double height;
        private double playerY;
        private double computerY;
        private double circleWidth;
        private double circleHeight;
        public double canvasHeight;
        public double canvasWidth;
        private MainWindowViewModel _mv;
        public int score1;
        public int score2;
        public MainWindowModel(MainWindowViewModel mv)
        {
            _mv = mv;
            Width = 900;
            Height = 600;
            CircleWidth = 35;
            CircleHeight = 35;
            X = Width/2 - CircleWidth/2;
            Y = Height / 2 - CircleHeight / 2;
            PlayerY = 250;
            ComputerY = 250;
            Score1 = 0;
            Score2 = 0;
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
                _mv.Score1 = value;
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
                _mv.Score2 = value;
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
                _mv.X = value;
                
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
                _mv.Y = value;
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
                _mv.PlayerY = value;
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
                _mv.ComputerY = value;
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
                _mv.Width = value;
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
                _mv.Height = value;
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
                _mv.CircleWidth = value;
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
                _mv.CircleHeight = value;
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

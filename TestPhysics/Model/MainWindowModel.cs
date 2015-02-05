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
        private double circleWidth;
        private double circleHeight;
        private MainWindowViewModel _mv;
        public MainWindowModel(MainWindowViewModel mv)
        {
            _mv = mv;
            Width = 900;
            Height = 600;
            CircleWidth = 50;
            CircleHeight = 50;
            X = 900 - 50;
            Y = Height / 2 - CircleHeight / 2;
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

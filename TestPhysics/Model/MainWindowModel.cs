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
        private int x;
        private int y;
        private int width;
        private int height;
        private int circleWidth;
        private int circleHeight;
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
        public int X
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
        public int Y
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
        public int Width
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
        public int Height
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
        public int CircleWidth
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
        public int CircleHeight
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

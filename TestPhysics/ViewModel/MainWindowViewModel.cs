using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPhysics.Model;

namespace TestPhysics.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int x;
        private int y;
        private int width;
        private int height;
        private int circleWidth;
        private int circleHeight;
        MainWindowModel m;
        public MainWindowViewModel()
        {
            m = new MainWindowModel(this);
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
                OnPropertyChanged("X");
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
                OnPropertyChanged("Y");
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
                OnPropertyChanged("Width");
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
                OnPropertyChanged("Height");
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
                OnPropertyChanged("CircleWidth");
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
                OnPropertyChanged("CircleHeight");
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

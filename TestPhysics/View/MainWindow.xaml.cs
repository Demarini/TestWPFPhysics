using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestPhysics.ViewModel;

namespace TestPhysics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool mouseDown = false;
        double newX;
        double newY;
        double oldX;
        double oldY;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            MainWindowReference.MainWindowRef = this;
        }

        private void Ellipse_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            mouseDown = true;
            oldX = e.GetPosition(canvas).X;
            oldY = e.GetPosition(canvas).Y;
        }

        private void Grid_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                newX = e.GetPosition(canvas).X;
                newY = e.GetPosition(canvas).Y; 
            }
        }

        private void Ellipse_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            mouseDown = false;
        }
    }

    public static class MainWindowReference
    {
        public static MainWindow mainWindowRef;
        public static MainWindow MainWindowRef
        {
            get
            {
                return mainWindowRef;
            }
            set
            {
                mainWindowRef = value;
            }
        }
    }
}

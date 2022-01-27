using System.Windows;
using System.Windows.Input;

namespace EnvGraphique.Evaluation2.ATM.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /**********************************************************************************************************
        * Properties
        ***********************************************************************************************************/
        private bool dragWindow = false;
        private Point lastWindowPosition;

        public MainWindow()
        {
            InitializeComponent();
        }

        /**********************************************************************************************************
        * Event handling
        ***********************************************************************************************************/
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                lastWindowPosition = new Point(e.GetPosition(this).X, e.GetPosition(this).Y);
                dragWindow = true;
            }
        }

        private void Window_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released)
            {
                dragWindow = false;
            }
        }

        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (dragWindow)
            {
                this.Left += e.GetPosition(this).X - lastWindowPosition.X;
                this.Top += e.GetPosition(this).Y - lastWindowPosition.Y;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}

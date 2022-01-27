using System.Windows;
using System.Windows.Controls;

namespace EnvGraphique.Evaluation2.ATM.WPF.Controls
{
    /// <summary>
    /// Interaction logic for ToolBoxBar.xaml
    /// </summary>
    public partial class MainWindowBar : UserControl
    {
        public MainWindowBar()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void buttonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}

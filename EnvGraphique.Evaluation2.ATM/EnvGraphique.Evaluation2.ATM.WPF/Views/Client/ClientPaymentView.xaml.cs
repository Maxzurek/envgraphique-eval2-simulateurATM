using System;
using System.Windows;
using System.Windows.Controls;

namespace EnvGraphique.Evaluation2.ATM.WPF.Views
{
    /// <summary>
    /// Interaction logic for ClientPaymentView.xaml
    /// </summary>
    public partial class ClientPaymentView : UserControl
    {
        public ClientPaymentView()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox textBox = (TextBox)sender;

                if (textBox.Text.Equals("0"))
                {
                    textBox.Dispatcher.BeginInvoke(new Action(() => textBox.SelectAll()));
                }
            }
        }
    }
}

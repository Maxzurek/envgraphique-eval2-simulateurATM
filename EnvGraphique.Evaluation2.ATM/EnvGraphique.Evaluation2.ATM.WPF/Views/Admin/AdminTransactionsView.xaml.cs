using System.Windows.Controls;

namespace EnvGraphique.Evaluation2.ATM.WPF.Views
{
    /// <summary>
    /// Interaction logic for AdminTransactionsView.xaml
    /// </summary>
    public partial class AdminTransactionsView : UserControl
    {
        public AdminTransactionsView()
        {
            InitializeComponent();

            comboBoxFilterType.Items.Add("Id");
            comboBoxFilterType.Items.Add("Transaction type");
            comboBoxFilterType.Items.Add("Montant");
            comboBoxFilterType.Items.Add("Date");
            comboBoxFilterType.Items.Add("Id compte source");
            comboBoxFilterType.Items.Add("Id compte cible");
        }
    }
}

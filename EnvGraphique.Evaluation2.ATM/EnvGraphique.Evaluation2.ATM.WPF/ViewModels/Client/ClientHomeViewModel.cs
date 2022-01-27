using System.ComponentModel;
using System.Windows.Data;

namespace EnvGraphique.Evaluation2.ATM.WPF.ViewModels
{
    public class ClientHomeViewModel : ViewModelBase
    {
        public ClientHomeViewModel(MainViewModel mainViewModel)
        {
            // We want to sort the logged in user accounts by account type
            ICollectionView collectionToSort = CollectionViewSource.GetDefaultView(mainViewModel.LoggedInUserAccounts);
            collectionToSort.SortDescriptions.Add(new SortDescription("IdAccountType", ListSortDirection.Ascending));
            loggedInUserAccounts = collectionToSort;
        }

        private ICollectionView loggedInUserAccounts;
        public ICollectionView LoggedInUserAccounts
        {
            get
            {
                return loggedInUserAccounts;
            }
            set
            {
                loggedInUserAccounts = value;
                OnPropertyChanged(nameof(LoggedInUserAccounts));
            }
        }
    }
}

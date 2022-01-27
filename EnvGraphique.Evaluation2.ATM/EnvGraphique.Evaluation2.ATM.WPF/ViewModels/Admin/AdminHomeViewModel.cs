using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Admin;
using EnvGraphique.Evaluation2.ATM.WPF.Commands.Admin;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EnvGraphique.Evaluation2.ATM.WPF.ViewModels
{
    public class AdminHomeViewModel : ViewModelBase
    {
        public MainViewModel MainViewModel { get; }

        public ICommand AdminBlockUserCommand { get; }

        public ICommand AdminUnblockUserCommand { get; }

        public ICommand AdminRefillAtmCommand { get; }

        public ICommand AdminPayInterestCommand { get; }

        public ICommand AdminIncreaseMarginBalanceCommand { get; }

        public AdminHomeViewModel(MainViewModel mainViewModel, IAdminManagementService adminManagementService)
        {
            this.MainViewModel = mainViewModel;

            AdminBlockUserCommand = new AdminBlockUserCommand(mainViewModel, this, adminManagementService);
            AdminUnblockUserCommand = new AdminUnblockUserCommand(mainViewModel, this, adminManagementService);
            AdminRefillAtmCommand = new AdminRefillAtmCommand(mainViewModel, this);
            AdminPayInterestCommand = new AdminPayInterestCommand(mainViewModel, this, adminManagementService);
            AdminIncreaseMarginBalanceCommand = new AdminIncreaseMarginBalanceCommand(mainViewModel, this, adminManagementService);
        }

        private ObservableCollection<UserDTO> unblockedUsers;
        public ObservableCollection<UserDTO> UnblockedUsers
        {
            get
            {
                unblockedUsers = GetUnblockedUsers();
                return unblockedUsers;
            }
            set
            {
                unblockedUsers = value;
                OnPropertyChanged(nameof(UnblockedUsers));
            }
        }

        private ObservableCollection<UserDTO> blockedUsers;
        public ObservableCollection<UserDTO> BlockedUsers
        {
            get
            {
                blockedUsers = GetBlockedUsers();
                return blockedUsers;
            }
            set
            {
                blockedUsers = value;
                OnPropertyChanged(nameof(BlockedUsers));
            }
        }

        private string refillAmount;
        public string RefillAmount
        {
            get
            {
                return refillAmount;
            }
            set
            {
                refillAmount = value;
                OnPropertyChanged(nameof(RefillAmount));
            }
        }

        private UserDTO selectedUserToBlock;
        public UserDTO SelectedUserToBlock
        {
            get
            {
                return selectedUserToBlock;
            }
            set
            {
                selectedUserToBlock = value;
                OnPropertyChanged(nameof(SelectedUserToBlock));
            }
        }

        private UserDTO selectedUserToUnblock;
        public UserDTO SelectedUserToUnblock
        {
            get
            {
                return selectedUserToUnblock;
            }
            set
            {
                selectedUserToUnblock = value;
                OnPropertyChanged(nameof(SelectedUserToUnblock));
            }
        }

        private ObservableCollection<UserDTO> GetUnblockedUsers()
        {
            ObservableCollection<UserDTO> unblockedUsersDTO = new ObservableCollection<UserDTO>();

            foreach (UserDTO user in MainViewModel.SystemUsers)
            {
                if (user.Enabled == true && user.IdUserType != 2)
                {
                    unblockedUsersDTO.Add(user);
                }
            }

            return unblockedUsersDTO;
        }

        private ObservableCollection<UserDTO> GetBlockedUsers()
        {
            ObservableCollection<UserDTO> blockedUsersDTO = new ObservableCollection<UserDTO>();

            foreach (UserDTO user in MainViewModel.SystemUsers)
            {
                if (user.Enabled == false)
                {
                    blockedUsersDTO.Add(user);
                }
            }

            return blockedUsersDTO;
        }
    }
}

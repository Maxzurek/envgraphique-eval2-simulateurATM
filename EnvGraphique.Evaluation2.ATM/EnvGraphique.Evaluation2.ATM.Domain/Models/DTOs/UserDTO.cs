using System;
using System.Collections.ObjectModel;

namespace EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs
{
    public class UserDTO : ObservableObject, IComparable<UserDTO>
    {

        /**********************************************************************************************************
        * Public enum
        ***********************************************************************************************************/
        public enum EUserType : int
        {
            Client = 1,
            Admin = 2,
        }

        /**********************************************************************************************************
        * Properties
        ***********************************************************************************************************/
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(nameof(Id)); }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged(nameof(LastName)); }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; OnPropertyChanged(nameof(Phone)); }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(nameof(Email)); }
        }

        private string nip;

        public string Nip
        {
            get { return nip; }
            set { nip = value; OnPropertyChanged(nameof(Nip)); }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(nameof(Username)); }
        }

        private int idUserType;


        public int IdUserType
        {
            get { return idUserType; }
            set { idUserType = value; OnPropertyChanged(nameof(IdUserType)); }
        }

        private bool enabled;

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; OnPropertyChanged(nameof(Enabled)); }
        }

        private ObservableCollection<Account> accounts = new ObservableCollection<Account>();

        public ObservableCollection<Account> Accounts
        {
            get { return accounts; }
            private set { accounts = value; }
        }

        private UserType userType;

        public UserType UserType
        {
            get { return userType; }
            set { userType = value; OnPropertyChanged(nameof(UserType)); }
        }



        /**********************************************************************************************************
        * Constructors
        ***********************************************************************************************************/
        private UserDTO()
        {
        }

        public UserDTO(User user)
        {
            this.id = user.Id;
            this.firstName = user.FirstName;
            this.lastName = user.LastName;
            this.phone = user.Phone;
            this.email = user.Email;
            this.nip = user.Nip;
            this.username = user.Username;
            this.idUserType = user.IdUserType;
            this.enabled = user.Enabled;
            this.userType = user.UserType;

            foreach (Account account in user.Accounts)
            {
                this.accounts.Add(account);
            }
        }

        public UserDTO(string firstName, string lastName, string phone, string nip, string username, int idUserType, string email = null, bool enabled = true, ObservableCollection<Account> accounts = null, UserType userType = null)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.email = email;
            this.nip = nip;
            this.username = username;
            this.idUserType = idUserType;
            this.enabled = enabled;
            this.accounts = accounts;
            this.userType = userType;
        }


        /**********************************************************************************************************
        * Public overriden methods
        ***********************************************************************************************************/
        public override string ToString()
        {
            return String.Format("{0} - {1} {2}", Id, LastName, FirstName);
        }


        /**********************************************************************************************************
        * Interface implementation
        ***********************************************************************************************************/
        public int CompareTo(UserDTO other)
        {
            if (Id < other.Id)
            {
                return -1;
            }
            if (Id == other.Id)
            {
                return 0;
            }

            return 1;
        }
    }
}

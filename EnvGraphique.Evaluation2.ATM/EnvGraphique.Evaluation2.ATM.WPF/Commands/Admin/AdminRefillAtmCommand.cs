using EnvGraphique.Evaluation2.ATM.WPF.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;

namespace EnvGraphique.Evaluation2.ATM.WPF.Commands.Admin
{
    public class AdminRefillAtmCommand : CommandBase
    {
        private readonly MainViewModel mainViewModel;
        private readonly AdminHomeViewModel adminHomeViewModel;

        public AdminRefillAtmCommand(MainViewModel mainViewModel, AdminHomeViewModel adminHomeViewModel)
        {
            this.mainViewModel = mainViewModel;
            this.adminHomeViewModel = adminHomeViewModel;

            adminHomeViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(adminHomeViewModel.RefillAmount) && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            decimal refillAmount;

            try
            {
                refillAmount = decimal.Parse(adminHomeViewModel.RefillAmount);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                                  "Impossible d'ajouter de l'argent papier. Veuillez entrer un montant).",
                                  "Échec de l'opération - Ajouter argent papier");

                return;
            }
            catch (FormatException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                 "Impossible d'ajouter de l'argent papier. Le montant entré est invalide.",
                 "Échec de l'opération - Ajouter argent papier");

                return;
            }

            if (refillAmount <= 0)
            {
                MessageBox.Show(Application.Current.MainWindow,
                 "Impossible d'ajouter de l'argent papier. Le montant entré doit etre plus grand que 0.",
                 "Échec de l'opération - Ajouter argent papier");

                return;
            }

            mainViewModel.AvailableCurrency += refillAmount;

            MessageBox.Show(Application.Current.MainWindow,
                  "Le remplissage en argent du guichet ATM s'est terminé avec succès.",
                  "Opération terminé - Ajouter argent papier");

            return;
        }

        protected override void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(adminHomeViewModel.RefillAmount))
            {
                OnCanExecutedChanged();
            }
        }
    }
}

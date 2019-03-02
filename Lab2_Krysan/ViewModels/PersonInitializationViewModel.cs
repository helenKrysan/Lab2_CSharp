using Lab2_Krysan.Models;
using Lab2_Krysan.Tools;
using Lab2_Krysan.Tools.Managers;
using Lab2_Krysan.Tools.Navigation;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace Lab2_Krysan.ViewModels
{
    class PersonInitializationViewModel : INotifyPropertyChanged
    {
        private DateTime _date;
        private string _name;
        private string _surname;
        private string _email;

        private RelayCommand _proccedCommand;


        public PersonInitializationViewModel()
        {
        }

        public DateTime Date
        {
            get { return _date; }

            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }

            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get { return _surname; }

            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }

            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand ProceedCommand
        {
            get
            {
                return _proccedCommand ?? (_proccedCommand = new RelayCommand(
                           ProceedImpl, o => CanExecuteCommand()));
            }
        }

        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_email) && !string.IsNullOrWhiteSpace(_name) && !string.IsNullOrWhiteSpace(_surname) && (_date != new DateTime());
        }

        private async void ProceedImpl(object o)
        {
            LoaderManager.Instance.ShowLoader();
            Person person = null;
            bool isError = false;
            await Task.Run(() =>
            {
                try
                {
                    person = new Person(_name, _surname, _email, _date);
                    var checkAge = person.IsAdult;
                }
                catch (Exception e)
                {
                    isError = true;
                }
            }
            );
            if (isError)
            {
                MessageBox.Show("Input date is invalid");
            }
            else
            {
                if (person != null && person.IsBirthday)
                {
                    MessageBox.Show("Happy BirthDay!!!");
                }
                StationManager.CurrentPerson = person;
                LoaderManager.Instance.HideLoader();
                NavigationManager.Instance.Navigate(ViewType.Main);
            }
            LoaderManager.Instance.HideLoader();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

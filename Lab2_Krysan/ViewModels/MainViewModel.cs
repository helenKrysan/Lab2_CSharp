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
    class MainViewModel : INotifyPropertyChanged
    {
        private string _date;
        private string _name;
        private string _surname;
        private string _email;
        private string _isAdult;
        private string _chineaseAstrologicalSign;
        private string _astrologicalSign;
        private string _isBirthday;


        private RelayCommand _returnCommand;


        public MainViewModel()
        {
            SetData();
        }

        public string Date
        {
            get { return _date; }

            private set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }

            private set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get { return _surname; }

            private set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }

            private set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string ChineaseAstrologicalSign
        {
            get { return _chineaseAstrologicalSign; }

            private set
            {
                _chineaseAstrologicalSign = value;
                OnPropertyChanged();
            }
        }

        public string AstrologicalSign
        {
            get { return _astrologicalSign; }

            private set
            {
                _astrologicalSign = value;
                OnPropertyChanged();
            }
        }

        public string IsAdult
        {
            get { return _isAdult; }

            private set
            {
                _isAdult = value;
                OnPropertyChanged();
            }
        }

        public string IsBirthday
        {
            get { return _isBirthday; }

            private set
            {
                _isBirthday = value;
                OnPropertyChanged();
            }
        }

        private async void SetData()
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                Date = "Date of birth : " + StationManager.CurrentPerson.DateOfBirth.Date.ToString();
                Name = "Name : " + StationManager.CurrentPerson.Name;
                Surname = "Surname : " + StationManager.CurrentPerson.Surname;
                Email = "E-mail : " + StationManager.CurrentPerson.Email;
                IsAdult = "Is Adult : " + StationManager.CurrentPerson.IsAdult;
                AstrologicalSign = "Sun sign : " + StationManager.CurrentPerson.SunSign;
                ChineaseAstrologicalSign = "Chinese sign : " + StationManager.CurrentPerson.ChineseSign;
                IsBirthday = "Is birthay : " + StationManager.CurrentPerson.IsBirthday;
            });
            LoaderManager.Instance.HideLoader();
        }

        public RelayCommand ReturnCommand
        {
            get
            {
                return _returnCommand ?? (_returnCommand = new RelayCommand(
                           o => { NavigationManager.Instance.Navigate(ViewType.PersonInitialization);  }));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

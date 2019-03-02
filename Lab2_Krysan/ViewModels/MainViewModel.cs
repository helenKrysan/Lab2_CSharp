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
        private DateTime _date;
        private string _name;
        private string _surname;
        private string _email;
        private bool _isAdult;
        private string _chineaseAstrologicalSign;
        private string _astrologicalSign;
        private bool _isBirthday;


        private RelayCommand _returnCommand;


        public MainViewModel()
        {
            SetData();
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

        public string ChineaseAstrologicalSign
        {
            get { return _chineaseAstrologicalSign; }

            set
            {
                _chineaseAstrologicalSign = value;
                OnPropertyChanged();
            }
        }

        public string AstrologicalSign
        {
            get { return _astrologicalSign; }

            set
            {
                _astrologicalSign = value;
                OnPropertyChanged();
            }
        }

        private async void SetData()
        {
            LoaderManager.Instance.ShowLoader();
            Person person = null;
            await Task.Run(() =>
            {
            });
            LoaderManager.Instance.HideLoader();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

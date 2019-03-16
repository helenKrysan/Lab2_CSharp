using Lab2_Krysan.Models;
using Lab2_Krysan.Tools;
using Lab2_Krysan.Tools.Managers;
using Lab2_Krysan.Tools.Navigation;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using Lab2_Krysan.Tools.Exception;

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
            bool noError =  await Task.Run(() =>
            {
                try
                {
                    Person person = new Person(_name, _surname, _email, _date);
                    if (person.IsBirthday)
                    {
                        MessageBox.Show("Happy BirthDay!!!");
                    }
                    StationManager.CurrentPerson = person;
                }
                catch (InvalidEmailException e)
                {
                    MessageBox.Show($"Proceed failed for person {_name} {_surname}. Reason:{Environment.NewLine} Email {_email} is not valid");
                    return false;
                }
                catch(FutureInputDateException e)
                {
                    MessageBox.Show($"Proceed failed for person {_name} {_surname}. Reason:{Environment.NewLine} Birth date couldn't be in the future");
                    return false;
                }
                catch (LivePersonRequireException e)
                {
                    MessageBox.Show($"Proceed failed for person {_name} {_surname}. Reason:{Environment.NewLine} Person must be alive");
                    return false;
                }

                catch (Exception e)
                {
                    MessageBox.Show($"Proceed failed for person {_name} {_surname}. Reason:{Environment.NewLine} {e.Message}");
                    return false;
                }
                return true;
            }
            );
            LoaderManager.Instance.HideLoader();
            if (noError){
                NavigationManager.Instance.Navigate(ViewType.Main);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

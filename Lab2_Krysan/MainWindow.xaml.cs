using System.Windows;
using System.Windows.Controls;
using Lab2_Krysan.Tools.Managers;
using Lab2_Krysan.Tools.Navigation;
using Lab2_Krysan.ViewModels;

namespace Lab2_Krysan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            NavigationManager.Instance.Initialize(new PersonInitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.PersonInitialization);
        }
    }
}

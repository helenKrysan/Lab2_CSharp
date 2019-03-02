using Lab2_Krysan.Tools.Navigation;
using System.Windows.Controls;
using Lab2_Krysan.ViewModels;

namespace Lab2_Krysan.Views
{
    /// <summary>
    /// Interaction logic for PersonInitializationControl.xaml
    /// </summary>
    public partial class PersonInitializationView : UserControl, INavigatable
    {
        public PersonInitializationView()
        {
            InitializeComponent();
            DataContext = new PersonInitializationViewModel();
        }
    }
}

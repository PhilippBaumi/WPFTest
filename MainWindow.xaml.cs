using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ViewModel viewModel = new();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void AddDateToList(object sender, RoutedEventArgs e)
        {
            if (viewModel.SelectedDate == null)
            {
                MessageBox.Show("Kein Datum gewählt", "Datum fehlt", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            string date = viewModel.SelectedDate.Value.ToString("dd.MM.yyyy");
            if (viewModel.Dates.Contains(date))
            {
                MessageBox.Show("Datum bereits in der Liste", "Datum vorhanden", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            
            viewModel.Dates.Add(date);
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (viewModel.SelectedDate != null)
            {
                DateTime? date = viewModel.SelectedDate;
                MessageBox.Show(date.Value.ToString("dd.MM.yyyy"), "Gewähltes Datum", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        }
    }
}
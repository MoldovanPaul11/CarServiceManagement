using System.Collections.ObjectModel;
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
using Gestiune_Service.model;
namespace Gestiune_Service
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Car> CarsInService { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            CarsInService = new ObservableCollection<Car>();

            CarsInService.Add(new Car("Dacia", "logan", "BV05abc", "pana", 100, false));


            this.DataContext = this;
        }

        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmarca.Text))
            {
                MessageBox.Show("Te rog introdu marca masinii");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtmodel.Text))
            {
                MessageBox.Show("Te rog introdu modelul masinii");
            }

            Car newCar = new Car(txtmarca.Text, txtmodel.Text, txtNrInmatriculare.Text, "urmeaza constatare", 0, false);

            CarsInService.Add(newCar);

            txtmarca.Clear();
            txtmodel.Clear();
            txtNrInmatriculare.Clear();

            txtmarca.Focus();

        }
        private void btnDeleteCar_Click(object sender, RoutedEventArgs e)
        {
            Button buttonpressed = sender as Button;

            Car carForDelete = buttonpressed.DataContext as Car;

            if (carForDelete != null)
            {
                CarsInService.Remove(carForDelete);
            }
        }
    }
}
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
using Gestiune_Service.views;

using System.ComponentModel;


namespace Gestiune_Service
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Car> CarsInService { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            CarsInService = new ObservableCollection<Car>();

            CarsInService.Add(new Car("Dacia", "logan", "BV05abc", "pana", 100, false));
            CarsInService.Add(new Car("Volkswagen", "Golf 7", "B123ABC", "Schimb ulei și filtre", 450, false));
            CarsInService.Add(new Car("BMW", "X5", "CJ99XYZ", "Probleme suspensie", 1200, false));
            CarsInService.Add(new Car("Audi", "A4", "TM22AUD", "Distribuție", 2500, false));
            CarsInService.Add(new Car("Ford", "Focus", "IS08FRD", "Verificare frâne", 300, true));
            CarsInService.Add(new Car("Toyota", "Corolla", "B777TOY", "Revizie anuală", 600, false));
            CarsInService.Add(new Car("Renault", "Clio", "GL45REN", "Înlocuire ambreiaj", 1800, false));
            CarsInService.Add(new Car("Mercedes", "C-Class", "B01BENZ", "Diagnosticare motor", 0, false));
            CarsInService.Add(new Car("Skoda", "Octavia", "BV10SKO", "Schimb plăcuțe frână", 350, true));
            CarsInService.Add(new Car("Hyundai", "Tucson", "PH55HYU", "Geometrie roți", 150, false));
            CarsInService.Add(new Car("Opel", "Astra", "CT03OPL", "Curățare EGR", 400, false));

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
        private void btnFinishCar_Click(object sender, RoutedEventArgs e)
        {
            Button buttonPressed = sender as Button;
            Car carToFinish = buttonPressed.DataContext as Car;

            if (carToFinish != null)
            {
                carToFinish.Finished = true;

                MessageBox.Show($"Mașina cu nr. de înmatriculare {carToFinish.NrInmatriculare} a fost scoasă din service!",
                                "Finalizare Reparație",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                CarsInService.Remove(carToFinish);
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(CarsInService);

            if (view != null)
            {
                view.Filter = item =>
                {
                    if (string.IsNullOrWhiteSpace(txtSearch.Text)) return true;

                    var car = item as Car;
                   
                    string[] cuvinteCautate = txtSearch.Text.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (cbCriteriu.SelectedIndex == 0) // Marca + Model
                    {
                        
                        string dateMasina = (car.Marca + " " + car.Model).ToLower();

                       
                        return cuvinteCautate.All(cuvant => dateMasina.Contains(cuvant));
                    }
                    else // Nr Inmatriculare
                    {
                        return car.NrInmatriculare.ToLower().Contains(txtSearch.Text.ToLower());
                    }
                };

                view.Refresh(); 
            }
        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = sender as DataGridRow;
            if (row == null) return;

            var masinaSelectata = row.Item as Car;

            if (masinaSelectata != null)
            {
                EditWindow fereastraEditare = new EditWindow(masinaSelectata);

                fereastraEditare.Owner = this;

                if (fereastraEditare.ShowDialog() == true)
                {
                    dgMasini.Items.Refresh();
                }
            }
        }
    }
}
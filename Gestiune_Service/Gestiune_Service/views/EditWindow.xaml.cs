using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using Gestiune_Service.model;

namespace Gestiune_Service.views
{
   
    public partial class EditWindow : Window
    {

        private Car masinaCurenta;

        public EditWindow(Car masinadeeditat)
        {
            InitializeComponent();

            masinaCurenta = masinadeeditat;

            txtAddProblem.Text = masinaCurenta.Problem;
            txtAddPrice.Text=masinaCurenta.Price.ToString();
        }

        

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
                masinaCurenta.Problem = txtAddProblem.Text;

                if (double.TryParse(txtAddPrice.Text, out double newPrice))
                {
                    masinaCurenta.Price = newPrice;
                    this.DialogResult = true; // inchidere
                
                }
                else
                {
                    MessageBox.Show("Te rugăm să introduci un preț valid.");
                }
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemExamFTest.Views
{
    
    public partial class AddEdit : Page
    {
        private Model.Hotel _currentHotel = new Model.Hotel();

        public AddEdit(Model.Hotel selectedhotel)
        {

            InitializeComponent();

            if (selectedhotel != null)
                _currentHotel = selectedhotel;

            DataContext = _currentHotel;
            CmbCountry.ItemsSource = Model.DataBase.GetContext().Country.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentHotel.Name))
                errors.AppendLine("Укажите название отеля");
            if (_currentHotel.CountOfStars < 1 || _currentHotel.CountOfStars > 5)
                errors.AppendLine("Укажите количество звезд");
            if (_currentHotel.Country == null)
                errors.AppendLine("Выбирите страну");
            if (errors.Length >0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentHotel.Id == 0)
                Model.DataBase.GetContext().Hotel.Add(_currentHotel);
            try
            {
                Model.DataBase.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

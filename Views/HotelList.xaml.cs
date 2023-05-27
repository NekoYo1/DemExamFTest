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
   
    public partial class HotelList : Page
    {
        public HotelList()
        {
            InitializeComponent();
            DGridHotels.ItemsSource = Model.DataBase.GetContext().Hotel.ToList();
        }

        private void BtnEd_Click(object sender, RoutedEventArgs e)
        {
            Utility.Manager.MainFrame.Navigate(new AddEdit((sender as Button).DataContext as Model.Hotel));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = DGridHotels.SelectedItems.Cast<Model.Hotel>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить данные?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question)== MessageBoxResult.Yes)
            {
                try
                {
                    Model.DataBase.GetContext().Hotel.RemoveRange(hotelsForRemoving);
                    Model.DataBase.GetContext().SaveChanges();
                    MessageBox.Show("Данны удалены");
                    DGridHotels.ItemsSource = Model.DataBase.GetContext().Hotel.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Utility.Manager.MainFrame.Navigate(new AddEdit(null));
        }
    }
}

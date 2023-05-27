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
 
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userData = Model.DataBase.GetContext().User.FirstOrDefault(x => x.Login == txbLogin.Text && x.Password == psbPassword.Password);
                if (userData == null)
                {
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Utility.Manager.MainFrame.Navigate(new Views.HotelList());

                    MessageBox.Show("Здравствуйте, " + userData.FullName + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);


                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка" + Ex.Message.ToString() + "Критическая ошибка приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            Utility.Manager.MainFrame.Navigate(new Views.Reg());
        }
    }
}

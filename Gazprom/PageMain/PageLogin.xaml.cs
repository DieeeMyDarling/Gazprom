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
using Gazprom.DataBase;
using Gazprom.Users;
using Gazprom.Users.Admin;


namespace Gazprom.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = ODBConnectHelper.entObj.User.FirstOrDefault(
                x => x.Login == txtUser.Text && x.Password ==
                txtPass.Password
                );
                if (userObj == null)
                {
                    MessageBox.Show("Такой пользователь не найден.",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                    FrameApp.frmObj.Navigate(new PageRegistration());

                }
                else
                {
                    switch (userObj.idRole)
                    {
                        case 2:
                            FrameApp.frmObj.Navigate(new PageDirector());
                            MessageBox.Show("Здравствуйте 'Директор'");
                         
                        break;

                        case 1:
                            FrameApp.frmObj.Navigate(new PageVet());
                            MessageBox.Show("Здравствуйте 'Ветеринар'");
                            break;
                       
                        case 3:
                            FrameApp.frmObj.Navigate(new PageAdmin());
                            MessageBox.Show("Здравствуйте 'Администратор'");
                            break;

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Критический сбой в работе приложения: " +
                ex.Message.ToString(),
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
            }


        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageRegistration());
        }

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

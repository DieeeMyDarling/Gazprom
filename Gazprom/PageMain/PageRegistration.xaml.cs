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

namespace Gazprom.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageRegistration.xaml
    /// </summary>
    public partial class PageRegistration : Page
    {
        public PageRegistration()
        {
            InitializeComponent();
        }

        private void txtpassans_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtPass.Password == txtpassans.Password)
            {
                btncreate.IsEnabled = true;
                txtpassans.Background = Brushes.LightGreen;
                txtpassans.Background = Brushes.Green;
            }
            else
            {
                btncreate.IsEnabled = false;
                txtpassans.Background = Brushes.LightCoral;
                txtpassans.Background = Brushes.Red;
            }
        }

        private void btncreate_Click(object sender, RoutedEventArgs e)
        {
            if (ODBConnectHelper.entObj.User.Count(x => x.Login == txtUser.Text) < 1)
            {
                if(txtPass.Password == txtpassans.Password)
                {


                    User user = new User
                    {
                        Login = txtUser.Text,
                        Password = txtPass.Password,
                        idRole = 1,
                        Name = "ilya"

                    };
                    ODBConnectHelper.entObj.User.Add(user);
                    ODBConnectHelper.entObj.SaveChanges();
                    FrameApp.frmObj.GoBack();
                }
            }
            else
            {
                MessageBox.Show("Такой пользватель уже существует");
            }
        }

        private void txtPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
           
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}

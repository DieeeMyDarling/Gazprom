using Gazprom.DataBase;
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

namespace Gazprom.Users.Admin
{
    /// <summary>
    /// Логика взаимодействия для PageAddUsers.xaml
    /// </summary>
    public partial class PageAddUsers : Page
    {
        private User _addUser = new User();

        public PageAddUsers(User selectedUser)
        {
            InitializeComponent();

            if (selectedUser != null)
            {
                _addUser = selectedUser;
            }

            DataContext = _addUser;
            CmbDolzh.ItemsSource = ODBConnectHelper.entObj.Role.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            _addUser.idRole = (CmbDolzh.SelectedItem as Role).id;
           



            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_addUser.id == 0)
                ODBConnectHelper.entObj.User.Add(_addUser);
            try
            {
                ODBConnectHelper.entObj.SaveChanges();
                MessageBox.Show("Информация сохранена!");
                FrameApp.frmObj.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageUsers());
        }

        private void CmbDolzh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

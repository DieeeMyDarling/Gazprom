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
using Gazprom.PageMain;
using Gazprom.Users;
using Gazprom.Users.Director;

namespace Gazprom.Users.Admin
{
    /// <summary>
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageUsers());
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageLogin());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageProsmotrSotrudnikov());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageNewPostavshik());
        }
    }
}

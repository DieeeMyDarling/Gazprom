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

namespace Gazprom.Users.Director
{
    /// <summary>
    /// Логика взаимодействия для PageProsmotrSotrudnikov.xaml
    /// </summary>
    public partial class PageProsmotrSotrudnikov : Page
    {
        public PageProsmotrSotrudnikov()
        {
            InitializeComponent();
            Sotrudnik.ItemsSource = ODBConnectHelper.entObj.Worker.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageDirector());
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Medcard_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

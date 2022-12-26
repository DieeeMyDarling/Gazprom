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
using Gazprom.PageMain;


namespace Gazprom.Users
{
    /// <summary>
    /// Логика взаимодействия для PageSklad.xaml
    /// </summary>
    public partial class PageSklad : Page
    {
        public PageSklad()
        {
            InitializeComponent();
            MaterialList.ItemsSource = ODBConnectHelper.entObj.Product.Where(x => x.Name.Contains(TxbSearch.Text)).Take(15).ToList();
            ResultTxb.Text = MaterialList.Items.Count + "/" + ODBConnectHelper.entObj.Product.Where(x => x.Name.Contains(TxbSearch.Text)).Count().ToString();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaterialList.ItemsSource = ODBConnectHelper.entObj.Product.Where(x => x.Name.Contains(TxbSearch.Text)).Take(15).ToList();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void MaterialList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                MaterialList.ItemsSource = ODBConnectHelper.entObj.Product.Take(15).ToList();

                ResultTxb.Text = MaterialList.Items.Count + "/" + ODBConnectHelper.entObj.Product.Count().ToString();
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message, "Упс, что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAdd(null));
        }

        private void CHX1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

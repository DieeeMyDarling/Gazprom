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

namespace Gazprom.Users
{
    /// <summary>
    /// Логика взаимодействия для PageAdd.xaml
    /// </summary>
    public partial class PageAdd : Page
    {
        private Product _product = new Product();
        public PageAdd(Product selectedProduct)
        
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (_product.Id == 0)
            {
                ODBConnectHelper.entObj.Product.Add(_product);
            }
            try
            {
                ODBConnectHelper.entObj.SaveChanges();
                MessageBox.Show("Сохранено");
                FrameApp.frmObj.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверный формат данных");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}

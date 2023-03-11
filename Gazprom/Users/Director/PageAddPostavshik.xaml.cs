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
    /// Логика взаимодействия для PageAddPostavshik.xaml
    /// </summary>
    public partial class PageAddPostavshik : Page
    {
        private Feed_supply _addSupplie = new Feed_supply();

        public PageAddPostavshik(Feed_supply selectedFeed_supply)
        {
            InitializeComponent();

            if (selectedFeed_supply != null)
            {
                _addSupplie = selectedFeed_supply;
            }

            DataContext = _addSupplie;
            CmbPost.ItemsSource = ODBConnectHelper.entObj.The_supplier.ToList();
            CmbCorm.ItemsSource = ODBConnectHelper.entObj.Feed.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            _addSupplie.idSupplier = (CmbPost.SelectedItem as The_supplier).id;
            _addSupplie.idFeed = (CmbCorm.SelectedItem as Feed).id;



            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_addSupplie.id == 0)
                ODBConnectHelper.entObj.Feed_supply.Add(_addSupplie);
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
            FrameApp.frmObj.Navigate(new PageProsmotrPostavshikov());
        }

        private void CmbCorm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

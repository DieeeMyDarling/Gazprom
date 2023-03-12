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
    /// Логика взаимодействия для PageProsmotrPostavshikov.xaml
    /// </summary>
    public partial class PageProsmotrPostavshikov : Page
    {
        public PageProsmotrPostavshikov()
        {
            InitializeComponent();
            //Postavshik.ItemsSource = ODBConnectHelper.entObj.Feed_supply.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageDirector());
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var animalsForRemoving = Postavshik.SelectedItems.Cast<Feed_supply>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {animalsForRemoving.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)


            {
                try
                {
                    ODBConnectHelper.entObj.Feed_supply.RemoveRange(animalsForRemoving);
                    ODBConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            FrameApp.frmObj.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAddPostavshik(null));
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Medcard_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAddPostavshik((sender as Button).DataContext as Feed_supply));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ODBConnectHelper.entObj.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                Postavshik.ItemsSource = ODBConnectHelper.entObj.Feed_supply.ToList();
            }
        }
    }
}

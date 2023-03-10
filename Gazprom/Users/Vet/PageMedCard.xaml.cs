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
using Gazprom.Users.Vet;

namespace Gazprom.Users
{
    /// <summary>
    /// Логика взаимодействия для PageMedCard.xaml
    /// </summary>
    public partial class PageMedCard : Page
    {
        public PageMedCard()
        {
            InitializeComponent();
            //Medcard.ItemsSource = ODBConnectHelper.entObj.Animal_card.ToList();
        }

        private void MaterialList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var animalsForRemoving = Medcard.SelectedItems.Cast<Animal_card>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {animalsForRemoving.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)


            {
                try
                {
                    ODBConnectHelper.entObj.Animal_card.RemoveRange(animalsForRemoving);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate (new PageAddMedCard(null));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate (new PageVet());
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAddMedCard((sender as Button).DataContext as Animal_card));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ODBConnectHelper.entObj.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                Medcard.ItemsSource = ODBConnectHelper.entObj.Animal_card.ToList();
            }
        }
    }
}

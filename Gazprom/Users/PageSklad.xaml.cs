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
            //MaterialList.ItemsSource = ODBConnectHelper.entObj.Animal.ToList();
            Animal.ItemsSource = ODBConnectHelper.entObj.Animal.ToList(); 

        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //MaterialList.ItemsSource = ODBConnectHelper.entObj.Animal.Where(x => x.NameOfTheAnimal.Contains(TxbSearch.Text)).Take(15).ToList();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void MaterialList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAdd((sender as Button).DataContext as Animal));
        }

        private void CHX1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Filtr.SelectedIndex == 0)
                {
                    Animal.ItemsSource = ODBConnectHelper.entObj.Animal.ToList();
                }
                else if (Filtr.SelectedIndex == 1) 
                {                                                                      
                    Animal.ItemsSource = ODBConnectHelper.entObj.Animal.Where(x => x.Kind.id == Filtr.SelectedIndex).ToList();
                }
                else if (Filtr.SelectedIndex == 2)
                {
                    Animal.ItemsSource = ODBConnectHelper.entObj.Animal.Where(x => x.Kind.id == Filtr.SelectedIndex).ToList();
                }
                else if (Filtr.SelectedIndex == 3)
                {
                    
                }
            }
            catch (Exception ex) { 
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAdd((sender as Button).DataContext as Animal));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ODBConnectHelper.entObj.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                Animal.ItemsSource = ODBConnectHelper.entObj.Animal.ToList();
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var animalsForRemoving = Animal.SelectedItems.Cast<Animal>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {animalsForRemoving.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
               
          
            {
                try
                {
                    ODBConnectHelper.entObj.Animal.RemoveRange(animalsForRemoving);
                    ODBConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            FrameApp.frmObj.Refresh();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}

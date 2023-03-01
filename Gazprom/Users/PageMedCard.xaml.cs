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
            MedCard.ItemsSource = ODBConnectHelper.entObj.Animal_card.ToList();
        }

        private void MaterialList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

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
    }
}

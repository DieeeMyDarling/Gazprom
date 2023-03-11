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

namespace Gazprom.Users.Vet
{
    /// <summary>
    /// Логика взаимодействия для PageAddMedCard.xaml
    /// </summary>
    public partial class PageAddMedCard : Page
    {
        private Animal_card _addCard = new Animal_card();



        public PageAddMedCard(Animal_card selectedAnimal_card)
        {
            InitializeComponent();

            if(selectedAnimal_card != null)
            {
                _addCard = selectedAnimal_card;
            }

            DataContext = _addCard;
            CmbClichka.ItemsSource = ODBConnectHelper.entObj.Animal.ToList();
            Nazv.ItemsSource = ODBConnectHelper.entObj.Animal.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageMedCard());
        }

        private void EditAnimal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            _addCard.idAnimal = (Nazv.SelectedItem as Animal).id;
           
         

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_addCard.id == 0)
                ODBConnectHelper.entObj.Animal_card.Add(_addCard);
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

        private void CmbClimat_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void View_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbCell_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbClichka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Animal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Nazv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

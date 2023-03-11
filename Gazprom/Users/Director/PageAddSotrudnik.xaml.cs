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
    /// Логика взаимодействия для PageAddSotrudnik.xaml
    /// </summary>
    public partial class PageAddSotrudnik : Page
    {
        private Worker _addSupplie = new Worker();

        public PageAddSotrudnik(Worker selectedWorker)
        {
            InitializeComponent();

            if (selectedWorker != null)
            {
                _addSupplie = selectedWorker;
            }

            DataContext = _addSupplie;
            CmbDolzh.ItemsSource = ODBConnectHelper.entObj.Post.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageProsmotrSotrudnikov());
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            _addSupplie.idPost = (CmbDolzh.SelectedItem as Post).id;



            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_addSupplie.id == 0)
                ODBConnectHelper.entObj.Worker.Add(_addSupplie);
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

        private void CmbClichka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Nazv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbDolzh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

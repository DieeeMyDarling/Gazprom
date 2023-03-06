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
using System.IO;
using Microsoft.Win32;

namespace Gazprom.Users
{
    /// <summary>
    /// Логика взаимодействия для PageAdd.xaml
    /// </summary>
    public partial class PageAdd : Page
    {
        private Animal _product = new Animal();
        public PageAdd(Animal selectedAnimal)
        
        {
            InitializeComponent();

            if (selectedAnimal != null)
            {
                _product = selectedAnimal;

                //ComboKind.SelectedItem = _product.Kind;
                //CmbCell.SelectedItem = _product.Cell;
                //CmbClimat.SelectedItem = _product.Climate_zone;
               
                
                
            }
                DataContext = _product;
                View.ItemsSource = ODBConnectHelper.entObj.Kind.ToList();
            CmbCell.ItemsSource = ODBConnectHelper.entObj.Cell.ToList();
            CmbClimat.ItemsSource = ODBConnectHelper.entObj.Climate_zone.ToList();



            //CmbClimat.ItemsSource = ODBConnectHelper.entObj.Climate_zone.ToList();
            //CmbCell.SelectedValuePath = "id";
            //CmbCell.DisplayMemberPath = "number";
            //CmbCell.ItemsSource = ODBConnectHelper.entObj.Cell.ToList();
            //CmbClimat.SelectedValuePath = "id";
            //CmbClimat.DisplayMemberPath = "climateZone";
            //CmbClimat.ItemsSource = ODBConnectHelper.entObj.Climate_zone.ToList();
            //ComboKind.SelectedValuePath = "id";
            //ComboKind.DisplayMemberPath = "title";
            //ComboKind.ItemsSource = ODBConnectHelper.entObj.Kind.ToList();

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            _product.idCell = (CmbCell.SelectedItem as Cell).id;
            _product.idClimatZone = (CmbClimat.SelectedItem as Climate_zone).id;
            _product.idKind = (View.SelectedItem as Kind).id;
            _product.image = (imgAnimal.Text);
            if (string.IsNullOrWhiteSpace(_product.NameOfTheAnimal))
                errors.AppendLine("Укажите название животного");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
                if (_product.id == 0)
                    ODBConnectHelper.entObj.Animal.Add(_product);
                try
                {
                    ODBConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    FrameApp.frmObj.GoBack();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboKind_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
///*            var r = View.SelectedItem as Animal;*/
//           /* var c = ODBConnectHelper.entObj.Animal.Where(x => x.Kind.id ==View.SelectedIndex).FirstOrDefault();
//            int f = Convert.ToInt32(c);*/

//            if (View.SelectedIndex == 0)
//            {
//                tdttest.Text = "пизщдец";
//            }
//            if (View.SelectedIndex == 1)
//            {
//                tdttest.Text = "пизfgjhjhhfgщдец";
//            }

        }

        private void CmbClimat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
        }

        private void CmbCell_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EditAnimal_Click(object sender, RoutedEventArgs e)
        {
            Image image = new Image();
            if (!Directory.Exists("AnimalImage"))
            {
                Directory.CreateDirectory("AnimalImage");
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)| *.png;*.jpeg;*.jpg|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                MessageBox.Show(Environment.CurrentDirectory + "\\" + System.IO.Path.GetFileName(openFileDialog.FileName));
                if (!File.Exists("AnimalImage\\" + System.IO.Path.GetFileName(openFileDialog.FileName)))
                {
                    File.Copy(openFileDialog.FileName, Environment.CurrentDirectory + "\\AnimalImage\\" + System.IO.Path.GetFileName(openFileDialog.FileName));
                }
            }
            imgAnimal.Text = (Environment.CurrentDirectory + "\\AnimalImage\\" + System.IO.Path.GetFileName(openFileDialog.FileName)).ToString();
        }

        private void imgAnimal_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

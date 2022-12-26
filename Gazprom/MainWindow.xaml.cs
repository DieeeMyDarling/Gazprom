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
using System.Windows.Controls;
using Gazprom.PageMain;
using Gazprom.DataBase;

namespace Gazprom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameApp.frmObj = FrmMain;
            FrmMain.Navigate(new PageLogin());
            ODBConnectHelper.entObj = new GazpromEntities();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FrmMain_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}

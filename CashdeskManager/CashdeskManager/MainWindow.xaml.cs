using CashdeskManager.Models;
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

namespace CashdeskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CashMachine> cashMachines = new List<CashMachine>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowCamera(object sender, RoutedEventArgs e)
        {

        }

        private void AddCustomer(object sender, RoutedEventArgs e)
        {
        }

        private void RemoveCustomer(object sender, RoutedEventArgs e)
        {

        }

        private void OpenClose2(object sender, RoutedEventArgs e)
        {
            cashMachines.Add(new CashMachine(2, true, 0));
            Icon2.Source = new BitmapImage(new Uri(@"C:\Users\Boyan\source\repos\CashdeskManager\CashdeskManager\cashdeskOpen.png"));
        }
    }
}

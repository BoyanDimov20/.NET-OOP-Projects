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
        List<CashMachineUserControl> cashMachines = new List<CashMachineUserControl>();

        private int customersInLine = 0;

        public MainWindow()
        {
            InitializeComponent();
            MainConfig();
        }

        private void ShowCamera(object sender, RoutedEventArgs e)
        {

        }

        private void AddCustomer(object sender, RoutedEventArgs e)
        {
            
            customersInLine++;
            int min = cashMachines.Where(x => x.IsOpened).Min(x => x.CustomerCount);
            cashMachines.Where(x => x.IsOpened).First(x => x.CustomerCount == min).WaitInLine();
            
        }
        
        private void ManageCustomers()
        {
            
        }

        private void RemoveCustomer(object sender, RoutedEventArgs e)
        {
            cashMachines.First(x => x.CustomerCount > 0).LeftLine();
        }

        private void MainConfig()
        {
            CashMachine1.MachineNumber.Content = "№1";
            CashMachine2.MachineNumber.Content = "№2";
            CashMachine3.MachineNumber.Content = "№3";
            CashMachine4.MachineNumber.Content = "№4";
            CashMachine5.MachineNumber.Content = "№5";
            CashMachine6.MachineNumber.Content = "№6";
            CashMachine7.MachineNumber.Content = "№7";
            CashMachine8.MachineNumber.Content = "№8";

            cashMachines.Add(CashMachine1);
            cashMachines.Add(CashMachine2);
            cashMachines.Add(CashMachine3);
            cashMachines.Add(CashMachine4);
            cashMachines.Add(CashMachine5);
            cashMachines.Add(CashMachine6);
            cashMachines.Add(CashMachine7);
            cashMachines.Add(CashMachine8);

        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            var newPage = new LoginWindow();
            this.Close();
            newPage.Show();
        }
        private void Register(object sender, RoutedEventArgs e)
        {

        }
        private void Report(object sender, RoutedEventArgs e)
        {

        }
        private void ManageUI(object sender, RoutedEventArgs e)
        {

        }


    }
}

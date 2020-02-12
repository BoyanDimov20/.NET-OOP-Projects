using CashdeskManager.Contracts;
using CashdeskManager.Models;
using CashdeskManager.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for CashMachineUserControl.xaml
    /// </summary>
    public partial class CashMachineUserControl : UserControl, ICustomerCountIn, ICustomerCountOut, ICloseState, IOpenState, ICustomerInfo
    {
        private int totalCustomersServiced = 0;
        private CashdeskManagerDbContext context = new CashdeskManagerDbContext();

        public CashMachineUserControl()
        {
            InitializeComponent();
        }

        public bool IsOpened { get; private set; } = false;
        public bool IsOverflow { get; private set; } = false;
        public int CurrentCustomerCount { get; set; } = 0;
        public User LoginUser { get; set; }
        public int TotalCustomerCount => totalCustomersServiced;

        private void OpenClose(object sender, RoutedEventArgs e)
        {
            if (IsOpened)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
        public void WaitInLine()
        {
            CurrentCustomerCount++;
            totalCustomersServiced++;
            this.CustomerCountLabel.Text = $"In Line: {this.CurrentCustomerCount}";
            if (CurrentCustomerCount > 4 && !IsOverflow)
            {
                IsOverflow = true;
                this.Icon.Source = new BitmapImage(new Uri(@"C:\Users\Boyan\Documents\GitHub\.NET-OOP-Projects\CashdeskManager\CashdeskManager\Resources\cashdeskOverflow.png"));
            }
        }
        public void LeftLine()
        {
            CurrentCustomerCount--;
            this.CustomerCountLabel.Text = $"In Line: {this.CurrentCustomerCount}";
            if (CurrentCustomerCount <= 4 && IsOverflow)
            {
                IsOverflow = false;
                this.Icon.Source = new BitmapImage(new Uri(@"C:\Users\Boyan\Documents\GitHub\.NET-OOP-Projects\CashdeskManager\CashdeskManager\Resources\cashdeskOpen.png"));
            }
        }
        public void Open()
        {
            IsOpened = true;
            this.Icon.Source = new BitmapImage(new Uri(@"C:\Users\Boyan\Documents\GitHub\.NET-OOP-Projects\CashdeskManager\CashdeskManager\Resources\cashdeskOpen.png"));
        }
        public void Close()
        {
            IsOpened = false;
            CurrentCustomerCount = 0;
            this.CustomerCountLabel.Text = $"In Line: 0";
            this.Icon.Source = new BitmapImage(new Uri(@"C:\Users\Boyan\Documents\GitHub\.NET-OOP-Projects\CashdeskManager\CashdeskManager\Resources\cashdesk.png"));

            CashMachineOpened newEntity = new CashMachineOpened
            {
                Name = this.MachineNumber.Content.ToString(),
                CustomersServiced = this.totalCustomersServiced,
                UserId = this.LoginUser.Id,
            };

            context.Add(newEntity);
            context.SaveChanges();
            totalCustomersServiced = 0;
        }

    }
}

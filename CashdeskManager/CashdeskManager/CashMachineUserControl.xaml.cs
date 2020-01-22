using CashdeskManager.Contracts;
using System;
using System.Collections.Generic;
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
    public partial class CashMachineUserControl : UserControl, ICustomerCountIn, ICustomerCountOut, ICloseState, IOpenState
    {
        public bool IsOpened { get; private set; } = false;
        public bool isOverflowed { get; private set; } = false;
        public int CustomerCount { get; set; } = 0;

        public CashMachineUserControl()
        {
            InitializeComponent();
        }

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
            CustomerCount++;
            this.CustomerCountLabel.Text = $"In Line: {this.CustomerCount}";
            if (CustomerCount > 4 && !isOverflowed)
            {
                isOverflowed = true;
                this.Icon.Source = new BitmapImage(new Uri(@"C:\Users\Boyan\Documents\GitHub\.NET-OOP-Projects\CashdeskManager\CashdeskManager\cashdeskOverflow.png"));
            }
        }
        public void LeftLine()
        {
            CustomerCount--;
            this.CustomerCountLabel.Text = $"In Line: {this.CustomerCount}";
            if (CustomerCount <= 4 && isOverflowed)
            {
                isOverflowed = false;
                this.Icon.Source = new BitmapImage(new Uri(@"C:\Users\Boyan\Documents\GitHub\.NET-OOP-Projects\CashdeskManager\CashdeskManager\cashdeskOpen.png"));
            }
        }
        public void Open()
        {
            IsOpened = true;
            this.Icon.Source = new BitmapImage(new Uri(@"C:\Users\Boyan\Documents\GitHub\.NET-OOP-Projects\CashdeskManager\CashdeskManager\cashdeskOpen.png"));
        }
        public void Close()
        {
            IsOpened = false;
            CustomerCount = 0;
            this.CustomerCountLabel.Text = $"In Line: 0";
            this.Icon.Source = new BitmapImage(new Uri(@"C:\Users\Boyan\Documents\GitHub\.NET-OOP-Projects\CashdeskManager\CashdeskManager\cashdesk.png"));
        }
        
    }
}

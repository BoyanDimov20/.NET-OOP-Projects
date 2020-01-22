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
    public partial class CashMachineUserControl : UserControl
    {
        public bool IsOpened { get; private set; } = false;
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
        }
        public void LeftLine()
        {
            CustomerCount--;
            this.CustomerCountLabel.Text = $"In Line: {this.CustomerCount}";
        }
        private void Open()
        {
            IsOpened = true;
            this.Icon.Source = new BitmapImage(new Uri(@"C:\Users\Boyan\Documents\GitHub\.NET-OOP-Projects\CashdeskManager\CashdeskManager\cashdeskOpen.png"));
        }
        private void Close()
        {
            IsOpened = false;
            this.CustomerCountLabel.Text = $"In Line: 0";
            this.Icon.Source = new BitmapImage(new Uri(@"C:\Users\Boyan\Documents\GitHub\.NET-OOP-Projects\CashdeskManager\CashdeskManager\cashdesk.png"));
        }
        
    }
}

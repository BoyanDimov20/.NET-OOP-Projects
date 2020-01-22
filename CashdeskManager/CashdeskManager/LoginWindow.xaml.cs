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
using System.Windows.Shapes;

namespace CashdeskManager
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        string username = "Sorion";
        string password = "123qwe";
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if (Username.Text.Equals(username) && Password.Password.Equals(password))
            {
                var newPage = new MainWindow();
                newPage.Show();
                this.Close();
            }
            else
            {
                ErrorMessage.Text = "Wrong username or password!";
                Username.Text = "";
                Password.Password = "";
            }
        }
    }
}

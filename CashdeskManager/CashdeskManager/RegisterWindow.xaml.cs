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
using System.Windows.Shapes;

namespace CashdeskManager
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private CashdeskManagerDbContext context = new CashdeskManagerDbContext();
        private bool isAdmin;
        public RegisterWindow(bool isAdmin = false)
        {
            this.isAdmin = isAdmin;
            InitializeComponent();
            if (!isAdmin)
            {
                RegisterAsAdmin.Visibility = Visibility.Hidden;
            }
        }

        private void Continue(object sender, RoutedEventArgs e)
        {
            if (context.Users.Any(x => x.Username == Username.Text))
            {
                ErrorMessage.Text = "Username already taken!";
                Username.Text = "";
                Password.Password = "";
            }
            else
            {
                User newUser = new User()
                {
                    Username = Username.Text,
                    FullName = Name.Text,
                    Password = Password.Password,
                    IsAdministrator = RegisterAsAdmin.IsChecked.Value,
                };
                context.Users.Add(newUser);
                context.SaveChanges();

                LoginWindow newPage = new LoginWindow();

                newPage.Show();
                this.Close();
            }
        }
    }
}

using CashdeskManager.Models;
using CashdeskManager.Models.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private User loginUser;
        private CashdeskManagerDbContext context = new CashdeskManagerDbContext();

        public LoginWindow()
        {
            if(!(context.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
            {
                context.Database.EnsureCreated();
                RegisterWindow newPage = new RegisterWindow(true);

                newPage.Show();
                this.Close();
            }
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if (context.Users.Any(x => x.Username == Username.Text && x.Password == Password.Password))
            {
                loginUser = context.Users.First(x => x.Username == Username.Text && x.Password == Password.Password);
                var newPage = new MainWindow(loginUser);
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

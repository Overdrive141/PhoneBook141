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
using System.Windows.Shapes;

namespace PhoneBook
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Contacts contactsWindow = new Contacts();
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if((Properties.Settings.Default.finalUsername == txtUsername.Text) && (Properties.Settings.Default.finalPassword == txtPassword.Password))
            {
                this.Close();
                contactsWindow.Show();
            }
            else
            {
                MessageBox.Show("You have entered an incorrect username or password. Please try again", "Incorrect Username or Password", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                txtUsername.Focus();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

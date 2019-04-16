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

namespace PhoneBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtPassword.Password = Properties.Settings.Default.password;
            txtUsername.Text = Properties.Settings.Default.username;
        }
        
        private void Submit_Click(object sender, EventArgs e)
        {
            
            if (txtUsername.Text.Length == 0)
            {
                MessageBox.Show("Enter a Username");
            }
            
            else
            {
                String UserName = txtUsername.Text;
                String Password = txtPassword.Password;
                String Password2 = txtPassword2.Password;

                if (txtPassword.Password.Length == 0)
                {
                    MessageBox.Show("Enter Password.");
                    txtPassword.Focus();
                }
                else if (txtPassword2.Password.Length == 0)
                {
                    MessageBox.Show("Re-Enter Password");
                    txtPassword2.Focus();
                }
                else if (txtPassword.Password != txtPassword2.Password)
                {
                    MessageBox.Show("Passwords do not match. Please enter again.");
                    txtPassword2.Focus();
                }
                else
                {
                    MessageBox.Show("You have Signed Up Successfully. You may Login now.");
                    Console.WriteLine(UserName + Password + Password2);
                }
         
            }
            Properties.Settings.Default.username = txtUsername.Text;
            Properties.Settings.Default.password = txtPassword.Password;
            Properties.Settings.Default.Save();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

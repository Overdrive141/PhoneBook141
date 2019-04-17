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
using Microsoft.Win32;


namespace PhoneBook
{
    /// <summary>
    /// Interaction logic for Contacts.xaml
    /// </summary>
    public partial class Contacts : Window
    {
        Class1 c1 = new Class1();
        Image image = new Image();

        ImageBrush imageBrush = new ImageBrush();



        public Contacts()
        {
            InitializeComponent();

            c1.AddContact(new Contact()
            {
                FName = "Alpha",
                LName = "Bravo",
                PhArea = "051",
                PhNumber = "2296806",
                Company = "COMSATS",
                JobTitle = "Professor",
                Email = "alpha@gmail.com",
                Address = "Tarlai Kalan",
                photo = "141.png"
                
                    

                });

                this.listContacts.ItemsSource = null;
                this.listContacts.Items.Refresh();
                this.listContacts.ItemsSource = c1.GetAllContacts();
                this.content1.Content = c1.GetAllContacts();

            

        }



        private void PhotoUpload_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                imageBrush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
            


        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            c1.AddContact(new Contact()
            {
                FName = txtFName.Text,
                LName = txtLName.Text,
                PhArea = txtPhArea.Text,
                PhNumber = txtPhNumber.Text,
                Company = txtCompany.Text,
                JobTitle = txtJobtitle.Text,
                Email = txtEmail.Text,
                Address = txtAddress.Text,
                photo = imageBrush.ImageSource.ToString()
            });

            
        
        }

        private void ListContacts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btnEdit.Visibility = Visibility.Visible;
        }

        private void Edit_Click(object sender, EventArgs e)
        {

        }
    }
}

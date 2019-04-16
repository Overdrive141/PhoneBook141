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
        Ellipse ellipse = new Ellipse();
        string defaultPath = "C:/Users/farha/Desktop/Wallpapers/141.png";

        BitmapImage cImage = new BitmapImage();


        public Contacts()
        {
            InitializeComponent();

           // var cImage = new BitmapImage(new Uri("C:/Users/farha/Desktop/Wallpapers/141.png"));
             
              cImage.BeginInit();

            cImage.CacheOption = BitmapCacheOption.None;
            cImage.UriCachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
            cImage.CacheOption = BitmapCacheOption.OnLoad;
            cImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;


             cImage.UriSource = new Uri(getPhoto(), UriKind.Relative);
             cImage.EndInit();

            Resources["ContactPhoto"] = cImage;

            //this.listContacts.ItemsSource = c1.GetAllContacts();
            //Load contacts in List
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
                photo = getPhoto()
                
                    

                });

                this.listContacts.ItemsSource = null;
            this.listContacts.Items.Refresh();
                this.listContacts.ItemsSource = c1.GetAllContacts();

            

        }

        private string getPhoto()
        {
            if (btnUpload.Content.ToString() == "Upload")
                return defaultPath;
            else
                return btnUpload.Content.ToString();

        }

        private void PhotoUpload_Click(object sender, RoutedEventArgs e)
        {
            btnUpload.Content = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                btnUpload.Content = openFileDialog.FileName;


        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            /*c1.AddContact(
                txtFName.Text, txtLName.Text, txtPhArea.Text, txtPhNumber.Text, txtCompany.Text, txtJobtitle.Text, txtEmail.Text, txtAddress.Text
                );*/
            c1.AddContact(new Contact()
            {
                FName = txtFName.Text,
                LName = txtLName.Text,
                PhArea = txtPhArea.Text,
                PhNumber = txtPhNumber.Text,
                Company = txtCompany.Text,
                JobTitle = txtJobtitle.Text,
                Email = txtEmail.Text,
                Address = txtAddress.Text
            });
           // btnUpload.Content = "";
            
            //Console.WriteLine(c1.GetContact(0));
        
        }
        
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            this.listContacts.ItemsSource = null;
            this.listContacts.ItemsSource = c1.GetAllContacts();
            Resources["ContactPhoto"] = cImage;

        }

        
    }
}

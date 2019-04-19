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
        ListBox listBox = new ListBox();

        TextBox lblFNameEdit;
        TextBox lblLNameEdit;
        TextBox lblphoneAreaEdit;
        TextBox lblphoneNumberEdit;
        TextBox lblCompanyEdit;
        TextBox lblEmailEdit;
        TextBox lblAddressEdit;

        public List<TextBox> mytxtBox = new List<TextBox>();

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

            this.listContacts.ItemsSource = c1.GetAllContacts();
            this.content1.Content = c1.GetAllContacts();



        }
        //SelfExplanatory
        private void PhotoUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();  
            if (openFileDialog.ShowDialog() == true)
            {
                imageBrush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
                btnUpload.Content = "Uploaded";
            }
                    
        }
        /* Adds new contact and Changes text of upload button between Uploaded and Upload for
         distinguishing between Default and Loaded images.*/
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (btnUpload.Content.ToString() == "Uploaded")
            {
                c1.AddContact(new Contact()
                {
                    _FName = txtFName.Text,
                    _LName = txtLName.Text,
                    _PhArea = txtPhArea.Text,
                    _PhNumber = txtPhNumber.Text,
                    _Company = txtCompany.Text,
                    _JobTitle = txtJobtitle.Text,
                    _Email = txtEmail.Text,
                    _Address = txtAddress.Text,
                    photo = imageBrush.ImageSource.ToString()
                });      
            }
            else
            {
                MessageBox.Show("You have not selected an Image. Default image will be added.", "No Image Selected", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                c1.AddContact(new Contact()
                {
                    _FName = txtFName.Text,
                    _LName = txtLName.Text,
                    _PhArea = txtPhArea.Text,
                    _PhNumber = txtPhNumber.Text,
                    _Company = txtCompany.Text,
                    _JobTitle = txtJobtitle.Text,
                    _Email = txtEmail.Text,
                    _Address = txtAddress.Text,
                    photo = "141.png"
                });
            }

            txtFName.Text = "";
            txtLName.Text = "";
            txtPhArea.Text = "";
            txtPhNumber.Text = "";
            txtCompany.Text = "";
            txtJobtitle.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            btnUpload.Content = "Upload";

            tabControl.SelectedIndex = 1;
       
            
        
            this.listContacts.ItemsSource = c1.GetAllContacts();

        }

        private void ListContacts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btnEdit.Visibility = Visibility.Visible;
        }

        //Simply adds an item of TextBox type to the List mytxtbox
        public void AddTextBox(TextBox textBox)
        {
            mytxtBox.Add(textBox);
        }

        /*Edit EventHandler switches between Done and Edit. If Done then Visibility of TextBoxes overlapping the lables 
         are changed back to Hidden and if Edit is pressed then Visibility of TextBoxes is visible so that they can be editted and getTextBox and addListItems
         Methods are called here. Their descriptions are written alongside their methods.
         List Items are refreshed upon exit*/
        private void Edit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Content.ToString() == "Done")
            {
                foreach (TextBox textBox in mytxtBox)
                {
                    ChangeVisibility(textBox);
                }
                this.listContacts.Items.Refresh();
                btnEdit.Content = "Edit";
            }
            else
            {
                getTextBox();
                addListItems();
                foreach (TextBox textBox in mytxtBox)
                {
                    ChangeVisibility(textBox);
                }
                btnEdit.Content = "Done";
            }
        }


        /* This method basically climbs up the hierarchy to get the TextBoxes defined in ContentControl DataTemplate that are not publicly accessible.
         After getting them and saving them as variables they are typecasted to textboxes*/
        private void getTextBox()
        {
            var gridView = VisualTreeHelper.GetParent(btnEdit);
            var gridDetails = VisualTreeHelper.GetChild(gridView, 1);
            var content1 = VisualTreeHelper.GetChild(gridDetails, 0);
            var datatmpDetails = VisualTreeHelper.GetChild(content1, 0);
            var borderDetails = VisualTreeHelper.GetChild(datatmpDetails, 0);
            var gridDetailsImage = VisualTreeHelper.GetChild(borderDetails, 0);

            var txtbox1 = VisualTreeHelper.GetChild(gridDetailsImage, 3);
            var txtbox2 = VisualTreeHelper.GetChild(gridDetailsImage, 6);
            var txtbox3 = VisualTreeHelper.GetChild(gridDetailsImage, 9);
            var txtbox4 = VisualTreeHelper.GetChild(gridDetailsImage, 11);
            var txtbox5 = VisualTreeHelper.GetChild(gridDetailsImage, 14);
            var txtbox6 = VisualTreeHelper.GetChild(gridDetailsImage, 17);
            var txtbox7 = VisualTreeHelper.GetChild(gridDetailsImage, 20);

            lblFNameEdit = (txtbox1 as TextBox);
            lblLNameEdit = (txtbox2 as TextBox);
            lblphoneAreaEdit = (txtbox3 as TextBox);
            lblphoneNumberEdit = (txtbox4 as TextBox);
            lblCompanyEdit = (txtbox5 as TextBox);
            lblEmailEdit = (txtbox6 as TextBox);
            lblAddressEdit = (txtbox7 as TextBox);

        }

        /* This calls the AddTextBox method that has been defined above to add all the TextBoxes 
         that have been saved through VisualTreeHelper and adds them to a List of type TextBox*/
        public void addListItems()
        {      
            AddTextBox(lblFNameEdit);
            AddTextBox(lblLNameEdit);
            AddTextBox(lblphoneAreaEdit);
            AddTextBox(lblphoneNumberEdit);
            AddTextBox(lblCompanyEdit);
            AddTextBox(lblEmailEdit);
            AddTextBox(lblAddressEdit);
        }

        //Basic method that changes visibility between Collapsed and Visible
        public void ChangeVisibility(TextBox textBox)
        {
            if (textBox.Visibility == Visibility.Collapsed)
                textBox.Visibility = Visibility.Visible;
            else
                textBox.Visibility = Visibility.Collapsed;

        }

        //EventHandler for SearchBox that detects TextChange
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.listContacts.ItemsSource = (c1[txtSearch.Text]);
        }

        //Delete EventHandler that deletes only if there is any item in ObservableCollection.
        public void Delete_Click(object sender, EventArgs e)
        {
            int index = listContacts.SelectedIndex;
            if (index != -1)
            {
                c1.DeleteContact(index);
            }
            else
                MessageBox.Show("List is Empty. Please add before deleting", "Unable to Delete", MessageBoxButton.OK, MessageBoxImage.Error);

        }
    }
}

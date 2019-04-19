using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows;

namespace PhoneBook
{
    public enum ContactType
    {
        FName, LName, PhArea, PhNumber, Company, JobTitle, Email, Address, Photo
    }

    public class Class1
    {

        private ObservableCollection<Contact> cList = new ObservableCollection<Contact>();

        public void AddContact(Contact contact)
        {
            cList.Add(contact);
        }

        public ObservableCollection<Contact> GetAllContacts()
        {
            return this.cList;
        }

        public Contact GetContact(int index)
        {
            return cList[index];
        }

        public void DeleteContact(int index)
        {
            cList.RemoveAt(index);
        }

        public String this[int index]
        {
            get
            {
                return this.cList[index].Name;
            }

        }

        public ObservableCollection<Contact> this[string search]
        {
            get
            {
                return new ObservableCollection<Contact>(this.cList.Where(x => x.Name.Contains(search)).ToList());
            }

        }


    }
    public class Contact
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string FName;
        public string LName;
        public string PhArea;
        public string PhNumber;
        public string Company;
        public string JobTitle;
        public string Email;
        public string Address;
        public string photo { get; set; }

        /* All methods are defined to implement the OnPropertyChanged method to support TwoWayBinding and display changes made in TextBox to Labels overlapping
         and the List Items in ListBox.*/

        public string _FName
        {
            set
            {
                FName = value;
                OnPropertyChanged("_FName");
            }
            get
            {
                return FName;
            }
        }

        public string _LName
        {
            set
            {
                LName = value;
                OnPropertyChanged("_LName");
            }
            get
            {
                return LName;
            }
        }

        public string _PhArea
        {
            set
            {
                PhArea = value;
                OnPropertyChanged("_PhArea");
            }
            get
            {
                return PhArea;
            }
        }

        public string _PhNumber
        {
            set
            {
                PhNumber = value;
                OnPropertyChanged("_PhNumber");
            }
            get
            {
                return PhNumber;
            }
        }

        public string _Company
        {
            set
            {
                Company = value;
                OnPropertyChanged("_Company");
            }
            get
            {
                return Company;
            }
        }

        public string _JobTitle
        {
            set
            {
                JobTitle = value;
                OnPropertyChanged("_JobTitle");
            }
            get
            {
                return JobTitle;
            }
        }

        public string _Email
        {
            set
            {
                Email = value;
                OnPropertyChanged("_Email");
            }
            get
            {
                return Email;
            }
        }

        public string _Address
        {
            set
            {
                Address = value;
                OnPropertyChanged("_Address");
            }
            get
            {
                return Address;
            }
        }


        public string Name
        {

            get
            {
                return _FName + " " + _LName;
            }
        }

        public string Number
        {
            get
            {
                return _PhArea + "-" + _PhNumber;
                
            }
        }

        public override string ToString()
        {
            return this.FName + this.LName + ", " + this.PhArea + this.PhNumber;
        }

        //A method that automatically reflects changes made in Edittable Mode to ObservableCollection (List).
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

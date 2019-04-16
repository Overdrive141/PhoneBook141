using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace PhoneBook
{
    public enum ContactType { FName, LName, PhArea, PhNumber, Company, JobTitle, Email, Address, Photo
    }

    public class Class1
    {
        //private List<Contact> cList = new List<Contact>();
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

        public Contact this[int index]
        {
            get
            {
                return this.cList[index];
            }
            set
            {
                this.cList[index] = value;
            }
        }

        public Contact this[string Name]
        {
            get
            {
                foreach (var item in cList)
                {
                    if (item.FName.StartsWith(Name) || item.LName.StartsWith(Name))
                        return item;
                }
                return new Contact();
            }
            // TODO: Write set part of indexer. It searches for name and replaces contact
        }

     

      /*  public Contact this[string Number, ContactType contactType]
        {
            get
            {
                return this.cList.Find(x => x.PhNumber.StartsWith(Number));
            }
            //TODO: Convert this indexer as generic indexer which works with Name and Number
            // Based on user selection of ContactType
        }
        */
    }
    public class Contact
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string PhArea { get; set; }
        public string PhNumber { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string photo { get; set; }
       
       public string Name
        {
            get
            {
                return FName + LName;
            }
        }

        public string Number
        {
            get
            {
                return PhArea + PhNumber;
            }
        }



        public override string ToString()
        {
            return this.FName + this.LName + ", " + this.PhArea + this.PhNumber;
        }
    }
}

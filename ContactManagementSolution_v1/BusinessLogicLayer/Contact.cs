using DataAccessLayer;
using DataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial class Contact
    {

        public int ContactID { get; private set; }
        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;
        public string Email { get; set; } = null;
        public string Phone { get; set; } = null;
        public string Address { get; set; } = null;
        public DateTime? DateOfBirth { get; set; }

        public Country Country 
        {
            get
            {
                return Country.GetCuntryByID(CountryID);
            }
        }

        public ContactsImage ImageContact
        {
            get
            {
                return ContactsImage.GetByID(ImageContactID);
            }
        }

        public int CountryID { get; set; }

        public int ImageContactID { get; set; }

        public enMode Mode { get; set; }

        public Contact( enMode mode = enMode.Add)
        {
            this.ContactID = -1;
            this.Mode = mode;
        }

        private bool _AddNew()
        {
            ContactDTO contact = SetContactDTO();

            int ID = DataAccessLayer.ContactDB.AddNew(contact);

            if (ID > 0)
            {
                ContactID = ID;
                return true;
            }

            return false;
        }

        private bool _Updat()
        {

            ContactDTO contact = SetContactDTO();
            contact.ID = this.ContactID;

            return DataAccessLayer.ContactDB.Update(contact);

        }

        public bool Save()
        {

            bool Saved = false;

            switch (Mode)
            {
                case enMode.None:
                    return Saved;
                case enMode.Add:
                    if (_AddNew())
                    {
                        Saved = true;
                        Mode = enMode.Update;
                        break;
                    }
                    else
                    {
                        Saved = false;
                        break;
                    }
                case enMode.Update:
                    if (_Updat())
                    {
                        Saved = true;
                    }
                    break;
                default:
                    break;
            }


            return Saved;

        }

        private ContactDTO SetContactDTO()
        {

           return
           new ContactDTO()
           {
               ID = ContactID,
               FirstName = FirstName,
               LastName = LastName,
               Email = Email,
               Phone = Phone,
               Address = Address,
               CountryID = CountryID,
               DateOfBirth = DateOfBirth,
               ImageID = ImageContactID,
           };
        }

        public static List<Contact> GetAll()
        {

            List<Contact> listContacts = new List<Contact>();

            foreach (var record in DataAccessLayer.ContactDB.GetAll())
            {

                var con =
                    new Contact()
                    {
                        ContactID = record.ID,
                        FirstName = record.FirstName,
                        LastName = record.LastName,
                        Email = record.Email,
                        Phone = record.Phone,
                        Address = record.Address,
                        CountryID = record.CountryID,
                        DateOfBirth= record.DateOfBirth,
                    };

                listContacts.Add(con);

            }

            return listContacts;

        }

        public static bool Delete(int contactId)
        {
            return DataAccessLayer.ContactDB.Delete(contactId);
        }

        public static Contact GetContactByID(int contactId)
        {
            var con = DataAccessLayer.ContactDB.GetById(contactId);

            if (con != null)
                return new Contact()
                {
                    ContactID = con.ID,
                    FirstName = con.FirstName,
                    LastName = con.LastName,
                    Email = con.Email,
                    Phone = con.Phone,
                    Address = con.Address,
                    CountryID = con.CountryID,
                    DateOfBirth= con.DateOfBirth,
                    ImageContactID = con.ImageID,
                    Mode = enMode.Update,
                };
            else return null;

        }

        public static bool IsContactExist(int contactId)
        {
            return ContactDB.IsContactExist(contactId);
        }

    }
}

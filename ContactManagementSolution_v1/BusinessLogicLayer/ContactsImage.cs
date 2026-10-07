using DataAccessLayer;
using DataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogicLayer.Contact;

namespace BusinessLogicLayer
{
    public class ContactsImage
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageContentType { get; set; }

        public enMode Mode { get; set; }

        public ContactsImage(enMode mode = enMode.Add)
        {
            this.Id = -1;
            this.Mode = mode;
        }

        private bool _AddNew()
        {
            ImageContactDTO ImageContact = SetContactDTO();

            int ID = DataAccessLayer.ImageContactDB.AddNew(ImageContact);

            if (ID > 0)
            {
                this.Id = ID;
                return true;
            }

            return false;
        }

        private bool _Updat()
        {

            ImageContactDTO ImageContact = SetContactDTO();
            ImageContact.Id = this.Id;

            return DataAccessLayer.ImageContactDB.Update(ImageContact);

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

        private ImageContactDTO SetContactDTO()
        {
            return
            new ImageContactDTO
            {
                Id = this.Id,
                Name = this.Name,
                ImageContentType = this.ImageContentType,
                ImageData = this.ImageData,
            };
        }

        public static List<ContactsImage> GetAll()
        {

            List<ContactsImage> ListImageContacts = new List<ContactsImage>();

            foreach (DataRow row in DataAccessLayer.CountryDB.GetAll().Rows)
            {

                ListImageContacts.Add
                    (
                        new ContactsImage()
                        {
                            Id = Convert.ToInt32(row[0]),
                            Name = Convert.ToString(row[1]),
                            ImageData = (byte[])row[2],
                            ImageContentType = Convert.ToString(row[3]),
                        }
                    );
            }

            return ListImageContacts;

        }

        public static bool IsExist(int id)
        {
            return DataAccessLayer.ImageContactDB.IsExist(id);
        }

        public static bool IsCountryExist(string countryName)
        {
            return CountryDB.IsContactExist(countryName);
        }

        public static ContactsImage GetByID(int ID)
        {
            ImageContactDTO con = DataAccessLayer.ImageContactDB.GetById(ID);

            if (con != null)
                return
                new ContactsImage()
                {
                    Id = con.Id,
                    Name = con.Name,
                    ImageData = con.ImageData,
                    ImageContentType = con.ImageContentType,
                };
            else return null;

        }

        public static bool Delete(int ID)
        {
            return DataAccessLayer.ImageContactDB.Delete(ID);
        }
    }
}

using DataAccessLayer;
using DataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogicLayer.Contact;

namespace BusinessLogicLayer
{
    public class Country
    {

        public int CountryID { get; set; }
        public string CountryName { get; set; } = null;
        public string Code { get; set; } = null;
        public string PhoneCode { get; set; } = null;

        public enMode Mode { get; set; }

        public Country(enMode mode = enMode.Add)
        {
            this.CountryID = -1;
            this.Mode = mode;
        }

        private bool _AddNew()
        {
            CountryDTO country = SetContactDTO();

            int ID = DataAccessLayer.CountryDB.AddNew(country);

            if (ID > 0)
            {
                this.CountryID = ID;
                return true;
            }

            return false;
        }

        private bool _Updat()
        {

            CountryDTO country = SetContactDTO();
            country.CountryID = this.CountryID;

            return DataAccessLayer.CountryDB.Update(country);

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

        private CountryDTO SetContactDTO()
        {
            return
            new CountryDTO
            {
                CountryName = this.CountryName,
                CountryID = this.CountryID,
                Code = this.Code,
                PhoneCode = this.PhoneCode,
            };
        }

        public static List<Country> GetAll()
        {

            List<Country> listContacts = new List<Country>();

            foreach (DataRow row in DataAccessLayer.CountryDB.GetAll().Rows)
            {

                listContacts.Add
                    (
                        new Country()
                        {
                            CountryID = Convert.ToInt32(row[0]),
                            CountryName = Convert.ToString(row[1]),
                            Code = Convert.ToString(row[2]),
                            PhoneCode = Convert.ToString(row[3]),
                        }
                    );
            }

            return listContacts;

        }

        public static bool IsCountryExist(int cuntryID)
        {
            return CountryDB.IsContactExist(cuntryID);
        }

        public static bool IsCountryExist(string countryName)
        {
            return CountryDB.IsContactExist(countryName);
        }

        public static Country GetCuntryByID(int cuntryID)
        {
            CountryDTO con = DataAccessLayer.CountryDB.GetById(cuntryID);

            if (con != null)
                return
                new Country()
                {
                    CountryID = con.CountryID,
                    CountryName = con.CountryName,
                    Code = con.Code,
                    PhoneCode = con.PhoneCode,
                };
            else return null;

        }

        public static Country GetCountryByName(string  CountryName)
        {
            CountryDTO con = DataAccessLayer.CountryDB.GetByName(CountryName);

            if (con != null)
                return
                new Country()
                {
                    CountryID = con.CountryID,
                    CountryName = con.CountryName,
                    Code = con.Code,
                    PhoneCode = con.PhoneCode,
                };
            else return null;
        }

        public static bool Delete(int cuntryID)
        {
            return DataAccessLayer.CountryDB.Delete(cuntryID);
        }

    }
}

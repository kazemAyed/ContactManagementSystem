using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ContactManagmrnt_WindowsFormsApp
{

    public partial class AddEditForm : Form
    {

        public BusinessLogicLayer.Contact Contact;
        public BusinessLogicLayer.ContactsImage ContactImage;
        public BusinessLogicLayer.Country Country;

        public ContactManagment_Form ContactManagment_ { get; set; }

        public AddEditForm()
        {
            InitializeComponent();
        }

        public BusinessLogicLayer.Contact.enMode Mode = BusinessLogicLayer.Contact.enMode.None;

        private string SetTheTitileName() => this.Mode.ToString();

        private void LoadCuntriesTocmbCuntry()
        {
            List<string> ListOfCountries = new List<string>();

            foreach (var countryName in BusinessLogicLayer.Country.GetAll())
                ListOfCountries.Add(countryName.CountryName);

            this.cmbCuntry.DataSource = ListOfCountries;
        }

        private void ShowRemoveImageLable()
        {
            if (this.Mode == BusinessLogicLayer.Contact.enMode.Update) this.lblRemoveImage.Visible = true;
            else this.lblRemoveImage.Visible = false;
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
            this.lblTitile.Text = SetTheTitileName();
            ShowRemoveImageLable();
            LoadCuntriesTocmbCuntry();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (this.Mode)
            {
                case BusinessLogicLayer.Contact.enMode.None:
                    break;
                case BusinessLogicLayer.Contact.enMode.Add:
                    {
                        Add();
                    }
                    break;
                case BusinessLogicLayer.Contact.enMode.Update:
                    {
                        Upate();
                    }
                    break;
                default:
                    break;
            }
        }

        private void lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            switch (this.Mode)
            {
                case BusinessLogicLayer.Contact.enMode.None:
                    break;
                case BusinessLogicLayer.Contact.enMode.Add:
                    {
                        SetImageFromFile();
                    }
                    break;
                case BusinessLogicLayer.Contact.enMode.Update:
                    {
                        UpdatImageFromFile();
                    }
                    break;
                default:
                    break;
            }

        }

    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManagmrnt_WindowsFormsApp
{

    public partial class ContactManagment_Form : Form
    {

        public ContactManagment_Form()
        {
            InitializeComponent();
        }

        public void LaodContactData()
        {

            DataTable allContact = new DataTable();

            allContact.Columns.Add("ContactID", typeof(int));
            allContact.Columns.Add("FirstName", typeof(string));
            allContact.Columns.Add("LastName", typeof(string));
            allContact.Columns.Add("Date Of Birth", typeof(DateTime));
            allContact.Columns.Add("Country", typeof(string));
            allContact.Columns.Add("Email", typeof(string));
            allContact.Columns.Add("Address", typeof(string));
           

            var contact = BusinessLogicLayer.Contact.GetAll();

            foreach (BusinessLogicLayer.Contact contactItem in contact)
            {
                allContact.Rows.Add(
                    contactItem.ContactID,
                    contactItem.FirstName,
                    contactItem.LastName,
                    contactItem.DateOfBirth,
                    contactItem.Country?.CountryName,
                    contactItem.Email,
                    contactItem.Address
                );
            }

            dgvContacts.DataSource = allContact;
            dgvContacts.ClearSelection();

        }

        private void ContactManagment_Form_Load(object sender, EventArgs e)
        {
            LaodContactData();
        }

        private void dgvContacts_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvContacts.ClearSelection();
                dgvContacts.Rows[e.RowIndex].Selected = true;
                dgvContacts.CurrentCell = dgvContacts.Rows[e.RowIndex].Cells[0];
            }
        }

        private int GetIdRowSelected()
        {
            if (dgvContacts.SelectedRows.Count == 0)
                return -1;

            DataGridViewRow row = dgvContacts.SelectedRows[0];

            if (row.Cells["ContactID"].Value == null || row.Cells["ContactID"].Value == DBNull.Value) 
                return -1;

            return Convert.ToInt32(row.Cells["ContactID"].Value);
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            int id = GetIdRowSelected();

            if (id == -1)
            {
                MessageBox.Show(
                    "Please select a contact first.",
                    "Delete Contact",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Ask for confirmation
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this contact?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                // Delete the contact
                bool deleted = BusinessLogicLayer.Contact.Delete(id);

                if (deleted)
                {
                    MessageBox.Show(
                        "Contact deleted successfully.",
                        "Delete Contact",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Refresh DataGridView
                    LaodContactData();

                    // Clear selection
                    dgvContacts.ClearSelection();
                }
                else
                {
                    MessageBox.Show(
                        "The contact could not be deleted.",
                        "Delete Contact",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred while deleting the contact.\n\n" +
                    ex.Message,
                    "Delete Contact",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ContactId = GetIdRowSelected();

            BusinessLogicLayer.Contact contact = BusinessLogicLayer.Contact.GetContactByID(ContactId);

            BusinessLogicLayer.ContactsImage image = null;

            if (contact != null && contact.ImageContactID > 0) 
            {
                image = BusinessLogicLayer.ContactsImage.GetByID(contact.ImageContactID);
                image.Mode = BusinessLogicLayer.Contact.enMode.Update;
            }
            
            AddEditForm addEditForm = new AddEditForm();

            if (contact != null)
                contact.Mode = addEditForm.Mode = BusinessLogicLayer.Contact.enMode.Update;

            addEditForm.Contact = contact;
            addEditForm.ContactImage = image;
            addEditForm.FullContactData();
            addEditForm.ContactManagment_ = this;
            addEditForm.ShowDialog();
        }

        private void btnAddNewContact_Click(object sender, EventArgs e)
        {
            AddEditForm addEditForm = new AddEditForm();
            addEditForm.ContactManagment_ = this;
            addEditForm.Mode = BusinessLogicLayer.Contact.enMode.Add;
            addEditForm.ShowDialog();
        }

    }

}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManagmrnt_WindowsFormsApp
{

    ///////////////////////////////////
    //////                         ////
    //////      Add CONTACT        ////
    //////                         ////
    ///////////////////////////////////


    public partial class AddEditForm
    {

        private void Add()
        {
            try
            {

                bool imageSaved = false;

                if (this.ContactImage != null && string.IsNullOrEmpty(this.txtFirstName.Text))
                {
                    // Validate contact data first
                    MessageBox.Show(
                      "Please enter the first name.",
                      "Validation",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);

                    return;
                }


                if (this.ContactImage != null)
                {
                    // save the name image 
                    this.ContactImage.Name = this.txtFirstName.Text;

                    // Save image first
                    imageSaved = ContactImage.Save();
                }

                if (!imageSaved && this.ContactImage == null)
                {
                    MessageBox.Show(
                        "The image could not be saved.",
                        "Save Contact",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    // return;
                }

                this.Contact = SetContactInfoFromForm();

                if (imageSaved && this.ContactImage.Id > 0)
                {
                    // Set the generated ImageID on the contact
                    this.Contact.ImageContactID = ContactImage.Id;
                }

                // Save contact
                bool contactSaved = Contact.Save();

                if (!contactSaved)
                {
                    MessageBox.Show(
                        "The contact could not be saved.",
                        "Save Contact",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                MessageBox.Show(
                    "Contact saved successfully.",
                    "Save Contact",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                if (this.ContactManagment_ != null) this.ContactManagment_.LaodContactData();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred while saving the contact.\n\n" +
                    ex.Message,
                    "Save Contact",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string GetContentType(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLower();

            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";

                case ".png":
                    return "image/png";

                case ".gif":
                    return "image/gif";

                case ".bmp":
                    return "image/bmp";

                default:
                    return "application/octet-stream";
            }
        }

        private void SetImageFromFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Contact Image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    // Load the image without locking the original file
                    using (FileStream stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (System.Drawing.Image tempImage = System.Drawing.Image.FromStream(stream))
                        {

                            // Create a copy
                            pictureContact.Image = new Bitmap(tempImage);

                            // Save information for later database insertion
                            byte[] imageData = File.ReadAllBytes(openFileDialog.FileName);
                            string imageContentType = GetContentType(openFileDialog.FileName);

                            this.ContactImage = new BusinessLogicLayer.ContactsImage();

                            this.ContactImage.ImageContentType = imageContentType;
                            this.ContactImage.ImageData = imageData;

                            this.ContactImage.Name =
                                string.IsNullOrEmpty(this.txtFirstName.Text) ? openFileDialog.FileName : this.txtFirstName.Text;

                            if (this.Contact != null)
                            {
                                this.ContactImage.Id = this.Contact.ImageContactID;
                                this.ContactImage.Name = this.Contact.FirstName;
                            }

                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Could not load the image.\n\n" + ex.Message,
                        "Image Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

            }
        }

        private DateTime GetDateOfBirth()
        {
            if (this.dtpDateOfContact == null || this.dtpDateOfContact.Value == null) return DateTime.Now;
            else return this.dtpDateOfContact.Value;
        }

        private BusinessLogicLayer.Contact SetContactInfoFromForm()
        {

            BusinessLogicLayer.Contact contact = new BusinessLogicLayer.Contact();

            contact.FirstName = this.txtFirstName.Text;
            contact.LastName = this.txtLastName.Text;
            contact.Email = this.txtEmail.Text;
            contact.Address = this.txtAddress.Text;
            contact.Phone = this.txtPhone.Text;
            contact.CountryID = BusinessLogicLayer.Country.GetCountryByName(this.cmbCuntry.Text).CountryID;
            contact.DateOfBirth = GetDateOfBirth();

            return contact;

        }

    }
}

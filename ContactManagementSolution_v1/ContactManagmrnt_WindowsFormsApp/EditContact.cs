using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManagmrnt_WindowsFormsApp
{

    ///////////////////////////////////
    //////                         ////
    //////      Edit CONTACT       ////
    //////                         ////
    ///////////////////////////////////

    public partial class AddEditForm
    {

        private void Upate()
        {
            try
            {
                // -------------------------------------------------
                // 1. Get the updated contact
                // -------------------------------------------------
                this.Contact = this.ModifyTheContact();

                if (this.Contact == null)
                    return;

                // Make sure the contact is in Update mode
                this.Contact.Mode = BusinessLogicLayer.Contact.enMode.Update;


                // -------------------------------------------------
                // 2. Validate contact information
                // -------------------------------------------------
                if (string.IsNullOrWhiteSpace(this.txtFirstName.Text))
                {
                    MessageBox.Show(
                        "Please enter the first name.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // -------------------------------------------------
                // 3. Get the image information
                // -------------------------------------------------
                this.ContactImage = this.ModifyTheContactImage();


                // -------------------------------------------------
                // 4. Save image if there is an image
                // -------------------------------------------------
                if (this.ContactImage != null)
                {
                    // Update image name
                    this.ContactImage.Name = this.txtFirstName.Text;

                    // Determine whether this is an existing image
                    // or a new image.
                    if (this.ContactImage.Id > 0)
                    {
                        this.ContactImage.Mode =
                            BusinessLogicLayer.Contact.enMode.Update;
                    }
                    else
                    {
                        this.ContactImage.Mode =
                            BusinessLogicLayer.Contact.enMode.Add;
                    }


                    // Save image
                    bool imageSaved = this.ContactImage.Save();

                    if (!imageSaved)
                    {
                        MessageBox.Show(
                            "The image could not be saved.",
                            "Save Contact",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return;
                    }


                    // -------------------------------------------------
                    // 5. Set the image ID on the contact
                    // -------------------------------------------------
                    if (this.ContactImage.Id > 0)
                    {
                        this.Contact.ImageContactID = this.ContactImage.Id;
                    }
                }


                // -------------------------------------------------
                // 6. Save contact
                // -------------------------------------------------
                bool contactSaved = this.Contact.Save();

                if (!contactSaved)
                {
                    MessageBox.Show(
                        "The contact could not be saved.",
                        "Save Contact",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }


                // -------------------------------------------------
                // 7. Success
                // -------------------------------------------------
                MessageBox.Show(
                    "Contact saved successfully.",
                    "Save Contact",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                if (this.ContactManagment_ != null)
                {
                    this.ContactManagment_.LaodContactData();
                }

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

        private ContactsImage ModifyTheContactImage()
        {
            Image image = this.pictureContact.Image;

            // No image selected
            if (image == null)
                return null;

            byte[] imageBytes;

            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                imageBytes = ms.ToArray();
            }

            ContactsImage imageContact = this.Contact.ImageContact;

            // Contact doesn't have an image yet
            if (imageContact == null)
            {
                imageContact = new ContactsImage();
                imageContact.Mode = Contact.enMode.Add;
            }
            else
            {
                // Contact already has an image
                imageContact.Mode = Contact.enMode.Update;
            }

            imageContact.ImageData = imageBytes;
            imageContact.Name = this.Contact.FirstName;
            imageContact.ImageContentType = ".png";

            return imageContact;
        }

        private BusinessLogicLayer.Contact ModifyTheContact()
        {
            
            BusinessLogicLayer.Contact contact = 
                BusinessLogicLayer.Contact.GetContactByID(Convert.ToInt32(this.lblID.Text)) 
                as BusinessLogicLayer.Contact;

            contact.FirstName = this.txtFirstName.Text;
            contact.LastName = this.txtLastName.Text;
            contact.Email = this.txtEmail.Text;
            contact.Address = this.txtAddress.Text;
            contact.Phone = this.txtPhone.Text;
            contact.CountryID = BusinessLogicLayer.Country.GetCountryByName(this.cmbCuntry.Text).CountryID;
            contact.DateOfBirth = GetDateOfBirth();

            return contact;
        }

        public void FullContactData()
        {

            FullFormByContactData();
            this.ContactImage = BusinessLogicLayer.ContactsImage.GetByID(this.Contact.ImageContactID);

            if (this.ContactImage != null)
                SetImageConact(this.ContactImage.ImageData);

        }

        private void FullFormByContactData()
        {
            this.lblID.Text = this.Contact.ContactID.ToString();
            this.txtFirstName.Text = this.Contact.FirstName;
            this.txtLastName.Text = this.Contact.FirstName;
            this.txtLastName.Text = this.Contact.LastName;
            this.txtPhone.Text = this.Contact.Phone;
            this.txtEmail.Text = this.Contact.Email;
            this.txtAddress.Text = this.Contact.Address;

            this.dtpDateOfContact.Value = this.Contact.DateOfBirth != null ?
                this.Contact.DateOfBirth.Value : DateTime.Now;

            this.cmbCuntry.Text = this.Contact.Country != null ?
                this.Contact.Country.CountryName.ToString() : string.Empty;

        }

        private void SetImageConact(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
            {
                this.pictureContact.Image = null;
                return;
            }

            using (MemoryStream ms = new MemoryStream(imageData))
            {
                using (System.Drawing.Image tempImage = System.Drawing.Image.FromStream(ms))
                {
                    this.pictureContact.Image = new Bitmap(tempImage);
                }
            }
        }

        private void UpdatImageFromFile()
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

                            UpdatContactImige(imageContentType, imageData, openFileDialog.FileName);

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

        private void UpdatContactImige(
            string imageContentType,
            byte[] imageData,
            string nameImage)
        {
            this.ContactImage = new ContactsImage();

            this.ContactImage.ImageContentType = imageContentType;
            this.ContactImage.ImageData = imageData;

            this.ContactImage.Name =
                string.IsNullOrEmpty(this.txtFirstName.Text)
                    ? nameImage
                    : this.txtFirstName.Text;

            if (this.Contact != null && this.Contact.ImageContactID > 0)
            {
                // Existing image
                this.ContactImage.Id = this.Contact.ImageContactID;
                this.ContactImage.Mode = Contact.enMode.Update;
            }
            else
            {
                // New image
                this.ContactImage.Mode = Contact.enMode.Add;
            }
        }

    }

}

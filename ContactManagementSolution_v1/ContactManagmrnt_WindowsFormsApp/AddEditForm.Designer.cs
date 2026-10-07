namespace ContactManagmrnt_WindowsFormsApp
{
    partial class AddEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitile = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCuntry = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureContact = new System.Windows.Forms.PictureBox();
            this.lblSetImage = new System.Windows.Forms.LinkLabel();
            this.lblRemoveImage = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDateOfContact = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureContact)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitile
            // 
            this.lblTitile.AutoSize = true;
            this.lblTitile.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitile.Location = new System.Drawing.Point(293, 25);
            this.lblTitile.Name = "lblTitile";
            this.lblTitile.Size = new System.Drawing.Size(92, 31);
            this.lblTitile.TabIndex = 0;
            this.lblTitile.Text = "label1";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(50, 129);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(111, 20);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "First Name : ";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(184, 126);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(254, 26);
            this.txtFirstName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contact ID : ";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(180, 91);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(29, 20);
            this.lblID.TabIndex = 4;
            this.lblID.Text = "??";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(184, 182);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(254, 26);
            this.txtLastName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Last Name : ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(184, 237);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(254, 26);
            this.txtEmail.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Email : ";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(184, 284);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(254, 26);
            this.txtPhone.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Phone :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Cuntry :";
            // 
            // cmbCuntry
            // 
            this.cmbCuntry.FormattingEnabled = true;
            this.cmbCuntry.Location = new System.Drawing.Point(184, 377);
            this.cmbCuntry.Name = "cmbCuntry";
            this.cmbCuntry.Size = new System.Drawing.Size(254, 28);
            this.cmbCuntry.TabIndex = 14;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(184, 437);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(334, 150);
            this.txtAddress.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 440);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Address : ";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(573, 623);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 32);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(432, 623);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 32);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureContact
            // 
            this.pictureContact.Location = new System.Drawing.Point(523, 129);
            this.pictureContact.Name = "pictureContact";
            this.pictureContact.Size = new System.Drawing.Size(173, 181);
            this.pictureContact.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureContact.TabIndex = 19;
            this.pictureContact.TabStop = false;
            // 
            // lblSetImage
            // 
            this.lblSetImage.AutoSize = true;
            this.lblSetImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetImage.Location = new System.Drawing.Point(519, 91);
            this.lblSetImage.Name = "lblSetImage";
            this.lblSetImage.Size = new System.Drawing.Size(92, 20);
            this.lblSetImage.TabIndex = 20;
            this.lblSetImage.TabStop = true;
            this.lblSetImage.Text = "Set Image";
            this.lblSetImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSetImage_LinkClicked);
            // 
            // lblRemoveImage
            // 
            this.lblRemoveImage.AutoSize = true;
            this.lblRemoveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemoveImage.Location = new System.Drawing.Point(617, 91);
            this.lblRemoveImage.Name = "lblRemoveImage";
            this.lblRemoveImage.Size = new System.Drawing.Size(129, 20);
            this.lblRemoveImage.TabIndex = 21;
            this.lblRemoveImage.TabStop = true;
            this.lblRemoveImage.Text = "Remove Image";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 334);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Date Of Birth : ";
            // 
            // dtpDateOfContact
            // 
            this.dtpDateOfContact.Location = new System.Drawing.Point(184, 329);
            this.dtpDateOfContact.Name = "dtpDateOfContact";
            this.dtpDateOfContact.Size = new System.Drawing.Size(334, 26);
            this.dtpDateOfContact.TabIndex = 12;
            // 
            // AddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 692);
            this.Controls.Add(this.lblRemoveImage);
            this.Controls.Add(this.lblSetImage);
            this.Controls.Add(this.pictureContact);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbCuntry);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpDateOfContact);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblTitile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "AddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddEditForm";
            this.Load += new System.EventHandler(this.AddEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureContact)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitile;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCuntry;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureContact;
        private System.Windows.Forms.LinkLabel lblSetImage;
        private System.Windows.Forms.LinkLabel lblRemoveImage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDateOfContact;
    }
}
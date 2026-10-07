namespace ContactManagmrnt_WindowsFormsApp
{
    partial class ContactManagment_Form
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
            this.components = new System.ComponentModel.Container();
            this.dgvContacts = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewContact = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvContacts
            // 
            this.dgvContacts.AllowUserToAddRows = false;
            this.dgvContacts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContacts.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvContacts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvContacts.Location = new System.Drawing.Point(0, 97);
            this.dgvContacts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvContacts.Name = "dgvContacts";
            this.dgvContacts.Size = new System.Drawing.Size(1333, 595);
            this.dgvContacts.TabIndex = 0;
            this.dgvContacts.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvContacts_CellMouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewToolStripMenuItem,
            this.updateToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 48);
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.addNewToolStripMenuItem.Text = "Delete";
            this.addNewToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // btnAddNewContact
            // 
            this.btnAddNewContact.BackColor = System.Drawing.Color.White;
            this.btnAddNewContact.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnAddNewContact.Location = new System.Drawing.Point(1130, 18);
            this.btnAddNewContact.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddNewContact.Name = "btnAddNewContact";
            this.btnAddNewContact.Size = new System.Drawing.Size(183, 46);
            this.btnAddNewContact.TabIndex = 1;
            this.btnAddNewContact.Text = "Add New Contact";
            this.btnAddNewContact.UseVisualStyleBackColor = false;
            this.btnAddNewContact.Click += new System.EventHandler(this.btnAddNewContact_Click);
            // 
            // ContactManagment_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 692);
            this.Controls.Add(this.btnAddNewContact);
            this.Controls.Add(this.dgvContacts);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "ContactManagment_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ContactManagment_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvContacts;
        private System.Windows.Forms.Button btnAddNewContact;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
    }
}


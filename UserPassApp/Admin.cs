using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserPassMgrApp
{
    /// <summary>
    /// Displays the admin form that allows the admin user to set a new admin password
    /// </summary>
    /// <remarks>
    /// author: David Pyle 041110777
    /// version: 1.0
    /// date: 02/6/2016
    /// </remarks>
    public partial class Admin : Form
    {
        /// <summary>
        /// Reference back to main form
        /// </summary>
        public MainForm parent;        
        /// <summary>
        /// Current admin password
        /// </summary>
        private string adminPassword;

        /// <summary>
        /// Constructor - initialises form components and sets the admin password from the database
        /// </summary>
        /// <param name="adminPassword"></param>
        public Admin(string adminPassword)
        {
            InitializeComponent();
            this.adminPassword = adminPassword;
        }

        /// <summary>
        /// Sets the mask used for obscuring password fields and clears error messages
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">event arguments</param>
        private void Admin_Load(object sender, EventArgs e)
        {
            txtBoxPassword.PasswordChar = txtBoxPasswordConfirm.PasswordChar = txtBoxCurrentPassword.PasswordChar = '\u25CF';
            lblAddAccountError.Text = string.Empty;
        }

        /// <summary>
        /// Closes the admin form
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">event arguments</param>
        private void btnCancelAccount_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Updates the admin password 
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">event arguments</param>
        private void btnSaveAdmin_Click(object sender, EventArgs e)
        {
            //clear error flag
            bool errorFound = false;
            
            //check that the user entered the correct current admin password
            if (!txtBoxCurrentPassword.Text.Equals(adminPassword))
            {
                lblAddAccountError.Text = "Incorrect admin password";
                errorFound = true;                
            }
                //check that the new admin password is not blank
            else if (txtBoxPassword.Text.Equals(string.Empty))
            {
                lblAddAccountError.Text = "Error: Password cannot be blank";
                lblAddAccountError.Visible = true;
                errorFound = true;                
            }
                //check that the new admin passwords match
            else if (!txtBoxPassword.Text.Equals(txtBoxPasswordConfirm.Text))
            {
                lblAddAccountError.Text = "Error: Passwords do not match";
                lblAddAccountError.Visible = true;
                errorFound = true;                
            }

            //if no errors then update the admin password in the database and close the form
            if (!errorFound)
            {                                
                parent.updateAdminAccount(txtBoxPassword.Text);
                MessageBox.Show("Admin password changed successfully!", "Admin Password Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                //show any error messages
                lblAddAccountError.Visible = true;
            }
        }

        /// <summary>
        /// Hides or shows the password in the password field
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">event arguments</param>
        private void cBoxShowPasswordAccount_CheckedChanged(object sender, EventArgs e)
        {
            txtBoxPassword.PasswordChar = txtBoxCurrentPassword.PasswordChar = txtBoxPasswordConfirm.PasswordChar = cBoxShowPasswordAccount.Checked ? '\0' : '\u25CF';    
        }

        /// <summary>
        /// Get a new 10 character randomly generated password
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">event arguments</param>
        private void btnGenPassword_Click(object sender, EventArgs e)
        {
            //clear any error messages
            lblAddAccountError.Visible = false;
            //generate password
            txtBoxPassword.Text = txtBoxPasswordConfirm.Text = MainForm.CreateRandomPassword(10);
        }
    }
}

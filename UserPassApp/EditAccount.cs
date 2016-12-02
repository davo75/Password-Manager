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
    /// Displays the Account form for editing an exisint account
    /// </summary>
    /// <remarks>
    /// author: David Pyle 041110777
    /// version: 1.0
    /// date: 02/6/2016
    /// </remarks>
    public partial class EditAccount : Form
    {
        /// <summary>
        /// Reference back to main form 
        /// </summary>
        public MainForm parent;        
        /// <summary>
        /// LoginID of account
        /// </summary>
        private string loginID;
        /// <summary>
        /// Password before editing
        /// </summary>
        private string oldPassword;

        /// <summary>
        /// Constructor - initialise the form components and set the mask for obscuring password fields
        /// </summary>
        public EditAccount()
        {
            InitializeComponent();
            txtBoxPassword.PasswordChar = txtBoxPasswordConfirm.PasswordChar = '\u25CF';            
        }

        /// <summary>
        /// When loading the form bind existing account details to form fields
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">event arguments</param>
        private void AccountForm_Load(object sender, EventArgs e)
        {    
            //bind account details
            bindAccountDetails();     
            //hide error label
            lblAddAccountError.Visible = false;
            //disable editing passwords controls
            txtBoxPassword.Enabled = txtBoxPasswordConfirm.Enabled = false;
            cBoxShowPasswordAccount.Enabled = false;
            btnGenPassword.Enabled = false;
            //store the current password in case password edit cancelled
            oldPassword = txtBoxPassword.Text;
        }

        /// <summary>
        /// Binds account info to the relevant form fields
        /// </summary>
        private void bindAccountDetails()
        {
            //get the currently selected loginID from the binding source
            loginID = ((DataRowView)parent.bs.Current).Row["LoginID"].ToString();
            //bind account name
            txtBoxAccountName.DataBindings.Add("Text", parent.bs, "AccountName");
            //bind account username
            txtBoxUsername.DataBindings.Add("Text", parent.bs, "Username");
            //bind account password
            txtBoxPassword.DataBindings.Add("Text", parent.bs, "Password");
            //bind account URl
            txtBoxURL.DataBindings.Add("Text", parent.bs, "URL");
        }

        /// <summary>
        /// Updates account details in the database
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">event arguments</param>
        private void button1_Click(object sender, EventArgs e)
        {
            //set error flag
            bool errorFound = false;
            
            //check that the account name is not blank
            if (txtBoxAccountName.Text.Equals(string.Empty))
            {
                lblAddAccountError.Text = "Error: Account Name cannot be blank";
                lblAddAccountError.Visible = true;
                errorFound = true;
            }

            //if the user wants to change the password
            else if (cBoxChangePassword.Checked)
            {
                //check that password is not blank
                if (txtBoxPassword.Text.Equals(string.Empty))
                {
                    lblAddAccountError.Text = "Error: Password cannot be blank";
                    lblAddAccountError.Visible = true;
                    errorFound = true;
                }
                //check the passwords match
                else if (!txtBoxPassword.Text.Equals(txtBoxPasswordConfirm.Text))
                {
                    lblAddAccountError.Text = "Error: Passwords do not match";
                    lblAddAccountError.Visible = true;
                    errorFound = true;
                }
            }          
           
            //if there are no errors update the account and close the form
            if (!errorFound) 
            {
                //if the Show Password checkbox is not checked then ignore any password edits 
                if (!cBoxChangePassword.Checked)
                {                    
                    //data table is bound to the controls so the password will be overwritten so we must restore it back
                    //to the old one
                    ((DataRowView)parent.bs.Current).Row["Password"] = oldPassword;
                    parent.updateAccount(loginID, txtBoxUsername.Text, oldPassword, txtBoxAccountName.Text, txtBoxURL.Text);
                }
                //else the password must have changed so save it
                else
                {
                    parent.updateAccount(loginID, txtBoxUsername.Text, txtBoxPassword.Text, txtBoxAccountName.Text, txtBoxURL.Text);
                }
                
                this.Dispose();
            }
        }

        /// <summary>
        /// Closes the form when the cancel button clicked
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">event arguments</param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Shows or hides the characters in any password fields
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">event arguments</param>
        private void cBoxShowPasswordAccount_CheckedChanged(object sender, EventArgs e)
        {
            txtBoxPassword.PasswordChar = txtBoxPasswordConfirm.PasswordChar = cBoxShowPasswordAccount.Checked ? '\0' : '\u25CF';   
              
        }

        /// <summary>
        /// Enables or disables the password editing controls
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">event arguments</param>
        private void cBoxChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            txtBoxPassword.Enabled = txtBoxPasswordConfirm.Enabled = cBoxShowPasswordAccount.Enabled = btnGenPassword.Enabled = cBoxChangePassword.Checked ? true : false;
            //clear any error messages
            lblAddAccountError.Visible = false;
            
        }

        /// <summary>
        /// Gets a 10 character randomly generated password
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">event arguments</param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            //clear any error messages
            lblAddAccountError.Visible = false;
            //generate password
            txtBoxPassword.Text = txtBoxPasswordConfirm.Text = MainForm.CreateRandomPassword(10);
        }
    }
}

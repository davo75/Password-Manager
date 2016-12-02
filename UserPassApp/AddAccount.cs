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
    /// Displays the Add account form
    /// </summary>
    /// <remarks>
    /// author: David Pyle 041110777
    /// version: 1.0
    /// date: 02/6/2016
    /// </remarks>
    public partial class AddAccount : Form
    {
        /// <summary>
        /// Reference back to main form
        /// </summary>
        public MainForm parent;
        /// <summary>
        /// Main dataset
        /// </summary>
        private DataSet ds;

        /// <summary>
        /// Constructor - initialises main form elements, sets the mask for obscuring password fields and sets the dataset
        /// </summary>
        /// <param name="ds"></param>
        public AddAccount(DataSet ds)
        {
            InitializeComponent();
            txtBoxPassword.PasswordChar = txtBoxPasswordConfirm.PasswordChar = '\u25CF';
            this.ds = ds;
        }

        /// <summary>
        /// Clears any error messages when loadin the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAccount_Load(object sender, EventArgs e)
        {
            //hide error label
            lblAddAccountError.Visible = false;
        }

        /// <summary>
        /// Saves a new account to the database 
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">event arguments</param>
        private void btnSaveAccount_Click(object sender, EventArgs e)
        {
            //checks that the account name isn't blank
            if (txtBoxAccountName.Text.Equals(string.Empty))
            {
                lblAddAccountError.Text = "Error: Account Name cannot be blank";
                lblAddAccountError.Visible = true;
            }

           //checks that the password isn't blank
            else  if (txtBoxPassword.Text.Equals(string.Empty))
            {
                lblAddAccountError.Text = "Error: Password cannot be blank";
                lblAddAccountError.Visible = true;
            }
            //checks that the password and confrim passwords match
            else if (!txtBoxPassword.Text.Equals(txtBoxPasswordConfirm.Text))
            {
                lblAddAccountError.Text = "Error: Passwords do not match";
                lblAddAccountError.Visible = true;
            } 
            
                //if there are no errors than create account
            else 
            {
                //clear any error messages
                lblAddAccountError.Visible = false;
                //create a new row in the database
                DataRow newAccountRow = ds.Tables["Login"].NewRow();
                //add the account details
                newAccountRow["AccountName"] = txtBoxAccountName.Text;
                newAccountRow["Username"] = txtBoxUsername.Text;
                newAccountRow["Password"] = txtBoxPassword.Text;
                newAccountRow["URL"] = txtBoxURL.Text;
                //add the row to the data table
                ds.Tables["Login"].Rows.Add(newAccountRow);
                //save the new account in the database
                parent.saveAccount(txtBoxUsername.Text, txtBoxPassword.Text, txtBoxAccountName.Text, txtBoxURL.Text);
                //close the form
                this.Dispose();
            }
        }

       
        /// <summary>
        /// Hide or show password characters
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">event arguments</param>
        private void cBoxShowPasswordAccount_CheckedChanged(object sender, EventArgs e)
        {
            txtBoxPassword.PasswordChar = txtBoxPasswordConfirm.PasswordChar = cBoxShowPasswordAccount.Checked ? '\0' : '\u25CF';
        }

        /// <summary>
        /// Close the form
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">event arguments</param>
        private void btnCancelAccount_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Gets a 10 character randomly generated password
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">event arguments</param>
        private void button1_Click(object sender, EventArgs e)
        {
            //clear any error messages
            lblAddAccountError.Visible = false;
            //generate password
            txtBoxPassword.Text = txtBoxPasswordConfirm.Text = MainForm.CreateRandomPassword(10);

        }

        
    }
}

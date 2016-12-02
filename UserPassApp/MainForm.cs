using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace UserPassMgrApp
{
    /// <summary>
    /// Displays the main form used for viewing managing accounts and passwords.
    /// </summary>
    /// <remarks>
    /// author: David Pyle 041110777
    /// version: 1.0
    /// date: 02/6/2016
    /// </remarks>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Connection to mysql database
        /// </summary>
        private MySqlConnection conn;
        /// <summary>
        /// Dataset to hold database data
        /// </summary>
        private DataSet ds;
        /// <summary>
        /// Default view of the dataset
        /// </summary>
        private DataViewManager dsView;
        /// <summary>
        /// Data adapter for the login table
        /// </summary>
        private MySqlDataAdapter loginsDA;
        /// <summary>
        /// Main binding source for user interface controls
        /// </summary>
        public BindingSource bs;
        /// <summary>
        /// Key for encrypting account passwords
        /// </summary>
        private string encryptionKey = "davepyle041110777";

        /// <summary>
        /// Constructor initialises the UI components of the main form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            //custom mask for password characters (small black circle)
            txtBoxPassword.PasswordChar = '\u25CF';            
        }

        /// <summary>
        /// Initiates the loading of the account data and population of data on form fields
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">event arguments</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //get account data
            getAccounts();
            //load data into form
            populateAccounts();           
        }

        
        /// <summary>
        /// Sets up binding sources for the accounts drop down list and binds text fields
        /// </summary>
        private void populateAccounts()
        {
           //drop down lists of account names
            cBoxAccounts.DataSource = bs;
            cBoxAccounts.DisplayMember = "AccountName";
            cBoxAccounts.ValueMember = "LoginID";
            //URL text field binding
            txtBoxURL.DataBindings.Add("Text", bs, "URL");
            //username text field binding
            txtBoxUsername.DataBindings.Add("Text", bs, "Username");
            //password text field binding
            txtBoxPassword.DataBindings.Add("Text", bs, "Password");

            //disable edit and delete buttons if no account data
            hideButtons();
        }

        /// <summary>
        /// Gets the data from the database and loads into a dataset for the application to use
        /// </summary>
        private void getAccounts()
        {
            try
            {
                //Open connection to database
                conn = openTheConnection();
                                
                //query the Login table and decrypt the passwords using key               
                loginsDA = new MySqlDataAdapter("SELECT LoginID, Username, CAST(AES_Decrypt(password, @Key) AS CHAR) AS 'Password', AccountName, URL FROM Login WHERE Username <> 'admin' ORDER BY AccountName", conn);
                loginsDA.SelectCommand.Parameters.AddWithValue("@Key", encryptionKey);
                
                //update command query
                loginsDA.UpdateCommand = new MySqlCommand("UPDATE Login SET Username = @Username, Password = AES_Encrypt(@Password, @Key), AccountName = @AccountName, URL = @URL WHERE LoginID = @LoginID", conn);

                //insert command query
                loginsDA.InsertCommand = new MySqlCommand("INSERT INTO Login (Username, Password, AccountName, URL) VALUES (@Username, AES_Encrypt(@Password, @Key), @AccountName, @URL)",conn);

                //delete command query with parameters
                loginsDA.DeleteCommand = new MySqlCommand("DELETE FROM Login WHERE LoginID = @LoginID", conn);
                loginsDA.DeleteCommand.Parameters.Add("@LoginID", MySqlDbType.Int16, 5, "LoginID");

                //fill AccountLogins dataset with the data from the login table in the database
                ds = new DataSet("AccountLogins");

                //rename the data tables from the default ones            
                loginsDA.TableMappings.Add("Table", "Login");
                //add the table to the dataset
                loginsDA.Fill(ds, "Login");              
                //set the default view
                dsView = ds.DefaultViewManager;

                //setup a binding source for the login table
                bs = new BindingSource();
                bs.DataSource = ds.Tables["Login"];                
            }

            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.ToString());

            }
            finally
            {
                //close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        /// <summary>
        /// Opens a connection to the MySQL database
        /// </summary>
        /// <returns></returns>
        private MySqlConnection openTheConnection()
        {
            //local XAMPP
            //string theConnString = "server=127.0.0.1;"
            //      + "User Id=root;password=dave;"
            //      + "database=041110777_password_mgr";

            //open a connection to the central server database and return it
            string theConnString = "server=223.27.22.124;"
                 + "User Id=davep002;password=Davo001;"
                 + "database=041110777_password_mgr";
            MySqlConnection conn = new MySqlConnection(theConnString);
            conn.Open();
            return conn;
        }

        
        /// <summary>
        /// Deletes an account from the dataset and database
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">event arguments</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //confirmation delete message dialog
            DialogResult deleteConfirm = MessageBox.Show("Are you sure you want to delete account " + cBoxAccounts.GetItemText(cBoxAccounts.SelectedItem) + "?",
                                                    "Delete Confirmation",
                                                    MessageBoxButtons.YesNo);
            //if deletion confirmed
            if (deleteConfirm == DialogResult.Yes)
            {
                //get the login id
                DataRow[] targetRow = ds.Tables["Login"].Select("LoginID = " + cBoxAccounts.SelectedValue.ToString());
                //delete the record from the data table
                targetRow[0].Delete();
                //delete the record from the database
                loginsDA.Update(ds, "Login");
                //update dataset
                ds.AcceptChanges();

                //hide edit and delete buttons if no account data
                hideButtons();
            }
                 
        }

        /// <summary>
        /// Disables the edit and delete buttons if there are no accounts
        /// </summary>
        private void hideButtons()
        {
            //check if combobox is empty
            if (cBoxAccounts.Items.Count == 0)
            {
                //disable the buttons
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                //enable the buttons if account data exists
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        /// <summary>
        /// Inserts a new account record into the dataset and database
        /// </summary>
        /// <param name="username">Account username</param>
        /// <param name="password">Account password</param>
        /// <param name="accountName">Account name</param>
        /// <param name="url">Account URL</param>
        public void saveAccount(string username, string password, string accountName, string url)
        {
            //add the parameters to the insert command
            loginsDA.InsertCommand.Parameters.Clear();
            loginsDA.InsertCommand.Parameters.AddWithValue("@Key", encryptionKey);
            loginsDA.InsertCommand.Parameters.AddWithValue("@Username", username);
            loginsDA.InsertCommand.Parameters.AddWithValue("@Password", password);
            loginsDA.InsertCommand.Parameters.AddWithValue("@AccountName", accountName);
            loginsDA.InsertCommand.Parameters.AddWithValue("@URL", url);

            //update the database and dataset
            loginsDA.Update(ds, "Login");
            ds.AcceptChanges();

            //need to clear the dataset and refill it because the password may have been changed (and encrypted) so is different to the
            //one stored in the current dataset
            ds.Clear();
            loginsDA.Fill(ds, "Login");

            //make the selection in the combobox equal to the newly added account
            DataRow[] maxRow = ds.Tables["Login"].Select("LoginID = MAX(LoginID)");           
            cBoxAccounts.SelectedValue = maxRow[0]["LoginID"];

            //hide edit and delete buttons if no account data
            hideButtons();
            
        }

        /// <summary>
        /// Updates the admin account record in the dataset and database
        /// </summary>
        /// <param name="newPassword">New admin password</param>
        public void updateAdminAccount(string newPassword)
        {
            //open the database connection
            conn = openTheConnection();
            //clear any parameters
            loginsDA.UpdateCommand.Parameters.Clear();
            //use the encyption key
            loginsDA.UpdateCommand.Parameters.AddWithValue("@Key", encryptionKey);
            //admin loginID is always 1
            loginsDA.UpdateCommand.Parameters.AddWithValue("@LoginID", "1");
            //admin username is always admin
            loginsDA.UpdateCommand.Parameters.AddWithValue("@Username", "admin");
            //get the new password that was set
            loginsDA.UpdateCommand.Parameters.AddWithValue("@Password", newPassword);
            //account name is always Password Manager
            loginsDA.UpdateCommand.Parameters.AddWithValue("@AccountName", "Password Manager");
            //account URL is just made up - can be blank if needed
            loginsDA.UpdateCommand.Parameters.AddWithValue("@URL", "www.admin.co.uk");
            //set the command's connection object
            loginsDA.UpdateCommand.Connection = conn;
            //execute the update query
            loginsDA.UpdateCommand.ExecuteNonQuery();
            //update the dataset
            ds.AcceptChanges();
            //close the db connection
            conn.Close();
        }

        /// <summary>
        /// Updates an existing account
        /// </summary>
        /// <param name="LoginID">LoginID</param>
        /// <param name="username">Account username</param>
        /// <param name="password">Account password</param>
        /// <param name="accountName">Account name</param>
        /// <param name="url">Account URl</param>
        public void updateAccount(string LoginID, string username, string password, string accountName, string url)
        {
            //clear any parameters to the update command
            loginsDA.UpdateCommand.Parameters.Clear();
            //use the encyption key
            loginsDA.UpdateCommand.Parameters.AddWithValue("@Key", encryptionKey);
            //set the loginID
            loginsDA.UpdateCommand.Parameters.AddWithValue("@LoginID", LoginID);
            //set the username
            loginsDA.UpdateCommand.Parameters.AddWithValue("@Username", username);
            //set the password
            loginsDA.UpdateCommand.Parameters.AddWithValue("@Password", password);
            //set account name
            loginsDA.UpdateCommand.Parameters.AddWithValue("@AccountName", accountName);
            //set URL
            loginsDA.UpdateCommand.Parameters.AddWithValue("@URL", url);
            //end editing
            bs.EndEdit();
            //update the database
            loginsDA.Update(ds, "Login");
            //update the dataset
            ds.AcceptChanges();

            foreach (DataRow row in ds.Tables["Login"].Rows)
            {
                Console.WriteLine(row["LoginID"] + " " + row["Username"] + " " + row["Password"] + " " + row["AccountName"] + " " + row["URL"]);
            }
        }

        /// <summary>
        /// Displays the account form for adding a new account
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">event arguments</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //create instance of account form
            AddAccount addAccount = new AddAccount(ds);
            //set reference back to the main form
            addAccount.parent = this;
            //show the form
            addAccount.ShowDialog();
        }

        
        /// <summary>
        /// Displays the account form for editing an existing account
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">event arguments</param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //create instance of account form
            EditAccount editAccount = new EditAccount();
            //set reference back to the main form
            editAccount.parent = this;
            //show the form
            editAccount.ShowDialog();
        }

        
        /// <summary>
        /// Generates a random password
        /// </summary>
        /// <remarks>
        /// Credit: http://madskristensen.net/post/generate-random-password-in-c
        /// </remarks>
        /// <param name="passwordLength">The length of the random password</param>
        /// <returns>The random password</returns>
        public static string CreateRandomPassword(int passwordLength)
        {
            //allowed cahracters to generate password from
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[passwordLength];
            Random rd = new Random();
            //create the password
            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }
            //return password
            return new string(chars);
        }

        /// <summary>
        /// Masks or shows a password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cBoxShowPasswords_CheckedChanged(object sender, EventArgs e)
        {
            txtBoxPassword.PasswordChar = cBoxShowPasswords.Checked ? '\0' : '\u25CF';                        
        }

        /// <summary>
        /// Gets the admin password from the database 
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">event arguments</param>
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set password to null
            string adminPassword=null;
            try
            {
                //Open connection to database
                conn = openTheConnection();
                //get the admin password from the database
                MySqlCommand getAdminPassword = new MySqlCommand("SELECT CAST(AES_DECRYPT(password, @key) AS CHAR) from login WHERE Username = 'admin'", conn);
                getAdminPassword.Parameters.AddWithValue("@key", encryptionKey);
                //get the query result
                adminPassword = Convert.ToString(getAdminPassword.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.ToString());

            }
            finally
            {
                //close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }

            //if the password was successfuly returned from database
            if (adminPassword != null)
            {
                //create instance of admin form
                Admin editAdmin = new Admin(adminPassword);
                //set reference back to this form
                editAdmin.parent = this;
                //show admin form
                editAdmin.ShowDialog();
            }
        }
    }
}

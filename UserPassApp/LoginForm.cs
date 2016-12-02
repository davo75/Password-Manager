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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace UserPassMgrApp
{
    public partial class LoginForm : Form
    {
       

        private MySqlConnection conn;
        private string encryptionKey = "davepyle041110777";

        /// <summary>
        /// Constructor initialise the UI components on the login form
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            txtBoxPassword.PasswordChar = '\u25CF';
        }

        /// <summary>
        /// Checks the login details entered by the user
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments arguments</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            getLogin();            
        }

        private void getLogin()
        {
            try
            {
                //Open connection to database
                conn = openTheConnection();

                //get the admin password from the database
                //MySqlCommand getAdminPassword = new MySqlCommand("SELECT CAST(AES_DECRYPT(password, @key) AS CHAR) from login WHERE Username = 'admin'", conn);
                //getAdminPassword.Parameters.AddWithValue("@key", encryptionKey);

                //string adminPassword = Convert.ToString(getAdminPassword.ExecuteScalar());
                //Console.WriteLine(adminPassword);

                //get the username and password for the main login account (login for the app)
                MySqlCommand cmd = new MySqlCommand(" SELECT * FROM Login where Username=@username AND password = AES_Encrypt(@password, @key)", conn);
               
                ////hash the entered password by the user along with the salt 
                //string hashedPasswordEnteredByUser = encrypt.hashPassword(txtBoxPassword.Text, theSalt);
                //Console.WriteLine("Hashed Password is: " + hashedPasswordEnteredByUser);
                
                //query parameters - username and password must match
                cmd.Parameters.AddWithValue("@username", txtBoxUser.Text);
                cmd.Parameters.AddWithValue("@password", txtBoxPassword.Text);
                cmd.Parameters.AddWithValue("@key", encryptionKey);

                ////execute the query and fill the dataset with the results
                MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);

                int count = ds.Tables[0].Rows.Count;
                //If count is equal to 1, then login is valid so show the main form and dismiss the dialog
                if (count == 1)
                {
                    DialogResult = DialogResult.OK;
                }
                //else show login error message
                else
                {
                    lblLoginError.Text = "Invalid username or password";
                }
            }       
            
            catch (MySqlException ex)
            {
                lblLoginError.Text = "Error: Unable to connect to database.";

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


        private MySqlConnection openTheConnection()
        {
            //local XAMPP
            //string theConnString = "server=127.0.0.1;"
            //      + "User Id=root;password=dave;"
            //      + "database=041110777_password_mgr";

            //central server
            string theConnString = "server=223.27.22.124;"
                 + "User Id=davep002;password=Davo001;"
                 + "database=041110777_password_mgr";
            MySqlConnection conn = new MySqlConnection(theConnString);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// Clears any error messages on the login form
        /// </summary>
        /// <remarks>
        /// The error message is cleared once the user begins entering text into either the 
        /// username or password field</remarks>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void txtBoxUser_TextChanged(object sender, EventArgs e)
        {
            //clear the error
            lblLoginError.Text = string.Empty;
        }
    }
}

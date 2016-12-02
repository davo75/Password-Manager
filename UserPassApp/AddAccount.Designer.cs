namespace UserPassMgrApp
{
    partial class AddAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAccount));
            this.gBoxAccount = new System.Windows.Forms.GroupBox();
            this.btnGenPassword = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cBoxShowPasswordAccount = new System.Windows.Forms.CheckBox();
            this.lblAddAccountError = new System.Windows.Forms.Label();
            this.txtBoxPasswordConfirm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxURL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxUsername = new System.Windows.Forms.TextBox();
            this.btnCancelAccount = new System.Windows.Forms.Button();
            this.btnSaveAccount = new System.Windows.Forms.Button();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxAccountName = new System.Windows.Forms.TextBox();
            this.gBoxAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxAccount
            // 
            this.gBoxAccount.Controls.Add(this.btnGenPassword);
            this.gBoxAccount.Controls.Add(this.label6);
            this.gBoxAccount.Controls.Add(this.cBoxShowPasswordAccount);
            this.gBoxAccount.Controls.Add(this.lblAddAccountError);
            this.gBoxAccount.Controls.Add(this.txtBoxPasswordConfirm);
            this.gBoxAccount.Controls.Add(this.label5);
            this.gBoxAccount.Controls.Add(this.txtBoxURL);
            this.gBoxAccount.Controls.Add(this.label3);
            this.gBoxAccount.Controls.Add(this.label4);
            this.gBoxAccount.Controls.Add(this.txtBoxUsername);
            this.gBoxAccount.Controls.Add(this.btnCancelAccount);
            this.gBoxAccount.Controls.Add(this.btnSaveAccount);
            this.gBoxAccount.Controls.Add(this.txtBoxPassword);
            this.gBoxAccount.Controls.Add(this.label1);
            this.gBoxAccount.Controls.Add(this.label2);
            this.gBoxAccount.Controls.Add(this.txtBoxAccountName);
            this.gBoxAccount.Location = new System.Drawing.Point(15, 12);
            this.gBoxAccount.Name = "gBoxAccount";
            this.gBoxAccount.Size = new System.Drawing.Size(353, 295);
            this.gBoxAccount.TabIndex = 7;
            this.gBoxAccount.TabStop = false;
            this.gBoxAccount.Text = "Account";
            // 
            // btnGenPassword
            // 
            this.btnGenPassword.Location = new System.Drawing.Point(280, 132);
            this.btnGenPassword.Name = "btnGenPassword";
            this.btnGenPassword.Size = new System.Drawing.Size(62, 36);
            this.btnGenPassword.TabIndex = 15;
            this.btnGenPassword.Text = "Generate Password";
            this.btnGenPassword.UseVisualStyleBackColor = true;
            this.btnGenPassword.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "*Required";
            // 
            // cBoxShowPasswordAccount
            // 
            this.cBoxShowPasswordAccount.AutoSize = true;
            this.cBoxShowPasswordAccount.Location = new System.Drawing.Point(117, 198);
            this.cBoxShowPasswordAccount.Name = "cBoxShowPasswordAccount";
            this.cBoxShowPasswordAccount.Size = new System.Drawing.Size(102, 17);
            this.cBoxShowPasswordAccount.TabIndex = 6;
            this.cBoxShowPasswordAccount.Text = "Show Password";
            this.cBoxShowPasswordAccount.UseVisualStyleBackColor = true;
            this.cBoxShowPasswordAccount.CheckedChanged += new System.EventHandler(this.cBoxShowPasswordAccount_CheckedChanged);
            // 
            // lblAddAccountError
            // 
            this.lblAddAccountError.AutoSize = true;
            this.lblAddAccountError.ForeColor = System.Drawing.Color.Red;
            this.lblAddAccountError.Location = new System.Drawing.Point(76, 274);
            this.lblAddAccountError.Name = "lblAddAccountError";
            this.lblAddAccountError.Size = new System.Drawing.Size(32, 13);
            this.lblAddAccountError.TabIndex = 13;
            this.lblAddAccountError.Text = "Error:";
            // 
            // txtBoxPasswordConfirm
            // 
            this.txtBoxPasswordConfirm.Location = new System.Drawing.Point(117, 163);
            this.txtBoxPasswordConfirm.Name = "txtBoxPasswordConfirm";
            this.txtBoxPasswordConfirm.Size = new System.Drawing.Size(156, 20);
            this.txtBoxPasswordConfirm.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "*Confirm Password";
            // 
            // txtBoxURL
            // 
            this.txtBoxURL.Location = new System.Drawing.Point(117, 58);
            this.txtBoxURL.Name = "txtBoxURL";
            this.txtBoxURL.Size = new System.Drawing.Size(156, 20);
            this.txtBoxURL.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "URL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Username";
            // 
            // txtBoxUsername
            // 
            this.txtBoxUsername.Location = new System.Drawing.Point(117, 93);
            this.txtBoxUsername.Name = "txtBoxUsername";
            this.txtBoxUsername.Size = new System.Drawing.Size(156, 20);
            this.txtBoxUsername.TabIndex = 3;
            // 
            // btnCancelAccount
            // 
            this.btnCancelAccount.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelAccount.Location = new System.Drawing.Point(198, 236);
            this.btnCancelAccount.Name = "btnCancelAccount";
            this.btnCancelAccount.Size = new System.Drawing.Size(75, 23);
            this.btnCancelAccount.TabIndex = 8;
            this.btnCancelAccount.Text = "Cancel";
            this.btnCancelAccount.UseVisualStyleBackColor = true;
            this.btnCancelAccount.Click += new System.EventHandler(this.btnCancelAccount_Click);
            // 
            // btnSaveAccount
            // 
            this.btnSaveAccount.Location = new System.Drawing.Point(117, 236);
            this.btnSaveAccount.Name = "btnSaveAccount";
            this.btnSaveAccount.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAccount.TabIndex = 7;
            this.btnSaveAccount.Text = "Save";
            this.btnSaveAccount.UseVisualStyleBackColor = true;
            this.btnSaveAccount.Click += new System.EventHandler(this.btnSaveAccount_Click);
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Location = new System.Drawing.Point(117, 128);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.Size = new System.Drawing.Size(156, 20);
            this.txtBoxPassword.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "*Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "*Password";
            // 
            // txtBoxAccountName
            // 
            this.txtBoxAccountName.Location = new System.Drawing.Point(117, 23);
            this.txtBoxAccountName.Name = "txtBoxAccountName";
            this.txtBoxAccountName.Size = new System.Drawing.Size(156, 20);
            this.txtBoxAccountName.TabIndex = 1;
            // 
            // AddAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 322);
            this.Controls.Add(this.gBoxAccount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Account";
            this.Load += new System.EventHandler(this.AddAccount_Load);
            this.gBoxAccount.ResumeLayout(false);
            this.gBoxAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxAccount;
        private System.Windows.Forms.CheckBox cBoxShowPasswordAccount;
        private System.Windows.Forms.Label lblAddAccountError;
        private System.Windows.Forms.TextBox txtBoxPasswordConfirm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxURL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxUsername;
        private System.Windows.Forms.Button btnCancelAccount;
        private System.Windows.Forms.Button btnSaveAccount;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxAccountName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGenPassword;
    }
}
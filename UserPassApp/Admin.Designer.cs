namespace UserPassMgrApp
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.gBoxAccount = new System.Windows.Forms.GroupBox();
            this.txtBoxCurrentPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenPassword = new System.Windows.Forms.Button();
            this.cBoxShowPasswordAccount = new System.Windows.Forms.CheckBox();
            this.lblAddAccountError = new System.Windows.Forms.Label();
            this.txtBoxPasswordConfirm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelAdmin = new System.Windows.Forms.Button();
            this.btnSaveAdmin = new System.Windows.Forms.Button();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gBoxAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxAccount
            // 
            this.gBoxAccount.Controls.Add(this.txtBoxCurrentPassword);
            this.gBoxAccount.Controls.Add(this.label1);
            this.gBoxAccount.Controls.Add(this.btnGenPassword);
            this.gBoxAccount.Controls.Add(this.cBoxShowPasswordAccount);
            this.gBoxAccount.Controls.Add(this.lblAddAccountError);
            this.gBoxAccount.Controls.Add(this.txtBoxPasswordConfirm);
            this.gBoxAccount.Controls.Add(this.label5);
            this.gBoxAccount.Controls.Add(this.btnCancelAdmin);
            this.gBoxAccount.Controls.Add(this.btnSaveAdmin);
            this.gBoxAccount.Controls.Add(this.txtBoxPassword);
            this.gBoxAccount.Controls.Add(this.label2);
            this.gBoxAccount.Location = new System.Drawing.Point(15, 12);
            this.gBoxAccount.Name = "gBoxAccount";
            this.gBoxAccount.Size = new System.Drawing.Size(353, 225);
            this.gBoxAccount.TabIndex = 8;
            this.gBoxAccount.TabStop = false;
            this.gBoxAccount.Text = "Admin Account";
            // 
            // txtBoxCurrentPassword
            // 
            this.txtBoxCurrentPassword.Location = new System.Drawing.Point(117, 28);
            this.txtBoxCurrentPassword.Name = "txtBoxCurrentPassword";
            this.txtBoxCurrentPassword.Size = new System.Drawing.Size(156, 20);
            this.txtBoxCurrentPassword.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Current Password";
            // 
            // btnGenPassword
            // 
            this.btnGenPassword.Location = new System.Drawing.Point(280, 65);
            this.btnGenPassword.Name = "btnGenPassword";
            this.btnGenPassword.Size = new System.Drawing.Size(62, 36);
            this.btnGenPassword.TabIndex = 15;
            this.btnGenPassword.Text = "Generate Password";
            this.btnGenPassword.UseVisualStyleBackColor = true;
            this.btnGenPassword.Click += new System.EventHandler(this.btnGenPassword_Click);
            // 
            // cBoxShowPasswordAccount
            // 
            this.cBoxShowPasswordAccount.AutoSize = true;
            this.cBoxShowPasswordAccount.Location = new System.Drawing.Point(117, 132);
            this.cBoxShowPasswordAccount.Name = "cBoxShowPasswordAccount";
            this.cBoxShowPasswordAccount.Size = new System.Drawing.Size(102, 17);
            this.cBoxShowPasswordAccount.TabIndex = 3;
            this.cBoxShowPasswordAccount.Text = "Show Password";
            this.cBoxShowPasswordAccount.UseVisualStyleBackColor = true;
            this.cBoxShowPasswordAccount.CheckedChanged += new System.EventHandler(this.cBoxShowPasswordAccount_CheckedChanged);
            // 
            // lblAddAccountError
            // 
            this.lblAddAccountError.AutoSize = true;
            this.lblAddAccountError.ForeColor = System.Drawing.Color.Red;
            this.lblAddAccountError.Location = new System.Drawing.Point(79, 203);
            this.lblAddAccountError.Name = "lblAddAccountError";
            this.lblAddAccountError.Size = new System.Drawing.Size(32, 13);
            this.lblAddAccountError.TabIndex = 13;
            this.lblAddAccountError.Text = "Error:";
            // 
            // txtBoxPasswordConfirm
            // 
            this.txtBoxPasswordConfirm.Location = new System.Drawing.Point(117, 96);
            this.txtBoxPasswordConfirm.Name = "txtBoxPasswordConfirm";
            this.txtBoxPasswordConfirm.Size = new System.Drawing.Size(156, 20);
            this.txtBoxPasswordConfirm.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Confirm Password";
            // 
            // btnCancelAdmin
            // 
            this.btnCancelAdmin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelAdmin.Location = new System.Drawing.Point(198, 167);
            this.btnCancelAdmin.Name = "btnCancelAdmin";
            this.btnCancelAdmin.Size = new System.Drawing.Size(75, 23);
            this.btnCancelAdmin.TabIndex = 5;
            this.btnCancelAdmin.Text = "Cancel";
            this.btnCancelAdmin.UseVisualStyleBackColor = true;
            this.btnCancelAdmin.Click += new System.EventHandler(this.btnCancelAccount_Click);
            // 
            // btnSaveAdmin
            // 
            this.btnSaveAdmin.Location = new System.Drawing.Point(117, 167);
            this.btnSaveAdmin.Name = "btnSaveAdmin";
            this.btnSaveAdmin.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAdmin.TabIndex = 4;
            this.btnSaveAdmin.Text = "Save";
            this.btnSaveAdmin.UseVisualStyleBackColor = true;
            this.btnSaveAdmin.Click += new System.EventHandler(this.btnSaveAdmin_Click);
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Location = new System.Drawing.Point(117, 61);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.Size = new System.Drawing.Size(156, 20);
            this.txtBoxPassword.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "New Password";
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 248);
            this.Controls.Add(this.gBoxAccount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.gBoxAccount.ResumeLayout(false);
            this.gBoxAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxAccount;
        private System.Windows.Forms.Button btnGenPassword;
        private System.Windows.Forms.CheckBox cBoxShowPasswordAccount;
        private System.Windows.Forms.Label lblAddAccountError;
        private System.Windows.Forms.TextBox txtBoxPasswordConfirm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelAdmin;
        private System.Windows.Forms.Button btnSaveAdmin;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxCurrentPassword;
        private System.Windows.Forms.Label label1;
    }
}
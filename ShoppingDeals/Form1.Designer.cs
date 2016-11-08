namespace ShoppingDeals
{
    partial class Form1
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
            this.Login = new System.Windows.Forms.GroupBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.txtUsernameToAdd = new System.Windows.Forms.TextBox();
            this.lblUsernameToAdd = new System.Windows.Forms.Label();
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtEnterUsername = new System.Windows.Forms.TextBox();
            this.lblEnterUsername = new System.Windows.Forms.Label();
            this.grpDeals = new System.Windows.Forms.GroupBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.lblExpries = new System.Windows.Forms.Label();
            this.btnAddDeal = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtProductToAdd = new System.Windows.Forms.TextBox();
            this.lblProductToAdd = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpLikeDislike = new System.Windows.Forms.GroupBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.radDislikeDeal = new System.Windows.Forms.RadioButton();
            this.radLikeDeal = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSearchDeal = new System.Windows.Forms.Button();
            this.txtSearchDeal = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstDeals = new System.Windows.Forms.ListBox();
            this.Login.SuspendLayout();
            this.grpLogin.SuspendLayout();
            this.grpDeals.SuspendLayout();
            this.grpLikeDislike.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.Controls.Add(this.btnAddUser);
            this.Login.Controls.Add(this.txtUsernameToAdd);
            this.Login.Controls.Add(this.lblUsernameToAdd);
            this.Login.Location = new System.Drawing.Point(23, 15);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(273, 83);
            this.Login.TabIndex = 0;
            this.Login.TabStop = false;
            this.Login.Text = "Register";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(166, 43);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(97, 32);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // txtUsernameToAdd
            // 
            this.txtUsernameToAdd.Location = new System.Drawing.Point(11, 48);
            this.txtUsernameToAdd.Name = "txtUsernameToAdd";
            this.txtUsernameToAdd.Size = new System.Drawing.Size(142, 22);
            this.txtUsernameToAdd.TabIndex = 1;
            // 
            // lblUsernameToAdd
            // 
            this.lblUsernameToAdd.AutoSize = true;
            this.lblUsernameToAdd.Location = new System.Drawing.Point(13, 28);
            this.lblUsernameToAdd.Name = "lblUsernameToAdd";
            this.lblUsernameToAdd.Size = new System.Drawing.Size(122, 17);
            this.lblUsernameToAdd.TabIndex = 0;
            this.lblUsernameToAdd.Text = "Username to Add:";
            // 
            // grpLogin
            // 
            this.grpLogin.Controls.Add(this.btnLogout);
            this.grpLogin.Controls.Add(this.btnLogin);
            this.grpLogin.Controls.Add(this.txtEnterUsername);
            this.grpLogin.Controls.Add(this.lblEnterUsername);
            this.grpLogin.Location = new System.Drawing.Point(23, 104);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(273, 104);
            this.grpLogin.TabIndex = 1;
            this.grpLogin.TabStop = false;
            this.grpLogin.Text = "Login";
            // 
            // btnLogout
            // 
            this.btnLogout.Enabled = false;
            this.btnLogout.Location = new System.Drawing.Point(166, 56);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(97, 30);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(166, 21);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(97, 29);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtEnterUsername
            // 
            this.txtEnterUsername.Location = new System.Drawing.Point(11, 57);
            this.txtEnterUsername.Name = "txtEnterUsername";
            this.txtEnterUsername.Size = new System.Drawing.Size(137, 22);
            this.txtEnterUsername.TabIndex = 1;
            // 
            // lblEnterUsername
            // 
            this.lblEnterUsername.AutoSize = true;
            this.lblEnterUsername.Location = new System.Drawing.Point(13, 29);
            this.lblEnterUsername.Name = "lblEnterUsername";
            this.lblEnterUsername.Size = new System.Drawing.Size(115, 17);
            this.lblEnterUsername.TabIndex = 0;
            this.lblEnterUsername.Text = "Enter Username:";
            // 
            // grpDeals
            // 
            this.grpDeals.Controls.Add(this.dateTimePicker);
            this.grpDeals.Controls.Add(this.lblExpries);
            this.grpDeals.Controls.Add(this.btnAddDeal);
            this.grpDeals.Controls.Add(this.txtPrice);
            this.grpDeals.Controls.Add(this.lblPrice);
            this.grpDeals.Controls.Add(this.txtProductToAdd);
            this.grpDeals.Controls.Add(this.lblProductToAdd);
            this.grpDeals.Location = new System.Drawing.Point(308, 15);
            this.grpDeals.Name = "grpDeals";
            this.grpDeals.Size = new System.Drawing.Size(273, 193);
            this.grpDeals.TabIndex = 2;
            this.grpDeals.TabStop = false;
            this.grpDeals.Text = "Deals";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "MM/dd/yyyy";
            this.dateTimePicker.Location = new System.Drawing.Point(16, 153);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(139, 22);
            this.dateTimePicker.TabIndex = 6;
            // 
            // lblExpries
            // 
            this.lblExpries.AutoSize = true;
            this.lblExpries.Location = new System.Drawing.Point(17, 130);
            this.lblExpries.Name = "lblExpries";
            this.lblExpries.Size = new System.Drawing.Size(58, 17);
            this.lblExpries.TabIndex = 5;
            this.lblExpries.Text = "Expires:";
            // 
            // btnAddDeal
            // 
            this.btnAddDeal.Location = new System.Drawing.Point(157, 89);
            this.btnAddDeal.Name = "btnAddDeal";
            this.btnAddDeal.Size = new System.Drawing.Size(110, 32);
            this.btnAddDeal.TabIndex = 4;
            this.btnAddDeal.Text = "Add Deal";
            this.btnAddDeal.UseVisualStyleBackColor = true;
            this.btnAddDeal.Click += new System.EventHandler(this.btnAddDeal_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(16, 94);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(135, 22);
            this.txtPrice.TabIndex = 3;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(17, 73);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(44, 17);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "Price:";
            // 
            // txtProductToAdd
            // 
            this.txtProductToAdd.Location = new System.Drawing.Point(16, 43);
            this.txtProductToAdd.Name = "txtProductToAdd";
            this.txtProductToAdd.Size = new System.Drawing.Size(135, 22);
            this.txtProductToAdd.TabIndex = 1;
            // 
            // lblProductToAdd
            // 
            this.lblProductToAdd.AutoSize = true;
            this.lblProductToAdd.Location = new System.Drawing.Point(17, 23);
            this.lblProductToAdd.Name = "lblProductToAdd";
            this.lblProductToAdd.Size = new System.Drawing.Size(106, 17);
            this.lblProductToAdd.TabIndex = 0;
            this.lblProductToAdd.Text = "Product to Add:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(274, 256);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 28);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // grpLikeDislike
            // 
            this.grpLikeDislike.Controls.Add(this.btnChoose);
            this.grpLikeDislike.Controls.Add(this.radDislikeDeal);
            this.grpLikeDislike.Controls.Add(this.radLikeDeal);
            this.grpLikeDislike.Enabled = false;
            this.grpLikeDislike.Location = new System.Drawing.Point(607, 214);
            this.grpLikeDislike.Name = "grpLikeDislike";
            this.grpLikeDislike.Size = new System.Drawing.Size(233, 104);
            this.grpLikeDislike.TabIndex = 5;
            this.grpLikeDislike.TabStop = false;
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(70, 58);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(98, 29);
            this.btnChoose.TabIndex = 2;
            this.btnChoose.Text = "Choose";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // radDislikeDeal
            // 
            this.radDislikeDeal.AutoSize = true;
            this.radDislikeDeal.Location = new System.Drawing.Point(116, 31);
            this.radDislikeDeal.Name = "radDislikeDeal";
            this.radDislikeDeal.Size = new System.Drawing.Size(103, 21);
            this.radDislikeDeal.TabIndex = 1;
            this.radDislikeDeal.TabStop = true;
            this.radDislikeDeal.Text = "Dislike Deal";
            this.radDislikeDeal.UseVisualStyleBackColor = true;
            // 
            // radLikeDeal
            // 
            this.radLikeDeal.AutoSize = true;
            this.radLikeDeal.Location = new System.Drawing.Point(22, 31);
            this.radLikeDeal.Name = "radLikeDeal";
            this.radLikeDeal.Size = new System.Drawing.Size(88, 21);
            this.radLikeDeal.TabIndex = 0;
            this.radLikeDeal.TabStop = true;
            this.radLikeDeal.Text = "Like Deal";
            this.radLikeDeal.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSearchDeal);
            this.groupBox5.Controls.Add(this.txtSearchDeal);
            this.groupBox5.Location = new System.Drawing.Point(846, 214);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(277, 104);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            // 
            // btnSearchDeal
            // 
            this.btnSearchDeal.Location = new System.Drawing.Point(162, 31);
            this.btnSearchDeal.Name = "btnSearchDeal";
            this.btnSearchDeal.Size = new System.Drawing.Size(109, 30);
            this.btnSearchDeal.TabIndex = 1;
            this.btnSearchDeal.Text = "Search Deal";
            this.btnSearchDeal.UseVisualStyleBackColor = true;
            this.btnSearchDeal.Click += new System.EventHandler(this.btnSearchDeal_Click);
            // 
            // txtSearchDeal
            // 
            this.txtSearchDeal.Location = new System.Drawing.Point(13, 35);
            this.txtSearchDeal.Name = "txtSearchDeal";
            this.txtSearchDeal.Size = new System.Drawing.Size(143, 22);
            this.txtSearchDeal.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusStrip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 332);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1135, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusStrip
            // 
            this.lblStatusStrip.Name = "lblStatusStrip";
            this.lblStatusStrip.Size = new System.Drawing.Size(0, 17);
            // 
            // lstDeals
            // 
            this.lstDeals.FormattingEnabled = true;
            this.lstDeals.ItemHeight = 16;
            this.lstDeals.Location = new System.Drawing.Point(607, 15);
            this.lstDeals.Name = "lstDeals";
            this.lstDeals.Size = new System.Drawing.Size(510, 180);
            this.lstDeals.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 354);
            this.Controls.Add(this.lstDeals);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.grpLikeDislike);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.grpDeals);
            this.Controls.Add(this.grpLogin);
            this.Controls.Add(this.Login);
            this.Name = "Form1";
            this.Text = "Shopping Deals";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Login.ResumeLayout(false);
            this.Login.PerformLayout();
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            this.grpDeals.ResumeLayout(false);
            this.grpDeals.PerformLayout();
            this.grpLikeDislike.ResumeLayout(false);
            this.grpLikeDislike.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Login;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TextBox txtUsernameToAdd;
        private System.Windows.Forms.Label lblUsernameToAdd;
        private System.Windows.Forms.GroupBox grpLogin;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtEnterUsername;
        private System.Windows.Forms.Label lblEnterUsername;
        private System.Windows.Forms.GroupBox grpDeals;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label lblExpries;
        private System.Windows.Forms.Button btnAddDeal;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtProductToAdd;
        private System.Windows.Forms.Label lblProductToAdd;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox grpLikeDislike;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.RadioButton radDislikeDeal;
        private System.Windows.Forms.RadioButton radLikeDeal;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSearchDeal;
        private System.Windows.Forms.TextBox txtSearchDeal;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusStrip;
        private System.Windows.Forms.ListBox lstDeals;
    }
}


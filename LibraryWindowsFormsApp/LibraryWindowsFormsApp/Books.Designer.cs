namespace LibraryWindowsFormsApp
{
    partial class Books
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
        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.ComboBox cmbMembership;
        private System.Windows.Forms.Button btnAddMember;
        private System.Windows.Forms.TextBox txtInventoryID;
        private System.Windows.Forms.TextBox txtMemberID;
        private System.Windows.Forms.TextBox txtStaffID;
        private System.Windows.Forms.DateTimePicker dtpLoanDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Button btnCreateLoan;
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.cmbMembership = new System.Windows.Forms.ComboBox();
            this.btnAddMember = new System.Windows.Forms.Button();
            this.txtInventoryID = new System.Windows.Forms.TextBox();
            this.txtMemberID = new System.Windows.Forms.TextBox();
            this.txtStaffID = new System.Windows.Forms.TextBox();
            this.dtpLoanDate = new System.Windows.Forms.DateTimePicker();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.btnCreateLoan = new System.Windows.Forms.Button();
            this.labelADDMember = new System.Windows.Forms.Label();
            this.labelAddLoan = new System.Windows.Forms.Label();
            this.labelAddStaff = new System.Windows.Forms.Label();
            this.txtFN = new System.Windows.Forms.TextBox();
            this.txtLN = new System.Windows.Forms.TextBox();
            this.txtEML = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.btnAddStaff = new System.Windows.Forms.Button();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.HireDate = new System.Windows.Forms.DateTimePicker();
            this.btnMainMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.AllowUserToAddRows = false;
            this.dataGridViewBooks.AllowUserToDeleteRows = false;
            this.dataGridViewBooks.ColumnHeadersHeight = 29;
            this.dataGridViewBooks.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.ReadOnly = true;
            this.dataGridViewBooks.RowHeadersWidth = 51;
            this.dataGridViewBooks.Size = new System.Drawing.Size(468, 200);
            this.dataGridViewBooks.TabIndex = 0;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(501, 53);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(198, 22);
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.Text = "First Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(501, 83);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(198, 22);
            this.txtLastName.TabIndex = 2;
            this.txtLastName.Text = "Last Name";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(501, 113);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(198, 22);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.Text = "Email";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(501, 143);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(198, 22);
            this.txtPhone.TabIndex = 4;
            this.txtPhone.Text = "Phone";
            // 
            // cmbMembership
            // 
            this.cmbMembership.Items.AddRange(new object[] {
            "Regular",
            "Premium"});
            this.cmbMembership.Location = new System.Drawing.Point(501, 173);
            this.cmbMembership.Name = "cmbMembership";
            this.cmbMembership.Size = new System.Drawing.Size(201, 24);
            this.cmbMembership.TabIndex = 5;
            this.cmbMembership.Text = "MemberShipType";
            // 
            // btnAddMember
            // 
            this.btnAddMember.Location = new System.Drawing.Point(537, 203);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(133, 23);
            this.btnAddMember.TabIndex = 6;
            this.btnAddMember.Text = "Add Member";
            this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
            // 
            // txtInventoryID
            // 
            this.txtInventoryID.Location = new System.Drawing.Point(17, 275);
            this.txtInventoryID.Name = "txtInventoryID";
            this.txtInventoryID.Size = new System.Drawing.Size(144, 22);
            this.txtInventoryID.TabIndex = 7;
            this.txtInventoryID.Text = "Inventory ID";
            // 
            // txtMemberID
            // 
            this.txtMemberID.Location = new System.Drawing.Point(17, 305);
            this.txtMemberID.Name = "txtMemberID";
            this.txtMemberID.Size = new System.Drawing.Size(144, 22);
            this.txtMemberID.TabIndex = 8;
            this.txtMemberID.Text = "Member ID";
            // 
            // txtStaffID
            // 
            this.txtStaffID.Location = new System.Drawing.Point(17, 335);
            this.txtStaffID.Name = "txtStaffID";
            this.txtStaffID.Size = new System.Drawing.Size(144, 22);
            this.txtStaffID.TabIndex = 9;
            this.txtStaffID.Text = "Staff ID";
            // 
            // dtpLoanDate
            // 
            this.dtpLoanDate.Location = new System.Drawing.Point(17, 365);
            this.dtpLoanDate.Name = "dtpLoanDate";
            this.dtpLoanDate.Size = new System.Drawing.Size(227, 22);
            this.dtpLoanDate.TabIndex = 10;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Location = new System.Drawing.Point(17, 395);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(227, 22);
            this.dtpDueDate.TabIndex = 11;
            // 
            // btnCreateLoan
            // 
            this.btnCreateLoan.Location = new System.Drawing.Point(86, 423);
            this.btnCreateLoan.Name = "btnCreateLoan";
            this.btnCreateLoan.Size = new System.Drawing.Size(75, 23);
            this.btnCreateLoan.TabIndex = 12;
            this.btnCreateLoan.Text = "Create Loan";
            this.btnCreateLoan.Click += new System.EventHandler(this.btnCreateLoan_Click);
            // 
            // labelADDMember
            // 
            this.labelADDMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelADDMember.Location = new System.Drawing.Point(496, 10);
            this.labelADDMember.Name = "labelADDMember";
            this.labelADDMember.Size = new System.Drawing.Size(206, 31);
            this.labelADDMember.TabIndex = 13;
            this.labelADDMember.Text = "Add Member";
            // 
            // labelAddLoan
            // 
            this.labelAddLoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddLoan.Location = new System.Drawing.Point(-2, 236);
            this.labelAddLoan.Name = "labelAddLoan";
            this.labelAddLoan.Size = new System.Drawing.Size(180, 27);
            this.labelAddLoan.TabIndex = 14;
            this.labelAddLoan.Text = "Create Loan";
            this.labelAddLoan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAddStaff
            // 
            this.labelAddStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddStaff.Location = new System.Drawing.Point(273, 232);
            this.labelAddStaff.Name = "labelAddStaff";
            this.labelAddStaff.Size = new System.Drawing.Size(197, 31);
            this.labelAddStaff.TabIndex = 21;
            this.labelAddStaff.Text = "Add Staff";
            // 
            // txtFN
            // 
            this.txtFN.Location = new System.Drawing.Point(278, 275);
            this.txtFN.Name = "txtFN";
            this.txtFN.Size = new System.Drawing.Size(189, 22);
            this.txtFN.TabIndex = 15;
            this.txtFN.Text = "First Name";
            // 
            // txtLN
            // 
            this.txtLN.Location = new System.Drawing.Point(278, 305);
            this.txtLN.Name = "txtLN";
            this.txtLN.Size = new System.Drawing.Size(189, 22);
            this.txtLN.TabIndex = 16;
            this.txtLN.Text = "Last Name";
            // 
            // txtEML
            // 
            this.txtEML.Location = new System.Drawing.Point(278, 335);
            this.txtEML.Name = "txtEML";
            this.txtEML.Size = new System.Drawing.Size(189, 22);
            this.txtEML.TabIndex = 17;
            this.txtEML.Text = "Email";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(278, 365);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(189, 22);
            this.txtPhoneNumber.TabIndex = 18;
            this.txtPhoneNumber.Text = "Phone";
            // 
            // btnAddStaff
            // 
            this.btnAddStaff.Location = new System.Drawing.Point(316, 452);
            this.btnAddStaff.Name = "btnAddStaff";
            this.btnAddStaff.Size = new System.Drawing.Size(110, 23);
            this.btnAddStaff.TabIndex = 20;
            this.btnAddStaff.Text = "Add Staff";
            this.btnAddStaff.Click += new System.EventHandler(this.btnAddStaff_Click);
            // 
            // txtRole
            // 
            this.txtRole.Location = new System.Drawing.Point(278, 421);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(189, 22);
            this.txtRole.TabIndex = 22;
            this.txtRole.Text = "Role";
            // 
            // HireDate
            // 
            this.HireDate.Location = new System.Drawing.Point(278, 393);
            this.HireDate.Name = "HireDate";
            this.HireDate.Size = new System.Drawing.Size(228, 22);
            this.HireDate.TabIndex = 23;
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnMainMenu.FlatAppearance.BorderSize = 0;
            this.btnMainMenu.Location = new System.Drawing.Point(501, 307);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(200, 50);
            this.btnMainMenu.TabIndex = 24;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // Books
            // 
            this.ClientSize = new System.Drawing.Size(726, 487);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.HireDate);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.labelAddStaff);
            this.Controls.Add(this.txtFN);
            this.Controls.Add(this.txtLN);
            this.Controls.Add(this.txtEML);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.btnAddStaff);
            this.Controls.Add(this.labelAddLoan);
            this.Controls.Add(this.labelADDMember);
            this.Controls.Add(this.dataGridViewBooks);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.cmbMembership);
            this.Controls.Add(this.btnAddMember);
            this.Controls.Add(this.txtInventoryID);
            this.Controls.Add(this.txtMemberID);
            this.Controls.Add(this.txtStaffID);
            this.Controls.Add(this.dtpLoanDate);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.btnCreateLoan);
            this.Name = "Books";
            this.Text = "Library Management System";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label labelADDMember;
        private System.Windows.Forms.Label labelAddLoan;
        private System.Windows.Forms.Label labelAddStaff;
        private System.Windows.Forms.TextBox txtFN;
        private System.Windows.Forms.TextBox txtLN;
        private System.Windows.Forms.TextBox txtEML;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Button btnAddStaff;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.DateTimePicker HireDate;
        private System.Windows.Forms.Button btnMainMenu;
    }
}


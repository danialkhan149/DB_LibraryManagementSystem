namespace LibraryWindowsFormsApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnGenres = new System.Windows.Forms.Button();
            this.btnPublishers = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnBooks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenres
            // 
            this.btnGenres.Location = new System.Drawing.Point(51, 132);
            this.btnGenres.Name = "btnGenres";
            this.btnGenres.Size = new System.Drawing.Size(200, 50);
            this.btnGenres.TabIndex = 0;
            this.btnGenres.Text = "Manage Genres";
            this.btnGenres.UseVisualStyleBackColor = true;
            this.btnGenres.Click += new System.EventHandler(this.btnGenres_Click);
            // 
            // btnPublishers
            // 
            this.btnPublishers.Location = new System.Drawing.Point(51, 213);
            this.btnPublishers.Name = "btnPublishers";
            this.btnPublishers.Size = new System.Drawing.Size(200, 50);
            this.btnPublishers.TabIndex = 1;
            this.btnPublishers.Text = "Manage Publishers";
            this.btnPublishers.UseVisualStyleBackColor = true;
            this.btnPublishers.Click += new System.EventHandler(this.btnPublishers_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(51, 332);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(200, 50);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnBooks
            // 
            this.btnBooks.Location = new System.Drawing.Point(51, 51);
            this.btnBooks.Name = "btnBooks";
            this.btnBooks.Size = new System.Drawing.Size(200, 50);
            this.btnBooks.TabIndex = 3;
            this.btnBooks.Text = "Manage Staff/Members/Loan";
            this.btnBooks.UseVisualStyleBackColor = true;
            this.btnBooks.Click += new System.EventHandler(this.btnAdd_S_M_L_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 426);
            this.Controls.Add(this.btnBooks);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPublishers);
            this.Controls.Add(this.btnGenres);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Management System";
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button btnGenres;
        private System.Windows.Forms.Button btnPublishers;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnBooks;
    }
}
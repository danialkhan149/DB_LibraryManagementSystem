using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace LibraryWindowsFormsApp
{
    public partial class Books : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LibraryApp"].ConnectionString;

        public Books()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void LoadBooks()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT b.Title AS BookTitle, b.ISBN, a.FirstName + ' ' + a.LastName AS Author, p.Name AS Publisher " +
                    "FROM Book b " +
                    "JOIN BookAuthor au ON au.BookID = b.BookID " +
                    "JOIN Author a ON a.AuthorID = au.AuthorID " +
                    "JOIN Publisher p ON p.PublisherID = b.PublisherID";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewBooks.DataSource = dt;
            }
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Member (FirstName, LastName, Email, Phone, MembershipType) " +
                               "VALUES (@FirstName, @LastName, @Email, @Phone, @Type)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Type", cmbMembership.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Member added successfully");
            }
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Staff (FirstName, LastName, Email, Phone, HireDate, Role) " +
                               "VALUES (@FirstName, @LastName, @Email, @Phone, @HDate, @Role)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@HDate", HireDate.Value);
                cmd.Parameters.AddWithValue("@Role", txtRole.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Staff added successfully");
            }
        }
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnCreateLoan_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Loan (InventoryID, MemberID, StaffID, LoanDate, DueDate, ReturnDate) " +
                               "VALUES (@InventoryID, @MemberID, @StaffID, @LoanDate, @DueDate, NULL)";

                SqlCommand cmd = new SqlCommand(query, con);

                int result;
                if(!int.TryParse(txtInventoryID.Text, out result) || !int.TryParse(txtMemberID.Text, out result) || !int.TryParse(txtStaffID.Text, out result))
                {
                    MessageBox.Show("Error Invalid Values entered");
                    return;
                }

                cmd.Parameters.AddWithValue("@InventoryID", int.Parse(txtInventoryID.Text));
                cmd.Parameters.AddWithValue("@MemberID", int.Parse(txtMemberID.Text));
                cmd.Parameters.AddWithValue("@StaffID", int.Parse(txtStaffID.Text));
                cmd.Parameters.AddWithValue("@LoanDate", dtpLoanDate.Value);
                cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Loan created successfully");
            }
        }
    }
}

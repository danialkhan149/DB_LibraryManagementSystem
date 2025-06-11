using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryWindowsFormsApp
{
    public partial class PublisherForm : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["LibraryApp"].ConnectionString;
        private SqlConnection con = new SqlConnection(connectionString);
        private SqlDataAdapter adapter;
        private DataTable dt = new DataTable();

        public PublisherForm()
        {
            InitializeComponent();
        }

        private void PublisherForm_Load(object sender, EventArgs e)
        {
            LoadPublishers();
        }

        private void LoadPublishers()
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM Publisher", con);
                dt.Clear();
                adapter.Fill(dt);
                dataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading publishers: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(dt);
                MessageBox.Show("Publishers saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving publishers: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                dataGridView.Rows.RemoveAt(dataGridView.CurrentRow.Index);
            }
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

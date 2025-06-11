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
    public partial class GenreForm : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["LibraryApp"].ConnectionString;
        private SqlConnection con = new SqlConnection(connectionString);
        private SqlDataAdapter adapter;
        private DataTable dt = new DataTable();

        public GenreForm()
        {
            InitializeComponent();
        }

        private void GenreForm_Load(object sender, EventArgs e)
        {
            LoadGenres();
        }

        private void LoadGenres()
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM Genre", con);
                dt.Clear();
                adapter.Fill(dt);
                dataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading genres: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(dt);
                MessageBox.Show("Genres saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving genres: " + ex.Message);
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
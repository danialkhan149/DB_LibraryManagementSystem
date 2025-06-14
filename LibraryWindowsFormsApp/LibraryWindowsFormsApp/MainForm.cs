﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryWindowsFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGenres_Click(object sender, EventArgs e)
        {
            var genreForm = new GenreForm();
            genreForm.ShowDialog();
        }

        private void btnPublishers_Click(object sender, EventArgs e)
        {
            var publisherForm = new PublisherForm();
            publisherForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_S_M_L_Click(object sender, EventArgs e)
        {
            var genreForm = new Books();
            genreForm.ShowDialog();
        }
    }
}


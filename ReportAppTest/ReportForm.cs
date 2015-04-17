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

namespace ReportAppTest
{
    public partial class ReportForm : Form
    {
        UserSettings us;
        Database db = new Database();

        public ReportForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void configureServersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create settings form
            SettingsForm settings = new SettingsForm();
            using (settings)
            {
                settings.ShowDialog();
            }
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            //db = new Database();
            us = new UserSettings();
            us.Reload();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            us.Reload();
            db.StoreConnectionStrings(userIDTextBox.Text, passwordTextBox.Text);
            if (db.CONNECTION_SUCCESS)
            {
                tabControl1.SelectTab(1);
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (reportListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a report type.", "No Server Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            reportTypeLabel.Text = reportListBox.Text;
            this.printDateTimePicker.Value = DateTime.Now;
            this.tabControl1.SelectTab(2);
        }

        private void reportPanelPrevButton_Click(object sender, EventArgs e)
        {
            db.CONNECTION_SUCCESS = false;
            db.RemoveConnections();
            this.tabControl1.SelectTab(0);
        }

        private void configPanelPrevButton_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(1);
        }
    }
}

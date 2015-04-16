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
            db.StoreConnectionStrings(userIDTextBox.Text, passwordTextBox.Text);
            if (db.CONNECTION_SUCCESS)
            {
                tabControl1.SelectTab(1);
            }
                /*try
                {
                    for (int i = 0; i < us.ServerCount; i++)
                    {
                        using (var connection = Database.CreateSqlConnection(userIDTextBox.Text, passwordTextBox.Text, us.ServerName[i], us.Database))
                        {
                            connection.Open();
                            MessageBox.Show("Connnection Established", "CONNECTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            connection.Close();
                        }
                        
                    }
                    tabControl1.SelectTab(1);
                }
                catch (SqlException)
                {
                    MessageBox.Show("INVALID CONNECTION: Check Server and Database Parameters");
                }*/
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
    }
}

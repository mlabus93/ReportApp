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
        static List<string> items;

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
            this.tabControl1.SelectTab(0);
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

        private void configPanelNextButton_Click(object sender, EventArgs e)
        {
            PopulateFacilityListBox();
            this.tabControl1.SelectTab(3);
        }

        private void unitActivityPrevButton_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(3);
        }

        private void PopulateFacilityListBox()
        {
            items = new List<string>();
            String server;
            foreach (string name in us.ServerName)
            {
                if (name != null)
                {
                    server = name.ToUpper();
                    items.Add(server);
                }
            }
            facilityListBox.DataSource = items;
        }

        private void StoreSelectedFacilities()
        {
            facilityComboBox.DataSource = null;
            facilityComboBox.DataSource = facilityListBox.SelectedItems;
            facilityComboBox.SelectedIndex = 0;
        }

        private void selectFacilityPrevBtn_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(2);
        }

        private void selectFacilityNextBtn_Click(object sender, EventArgs e)
        {
            StoreSelectedFacilities();
            this.tabControl1.SelectTab(4);
        }

        private void OpenSqlConn(String serverName)
        {
            DataSet ds = new DataSet();
            String connStr = "Data Source=" + serverName + ";Initial Catalog=" + us.Database + ";User ID=" 
                + userIDTextBox.Text + ";Password=" + passwordTextBox.Text;
            using(SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter dimZoneAdapter = new SqlDataAdapter("select * from dbo.DimZone", conn);
                SqlDataAdapter dimLocationAdapter = new SqlDataAdapter("select * from dbo.DimLocation", conn);
                dimZoneAdapter.Fill(ds, "dbo.DimZone");
                dimLocationAdapter.Fill(ds, "dbo.DimLocation");
                zoneListBox.DisplayMember = "Zone_Name";
                zoneListBox.ValueMember = "Zone_ID";
                zoneListBox.DataSource = ds.Tables["dbo.DimZone"];
                roomListBox.DisplayMember = "Room_Name";
                roomListBox.ValueMember = "Room_ID";
                roomListBox.DataSource = ds.Tables["dbo.dimLocation"];
            }
        }

        private void facilityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (facilityComboBox.SelectedValue != null)
                OpenSqlConn((String)facilityComboBox.SelectedValue);
        }
    }
}

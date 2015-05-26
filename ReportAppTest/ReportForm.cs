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
using ReportAppTest.Reports;
using Microsoft.Reporting.WinForms;

namespace ReportAppTest
{
    public partial class ReportForm : Form
    {
        UserSettings us;
        Database db = new Database();
        static List<string> items;
        int currentFacilityComboValue = -1;
        public ListBox currentZoneListBox = new ListBox();
        ListBox currentRoomListBox = new ListBox();
        List<DataSet> dsList = new List<DataSet>();
        List<string>[] selectedZItems = new List<string>[15];
        List<string>[] selectedRItems = new List<string>[15];

        public ReportForm()
        {
            InitializeComponent();
        }

        private void InitializeSelectedItems()
        {
            for (int i=0; i < 15; i++)
            {
                selectedZItems[i] = new List<string>();
                selectedRItems[i] = new List<string>();
            }
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
                Properties.Settings.Default.Reload();
                settings.ShowDialog();
            }
            if (settings.DialogResult.Equals((DialogResult)1))
            {
                this.Size = new System.Drawing.Size(800, 600);
                this.MaximumSize = new System.Drawing.Size(800, 600);
                this.MinimumSize = new System.Drawing.Size(800, 600);
                this.tabControl1.SelectTab(0);
            }
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            //db = new Database();
            InitializeSelectedItems();
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
            String facility;
            foreach (string name in Properties.Settings.Default.Facilities)
            {
                if (name != "Enter Server Name")
                {
                    facility = name.ToUpper();
                    items.Add(facility);
                    //OpenSqlConn(server);
                }
            }
            facilityListBox.DataSource = items;
        }

        private void StoreSelectedFacilities()
        {
            List<String> facilities = new List<string>();
            //String strItem;
            //DataTable data = new DataTable();
            //data.Columns.Add("Facilities");
            //foreach (var name in facilityListBox.SelectedItems)
            {
                //data.Rows.Add(name.ToString());
            }

            for (int i = 0; i < facilityListBox.Items.Count; i++)
            {
                if (facilityListBox.GetSelected(i))
                {
                    facilities.Add(facilityListBox.Text);
                }
            }

                //facilityComboBox.DisplayMember = facilityListBox.SelectedItems.ToString();
            facilityComboBox.DataSource = null;
            //facilityComboBox.DataSource = Properties.Settings.Default.Facilities;
            facilityComboBox.DataSource = facilityListBox.SelectedItems;
                //facilityComboBox.DisplayMember = "Facilities";
            facilityComboBox.SelectedIndex = 0;
        }

        private void selectFacilityPrevBtn_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(2);
        }

        private void selectFacilityNextBtn_Click(object sender, EventArgs e)
        {
            if (facilityListBox.SelectedItems.Count > 0)
            {
                StoreSelectedFacilities();
                OpenSqlConn();
                facilityComboBox.SelectedIndex = 0;
                this.tabControl1.SelectTab(4);
            }
            else
            {
                MessageBox.Show("Please select a facility to run a report.", "No Facility Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenSqlConn()
        {
            dsList.Clear();
            int serverIndex = -1;
            int i = 0;
            foreach (var selectedFacility in facilityListBox.Items)
            {
                serverIndex++;
                if (facilityListBox.GetSelected(serverIndex))
                {
                    dsList.Add(new DataSet(selectedFacility.ToString()));
                    /*foreach (String facility in facilityListBox.Items)
                    {

                    }
                
                    foreach (String facilityName in Properties.Settings.Default.Facilities)
                    {
                        //serverIndex = facilityComboBox.Items.IndexOf(facility);
                        if (facilityName.Equals(facility, StringComparison.InvariantCultureIgnoreCase))
                        {
                            //serverIndex = Properties.Settings.Default.Facilities.IndexOf(facilityName);
                            serverIndex++;
                            dsList.Add(new DataSet(facility));
                            break;
                        }
                    }*/

                    String connStr = "Data Source=" + Properties.Settings.Default.Servers[serverIndex] + ";Initial Catalog=" + Properties.Settings.Default.Database + ";User ID="
                        + userIDTextBox.Text + ";Password=" + passwordTextBox.Text;
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        SqlDataAdapter dimZoneAdapter = new SqlDataAdapter("select distinct Zone_Name, Zone_ID from dbo.DimZone", conn);
                        SqlDataAdapter dimLocationAdapter = new SqlDataAdapter("select distinct Room_Name, Room_ID from dbo.DimLocation", conn);
                        //SqlDataAdapter dimFacilityAdapter = new SqlDataAdapter("select * from dbo.DimFacility where Facility_ID=1", conn);
                        //dimFacilityAdapter.Fill(ds, "dbo.DimFacility");
                        //facilityListBox.DisplayMember = "Facility_Name";
                        //facilityListBox.ValueMember = "Facility_ID";
                        //facilityListBox.DataSource = ds.Tables["dbo.DimFacility"];
                        dimZoneAdapter.Fill(dsList[i], "dbo.DimZone");
                        dimLocationAdapter.Fill(dsList[i], "dbo.DimLocation");
                        /*zoneListBox.DisplayMember = "Zone_Name";
                        zoneListBox.ValueMember = "Zone_ID";
                        zoneListBox.DataSource = dsList[i].Tables["dbo.DimZone"];
                        roomListBox.DisplayMember = "Room_Name";
                        roomListBox.ValueMember = "Room_ID";
                        roomListBox.DataSource = dsList[i].Tables["dbo.DimLocation"];*/
                    }
                    i++;
                }
            }
            if (facilityComboBox.Items.Count > 1)
                facilityComboBox.SelectedIndex = 1;
            else
                facilityComboBox_SelectedIndexChanged(facilityComboBox, new EventArgs());
        }

        private void StoreZoneRoomComboBoxes()
        {

        }

        private void facilityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (facilityComboBox.SelectedValue != null)
            {
                //int index = 0;
                /*foreach (string facility in Properties.Settings.Default.Facilities)
                {
                    if (facility.Equals(facilityComboBox.SelectedValue.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        index = Properties.Settings.Default.Facilities.IndexOf(facility);
                    }
                }*/
                //DataSet set = dsList.Find(item => item.DataSetName.Equals(Properties.Settings.Default.Servers[index], StringComparison.InvariantCultureIgnoreCase));
                DataSet set = null;
                if (dsList.Count != 0)
                    set = dsList[facilityComboBox.SelectedIndex];
                if (set != null)
                {
                    zoneListBox.DisplayMember = "Zone_Name";
                    zoneListBox.ValueMember = "Zone_ID";
                    zoneListBox.DataSource = set.Tables["dbo.DimZone"];
                    roomListBox.DisplayMember = "Room_Name";
                    roomListBox.ValueMember = "Room_ID";
                    roomListBox.DataSource = set.Tables["dbo.DimLocation"];
                }
                //string server = Properties.Settings.Default.Servers[facilityComboBox.SelectedIndex];
                //OpenSqlConn(server);
                foreach (string facilityName in Properties.Settings.Default.Facilities)
                {
                    if (facilityComboBox.SelectedItem.ToString().Equals(facilityName, StringComparison.InvariantCultureIgnoreCase))
                        UnitActivityReport.SetLocations(zoneListBox, roomListBox, facilityComboBox.SelectedItem.ToString());
                }

                int i = 0;
                if (selectedZItems != null && selectedRItems != null)
                {
                    for (i = 0; i < zoneListBox.Items.Count; i++)
                    {
                        for (int j = 0; j < selectedZItems[facilityComboBox.SelectedIndex].Count; j++)
                        {
                            if (selectedZItems[facilityComboBox.SelectedIndex][j].Equals(zoneListBox.GetItemText(zoneListBox.Items[i])))
                            {
                                zoneListBox.SetSelected(i, true);
                            }
                        }
                    }
                    for (i = 0; i < roomListBox.Items.Count; i++)
                    {
                        for (int j = 0; j < selectedRItems[facilityComboBox.SelectedIndex].Count; j++)
                        {
                            if (selectedRItems[facilityComboBox.SelectedIndex][j].Equals(roomListBox.GetItemText(roomListBox.Items[i])))
                            {
                                this.roomListBox.SetSelected(i, true);
                            }
                        }
                    }
                }
            }

            if (currentFacilityComboValue != facilityComboBox.SelectedIndex)
            {
                ResetFacilitySaveButton();
            }
        }

        private void ResetFacilitySaveButton()
        {
            this.pictureBox1.Image = null;
            this.confirmFacilityButton.Text = "Confirm Facility Settings";
            this.confirmFacilityButton.Enabled = true;
            this.currentFacilityComboValue = facilityComboBox.SelectedIndex;
        }

        private void reportNextButton_Click(object sender, EventArgs e)
        {
            UnitActivityReport.SetLocations(zoneListBox, roomListBox,  facilityComboBox.SelectedItem.ToString());
            /*this.reportViewer1.ServerReport.ReportServerUrl = new System.Uri(Properties.Settings.Default.URI);
            ReportParameter param = new ReportParameter("Locations", UnitActivityReport.locations[0]);*/
            UnitActivityReport.startDate = startDatePicker.Value;
            UnitActivityReport.endDate = endDatePicker.Value;
            /*var startDate = new ReportParameter("StartDate", UnitActivityReport.startDate.ToString("MM/dd/yyyy"));
            var endDate = new ReportParameter("EndDate", UnitActivityReport.endDate.ToString("MM/dd/yyyy"));
            this.reportViewer1.ServerReport.SetParameters(param);
            this.reportViewer1.ServerReport.SetParameters(startDate);
            this.reportViewer1.ServerReport.SetParameters(endDate);
            string val = null;
            this.reportViewer1.ServerReport.SetParameters(new ReportParameter("CallTypeIds", val));
            string value = "true";
            this.reportViewer1.ServerReport.SetParameters(new ReportParameter("ShowBlankRecords", value));
            this.reportViewer1.ServerReport.SetParameters(new ReportParameter("PrintedBy", "GUY"));
            this.reportViewer1.ShowParameterPrompts = false;
            this.tabControl1.SelectTab(5);
            this.MaximumSize = new System.Drawing.Size(0, 0);
            //this.Size = new System.Drawing.Size(825, 850);
            this.WindowState = FormWindowState.Maximized;*/
            ReportViewerForm reportViewer = new ReportViewerForm();
            using (reportViewer)
            {
                reportViewer.ShowDialog();
            }
            //this.reportViewer1.RefreshReport();
        }

        private void confirmFacilityButton_Click(object sender, EventArgs e)
        {
            if (facilityComboBox.SelectedValue != null)
            {
                if (zoneListBox.SelectedItems.Count != 0 && roomListBox.SelectedItems.Count != 0)
                {
                    selectedZItems[facilityComboBox.SelectedIndex].Clear();
                    selectedRItems[facilityComboBox.SelectedIndex].Clear();
                    /*var zoneItems = new ListBox.SelectedObjectCollection(zoneListBox);
                    var roomItems = new ListBox.SelectedObjectCollection(roomListBox);
                    selectedZoneItems = zoneItems;
                    selectedRoomItems = roomItems;*/
                    for (int i = 0; i < zoneListBox.SelectedItems.Count; i++)
                    {
                        selectedZItems[facilityComboBox.SelectedIndex].Add(zoneListBox.GetItemText(zoneListBox.SelectedItems[i]));
                    }
                    for (int j = 0; j < roomListBox.SelectedItems.Count; j++)
                    {
                        selectedRItems[facilityComboBox.SelectedIndex].Add(roomListBox.GetItemText(roomListBox.SelectedItems[j]));
                    }

                    //string server = Properties.Settings.Default.Servers[facilityComboBox.SelectedIndex];
                    //OpenSqlConn(server);
                    foreach (string facilityName in Properties.Settings.Default.Facilities)
                    {
                        if (facilityComboBox.SelectedItem.ToString().Equals(facilityName, StringComparison.InvariantCultureIgnoreCase))
                            UnitActivityReport.SetLocations(zoneListBox, roomListBox, facilityComboBox.SelectedItem.ToString());
                    }

                    this.confirmFacilityButton.Text = "Facility " + facilityComboBox.SelectedItem.ToString() + " Saved";
                    this.confirmFacilityButton.Enabled = false;
                    this.pictureBox1.Image = Properties.Resources.checkmark;
                }
                else
                {
                    MessageBox.Show("Please select at least one zone and one room.", "No Selection Made", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void zoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetFacilitySaveButton();
        }

        private void roomListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetFacilitySaveButton();
        }

    }
}

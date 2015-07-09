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
using ReportAppTest.Tables;
using ReportAppTest.Tables.Collections;
using Microsoft.Reporting.WinForms;

namespace ReportAppTest
{
    public partial class ReportForm : Form
    {
        // Max number of servers
        const int MAX_SERVER_COUNT = 10;

        // Class to connect to each server in database
        Database db = new Database();

        // List used to populate facility listbox
        static List<string> facilityList;
        
        // flag for restting facility save button
        int currentFacilityComboValue = -1;

        // Data tables to read SQL data into
        DataTable dimZone = new DataTable();
        DataTable dimLocation = new DataTable();
        DataTable pr_UnitActivityReport = new DataTable();

        // Lists of class type for each row
        List<DimZone>[] zoneCollection = new List<DimZone>[MAX_SERVER_COUNT];
        List<DimLocation>[] locationsCollection = new List<DimLocation>[MAX_SERVER_COUNT];

        // Location and zone merged data type
        LocationZone locationZone = new LocationZone();

        // Location and zone class type list
        LocationZoneCollection[] lzCollection = new LocationZoneCollection[MAX_SERVER_COUNT];

        // Reports list
        public List<UnitActivityReport> reports = new List<UnitActivityReport>();

        // Stored Procedure Lists
        List<UnitActivityProcedure>[] unitActivityProcedureCollection = new List<UnitActivityProcedure>[MAX_SERVER_COUNT];

        int facilityIndex = -1;

        // StringBuilder for first procedure call
        public StringBuilder locationBuilder = new StringBuilder();

        // StringBuilders for procedure parameters
        StringBuilder locationParam = new StringBuilder();
        StringBuilder callTypeParam = new StringBuilder();


        // Constructor
        public ReportForm()
        {
            InitializeComponent();
        }
        
        // Retrieve Zone and Location Tables from specified server
        private void SQLQueries(string server)
        {
            {
                dimZone.Clear();
                dimLocation.Clear();
                string connect = "Data Source=" + server + ";Initial Catalog=RMDW;User ID=r5_rpt;Password=rpt";
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    try
                    {
                        SqlDataAdapter dimZoneAdapter = new SqlDataAdapter("SELECT * FROM dbo.DimZone WHERE Zone_Key > 0", conn);
                        SqlDataAdapter dimLocationAdapter = new SqlDataAdapter("SELECT * FROM dbo.DimLocation WHERE Location_Key > 0", conn);
                        
                        dimZoneAdapter.Fill(dimZone);
                        dimLocationAdapter.Fill(dimLocation);
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Sql Error: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }

        // Populate collections from DataTable objects
        private void AddRowsToCollection(int index)
        {
            // Loop through zone data table to add rows to custom zone collection
            foreach (DataRow row in dimZone.Rows)
            {
                DimZone zoneRow = new DimZone();
                zoneRow.Zone_Key = row.Field<int>("Zone_Key");
                zoneRow.Zone_ID = row.Field<int>("Zone_ID");
                zoneRow.Facility_Key = row.Field<int>("Facility_Key");
                zoneRow.Zone_Name = row.Field<string>("Zone_Name");
                zoneRow.Zone_Type = row.Field<string>("Zone_Type");
                zoneCollection[index].Add(zoneRow);
            }
            // Loop through location data table to add rows to custom location collection
            foreach (DataRow row in dimLocation.Rows)
            {
                DimLocation locationRow = new DimLocation();
                locationRow.Location_Key = row.Field<int>("Location_Key");
                locationRow.Location_ID = row.Field<int>("Location_ID");
                locationRow.Location_Type = row.Field<string>("Location_Type");
                locationRow.Facility_Key = row.Field<int>("Facility_Key");
                locationRow.Area_ID = row.Field<int>("Area_ID");
                locationRow.Area_Name = row.Field<string>("Area_Name");
                locationRow.Room_ID = row.Field<int>("Room_ID");
                locationRow.Room_Name = row.Field<string>("Room_Name");
                locationRow.Bed_ID = row.Field<int>("Bed_ID");
                locationRow.Bed_Name = row.Field<string>("Bed_Name");
                locationsCollection[index].Add(locationRow);
            }
        }

        // Merge and Populate location and zone collections into one collection
        private void MergeTables(int index)
        {
            foreach (var location in locationsCollection[index])
            {
                foreach (var zone in zoneCollection[index])
                {
                    if (location.Area_Name.Equals(zone.Zone_Name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        LocationZone locationZone = new LocationZone();
                        locationZone.Zone_ID = zone.Zone_ID;
                        locationZone.Zone_Name = zone.Zone_Name;
                        locationZone.Area_ID = location.Area_ID;
                        locationZone.Area_Name = location.Area_Name;
                        locationZone.Room_ID = location.Room_ID;
                        locationZone.Room_Name = location.Room_Name;
                        lzCollection[index].AddLocationZone(locationZone);
                    }
                }
            }
        }

        // Create location paramter string for initial SQL stored procedure call
        private string CreateZoneLocationString(int serverIndex)
        {
            // Format for location param is : "ZoneID,RoomID;"
            foreach (var zone in zoneCollection[serverIndex])
            {
                foreach (var location in locationsCollection[serverIndex])
                {
                    locationBuilder.Append(zone.Zone_ID);
                    locationBuilder.Append(",");
                    locationBuilder.Append(location.Room_ID);
                    locationBuilder.Append(";");
                }
            }
            return locationBuilder.ToString();
        }

        // Run initial UnitActivity Stored Procedure for selected dates on specified server
        private void GetUnitActivityTable(int serverIndex, string server, DateTime startDate, DateTime endDate)
        {
            string connString = "Data Source=" + server + ";Initial Catalog=" + Properties.Settings.Default.Database + ";User ID=r5_rpt;Password=rpt";
            string sql = "dbo.prFactEvent_Get_UnitActivityReport";

            // Call function to get location parameter string
            string locationParam = CreateZoneLocationString(serverIndex);

            // Run Unit Activity procedure
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand(sql, conn);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.AddWithValue("@StartDate", startDate);
                        da.SelectCommand.Parameters.AddWithValue("@EndDate", endDate);
                        da.SelectCommand.Parameters.AddWithValue("@Locations", locationParam);
                        da.SelectCommand.Parameters.AddWithValue("@StartTime", System.DBNull.Value);
                        da.SelectCommand.Parameters.AddWithValue("@EndTime", System.DBNull.Value);
                        da.SelectCommand.Parameters.AddWithValue("FirstShiftStartTime", System.DBNull.Value);
                        da.SelectCommand.Parameters.AddWithValue("@FirstShiftEndTime", System.DBNull.Value);
                        da.SelectCommand.Parameters.AddWithValue("@SecondShiftStartTime", System.DBNull.Value);
                        da.SelectCommand.Parameters.AddWithValue("@SecondShiftEndTime", System.DBNull.Value);
                        da.SelectCommand.Parameters.AddWithValue("@ThirdShiftStartTime", System.DBNull.Value);
                        da.SelectCommand.Parameters.AddWithValue("@ThirdShiftEndTime", System.DBNull.Value);
                        da.SelectCommand.Parameters.AddWithValue("@CallTypeIds", System.DBNull.Value);
                        da.SelectCommand.Parameters.AddWithValue("@IncludeMessages", 0);
                        da.SelectCommand.Parameters.AddWithValue("@CombineUnits", 0);
                        da.SelectCommand.Parameters.AddWithValue("@StaffServiceLevels", System.DBNull.Value);
                        da.SelectCommand.Parameters.AddWithValue("@StaffRegistrationLevels", System.DBNull.Value);
                        da.SelectCommand.Parameters.AddWithValue("@StaffIds", System.DBNull.Value);
                        da.SelectCommand.Parameters.AddWithValue("@ShowBlankRecords", 1);

                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        // Populate collection from Unit Activity Procedure table
                        foreach (DataRow row in dt.Rows)
                        {
                            UnitActivityProcedure unitActivityProcedure = new UnitActivityProcedure();
                            unitActivityProcedure.Account_Id = row.Field<int?>("Account_Id");
                            unitActivityProcedure.Activity_Type_Desc = row.Field<string>("Activity_Type_Desc");
                            unitActivityProcedure.Area_Id = row.Field<int?>("Area_Id");
                            unitActivityProcedure.Area_Name = row.Field<string>("Area_Name");
                            unitActivityProcedure.Bed_Id = row.Field<int?>("Bed_Id");
                            unitActivityProcedure.Bed_Name = row.Field<string>("Bed_Name");
                            unitActivityProcedure.CalendarDate = row.Field<DateTime?>("CalendarDate").ToString();
                            unitActivityProcedure.Call_Point = row.Field<byte?>("Call_Point");
                            unitActivityProcedure.Call_Stop = row.Field<byte?>("Call_Stop");
                            unitActivityProcedure.Call_Type_ID = row.Field<int?>("Call_Type_ID");
                            unitActivityProcedure.Detail_Id = row.Field<int?>("Detail_Id");
                            unitActivityProcedure.Device_Extension = row.Field<string>("Device_Extension");
                            unitActivityProcedure.Device_ID = row.Field<int?>("Device_ID");
                            unitActivityProcedure.Device_Type_Desc = row.Field<string>("Device_Type_Desc");
                            unitActivityProcedure.Elapsed_Time = row.Field<int?>("Elapsed_Time");
                            unitActivityProcedure.Event_Id = row.Field<int?>("Event_Id");
                            unitActivityProcedure.Event_Time = row.Field<DateTime?>("Event_Time").ToString();
                            unitActivityProcedure.Fact_Event_Activity_Key = row.Field<int?>("Fact_Event_Activity_Key");
                            unitActivityProcedure.Facility_Id = row.Field<int?>("Facility_Id");
                            unitActivityProcedure.Facility_Name = row.Field<string>("Facility_Name");
                            unitActivityProcedure.Group_Start_Time = row.Field<DateTime?>("Group_Start_Time").ToString();
                            unitActivityProcedure.In_Room_Duration = row.Field<long?>("In_Room_Duration");
                            unitActivityProcedure.NumOfConsoleNotifications = row.Field<int?>("NumOfConsoleNotifications");
                            unitActivityProcedure.NumOfPagerNotifications = row.Field<int?>("NumOfPagerNotifications");
                            unitActivityProcedure.NumOfPatientCalls = row.Field<int?>("NumOfPatientCalls");
                            unitActivityProcedure.NumOfPhoneNotifications = row.Field<int?>("NumOfPhoneNotifications");
                            unitActivityProcedure.NumOfServiceCalls = row.Field<int?>("NumOfServiceCalls");
                            unitActivityProcedure.NumOfStaffRegCalls = row.Field<int?>("NumOfStaffRegCalls");
                            unitActivityProcedure.Patient_First_Name = row.Field<string>("Patient_First_Name");
                            unitActivityProcedure.Patient_Gender = row.Field<string>("Patient_Gender");
                            unitActivityProcedure.Patient_Last_Name = row.Field<string>("Patient_Last_Name");
                            unitActivityProcedure.Priority_Desc = row.Field<string>("Priority_Desc");
                            unitActivityProcedure.Room_Id = row.Field<int?>("Room_Id");
                            unitActivityProcedure.Room_Name = row.Field<string>("Room_Name");
                            unitActivityProcedure.Service_Level_ID = row.Field<int?>("Service_Level_ID");
                            unitActivityProcedure.Service_Level_Name = row.Field<string>("Service_Level_Name");
                            unitActivityProcedure.Shift_End_Date_Time = row.Field<DateTime?>("Shift_End_Date_Time").ToString();
                            unitActivityProcedure.Shift_End_Time = row.Field<DateTime?>("Shift_End_Time").ToString();
                            unitActivityProcedure.Shift_Id = row.Field<int?>("Shift_Id");
                            unitActivityProcedure.Shift_Name = row.Field<string>("Shift_Name");
                            unitActivityProcedure.Shift_Start_Date_Time = row.Field<DateTime?>("Shift_Start_Date_Time").ToString();
                            unitActivityProcedure.Shift_Start_Time = row.Field<DateTime?>("Shift_Start_Time").ToString();
                            unitActivityProcedure.Staff_First_Name = row.Field<string>("Staff_First_Name");
                            unitActivityProcedure.Staff_ID = row.Field<int?>("Staff_ID");
                            unitActivityProcedure.Staff_Last_Name = row.Field<string>("Staff_Last_Name");
                            unitActivityProcedure.Staff_Response_Time = row.Field<long?>("Staff_Response_Time");
                            unitActivityProcedure.Summary_Id = row.Field<int?>("Summary_Id");
                            unitActivityProcedure.SummaryRank = row.Field<int?>("SummaryRank");
                            unitActivityProcedure.Text_Message = row.Field<string>("Text_Message");
                            unitActivityProcedure.TotalElapsedTimeInSummary = row.Field<int?>("TotalElapsedTimeInSummary");
                            unitActivityProcedure.TotalElapsedTimePerDay = row.Field<int?>("TotalElapsedTimePerDay");
                            unitActivityProcedure.Voice_Response_Time = row.Field<long?>("Voice_Response_Time");
                            unitActivityProcedure.Zone_ID = row.Field<int?>("Zone_ID");
                            unitActivityProcedure.Zone_Name = row.Field<string>("Zone_Name");

                            unitActivityProcedureCollection[serverIndex].Add(unitActivityProcedure);
                        }
                        
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        // Exit application from top menu exit item
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Configure settings item event handler
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

        // Event handler for next page (report type select page)
        // Test connection to all servers with provided credentials
        private void confirmButton_Click(object sender, EventArgs e)
        {
            db.StoreConnectionStrings(userIDTextBox.Text, passwordTextBox.Text);
            if (db.CONNECTION_SUCCESS)
            {
                tabControl1.SelectTab(1);
            }
        }

        // Event handler for next page (report config page)
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

        // Event handler for previous page (home login page)
        private void reportPanelPrevButton_Click(object sender, EventArgs e)
        {
            db.CONNECTION_SUCCESS = false;
            db.RemoveConnections();
            this.tabControl1.SelectTab(0);
        }

        // Event handler for previous page (report type select page)
        private void configPanelPrevButton_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(1);
        }

        // Event handler for initial configurations:
        // run Unit Activity Report stored procedure for selected dates and times
        // go to next page to select facility
        private void configPanelNextButton_Click(object sender, EventArgs e)
        {
            // Initialize collections for each server, run queries, and create class collections
            foreach (var server in Properties.Settings.Default.Servers)
            {
                if (!server.Equals("Enter Server Name", StringComparison.InvariantCultureIgnoreCase))
                {
                    int serverIndex = Properties.Settings.Default.Servers.IndexOf(server);
                    zoneCollection[serverIndex] = new List<DimZone>();
                    locationsCollection[serverIndex] = new List<DimLocation>();
                    lzCollection[serverIndex] = new LocationZoneCollection();
                    unitActivityProcedureCollection[serverIndex] = new List<UnitActivityProcedure>();
                    SQLQueries(server);
                    AddRowsToCollection(serverIndex);
                    MergeTables(serverIndex);
                    GetUnitActivityTable(serverIndex, server, startDatePicker.Value, endDatePicker.Value);
                }
            }
            // Add facilities to listbox on next page
            PopulateFacilityListBox();
            // Go to next page (select facility page)
            this.tabControl1.SelectTab(3);
        }

        // Event handler for previous page (select facility page)
        private void unitActivityPrevButton_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(3);
        }

        // Facility listbox populated from settings file
        private void PopulateFacilityListBox()
        {
            facilityList = new List<string>();
            String facility;
            foreach (string name in Properties.Settings.Default.Facilities)
            {
                if (name != "Enter Server Name")
                {
                    facility = name.ToUpper();
                    facilityList.Add(facility);
                }
            }
            facilityListBox.DataSource = facilityList;
        }

        // Populate facility combobox and initialize new UnitActivity reports
        private void StoreSelectedFacilities()
        {
            reports.Clear();
            foreach (var facility in facilityListBox.SelectedItems)
            {
                reports.Add(new UnitActivityReport(facilityListBox.GetItemText(facility)));
            }

            facilityComboBox.DataSource = null;
            facilityComboBox.DataSource = facilityListBox.SelectedItems;
            facilityComboBox.SelectedIndex = 0;
        }

        // Event handler for previous page (report config page) 
        private void selectFacilityPrevBtn_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(2);
        }

        // Event handler for next page (unit activity report page)
        private void selectFacilityNextBtn_Click(object sender, EventArgs e)
        {
            if (facilityListBox.SelectedItems.Count > 0)
            {
                StoreSelectedFacilities();
                facilityComboBox.SelectedIndex = 0;
                this.tabControl1.SelectTab(4);
            }
            else
            {
                MessageBox.Show("Please select a facility to run a report.", "No Facility Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for facility combobox selection
        private void facilityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (facilityComboBox.DataSource != null)
            {
                string connString = "Data Source=" + Properties.Settings.Default.Servers[facilityComboBox.SelectedIndex] + ";Initial Catalog=" + Properties.Settings.Default.Database + ";User ID=r5_rpt;Password=rpt";
                string sql = "dbo.pr_ReportFilter_CallType";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = new SqlCommand(sql, conn);
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.AddWithValue("@Facility_ID_List", 1);

                            DataSet ds = new DataSet();

                            da.Fill(ds, "result");

                            callTypeListBox.DataSource = ds.Tables["result"];
                            callTypeListBox.DisplayMember = "call_type_desc";
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("SQL Error: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            if (facilityComboBox.SelectedValue != null)
            {
                // Get index of currently selected facility
                foreach (var facility in Properties.Settings.Default.Facilities)
                {
                    if (facility.Equals(facilityComboBox.GetItemText(facilityComboBox.SelectedItem), StringComparison.InvariantCultureIgnoreCase))
                    {
                        facilityIndex = Properties.Settings.Default.Facilities.IndexOf(facility);
                    }
                }
                
                zoneListBox.DisplayMember = "Zone_Name";
                zoneListBox.ValueMember = "Zone_ID";
                zoneListBox.DataSource = lzCollection[facilityIndex].GetZoneList();
            }
            
            if (currentFacilityComboValue != facilityComboBox.SelectedIndex)
            {
                ResetFacilitySaveButton();
            }
        }

        // Reset save button when facility combobox changed
        private void ResetFacilitySaveButton()
        {
            this.pictureBox1.Image = null;
            this.confirmFacilityButton.Text = "Confirm Facility Settings";
            this.confirmFacilityButton.Enabled = true;
            this.currentFacilityComboValue = facilityComboBox.SelectedIndex;
        }

        // Event handler to open and run new reports
        private void reportNextButton_Click(object sender, EventArgs e)
        {
            if (roomListBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one zone and one room.", "No Selection Made", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Assign report parameters for each server
            foreach (var report in reports)
            {
                if (facilityComboBox.GetItemText(facilityComboBox.SelectedItem).Equals(report.reportName, StringComparison.InvariantCultureIgnoreCase))
                {
                    report.locationString = locationParam.ToString();
                    report.callTypeString = callTypeParam.ToString();
                    report.startDate = startDatePicker.Value;
                    report.endDate = endDatePicker.Value;
                }
            }
            // Launch new reports in new forms
            foreach (var report in reports)
            {
                var form = new ReportViewerForm(report);
                form.Shown += (o, args) => { this.Enabled = false; };
                form.FormClosed += (o, args) => { this.Enabled = true; };
                form.Show();
            }
        }

        // Event handler to save facility parameters for the selected facility
        private void confirmFacilityButton_Click(object sender, EventArgs e)
        {
            if (facilityComboBox.SelectedValue != null)
            {
                if (roomListBox.SelectedItems.Count != 0)
                {
                    locationParam.Clear();
                    // Create location parameter string
                    foreach (UnitActivityProcedure selectedRoom in roomListBox.SelectedItems)
                    {
                        var zoneID = selectedRoom.Zone_ID;
                        var roomID = selectedRoom.Room_Id;
                        locationParam.Append(zoneID);
                        locationParam.Append(",");
                        locationParam.Append(roomID);
                        locationParam.Append(";");
                    }
                    callTypeParam.Clear();
                    // Create call type parameter string
                    foreach (DataRowView callType in callTypeListBox.SelectedItems)
                    {
                        var callTypeID = callType[2];
                        callTypeParam.Append(callTypeID);
                        callTypeParam.Append(";");
                    }

                    // Assign UI selected parameters to UnitActivityReport class member variables
                    foreach (var report in reports)
                    {
                        if (facilityComboBox.GetItemText(facilityComboBox.SelectedItem).Equals(report.reportName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            report.locationString = locationParam.ToString();
                            report.callTypeString = callTypeParam.ToString();
                            report.startDate = startDatePicker.Value;
                            report.endDate = endDatePicker.Value;
                        }
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

        // Event handler for zone selection listbox
        private void zoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset save button if zone selection changes
            ResetFacilitySaveButton();

            // Populate room listbox based on selected zones
            if (zoneListBox.SelectedItems != null)
            {
                roomListBox.Enabled = true;
                List<UnitActivityProcedure> appended = new List<UnitActivityProcedure>();
                foreach (LocationZone zone in zoneListBox.SelectedItems)
                {
                    foreach (var location in unitActivityProcedureCollection[facilityIndex])
                    {
                        if (location.Zone_ID == zone.Zone_ID && location.Room_Id != null)
                        {
                            if (!location.DuplicateExists(appended))
                            {
                                appended.Add(location);
                            }
                        }
                    }
                }
                roomListBox.DisplayMember = "Room_Name";
                roomListBox.ValueMember = "Room_ID";
                roomListBox.DataSource = appended;
                // If no rooms in zone, listbox displays "no rooms" and is disabled
                if (roomListBox.Items.Count == 0)
                {
                    roomListBox.Enabled = false;
                    roomListBox.DataSource = null;
                    roomListBox.Items.Insert(0, "No rooms for selected dates");
                }
            }
        }

        // Event handler for changing selected rooms
        private void roomListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset save button if selections are modified
            ResetFacilitySaveButton();
        }

    }
}

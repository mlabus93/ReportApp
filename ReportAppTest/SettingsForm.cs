using ReportAppTest.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportAppTest
{
    public partial class SettingsForm : Form
    {
        public const int MAX_SERVER_COUNT = 10;

        //2d array for server labels and textboxes
        Object[,] servers = new Object[10,2];

        public SettingsForm()
        {
            InitializeComponent();

            //add textBoxes to servers array
            this.AddToServerArray(server1TextBox, 0);
            this.AddToServerArray(server2TextBox, 1);
            this.AddToServerArray(server3TextBox, 2);
            this.AddToServerArray(server4TextBox, 3);
            this.AddToServerArray(server5TextBox, 4);
            this.AddToServerArray(server6TextBox, 5);
            this.AddToServerArray(server7TextBox, 6);
            this.AddToServerArray(server8TextBox, 7);
            this.AddToServerArray(server9TextBox, 8);
            this.AddToServerArray(server10TextBox, 9);

            //add labels to servers array
            this.AddToServerArray(serverName1Label, 0);
            this.AddToServerArray(serverName2Label, 1);
            this.AddToServerArray(serverName3Label, 2);
            this.AddToServerArray(serverName4Label, 3);
            this.AddToServerArray(serverName5Label, 4);
            this.AddToServerArray(serverName6Label, 5);
            this.AddToServerArray(serverName7Label, 6);
            this.AddToServerArray(serverName8Label, 7);
            this.AddToServerArray(serverName9Label, 8);
            this.AddToServerArray(serverName10Label, 9);

            this.DialogResult = 0;


        }

        

        private void AddToServerArray(TextBox server, int index)
        {
            servers[index, 0] = server;
        }
        
        private void AddToServerArray(Label server, int index)
        {
            servers[index, 1] = server;
        }

        //Method for clearing user prompt in server textboxes
        private void serverTextBox_Enter(object sender, EventArgs e)
        {
            var serverTextBox = (TextBox)sender;

            if (serverTextBox.Text.Contains("Enter Server"))
            {
                serverTextBox.Text = null;
                serverTextBox.ForeColor = DefaultForeColor;
            }
        }

        //Method for restoring user prompt in empty server textboxes
        private void serverTextBox_Leave(object sender, EventArgs e)
        {
            var serverTextBox = (TextBox)sender;

            if (serverTextBox.Text == "")
            {
                serverTextBox.Text = "Enter Server Name";
                serverTextBox.ForeColor = SystemColors.InactiveCaptionText;
            }
            else
            {
                //if (serverTextBox.TabIndex-1 <= Properties.Settings.Default.ServerCount)
                    //Properties.Settings.Default.Servers[serverTextBox.TabIndex - 1] = serverTextBox.Text;
            }
        }


        //Method for clearing user prompt in database textbox
        private void databaseTextBox_Enter(object sender, EventArgs e)
        {
            var serverTextBox = (TextBox)sender;

            if (serverTextBox.Text.Contains("Enter Database"))
            {
                serverTextBox.Text = null;
                serverTextBox.ForeColor = DefaultForeColor;
            }
        }

        //Method for restoring user prompt in empty database textbox
        private void databaseTextBox_Leave(object sender, EventArgs e)
        {
            var serverTextBox = (TextBox)sender;

            if (serverTextBox.Text == "")
            {
                serverTextBox.Text = "Enter Database Name";
                serverTextBox.ForeColor = SystemColors.InactiveCaptionText;
            }
        }

        //Method for displaying number of server labels and textboxes
        private void serverCounter_ValueChanged(object sender, EventArgs e)
        {
            var count = serverCounter.Value;
            //base case to set visible false every value changed event
            serverInfoHide();
            //loop through labels/textboxes 2 to selected value
            for (int i=1; i<count; i++)
            {
                Label currentLabel = (Label)servers[i, 1];
                TextBox currentTextBox = (TextBox)servers[i,0];
                if (i < Properties.Settings.Default.ServerCount)
                    currentTextBox.Text = Properties.Settings.Default.Servers[i];
                if (currentTextBox.Text == "Enter Server Name")
                {
                    currentTextBox.Text = "Enter Server Name";
                    currentTextBox.ForeColor = SystemColors.InactiveCaptionText;
                }
                currentLabel.Visible = true;
                currentTextBox.Visible = true;
            }
            for (int j=(int)count; j<MAX_SERVER_COUNT; j++)
            {
                Label label = (Label)servers[j, 1];
                TextBox textBox = (TextBox)servers[j, 0];
                textBox.Text = "Enter Server Name";
                //Properties.Settings.Default.Servers[j] = "Enter Server Name";
            }
        }
        
        //helper method to reset servers invisible
        private void serverInfoHide()
        {
            for (int i=1; i<MAX_SERVER_COUNT; i++)
            {
                Label currentLabel = (Label)servers[i, 1];
                TextBox currentTextBox = (TextBox)servers[i, 0];
                if (currentTextBox.Text != "Enter Server Name")
                {
                    //do nothing
                }
                else
                {
                    currentTextBox.Text = "Enter Server Name";
                }
                currentLabel.Visible = false;
                currentTextBox.Visible = false;
            }
        }

        //Cancel settings and close form
        private void cancelSettingsButton_Click(object sender, EventArgs e)
        {
            //Properties.Settings.Default.Reload();
            this.Close();
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
           
            TextBox currentTextBox;
            

            for (int k=0; k<serverCounter.Value; k++)
            {
                currentTextBox = (TextBox)servers[k, 0];
                if (currentTextBox.Text == "Enter Server Name" && databaseTextBox.Text == "Enter Database Name")
                {
                    MessageBox.Show("Must fill in all server names.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Must enter database name.", "Invalid Database Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (databaseTextBox.Text == "Enter Database Name")
                {
                    MessageBox.Show("Must enter database name.", "Invalid Database Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (currentTextBox.Text == "Enter Server Name")
                {
                    MessageBox.Show("Must fill in all server names.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Properties.Settings.Default.Servers.Clear();
            for (int i=0; i<serverCounter.Value; i++)
            {
                currentTextBox = (TextBox)servers[i, 0];
                Properties.Settings.Default.Servers.Remove("null");
                Properties.Settings.Default.Servers.Insert(i, currentTextBox.Text);
                //us.ServerName[i] = currentTextBox.Text;
                currentTextBox.DataBindings.Add("Text", Properties.Settings.Default, "Servers");

                if (currentTextBox.Text.Equals("Enter Server Name"))
                    MessageBox.Show("Enter All Server Names");
                
            }
            for (int j = (int)serverCounter.Value; j < MAX_SERVER_COUNT; j++ )
            {
                currentTextBox = (TextBox)servers[j, 0];
                Properties.Settings.Default.Servers.Insert(j, currentTextBox.Text);
                //us.ServerName[j] = (String)us.Properties["ServerName"].DefaultValue;
                //currentTextBox.DataBindings.Add("Text", us, "ServerName");

            }
           
            /*us.ServerCount = (int)serverCounter.Value;
            us.Database = (String)databaseTextBox.Text;
            us.SettingsFlag = true;*/

            Properties.Settings.Default.ServerCount = (int)serverCounter.Value;
            Properties.Settings.Default.Database = (String)databaseTextBox.Text;
            Properties.Settings.Default.Flag = true;
            
            Properties.Settings.Default.Save();
            this.DialogResult = (DialogResult)1;
            //us.Save();
            this.Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            bool flag = Properties.Settings.Default.Flag;

            for (int k = 0; k < Properties.Settings.Default.ServerCount; k++ )
            {
                TextBox current = (TextBox)servers[k, 0];
                current.Text = Properties.Settings.Default.Servers[k].ToString();
                servers[k, 0] = current;
            }
            for (int k = Properties.Settings.Default.ServerCount; k < MAX_SERVER_COUNT; k++)
            {
                TextBox current = (TextBox)servers[k, 0];
                current.Text = "Enter Server Name";
            }

                if (!flag)
                {
                    //do nothing
                }

                else if (flag)
                {
                    TextBox currentTextBox;
                    serverCounter.Value = Properties.Settings.Default.ServerCount;
                    databaseTextBox.Text = Properties.Settings.Default.Database;
                    //us.Reload();
                    //serverCounter.Value = us.ServerCount;
                    //databaseTextBox.Text = us.Database;
                    if (databaseTextBox.Text != "Enter Database Name")
                        databaseTextBox.ForeColor = DefaultForeColor;

                    for (int i = 0; i < serverCounter.Value; i++)
                    {
                        currentTextBox = (TextBox)servers[i, 0];
                        //currentTextBox.Text = us.ServerName[i];
                        currentTextBox.Text = Properties.Settings.Default.Servers[i].ToString();
                        currentTextBox.ForeColor = DefaultForeColor;
                    }
                    for (int j = (int)serverCounter.Value; j < MAX_SERVER_COUNT; j++)
                    {
                        currentTextBox = (TextBox)servers[j, 0];
                        currentTextBox.Text = "Enter Server Name";
                        currentTextBox.ForeColor = SystemColors.InactiveCaptionText;
                    }
                }
        }
    }
}

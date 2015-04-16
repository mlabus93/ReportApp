namespace ReportAppTest
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.cancelSettingsButton = new System.Windows.Forms.Button();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.databaseTextBox = new System.Windows.Forms.TextBox();
            this.server10TextBox = new System.Windows.Forms.TextBox();
            this.server9TextBox = new System.Windows.Forms.TextBox();
            this.server8TextBox = new System.Windows.Forms.TextBox();
            this.server7TextBox = new System.Windows.Forms.TextBox();
            this.server6TextBox = new System.Windows.Forms.TextBox();
            this.server5TextBox = new System.Windows.Forms.TextBox();
            this.server4TextBox = new System.Windows.Forms.TextBox();
            this.server3TextBox = new System.Windows.Forms.TextBox();
            this.databaseNameLabel = new System.Windows.Forms.Label();
            this.serverName10Label = new System.Windows.Forms.Label();
            this.serverName9Label = new System.Windows.Forms.Label();
            this.server2TextBox = new System.Windows.Forms.TextBox();
            this.serverName8Label = new System.Windows.Forms.Label();
            this.serverName7Label = new System.Windows.Forms.Label();
            this.serverName6Label = new System.Windows.Forms.Label();
            this.serverName5Label = new System.Windows.Forms.Label();
            this.serverName4Label = new System.Windows.Forms.Label();
            this.serverName3Label = new System.Windows.Forms.Label();
            this.serverName2Label = new System.Windows.Forms.Label();
            this.server1TextBox = new System.Windows.Forms.TextBox();
            this.serverName1Label = new System.Windows.Forms.Label();
            this.serverCounter = new System.Windows.Forms.NumericUpDown();
            this.numOfServersLabel = new System.Windows.Forms.Label();
            this.settingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serverCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsPanel
            // 
            this.settingsPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.settingsPanel.Controls.Add(this.cancelSettingsButton);
            this.settingsPanel.Controls.Add(this.saveSettingsButton);
            this.settingsPanel.Controls.Add(this.databaseTextBox);
            this.settingsPanel.Controls.Add(this.server10TextBox);
            this.settingsPanel.Controls.Add(this.server9TextBox);
            this.settingsPanel.Controls.Add(this.server8TextBox);
            this.settingsPanel.Controls.Add(this.server7TextBox);
            this.settingsPanel.Controls.Add(this.server6TextBox);
            this.settingsPanel.Controls.Add(this.server5TextBox);
            this.settingsPanel.Controls.Add(this.server4TextBox);
            this.settingsPanel.Controls.Add(this.server3TextBox);
            this.settingsPanel.Controls.Add(this.databaseNameLabel);
            this.settingsPanel.Controls.Add(this.serverName10Label);
            this.settingsPanel.Controls.Add(this.serverName9Label);
            this.settingsPanel.Controls.Add(this.server2TextBox);
            this.settingsPanel.Controls.Add(this.serverName8Label);
            this.settingsPanel.Controls.Add(this.serverName7Label);
            this.settingsPanel.Controls.Add(this.serverName6Label);
            this.settingsPanel.Controls.Add(this.serverName5Label);
            this.settingsPanel.Controls.Add(this.serverName4Label);
            this.settingsPanel.Controls.Add(this.serverName3Label);
            this.settingsPanel.Controls.Add(this.serverName2Label);
            this.settingsPanel.Controls.Add(this.server1TextBox);
            this.settingsPanel.Controls.Add(this.serverName1Label);
            this.settingsPanel.Controls.Add(this.serverCounter);
            this.settingsPanel.Controls.Add(this.numOfServersLabel);
            this.settingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsPanel.Location = new System.Drawing.Point(0, 0);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(484, 462);
            this.settingsPanel.TabIndex = 0;
            // 
            // cancelSettingsButton
            // 
            this.cancelSettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelSettingsButton.Location = new System.Drawing.Point(14, 404);
            this.cancelSettingsButton.Name = "cancelSettingsButton";
            this.cancelSettingsButton.Size = new System.Drawing.Size(150, 46);
            this.cancelSettingsButton.TabIndex = 13;
            this.cancelSettingsButton.Text = "Cancel";
            this.cancelSettingsButton.UseVisualStyleBackColor = true;
            this.cancelSettingsButton.Click += new System.EventHandler(this.cancelSettingsButton_Click);
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSettingsButton.Location = new System.Drawing.Point(322, 404);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(150, 46);
            this.saveSettingsButton.TabIndex = 12;
            this.saveSettingsButton.Text = "Save";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // databaseTextBox
            // 
            this.databaseTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.databaseTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.databaseTextBox.Location = new System.Drawing.Point(164, 353);
            this.databaseTextBox.Name = "databaseTextBox";
            this.databaseTextBox.Size = new System.Drawing.Size(308, 23);
            this.databaseTextBox.TabIndex = 11;
            this.databaseTextBox.Text = "Enter Database Name";
            this.databaseTextBox.Enter += new System.EventHandler(this.databaseTextBox_Enter);
            this.databaseTextBox.Leave += new System.EventHandler(this.databaseTextBox_Leave);
            // 
            // server10TextBox
            // 
            this.server10TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.server10TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server10TextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.server10TextBox.Location = new System.Drawing.Point(337, 297);
            this.server10TextBox.Name = "server10TextBox";
            this.server10TextBox.Size = new System.Drawing.Size(135, 23);
            this.server10TextBox.TabIndex = 10;
            this.server10TextBox.Text = "Enter Server Name";
            this.server10TextBox.Visible = false;
            this.server10TextBox.Enter += new System.EventHandler(this.serverTextBox_Enter);
            this.server10TextBox.Leave += new System.EventHandler(this.serverTextBox_Leave);
            // 
            // server9TextBox
            // 
            this.server9TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.server9TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server9TextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.server9TextBox.Location = new System.Drawing.Point(104, 297);
            this.server9TextBox.Name = "server9TextBox";
            this.server9TextBox.Size = new System.Drawing.Size(135, 23);
            this.server9TextBox.TabIndex = 9;
            this.server9TextBox.Text = "Enter Server Name";
            this.server9TextBox.Visible = false;
            this.server9TextBox.Enter += new System.EventHandler(this.serverTextBox_Enter);
            this.server9TextBox.Leave += new System.EventHandler(this.serverTextBox_Leave);
            // 
            // server8TextBox
            // 
            this.server8TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.server8TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server8TextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.server8TextBox.Location = new System.Drawing.Point(337, 242);
            this.server8TextBox.Name = "server8TextBox";
            this.server8TextBox.Size = new System.Drawing.Size(135, 23);
            this.server8TextBox.TabIndex = 8;
            this.server8TextBox.Text = "Enter Server Name";
            this.server8TextBox.Visible = false;
            this.server8TextBox.Enter += new System.EventHandler(this.serverTextBox_Enter);
            this.server8TextBox.Leave += new System.EventHandler(this.serverTextBox_Leave);
            // 
            // server7TextBox
            // 
            this.server7TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.server7TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server7TextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.server7TextBox.Location = new System.Drawing.Point(105, 242);
            this.server7TextBox.Name = "server7TextBox";
            this.server7TextBox.Size = new System.Drawing.Size(135, 23);
            this.server7TextBox.TabIndex = 7;
            this.server7TextBox.Text = "Enter Server Name";
            this.server7TextBox.Visible = false;
            this.server7TextBox.Enter += new System.EventHandler(this.serverTextBox_Enter);
            this.server7TextBox.Leave += new System.EventHandler(this.serverTextBox_Leave);
            // 
            // server6TextBox
            // 
            this.server6TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.server6TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server6TextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.server6TextBox.Location = new System.Drawing.Point(337, 186);
            this.server6TextBox.Name = "server6TextBox";
            this.server6TextBox.Size = new System.Drawing.Size(135, 23);
            this.server6TextBox.TabIndex = 6;
            this.server6TextBox.Text = "Enter Server Name";
            this.server6TextBox.Visible = false;
            this.server6TextBox.Enter += new System.EventHandler(this.serverTextBox_Enter);
            this.server6TextBox.Leave += new System.EventHandler(this.serverTextBox_Leave);
            // 
            // server5TextBox
            // 
            this.server5TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.server5TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server5TextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.server5TextBox.Location = new System.Drawing.Point(105, 186);
            this.server5TextBox.Name = "server5TextBox";
            this.server5TextBox.Size = new System.Drawing.Size(135, 23);
            this.server5TextBox.TabIndex = 5;
            this.server5TextBox.Text = "Enter Server Name";
            this.server5TextBox.Visible = false;
            this.server5TextBox.Enter += new System.EventHandler(this.serverTextBox_Enter);
            this.server5TextBox.Leave += new System.EventHandler(this.serverTextBox_Leave);
            // 
            // server4TextBox
            // 
            this.server4TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.server4TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server4TextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.server4TextBox.Location = new System.Drawing.Point(337, 130);
            this.server4TextBox.Name = "server4TextBox";
            this.server4TextBox.Size = new System.Drawing.Size(135, 23);
            this.server4TextBox.TabIndex = 4;
            this.server4TextBox.Text = "Enter Server Name";
            this.server4TextBox.Visible = false;
            this.server4TextBox.Enter += new System.EventHandler(this.serverTextBox_Enter);
            this.server4TextBox.Leave += new System.EventHandler(this.serverTextBox_Leave);
            // 
            // server3TextBox
            // 
            this.server3TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.server3TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server3TextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.server3TextBox.Location = new System.Drawing.Point(104, 130);
            this.server3TextBox.Name = "server3TextBox";
            this.server3TextBox.Size = new System.Drawing.Size(135, 23);
            this.server3TextBox.TabIndex = 3;
            this.server3TextBox.Text = "Enter Server Name";
            this.server3TextBox.Visible = false;
            this.server3TextBox.Enter += new System.EventHandler(this.serverTextBox_Enter);
            this.server3TextBox.Leave += new System.EventHandler(this.serverTextBox_Leave);
            // 
            // databaseNameLabel
            // 
            this.databaseNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.databaseNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseNameLabel.Location = new System.Drawing.Point(9, 350);
            this.databaseNameLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.databaseNameLabel.Name = "databaseNameLabel";
            this.databaseNameLabel.Size = new System.Drawing.Size(151, 26);
            this.databaseNameLabel.TabIndex = 11;
            this.databaseNameLabel.Text = "Database Name:";
            this.databaseNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // serverName10Label
            // 
            this.serverName10Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serverName10Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverName10Label.Location = new System.Drawing.Point(243, 294);
            this.serverName10Label.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.serverName10Label.Name = "serverName10Label";
            this.serverName10Label.Size = new System.Drawing.Size(91, 26);
            this.serverName10Label.TabIndex = 10;
            this.serverName10Label.Text = "Server 10:";
            this.serverName10Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.serverName10Label.Visible = false;
            // 
            // serverName9Label
            // 
            this.serverName9Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serverName9Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverName9Label.Location = new System.Drawing.Point(9, 294);
            this.serverName9Label.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.serverName9Label.Name = "serverName9Label";
            this.serverName9Label.Size = new System.Drawing.Size(91, 26);
            this.serverName9Label.TabIndex = 9;
            this.serverName9Label.Text = "Server 9:";
            this.serverName9Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.serverName9Label.Visible = false;
            // 
            // server2TextBox
            // 
            this.server2TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server2TextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.server2TextBox.Location = new System.Drawing.Point(337, 74);
            this.server2TextBox.Name = "server2TextBox";
            this.server2TextBox.Size = new System.Drawing.Size(135, 23);
            this.server2TextBox.TabIndex = 2;
            this.server2TextBox.Text = "Enter Server Name";
            this.server2TextBox.Visible = false;
            this.server2TextBox.Enter += new System.EventHandler(this.serverTextBox_Enter);
            this.server2TextBox.Leave += new System.EventHandler(this.serverTextBox_Leave);
            // 
            // serverName8Label
            // 
            this.serverName8Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serverName8Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverName8Label.Location = new System.Drawing.Point(243, 239);
            this.serverName8Label.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.serverName8Label.Name = "serverName8Label";
            this.serverName8Label.Size = new System.Drawing.Size(91, 26);
            this.serverName8Label.TabIndex = 8;
            this.serverName8Label.Text = "Server 8:";
            this.serverName8Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.serverName8Label.Visible = false;
            // 
            // serverName7Label
            // 
            this.serverName7Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serverName7Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverName7Label.Location = new System.Drawing.Point(9, 239);
            this.serverName7Label.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.serverName7Label.Name = "serverName7Label";
            this.serverName7Label.Size = new System.Drawing.Size(91, 26);
            this.serverName7Label.TabIndex = 7;
            this.serverName7Label.Text = "Server 7:";
            this.serverName7Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.serverName7Label.Visible = false;
            // 
            // serverName6Label
            // 
            this.serverName6Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serverName6Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverName6Label.Location = new System.Drawing.Point(243, 183);
            this.serverName6Label.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.serverName6Label.Name = "serverName6Label";
            this.serverName6Label.Size = new System.Drawing.Size(91, 26);
            this.serverName6Label.TabIndex = 6;
            this.serverName6Label.Text = "Server 6:";
            this.serverName6Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.serverName6Label.Visible = false;
            // 
            // serverName5Label
            // 
            this.serverName5Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serverName5Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverName5Label.Location = new System.Drawing.Point(10, 183);
            this.serverName5Label.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.serverName5Label.Name = "serverName5Label";
            this.serverName5Label.Size = new System.Drawing.Size(91, 26);
            this.serverName5Label.TabIndex = 5;
            this.serverName5Label.Text = "Server 5:";
            this.serverName5Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.serverName5Label.Visible = false;
            // 
            // serverName4Label
            // 
            this.serverName4Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serverName4Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverName4Label.Location = new System.Drawing.Point(243, 127);
            this.serverName4Label.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.serverName4Label.Name = "serverName4Label";
            this.serverName4Label.Size = new System.Drawing.Size(91, 26);
            this.serverName4Label.TabIndex = 4;
            this.serverName4Label.Text = "Server 4:";
            this.serverName4Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.serverName4Label.Visible = false;
            // 
            // serverName3Label
            // 
            this.serverName3Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serverName3Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverName3Label.Location = new System.Drawing.Point(10, 127);
            this.serverName3Label.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.serverName3Label.Name = "serverName3Label";
            this.serverName3Label.Size = new System.Drawing.Size(91, 26);
            this.serverName3Label.TabIndex = 3;
            this.serverName3Label.Text = "Server 3:";
            this.serverName3Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.serverName3Label.Visible = false;
            // 
            // serverName2Label
            // 
            this.serverName2Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serverName2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverName2Label.Location = new System.Drawing.Point(243, 71);
            this.serverName2Label.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.serverName2Label.Name = "serverName2Label";
            this.serverName2Label.Size = new System.Drawing.Size(91, 26);
            this.serverName2Label.TabIndex = 2;
            this.serverName2Label.Text = "Server 2:";
            this.serverName2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.serverName2Label.Visible = false;
            // 
            // server1TextBox
            // 
            this.server1TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.server1TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server1TextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.server1TextBox.Location = new System.Drawing.Point(103, 74);
            this.server1TextBox.Name = "server1TextBox";
            this.server1TextBox.Size = new System.Drawing.Size(135, 23);
            this.server1TextBox.TabIndex = 1;
            this.server1TextBox.Text = "Enter Server Name";
            this.server1TextBox.Enter += new System.EventHandler(this.serverTextBox_Enter);
            this.server1TextBox.Leave += new System.EventHandler(this.serverTextBox_Leave);
            // 
            // serverName1Label
            // 
            this.serverName1Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serverName1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverName1Label.Location = new System.Drawing.Point(9, 71);
            this.serverName1Label.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.serverName1Label.Name = "serverName1Label";
            this.serverName1Label.Size = new System.Drawing.Size(91, 26);
            this.serverName1Label.TabIndex = 1;
            this.serverName1Label.Text = "Server 1:";
            this.serverName1Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // serverCounter
            // 
            this.serverCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverCounter.Location = new System.Drawing.Point(418, 13);
            this.serverCounter.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.serverCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.serverCounter.Name = "serverCounter";
            this.serverCounter.Size = new System.Drawing.Size(54, 26);
            this.serverCounter.TabIndex = 0;
            this.serverCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.serverCounter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.serverCounter.ValueChanged += new System.EventHandler(this.serverCounter_ValueChanged);
            // 
            // numOfServersLabel
            // 
            this.numOfServersLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numOfServersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOfServersLabel.Location = new System.Drawing.Point(9, 13);
            this.numOfServersLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.numOfServersLabel.Name = "numOfServersLabel";
            this.numOfServersLabel.Size = new System.Drawing.Size(406, 26);
            this.numOfServersLabel.TabIndex = 0;
            this.numOfServersLabel.Text = "Enter Number of Servers (10 max) :";
            this.numOfServersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.settingsPanel);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serverCounter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.Label numOfServersLabel;
        private System.Windows.Forms.NumericUpDown serverCounter;
        private System.Windows.Forms.TextBox server1TextBox;
        private System.Windows.Forms.Label serverName1Label;
        private System.Windows.Forms.Label serverName2Label;
        private System.Windows.Forms.Label serverName8Label;
        private System.Windows.Forms.Label serverName7Label;
        private System.Windows.Forms.Label serverName6Label;
        private System.Windows.Forms.Label serverName5Label;
        private System.Windows.Forms.Label serverName4Label;
        private System.Windows.Forms.Label serverName3Label;
        private System.Windows.Forms.TextBox server2TextBox;
        private System.Windows.Forms.Label databaseNameLabel;
        private System.Windows.Forms.Label serverName10Label;
        private System.Windows.Forms.Label serverName9Label;
        private System.Windows.Forms.TextBox databaseTextBox;
        private System.Windows.Forms.TextBox server10TextBox;
        private System.Windows.Forms.TextBox server9TextBox;
        private System.Windows.Forms.TextBox server8TextBox;
        private System.Windows.Forms.TextBox server7TextBox;
        private System.Windows.Forms.TextBox server6TextBox;
        private System.Windows.Forms.TextBox server5TextBox;
        private System.Windows.Forms.TextBox server4TextBox;
        private System.Windows.Forms.TextBox server3TextBox;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.Button cancelSettingsButton;

    }
}
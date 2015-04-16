namespace ReportAppTest
{
    partial class ReportForm
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.homeTabPage = new System.Windows.Forms.TabPage();
            this.homePanel = new System.Windows.Forms.Panel();
            this.confirmButton = new System.Windows.Forms.Button();
            this.enterPasswordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.reportManagerLabel = new System.Windows.Forms.Label();
            this.enterUserIDLabel = new System.Windows.Forms.Label();
            this.userIDTextBox = new System.Windows.Forms.TextBox();
            this.selectReportTabPage = new System.Windows.Forms.TabPage();
            this.selectReportTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.reportLabel = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.reportListBox = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureServersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configTabPage = new System.Windows.Forms.TabPage();
            this.configExceptionPanel = new System.Windows.Forms.Panel();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.homeTabPage.SuspendLayout();
            this.homePanel.SuspendLayout();
            this.selectReportTabPage.SuspendLayout();
            this.selectReportTableLayoutPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.configTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tabControl1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(784, 533);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(784, 562);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.homeTabPage);
            this.tabControl1.Controls.Add(this.selectReportTabPage);
            this.tabControl1.Controls.Add(this.configTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 533);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // homeTabPage
            // 
            this.homeTabPage.Controls.Add(this.homePanel);
            this.homeTabPage.Location = new System.Drawing.Point(4, 5);
            this.homeTabPage.Name = "homeTabPage";
            this.homeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.homeTabPage.Size = new System.Drawing.Size(776, 524);
            this.homeTabPage.TabIndex = 0;
            this.homeTabPage.Text = "tabPage1";
            this.homeTabPage.UseVisualStyleBackColor = true;
            // 
            // homePanel
            // 
            this.homePanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.homePanel.Controls.Add(this.confirmButton);
            this.homePanel.Controls.Add(this.enterPasswordLabel);
            this.homePanel.Controls.Add(this.passwordTextBox);
            this.homePanel.Controls.Add(this.reportManagerLabel);
            this.homePanel.Controls.Add(this.enterUserIDLabel);
            this.homePanel.Controls.Add(this.userIDTextBox);
            this.homePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homePanel.Location = new System.Drawing.Point(3, 3);
            this.homePanel.Name = "homePanel";
            this.homePanel.Size = new System.Drawing.Size(770, 518);
            this.homePanel.TabIndex = 1;
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.confirmButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.confirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.Location = new System.Drawing.Point(608, 460);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(150, 46);
            this.confirmButton.TabIndex = 8;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // enterPasswordLabel
            // 
            this.enterPasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.enterPasswordLabel.AutoSize = true;
            this.enterPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterPasswordLabel.Location = new System.Drawing.Point(305, 276);
            this.enterPasswordLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.enterPasswordLabel.Name = "enterPasswordLabel";
            this.enterPasswordLabel.Size = new System.Drawing.Size(180, 26);
            this.enterPasswordLabel.TabIndex = 5;
            this.enterPasswordLabel.Text = "Enter Password";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.Location = new System.Drawing.Point(310, 325);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(167, 32);
            this.passwordTextBox.TabIndex = 7;
            // 
            // reportManagerLabel
            // 
            this.reportManagerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.reportManagerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportManagerLabel.Location = new System.Drawing.Point(254, 43);
            this.reportManagerLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 75);
            this.reportManagerLabel.Name = "reportManagerLabel";
            this.reportManagerLabel.Size = new System.Drawing.Size(262, 37);
            this.reportManagerLabel.TabIndex = 3;
            this.reportManagerLabel.Text = "Report Manager";
            this.reportManagerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // enterUserIDLabel
            // 
            this.enterUserIDLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.enterUserIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterUserIDLabel.Location = new System.Drawing.Point(305, 155);
            this.enterUserIDLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.enterUserIDLabel.Name = "enterUserIDLabel";
            this.enterUserIDLabel.Size = new System.Drawing.Size(160, 26);
            this.enterUserIDLabel.TabIndex = 4;
            this.enterUserIDLabel.Text = "Enter User ID";
            this.enterUserIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userIDTextBox
            // 
            this.userIDTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.userIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userIDTextBox.Location = new System.Drawing.Point(310, 204);
            this.userIDTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 40);
            this.userIDTextBox.Name = "userIDTextBox";
            this.userIDTextBox.Size = new System.Drawing.Size(167, 32);
            this.userIDTextBox.TabIndex = 6;
            // 
            // selectReportTabPage
            // 
            this.selectReportTabPage.Controls.Add(this.selectReportTableLayoutPanel);
            this.selectReportTabPage.Location = new System.Drawing.Point(4, 5);
            this.selectReportTabPage.Name = "selectReportTabPage";
            this.selectReportTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.selectReportTabPage.Size = new System.Drawing.Size(776, 524);
            this.selectReportTabPage.TabIndex = 1;
            this.selectReportTabPage.Text = "tabPage2";
            this.selectReportTabPage.UseVisualStyleBackColor = true;
            // 
            // selectReportTableLayoutPanel
            // 
            this.selectReportTableLayoutPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.selectReportTableLayoutPanel.ColumnCount = 2;
            this.selectReportTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.selectReportTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.selectReportTableLayoutPanel.Controls.Add(this.reportLabel, 0, 0);
            this.selectReportTableLayoutPanel.Controls.Add(this.nextButton, 1, 2);
            this.selectReportTableLayoutPanel.Controls.Add(this.reportListBox, 0, 1);
            this.selectReportTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectReportTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.selectReportTableLayoutPanel.Name = "selectReportTableLayoutPanel";
            this.selectReportTableLayoutPanel.RowCount = 3;
            this.selectReportTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.51064F));
            this.selectReportTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.48936F));
            this.selectReportTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.selectReportTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.selectReportTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.selectReportTableLayoutPanel.Size = new System.Drawing.Size(770, 518);
            this.selectReportTableLayoutPanel.TabIndex = 0;
            // 
            // reportLabel
            // 
            this.reportLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.reportLabel.AutoSize = true;
            this.selectReportTableLayoutPanel.SetColumnSpan(this.reportLabel, 2);
            this.reportLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportLabel.Location = new System.Drawing.Point(187, 23);
            this.reportLabel.Name = "reportLabel";
            this.reportLabel.Size = new System.Drawing.Size(395, 37);
            this.reportLabel.TabIndex = 2;
            this.reportLabel.Text = "Select a Report to Begin:";
            // 
            // nextButton
            // 
            this.nextButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nextButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.nextButton.Location = new System.Drawing.Point(617, 460);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(150, 46);
            this.nextButton.TabIndex = 5;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            // 
            // reportListBox
            // 
            this.reportListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.reportListBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.selectReportTableLayoutPanel.SetColumnSpan(this.reportListBox, 2);
            this.reportListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportListBox.FormattingEnabled = true;
            this.reportListBox.ItemHeight = 25;
            this.reportListBox.Items.AddRange(new object[] {
            "Device Activity Report",
            "Exception Report"});
            this.reportListBox.Location = new System.Drawing.Point(195, 126);
            this.reportListBox.Name = "reportListBox";
            this.reportListBox.Size = new System.Drawing.Size(380, 279);
            this.reportListBox.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 25);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(104, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureServersToolStripMenuItem});
            this.settingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(78, 25);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // configureServersToolStripMenuItem
            // 
            this.configureServersToolStripMenuItem.Name = "configureServersToolStripMenuItem";
            this.configureServersToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.configureServersToolStripMenuItem.Text = "Configure Servers";
            this.configureServersToolStripMenuItem.Click += new System.EventHandler(this.configureServersToolStripMenuItem_Click);
            // 
            // configTabPage
            // 
            this.configTabPage.Controls.Add(this.configExceptionPanel);
            this.configTabPage.Location = new System.Drawing.Point(4, 5);
            this.configTabPage.Name = "configTabPage";
            this.configTabPage.Size = new System.Drawing.Size(776, 524);
            this.configTabPage.TabIndex = 2;
            this.configTabPage.Text = "tabPage1";
            this.configTabPage.UseVisualStyleBackColor = true;
            // 
            // configExceptionPanel
            // 
            this.configExceptionPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.configExceptionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configExceptionPanel.Location = new System.Drawing.Point(0, 0);
            this.configExceptionPanel.Name = "configExceptionPanel";
            this.configExceptionPanel.Size = new System.Drawing.Size(776, 524);
            this.configExceptionPanel.TabIndex = 2;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.homeTabPage.ResumeLayout(false);
            this.homePanel.ResumeLayout(false);
            this.homePanel.PerformLayout();
            this.selectReportTabPage.ResumeLayout(false);
            this.selectReportTableLayoutPanel.ResumeLayout(false);
            this.selectReportTableLayoutPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.configTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureServersToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage homeTabPage;
        private System.Windows.Forms.TabPage selectReportTabPage;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label enterUserIDLabel;
        private System.Windows.Forms.Label reportManagerLabel;
        private System.Windows.Forms.Label enterPasswordLabel;
        private System.Windows.Forms.TextBox userIDTextBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Panel homePanel;
        private System.Windows.Forms.TableLayoutPanel selectReportTableLayoutPanel;
        private System.Windows.Forms.Label reportLabel;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.ListBox reportListBox;
        private System.Windows.Forms.TabPage configTabPage;
        private System.Windows.Forms.Panel configExceptionPanel;
    }
}


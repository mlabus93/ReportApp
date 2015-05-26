namespace ReportAppTest
{
    partial class ReportViewerForm
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
            this.reportViewerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewerTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewerTableLayoutPanel
            // 
            this.reportViewerTableLayoutPanel.ColumnCount = 2;
            this.reportViewerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.reportViewerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.reportViewerTableLayoutPanel.Controls.Add(this.reportViewer2, 1, 0);
            this.reportViewerTableLayoutPanel.Controls.Add(this.reportViewer1, 0, 0);
            this.reportViewerTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.reportViewerTableLayoutPanel.Name = "reportViewerTableLayoutPanel";
            this.reportViewerTableLayoutPanel.RowCount = 2;
            this.reportViewerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.reportViewerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.reportViewerTableLayoutPanel.Size = new System.Drawing.Size(984, 580);
            this.reportViewerTableLayoutPanel.TabIndex = 0;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer2.Location = new System.Drawing.Point(495, 3);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.reportViewerTableLayoutPanel.SetRowSpan(this.reportViewer2, 2);
            this.reportViewer2.ServerReport.ReportPath = "/R5Reports/Unit Activity Report";
            this.reportViewer2.ServerReport.ReportServerUrl = new System.Uri("http://REPORT:80/reportserver", System.UriKind.Absolute);
            this.reportViewer2.Size = new System.Drawing.Size(486, 574);
            this.reportViewer2.TabIndex = 1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.reportViewerTableLayoutPanel.SetRowSpan(this.reportViewer1, 2);
            this.reportViewer1.ServerReport.ReportPath = "/R5Reports/Unit Activity Report";
            this.reportViewer1.ServerReport.ReportServerUrl = new System.Uri("http://REPORT2:80/reportserver", System.UriKind.Absolute);
            this.reportViewer1.Size = new System.Drawing.Size(486, 574);
            this.reportViewer1.TabIndex = 0;
            // 
            // ReportViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 580);
            this.Controls.Add(this.reportViewerTableLayoutPanel);
            this.Name = "ReportViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportViewerForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportViewerForm_Load);
            this.reportViewerTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel reportViewerTableLayoutPanel;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
    }
}
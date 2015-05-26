using Microsoft.Reporting.WinForms;
using ReportAppTest.Reports;
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
    public partial class ReportViewerForm : Form
    {
        public ReportViewerForm()
        {
            InitializeComponent();
        }

        private void ReportViewerForm_Load(object sender, EventArgs e)
        {
            this.reportViewer1.ServerReport.ReportServerUrl = new System.Uri(Properties.Settings.Default.URI);
            ReportParameter param = new ReportParameter("Locations", UnitActivityReport.locations[0, 0]);
            var startDate = new ReportParameter("StartDate", UnitActivityReport.startDate.ToString("MM/dd/yyyy"));
            var endDate = new ReportParameter("EndDate", UnitActivityReport.endDate.ToString("MM/dd/yyyy"));
            this.reportViewer1.ServerReport.SetParameters(param);
            this.reportViewer1.ServerReport.SetParameters(startDate);
            this.reportViewer1.ServerReport.SetParameters(endDate);
            string val = null;
            this.reportViewer1.ServerReport.SetParameters(new ReportParameter("CallTypeIds", val));
            string value = "true";
            this.reportViewer1.ServerReport.SetParameters(new ReportParameter("ShowBlankRecords", value));
            this.reportViewer1.ServerReport.SetParameters(new ReportParameter("PrintedBy", Properties.Settings.Default.Servers[0]));

            this.reportViewer2.ServerReport.ReportServerUrl = new System.Uri("http://" + Properties.Settings.Default.Servers[0] + ":80/reportserver");
            ReportParameter param2 = new ReportParameter("Locations", UnitActivityReport.locations[0, 0]);
            var startDate2 = new ReportParameter("StartDate", UnitActivityReport.startDate.ToString("MM/dd/yyyy"));
            var endDate2 = new ReportParameter("EndDate", UnitActivityReport.endDate.ToString("MM/dd/yyyy"));
            this.reportViewer2.ServerReport.SetParameters(param);
            this.reportViewer2.ServerReport.SetParameters(startDate);
            this.reportViewer2.ServerReport.SetParameters(endDate);
            string val2 = null;
            this.reportViewer2.ServerReport.SetParameters(new ReportParameter("CallTypeIds", val2));
            string value2 = "true";
            this.reportViewer2.ServerReport.SetParameters(new ReportParameter("ShowBlankRecords", value2));
            this.reportViewer2.ServerReport.SetParameters(new ReportParameter("PrintedBy", Properties.Settings.Default.Servers[1]));

            this.reportViewer1.ShowParameterPrompts = true;
            this.reportViewer2.ShowParameterPrompts = true;
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
        }
    }
}

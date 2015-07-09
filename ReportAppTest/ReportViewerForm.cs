using Microsoft.Reporting.WinForms;
using ReportAppTest.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Web.Services.Protocols;
using System.IO;
using System.Diagnostics;
using System.Security.Principal;
using ReportAppTest;

namespace ReportAppTest
{

    public partial class ReportViewerForm : Form
    {
        const int SERVER_COUNT = 15;

        UnitActivityReport[] uaReport = new UnitActivityReport[SERVER_COUNT];
        List<UnitActivityReport> reportsList = new List<Reports.UnitActivityReport>();
        UnitActivityReport currentReport;

        public ReportViewerForm(UnitActivityReport report)
        {
            InitializeComponent();
            currentReport = report;
        }

        private void ReportViewerForm_Load(object sender, EventArgs e)
        {
            RunReport(currentReport);
        }

        // Set parameters for new Unit Activity ReportViewer
        private void RunReport(UnitActivityReport report)
        {
            
            this.reportViewer1.ServerReport.ReportServerUrl = new System.Uri("http://" + report.serverName + ":80/reportserver");
            ReportParameter param = new ReportParameter("Locations", report.locationString);
            var startDate = new ReportParameter("StartDate", report.startDate.ToString("MM/dd/yyyy"));
            var endDate = new ReportParameter("EndDate", report.endDate.ToString("MM/dd/yyyy"));
            this.reportViewer1.ServerReport.SetParameters(param);
            this.reportViewer1.ServerReport.SetParameters(startDate);
            this.reportViewer1.ServerReport.SetParameters(endDate);
            string nullVal = null;
            this.reportViewer1.ServerReport.SetParameters(new ReportParameter("CallTypeIds", nullVal));
            string trueValue = "true";
            this.reportViewer1.ServerReport.SetParameters(new ReportParameter("ShowBlankRecords", trueValue));
            this.reportViewer1.ServerReport.SetParameters(new ReportParameter("PrintedBy", report.serverName));
            this.reportViewer1.ShowParameterPrompts = true;
            this.reportViewer1.RefreshReport();
            
        }

    }
}

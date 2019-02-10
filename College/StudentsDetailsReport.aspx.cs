
using College.App_Code;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace College
{
    public partial class StudentsDetails : System.Web.UI.Page
    {
        ReportDocument _reportDocument = new ReportDocument();

        protected void Page_Init(object sender, EventArgs e)
        {
            StudentDAL studentDAL = new StudentDAL();
            StudentDS studentDS = new StudentDS();

            studentDS.Clear();
            studentDS = studentDAL.GetStudents();

            _reportDocument.Load(Server.MapPath("~/studentDetails.rpt"));
            _reportDocument.SetDataSource(studentDS);

            int totalStudents = studentDS.Tables["Student"].Rows.Count;
            TextObject totalStd;

            if (_reportDocument.ReportDefinition.ReportObjects["totalStd"] != null)
            {
                totalStd = (TextObject)_reportDocument.ReportDefinition.ReportObjects["totalStd"];
                totalStd.Text = totalStudents.ToString();
            }

            int exportFormatFlags = (int)(CrystalDecisions.Shared.ViewerExportFormats.PdfFormat);

            rptStudentList.AllowedExportFormats = exportFormatFlags;
            rptStudentList.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
            rptStudentList.HasToggleGroupTreeButton = false;
            rptStudentList.HasToggleParameterPanelButton = false;
            rptStudentList.DisplayGroupTree = false;
            rptStudentList.EnableDrillDown = false;
            rptStudentList.HasDrilldownTabs = false;
            rptStudentList.HasCrystalLogo = false;
            rptStudentList.ReportSource = _reportDocument;
        }//end function
        protected void Page_Load(object sender, EventArgs e)
        {

        }//end page load
        protected void Page_Unload(object sender, EventArgs e)
        {
            CloseReports(_reportDocument);
            _reportDocument.Close();
            _reportDocument.Dispose();
            rptStudentList.Dispose();
            _reportDocument = null;
            rptStudentList = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }//end page load
        private void CloseReports(ReportDocument reportDocument)
        {
            Sections sections = reportDocument.ReportDefinition.Sections;
            foreach (Section section in sections)
            {
                ReportObjects reportObjects = section.ReportObjects;
                foreach (ReportObject reportObject in reportObjects)
                {
                    if (reportObject.Kind == ReportObjectKind.SubreportObject)
                    {
                        SubreportObject subreportObject = (SubreportObject)reportObject;
                        ReportDocument subReportDocument = subreportObject.OpenSubreport(subreportObject.SubreportName);
                        subReportDocument.Close();
                    }
                }
            }
            reportDocument.Close();
        }
    }
}
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentsDetailsReport.aspx.cs" Inherits="College.StudentsDetails" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Students List</title>
     <script src='<%=ResolveUrl("~/crystalreportviewers13/js/crviewer/crv.js")%>' type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="rptStudentList" runat="server" AutoDataBind="true" />
    </div>
    </form>
</body>
</html>

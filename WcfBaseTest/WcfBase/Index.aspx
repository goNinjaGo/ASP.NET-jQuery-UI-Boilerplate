<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WcfBase.Index" %>

<%@ Register Src="~/UserControls/DataGrid.ascx" TagPrefix="uc1" TagName="DataGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            openNotification("Oh Hi!", "NOTIFICATION!");
            createNewModal($('#modalForm').clone().show());
        });

    </script>

    <div>Hello World!</div>

    <uc1:DataGrid runat="server" ID="DataGrid" ColHeaders="true" ColumnSorting="true" Height="200" />

    <div id="modalForm" style="display:none;">
        <input type="text" id="txt1" /><br />
        <input type="text" id="txt2" /><br />
        <input type="text" id="txt3" />

    </div>
</asp:Content>

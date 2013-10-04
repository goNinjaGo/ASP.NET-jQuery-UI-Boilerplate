<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="TEst1.aspx.cs" Inherits="WcfBase.TEst1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            $.ajax({
                data: { testString: "howdy" },
                url: "MainService.svc/TestFunction",
                success: function(data) {
                    var x = 0;
                },
                error: function(a,b,c) {
                    var y = 0;
                }
            });
        });


    </script>
</asp:Content>

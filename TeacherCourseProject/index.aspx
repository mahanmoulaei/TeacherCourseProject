<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TeacherCourseProject.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SMTI ONLINE Teacher-Course Assignment</title>
    
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">

    <style type="text/css">
        .auto-style1 {
        text-decoration: underline;
        text-align: center;
        }
        .auto-style4 {
        width: 258px;
        }
        .auto-style6 {
        width: 99px;
        }
        .auto-style7 {
        height: 23px;
        width: 99px;
        }
        .auto-style5 {
        height: 23px;
        }
        .auto-style8 {
        width: 99px;
        height: 26px;
        }
        .auto-style9 {
        height: 26px;
        }
        .auto-style10 {
        width: 600px;
        }
        .auto-style11 {
        text-align: center;
        }
    </style>
</head>
<body>
    <h1 class="auto-style1">SMTI ONLINE Teacher-Course Assignment</h1>
    <form id="form1" runat="server">
        <div class="alert alert-danger">
            <table align="center" class="auto-style10">
                <tr>

                    <td colspan="2">
                        <table class="auto-style4" align="center">
                            <tr>
                                <td class="auto-style8">
                                    <asp:Label ID="labelSearchBy" runat="server" Text="Search By: "></asp:Label>
                                </td>

                                <td>
                                    <asp:RadioButtonList ID="radioButtonSearchBy" runat="server" OnSelectedIndexChanged="radioButtonSearchBy_SelectedIndexChanged" AutoPostBack="true"></asp:RadioButtonList>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="3">
                                    <asp:TextBox ID="textSearchField" runat="server" ReadOnly="false" Width="300px"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td align="center">
                                    <asp:Button ID="buttonSearch" runat="server" Text="Search" OnClick="buttonSearch_onClick" CssClass="btn btn-success"/>
                                </td>

                                <td align="center">
                                    <asp:Button ID="buttonShowAll" runat="server" Text="Show All Teachers" OnClick="buttonShowAll_onClick" CssClass="btn btn-success"/>
                                </td>
                            </tr>
                        </table>
                    </td>

                    
                </tr>

                <tr>
                    <td colspan="3" class="auto-style1">
                        <asp:GridView ID="gridResult" runat="server" BackColor="White" BorderColor="YellowGreen" BorderStyle="None" BorderWidth="1px" CellPadding="5" GridLines="Vertical">
                            <AlternatingRowStyle BackColor="#2D9AB2"/>
                            <FooterStyle BackColor="#D82BDE" ForeColor="Black"/>
                            <HeaderStyle BackColor="#1EDE4C" ForeColor="White" Font-Bold="true"/>
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center"/>
                            <SelectedRowStyle BackColor="#FF5733" ForeColor="White" Font-Bold="true" />
                            <SortedAscendingCellStyle BackColor="#DAF7A6" />
                            <SortedAscendingHeaderStyle BackColor="Yellow" />
                            <SortedDescendingCellStyle BackColor="#3160CC" />
                            <SortedDescendingHeaderStyle BackColor="#17F9F2" />
                        </asp:GridView>
                    </td>     

                </tr>    
            </table>
        </div>

        <br />
        <br />
        <br />
        <br />

        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>

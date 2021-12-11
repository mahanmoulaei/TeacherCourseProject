<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TeacherCourseProject.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">

    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
            text-align: center;
        }

        body {
            background-color: #9cffe1;
        }

        
        .button {
            border-radius: 10px;
            font-size: 20px;
            padding: 10px 20px 10px 20px;
        }

    </style>

    <title>SMTI ONLINE Teacher-Course Assignment</title>

</head>
<body class="body">
    <h1 class="auto-style1">SMTI ONLINE Teacher-Course Assignment</h1>
    <form runat="server">
        <div style="margin: 150px 70px 150px 70px;text-align: center;">
            <table align="center" style="width:300px;text-align:left">
                <tr>
                    <td>
                        <asp:Label ID="labelUsername" runat="server" Text="Username:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="textBoxUsername" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="labelPassword" runat="server" Text="Password:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="textBoxPassword" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <br />
            <br />
                
            <asp:Button ID="button1" runat="server" Text="Login" CssClass="button btn btn-success" BorderStyle="Double" OnClick="buttonLogin_onClick" Width="225px"/>

        </div>
    </form>
</body>
</html>

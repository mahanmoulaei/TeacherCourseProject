using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeacherCourseProject
{
    public partial class login : System.Web.UI.Page
    {
        static OleDbConnection myConnection;    //CONNECT
        OleDbCommand myCommand;                 //QUERIES
        OleDbDataReader myDataReader;           //READ/EXECUTE

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                myConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/DataBase.mdb;Persist Security Info=True"));
                myConnection.Open();
            }
        }

        protected void buttonLogin_onClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxUsername.Text))
            {
                if (!String.IsNullOrEmpty(textBoxPassword.Text))
                {
                    myCommand = new OleDbCommand("SELECT [Username], Password from Users WHERE Username=@username AND Password=@password", myConnection);
                    myCommand.Parameters.AddWithValue("username", textBoxUsername.Text);
                    myCommand.Parameters.AddWithValue("password", textBoxPassword.Text);

                    myDataReader = myCommand.ExecuteReader();

                    if (myDataReader.HasRows)
                    {
                        myDataReader.Close();

                        myCommand = new OleDbCommand("SELECT * FROM Employees WHERE EmployeeId=@user AND JobTitle=@jobTitle", myConnection);
                        myCommand.Parameters.AddWithValue("username", textBoxUsername.Text);
                        myCommand.Parameters.AddWithValue("jobTitle", "Coordinator");

                        myDataReader = myCommand.ExecuteReader();
                        if (myDataReader.HasRows)
                        {
                            Response.Redirect("index.aspx");
                            myDataReader.Close();
                        }
                        else
                        {
                            Response.Write("<script>alert(\"You Cannot Enter! You Are Not A Coordinator!!!\");</script>");
                            myDataReader.Close();
                        }

                    }
                    else
                    {
                        Response.Write("<script>alert(\"Incorrect Username or Password\");</script>");
                        myDataReader.Close();
                    }
                }
                else
                {
                    Response.Write("<script>alert(\"Password Text Box Cannot Be Empty!\");</script>");
                }
            } else
            {
                Response.Write("<script>alert(\"Username Text Box Cannot Be Empty!\");</script>");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeacherCourseProject
{
    public partial class index : System.Web.UI.Page
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

                radioButtonSearchBy.Items.Add(new ListItem("Employee ID", "id"));
                radioButtonSearchBy.Items.Add(new ListItem("First Name", "firstName"));
                radioButtonSearchBy.Items.Add(new ListItem("Last Name", "lastName"));
                radioButtonSearchBy.SelectedIndex = 0;


                myCommand = new OleDbCommand("SELECT [EmployeeId] as [Employee ID], [FirstName] as [First Name], [LastName] as [Last Name], [Email] FROM Employees WHERE [JobTitle] = @jobTitle ORDER BY [EmployeeId]", myConnection);
                myCommand.Parameters.AddWithValue("jobTitle", "Teacher");
                myDataReader = myCommand.ExecuteReader();
                gridViewTeachers.DataSource = myDataReader;
                gridViewTeachers.DataBind();
                myDataReader.Close();


                myCommand = new OleDbCommand("SELECT * FROM Courses ORDER BY [CourseCode]", myConnection);
                myDataReader = myCommand.ExecuteReader();
                while (myDataReader.Read())
                {
                    ListItem listItem = new ListItem(myDataReader["CourseCode"] + " - " + myDataReader["CourseTitle"] + " - " + myDataReader["Duration"] + "hr", myDataReader["CourseCode"].ToString());
                    dropdownCourseCode.Items.Add(listItem);
                }
                dropdownCourseCode.SelectedIndex = 0;
                myDataReader.Close();


                myCommand = new OleDbCommand("SELECT * FROM Groups ORDER BY [GroupNumber]", myConnection);
                myDataReader = myCommand.ExecuteReader();
                while (myDataReader.Read())
                {
                    ListItem listItem = new ListItem(myDataReader["GroupNumber"] + " - " + myDataReader["GroupName"], myDataReader["GroupNumber"].ToString());
                    dropdownGroupNumber.Items.Add(listItem);
                }
                dropdownGroupNumber.SelectedIndex = 0;
                myDataReader.Close();

                buttonDelete.Enabled = false;

            }
        }

        protected void radioButtonSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void buttonSearch_onClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxSearchField.Text))
            {
                String searchBy = radioButtonSearchBy.SelectedItem.Value;
                switch (searchBy)
                {
                    case "id":
                        myCommand = new OleDbCommand("SELECT [EmployeeId] as [Employee ID], [FirstName] as [First Name], [LastName] as [Last Name], [Email] FROM Employees WHERE [EmployeeId] = @employeeId ORDER BY [EmployeeId]", myConnection);
                        myCommand.Parameters.AddWithValue("employeeId", textBoxSearchField.Text);
                        myDataReader = myCommand.ExecuteReader();
                        gridViewTeachers.DataSource = myDataReader;
                        gridViewTeachers.DataBind();
                        myDataReader.Close();
                        break;
                    case "firstName":
                        myCommand = new OleDbCommand("SELECT [EmployeeId] as [Employee ID], [FirstName] as [First Name], [LastName] as [Last Name], [Email] FROM Employees WHERE [FirstName] = @firstName ORDER BY [EmployeeId]", myConnection);
                        myCommand.Parameters.AddWithValue("firstName", textBoxSearchField.Text);
                        myDataReader = myCommand.ExecuteReader();
                        gridViewTeachers.DataSource = myDataReader;
                        gridViewTeachers.DataBind();
                        myDataReader.Close();
                        break;
                    case "lastName":
                        myCommand = new OleDbCommand("SELECT [EmployeeId] as [Employee ID], [FirstName] as [First Name], [LastName] as [Last Name], [Email] FROM Employees WHERE [LastName] = @lastName ORDER BY [EmployeeId]", myConnection);
                        myCommand.Parameters.AddWithValue("lastName", textBoxSearchField.Text);
                        myDataReader = myCommand.ExecuteReader();
                        gridViewTeachers.DataSource = myDataReader;
                        gridViewTeachers.DataBind();
                        myDataReader.Close();
                        break;
                    case null:
                        break;
                }
            } else
            {
                Response.Write("<script>alert(\"Search Text Box Cannot Be Empty!!\");</script>");
            }
            gridViewTeachers.SelectedIndex = -1;
        }

        protected void buttonShowAll_onClick(object sender, EventArgs e)
        {
            myCommand = new OleDbCommand("SELECT [EmployeeId] as [Employee ID], [FirstName] as [First Name], [LastName] as [Last Name], [Email] FROM Employees WHERE [JobTitle] = @jobTitle ORDER BY [EmployeeId]", myConnection);
            myCommand.Parameters.AddWithValue("jobTitle", "Teacher");
            myDataReader = myCommand.ExecuteReader();
            gridViewTeachers.DataSource = myDataReader;
            gridViewTeachers.DataBind();
            myDataReader.Close();

            radioButtonSearchBy.SelectedIndex = 0;
            textBoxSearchField.Text = null;
            gridViewTeachers.SelectedIndex = -1;
        }

        protected void gridViewTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCommand = new OleDbCommand("SELECT * FROM CourseAssignments WHERE [EmployeeId] = @employeeId ORDER BY [CourseCode]", myConnection);
            myCommand.Parameters.AddWithValue("employeeId", gridViewTeachers.SelectedRow.Cells[1].Text);
            myDataReader = myCommand.ExecuteReader();
            gridViewCourseAssignments.DataSource = myDataReader;
            gridViewCourseAssignments.DataBind();
            myDataReader.Close();

            textBoxEmployeeID.Text = gridViewTeachers.SelectedRow.Cells[1].Text;
        }

        protected void dropdownCourseCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dropdownGroupNumber_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void buttonClear_onClick(object sender, EventArgs e)
        {
            textBoxEmployeeID.Text = null;
            gridViewCourseAssignments.SelectedIndex = -1;
            textBoxEmployeeID.ReadOnly = false;
            dropdownCourseCode.Enabled = true;
            dropdownGroupNumber.Enabled = true;
            buttonAssignCourse.Enabled = true;
            buttonDelete.Enabled = false;
            gridViewCourseAssignments.DataSource = null;
            gridViewCourseAssignments.DataBind();
        }

        protected void buttonDelete_onClick(object sender, EventArgs e)
        {
            myCommand = new OleDbCommand("DELETE FROM CourseAssignments WHERE [EmployeeId] = @employeeId AND [CourseCode] = @courseCode AND [GroupNumber] = @groupNumber", myConnection);
            myCommand.Parameters.AddWithValue("employeeId", textBoxEmployeeID.Text.ToString());
            myCommand.Parameters.AddWithValue("courseCode", dropdownCourseCode.SelectedValue.ToString());
            myCommand.Parameters.AddWithValue("groupNumber", dropdownGroupNumber.SelectedValue.ToString());

            myCommand.ExecuteNonQuery();

            Response.Write("<script>alert(\"Successfully Deleted The Assigned Course " + dropdownCourseCode.SelectedValue.ToString() + " In Group Of " + dropdownGroupNumber.SelectedValue.ToString() + " From The Teacher With The Employee ID Of " + textBoxEmployeeID.Text.ToString() + ".\");</script>");
        }

        protected void buttonAssignCourse_onClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxEmployeeID.Text))
            {
                int employeeId = Convert.ToInt32(textBoxEmployeeID.Text);

                myCommand = new OleDbCommand("SELECT * FROM Employees WHERE [EmployeeId] = @employeeId", myConnection);
                myCommand.Parameters.AddWithValue("employeeId", employeeId);

                myDataReader = myCommand.ExecuteReader();
               

                if (myDataReader.HasRows)
                {
                    myDataReader.Close();

                    myCommand = new OleDbCommand("SELECT * FROM CourseAssignments WHERE [EmployeeId] = @employeeId", myConnection);
                    myCommand.Parameters.AddWithValue("employeeId", textBoxEmployeeID.Text);

                    myDataReader = myCommand.ExecuteReader();

                    int numberOfAlreadyAssignedCourse = 0;
                    while (myDataReader.Read())
                    {
                        numberOfAlreadyAssignedCourse++;
                    }

                    myDataReader.Close();

                    if (numberOfAlreadyAssignedCourse < 3)
                    {
                        /*
                        DateTime dtclickdate = DateTime.Now;
                        OleDbParameter clickdate = new OleDbParameter("@clickdate ", OleDbType.DBTimeStamp);
                        clickdate.Value = dtclickdate;
                        */
                        //myCommand = new OleDbCommand("INSERT INTO CourseAssignments ([EmployeeId],[CourseCode],[GroupNumber],[AssignedDate]) VALUES (@employeeId,@courseCode,@groupNumber,@assignedDate)", myConnection);
                        myCommand = new OleDbCommand("INSERT INTO CourseAssignments ([EmployeeId],[CourseCode],[GroupNumber]) VALUES (@employeeId,@courseCode,@groupNumber)", myConnection);
                        myCommand.Parameters.AddWithValue("employeeId", textBoxEmployeeID.Text);
                        myCommand.Parameters.AddWithValue("courseCode", dropdownCourseCode.SelectedItem.Value);
                        myCommand.Parameters.AddWithValue("groupNumber", dropdownGroupNumber.SelectedItem.Value);
                        //myCommand.Parameters.AddWithValue("assignedDate", clickdate);

                        myCommand.ExecuteNonQuery();

                        Response.Write("<script>alert(\"Successfully Assigned The Course To The Teacher With The Employee ID Of " + textBoxEmployeeID.Text.ToString() + ".\");</script>");

                    } else
                    {
                        Response.Write("<script>alert(\"You Cannot Assign More Than 3 Course To The Teacher With The Employee ID Of " + textBoxEmployeeID.Text.ToString() + "!!\");</script>");
                    }
                } else
                {
                    Response.Write("<script>alert(\"The Entered Employee ID Does Not Exist In Database! Please Check Again...\");</script>");
                    myDataReader.Close();
                }


            }
            else
            {
                Response.Write("<script>alert(\"Employee ID Text Box Cannot Be Empty!!\");</script>");
            }
        }

        protected void gridViewCourseAssignments_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxEmployeeID.ReadOnly = true;
            dropdownCourseCode.Enabled = false;
            dropdownGroupNumber.Enabled = false;
            buttonAssignCourse.Enabled = false;
            buttonDelete.Enabled = true;

            textBoxEmployeeID.Text = gridViewTeachers.SelectedRow.Cells[1].Text;

            dropdownCourseCode.SelectedIndex = -1;
            dropdownCourseCode.Items.FindByValue(gridViewCourseAssignments.SelectedRow.Cells[2].Text).Selected = true;

            dropdownGroupNumber.SelectedIndex = -1;
            dropdownGroupNumber.Items.FindByValue(gridViewCourseAssignments.SelectedRow.Cells[3].Text).Selected = true;

            
        }
    }
}
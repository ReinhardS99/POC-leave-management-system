using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using POC_Leave_Management.Models;
using System.ComponentModel;
using system.data.sqlclient;

namespace POC_Leave_Management.Pages.View_Leave_Requests
{
    public LeaveInfo leaveInfo = new LeaveInfo();
    public String errorMessage = "";
    public String successMessage = "";
    public class Leave RequestModel : PageModel
    {
        public void OnGet()
        {
            
        }
    

        public void OnPost()
        {
        leaveInfo.Fname = Request.Form["Fname"];
        leaveInfo.Lname = Request.Form["Lname"];
        leaveInfo.Sdate = Request.Form["sdate"];
        leaveInfo.Edate = Request.Form["edate"];
        leaveInfo.Reason = Request.Form["RfLeave"];

        if (clientInfo.Fname.length == 0 || clientInfo.Lname.Length == 0 || clientInfo.Sdate.Length == 0 || clientInfo.Edate.Length == 0 || clientInfo.RfLeave.Length == 0)
        {
            errorMessage = "All the fields are required";
            return;
        }

        try
        {
            string connectionstring = "Password=ShadowStriderFantasy1599!;Persist Security Info=True;User ID=Steynrp_29997313;Initial Catalog=dbLeave_management;Data Source=poc-interview.database.windows.net\r\n";
            using(SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
            }
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
            return;
        }
        leaveInfo.Fname = "";
        leaveInfo.Lname = "";
        leaveInfo.Sdate ="";
        leaveInfo.Edate = "";
        leaveInfo.Reason = "";

        successMessage = "New Leave Request added";
    }
    }
}

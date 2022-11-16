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
    public int i=0;
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
          
            using(SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                string sql = "INSERT INTO Request_Leave (Req_ID, First Name, Last Name, Leave Start, Leave End, Reason " +
                             "VALUES (@I, @Fname, @Lname, @sdate, @edate, @RfLeave);";
                
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@I",i);
                    command.Parameters.AddWithValue("@Fname", leaveInfo.Fname);
                    command.Parameters.AddWithValue("@Lname", leaveInfo.Lname);
                    command.Parameters.AddWithValue("@sdate", leaveInfo.Sdate);
                    command.Parameters.AddWithValue("@edate", leaveInfo.Edate);
                    command.Parameters.AddWithValue("@RfLeave", leaveInfo.Reason);
                    command.ExecuteNonQuery();
                }
                
                
                i++;
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

        Respose.Redirect("/View Leave Requests/Index");
    }
    }
}

using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using POC_Leave_Management.Models;
using System.ComponentModel;
using system.data.sqlclient;

namespace POC_Leave_Management.Pages.View_Leave_Requests
{

    public class EditModel : PageModel
    {
        public LeaveInfo leaveInfo = new LeaveInfo();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {
            string id = Request.Query["id"];

            try
            {
                
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    con.Open();
                    String sql = "SELECT * FROM Request_Leave WHERE Req_ID=@id";
                    using (SqlCommand cmd = new SqlCommand(sql, Constr))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                view_Req.Id = "" + reader.GetInt32(0);
                                view_Req.FName = reader.GetString(1);
                                view_Req.LName = reader.GetString(2);
                                view_Req.lstart = reader.GetDateTime(3).ToString();
                                view_Req.lend = reader.GetDateTime(4).ToString();
                                view_Req.sReason = reader.GetString(5);

                            }
                        }
                    }
                }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public void OnPost()
        {
            leaveInfo.Id = Requests.Form["id"];
            leaveInfo.Fname = Request.Form["Fname"];
            leaveInfo.Lname = Request.Form["Lname"];
            leaveInfo.Sdate = Request.Form["sdate"];
            leaveInfo.Edate = Request.Form["edate"];
            leaveInfo.Reason = Request.Form["RfLeave"];
        }

         if (clientInfo.Fname.length == 0 || clientInfo.Lname.Length == 0 || clientInfo.Sdate.Length == 0 || clientInfo.Edate.Length == 0 || clientInfo.RfLeave.Length == 0)
        {
            errorMessage = "All the fields are required";
            return;
        }

    try
    {
    string Constr = "Password=ShadowStriderFantasy1599!;Persist Security Info=True;User ID=Steynrp_29997313;Initial Catalog=dbLeave_management;Data Source=poc-interview.database.windows.net\r\n";
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    con.Open();
                    String sql = "UPDATE Request_Leave SET Fname=@Fname, Lname=@Lname, sdate=@sdate, edate=@edate, RfLeave=@RfLeave WHERE Req_ID=@id";
         
                using (SqlCommand command = new SqlCommand(sql, connection))
                       {
                        command.Parameters.AddWithValue("@Id",leaveInfo.Id);
                        command.Parameters.AddWithValue("@Fname", leaveInfo.Fname);
                        command.Parameters.AddWithValue("@Lname", leaveInfo.Lname);
                        command.Parameters.AddWithValue("@sdate", leaveInfo.Sdate);
                        command.Parameters.AddWithValue("@edate", leaveInfo.Edate);
                        command.Parameters.AddWithValue("@RfLeave", leaveInfo.Reason);
                        command.ExecuteNonQuery();
                       }
                
                    }
    }
    catch (Exception ex)
{
    errorMessage = ex.Message;
    return;
}
Response.Redirect("/View_Leave_Req/Index");
}
}

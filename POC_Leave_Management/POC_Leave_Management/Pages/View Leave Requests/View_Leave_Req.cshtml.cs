using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using POC_Leave_Management.Models;
using System.ComponentModel;

namespace POC_Leave_Management.Pages.View_Leave_Requests
{
    public List<View_Req> ListView = new List<View_Req>();
    public class View_Leave_ReqModel : PageModel
    {
        public void OnGet()
        {
            try
            {
                
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    con.Open();
                    String sql = "SELECT * FROM Request_Leave";
                    using(SqlCommand cmd = new SqlCommand(sql, Constr))
                    {
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                View_Req view_Req = new View_Req();
                                view_Req.Id = "" + reader.GetInt32(0);
                                view_Req.FName = reader.GetString(1);
                                view_Req.LName = reader.GetString(2);
                                view_Req.lstart = reader.GetDateTime(3).ToString();
                                view_Req.lend = reader.GetDateTime(4).ToString();
                                view_Req.sReason = reader.GetString(5);

                                ListView.add(view_Req);
                            }
                        }
                    }
                }
            
            }catch (Exception ex)
            {
                Console.WriteLine("Exception "+ex.ToString());
            }
        }
    }

    public class View_Req
    {
        public int Id = 0;
        public string FName="";
        public string LName="";
        public DateOnly lstart;
        public DateOnly lend;
        public string sReason="";


    }
}

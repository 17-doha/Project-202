using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_DB.Models;
using System.Data.SqlClient;
using System.Runtime;

namespace Project_DB.Pages
{
    public class DeliveryProfileModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ID2 { get; set; }

        [BindProperty(SupportsGet = true)]
        public Driver deliveryinfo { get; set; }
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";
                //deliveryinfo.Id = ID2;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string q2 = "SELECT * FROM Userr " +
                                "INNER JOIN Delivery ON Userr.ID = Delivery.delivery_id " +
                                "WHERE Userr.ID = @ID";
                    using (SqlCommand cmd = new SqlCommand(q2, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID2);
                        
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            //deliveryinfo.Id = Convert.ToInt32(reader["ID"]);
                            deliveryinfo.UserName = reader["UserName"].ToString();
                            deliveryinfo.Email = reader["Email"].ToString();
                            deliveryinfo.Phone_Number = reader["Phone_Number"].ToString();
                            deliveryinfo.Vehicle_number = reader["Vehicle_number"].ToString();
                            deliveryinfo.User_Password = reader["User_Password"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


    }
}

using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Xml.Linq;
using WebApplicationMyPractice1616.Models;


namespace WebApplicationMyPractice1616.Business_logic
{
    public class Logic
    {

        public static bool InsertData(First obj)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string dbconnctionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnctionstr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Sp_mypractice", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", obj.Id);
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@EmailId", obj.EmailId);
                    cmd.Parameters.AddWithValue("@Password", obj.Password);
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return true;

                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception)
                {

                }
                finally
                {
                    con.Close();

                }
                return true;

            }
        }
    }
}

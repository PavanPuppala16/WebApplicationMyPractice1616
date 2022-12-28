using System.Data.SqlClient;
using WebApplicationMyPractice1616.Models;

namespace WebApplicationMyPractice1616.Business_logic
{
    public class InsertLogic
    {
        public static bool InsertData(InsetModel obj)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using(SqlConnection con=new SqlConnection(dbconnectionstr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ", con);
                    cmd.Parameters.AddWithValue("@EmailId", obj.EmailId);
                    cmd.Parameters.AddWithValue("@Password", obj.Password);
                    int x = cmd.ExecuteNonQuery();
                    if(x>0)
                    {
                        return res = true;

                    }
                    else
                    {
                        return res = false;
                    }
                }
                catch(Exception)
                {

                }
                finally
                {
                    con.Close();

                }
            }
            return res = true;

        }

    }
}

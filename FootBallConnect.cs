using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FootBallLeagueProgran
{
    public class FootBallLeague
    {
        static void Main(string[] args)
        {

            Connection();

        }
        static void Connection()
        {
            string cs = "Data Source=SureshGowd; Initial Catalog=SureshGowd;Integrated Security=True";
            SqlConnection con=new SqlConnection(cs);
            {

                con.Open();

                SqlCommand cmd = new SqlCommand("select * from FootBallLeague where status='Win'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Console.WriteLine("Winning Teams are---");

                while (dr.Read())
                {
                    Console.WriteLine("MatchID=" + dr[0] + "    " + "TeamName1=" + dr[1] + "    " + "TeamName2=" + dr[2]);
                    
                }
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("Press Enter To View Draw Match Teams");
                Console.ReadKey();
               
                con.Close();
                

                {
                    con.Open();
                    /*  
                    CREATE VIEW MatchView  AS
                    SELECT TeamName1,TeamName2
                    FROM FootBallLeague
                    WHERE Status='Draw';*/ // using Sql query to create MatchView

                    //Create View Match_View to display the teams whose status is Draw
                    
                    SqlCommand cmd1 = new SqlCommand("select * from [MatchView]", con);
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    dr1.Read();
                    Console.WriteLine("Displaying Draw Teams---");

                    while (dr1.Read())
                    {
                        Console.WriteLine("TeamName1=" + dr1[0] + "    " + "TeamName2=" + dr1[1]);

                    }
                    Console.WriteLine("-------------------------------------------------------------------------");
                    Console.WriteLine("Press Enter To View all matches in which Japan played");
                    Console.ReadKey();
                    con.Close();
                }

                {
                    con.Open();

                    // Retrieve the details of all matches in which Japan played   
                    SqlCommand cmd2 = new SqlCommand("select * from FootBallLeague where TeamName1= 'Japan' or TeamName2 = 'Japan' ", con);
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    dr2.Read();
                    Console.WriteLine("Displaying all matches which japan played are---");

                    while (dr2.Read())
                    {
                        Console.WriteLine("MatchID=" + dr2[0] +"    " +"TeamName1=" + dr2[1] + "    " + "TeamName2=" + dr2[2] + "    " + "Status=" + dr2[3] + "WinningTeam="+dr2[4]+"    "+ "Points="+dr2[5]);

                    }
                    
                    Console.ReadKey();
                    con.Close();
                }


            }
        }
    }
}

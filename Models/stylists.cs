using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Stylists
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public int StylistId {get;}

        public Stylists(string first_name, string last_name)
        {
            FirstName = first_name;
            LastName = last_name;
        }
        public static Stylists Find (int SearchId)
        {
            Stylists placeholderStylist = new Stylists("placeholder Stylist");
    return placeholderStylist;
        }
        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM salon;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
               conn.Dispose();
            }
        }
        public static List<Stylists> GetAll()
    {
        List<Stylists> allStylists = new List<Stylists> { };
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM salon;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while (rdr.Read())
        {
            int StylistId = rdr.GetInt32(0);
            string StylistName = rdr.GetString(1);
            Stylists newStylist = new Stylists(StylistsName, StylistId);
            allStylists.Add(newStylist);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allStylists;
    }
    }
}
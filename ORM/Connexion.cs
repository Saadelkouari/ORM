using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace ORMC
{
    public class Connexion
    {
        static IDbConnection con = null;
        static IDbCommand cmd = null;
        public static void Connect(string host, string user, string password, string database, string dialect)
        {
            if (con == null)
            {
                switch (dialect)
                {
                    case "mysql":
                        con = new MySqlConnection("server=" + host + ";user id=" + user + ";database=" + database);
                        cmd = new MySqlCommand();
                        break;
                    default:
                        throw new Exception("Invalid dialect name");
                }
            }

            if (con.State.ToString() == "Closed")
            {
                con.Open();
                cmd.Connection = con;
            }

        }
        public static int IUD(string req)
        {
            cmd.CommandText = req;
            return cmd.ExecuteNonQuery();
        }
        public static IDataReader Select(string req)
        {
            cmd.CommandText = req;
            return cmd.ExecuteReader();
        }
        /*public static Dictionary<string, string> getChamps_table(string table)
        {
            
        }*/
    }
}

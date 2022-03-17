using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORMC;
using System.Data;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Connexion.Connect("localhost", "root", "", "ensat", "mysql");
            IDataReader dr = Connexion.Select("select * from etudiant;");
            while (dr.Read())
            {
                Console.WriteLine(dr.GetString(2));
            }
            Console.ReadKey();
        }
    }
}

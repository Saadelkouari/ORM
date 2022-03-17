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
            Dictionary<string, string> map = Connexion.getChamps_table("etudiant");
            foreach (KeyValuePair<string,string> element in map)
            {
                Console.WriteLine(element.Key+" "+element.Value);
            }

            Console.ReadKey();
        }
    }
}

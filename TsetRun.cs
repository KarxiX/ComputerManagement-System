using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ComputerDB001
{
    class TsetRun
    {
        static void Main(string[] args)
        {
            Menus m = new Menus();
            m.Menuss();
            Console.ReadKey();
        }
    }
}

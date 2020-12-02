using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Puti_v_grafe
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter save_out = Console.Out;
            TextReader save_in = Console.In;
            var new_out = new StreamWriter(@"output.txt");
            var new_in = new StreamReader(@"scales_input.txt");
            Console.SetOut(new_out);
            Console.SetIn(new_in);

            Graf myGraf = new Graf();
            myGraf.Load();
            myGraf.shortByFord(9, 1);

            Console.SetOut(save_out); new_out.Close();
            Console.SetIn(save_in); new_in.Close();

            myGraf.Info();
            myGraf.shortByFord(9, 1);
            Console.ReadKey();
        }
    }
}

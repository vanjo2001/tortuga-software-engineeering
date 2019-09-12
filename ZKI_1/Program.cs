using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZKI_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "This is my first message gigigi1, Rost lox";
            string key = "govna kusok";
            
            Matrix matrix = new Matrix(text, key);
            matrix.PrintMatrixWithKey();

            SimpleTransposition test = new SimpleTransposition(matrix);
            test.Encode("");
            Console.WriteLine();
            test.Data.PrintMatrixWithKey();

            //int[] a = (from i in arr orderby i ascending select i).ToArray();

            Console.ReadLine();
        }
    }
}
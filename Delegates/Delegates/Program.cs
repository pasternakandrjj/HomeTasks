
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate void Add(string message);

    public class AlphaNumbericCollector
    {
        List<string> listnumber = new List<string>();
        public void Push(string message)
        {
            listnumber.Add(message);
            Console.WriteLine("Added to AlphaNumbericCollector : " + message);

            //foreach (var item in listnumber)
            //    Console.WriteLine(item);
        }
    }
    public class StringCollector
    {
        List<string> liststring = new List<string>();
        public void Push(string message)
        {
            liststring.Add(message);
            Console.WriteLine("Added to StringCollector : " + message);

            //foreach (var item in liststring)
            //    Console.WriteLine(item);
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Add add;
            string parsed;
            AlphaNumbericCollector alphaNumbericCollector = new AlphaNumbericCollector();
            StringCollector stringCollector = new StringCollector();

            while (true)
            {
                Console.WriteLine("Enter the string :");
                parsed = Console.ReadLine();
                if (HasDigits(parsed))
                    add = alphaNumbericCollector.Push;
                else
                    add = stringCollector.Push;
                add(parsed);

            }
        }
        static bool HasDigits(string s)
        {
            bool flag = false;
            for (int i = 0; i < s.Length; ++i)
            {
                if (char.IsDigit(s[i]) == true)
                    flag = true;
            }
            return flag;
        }
    }
}

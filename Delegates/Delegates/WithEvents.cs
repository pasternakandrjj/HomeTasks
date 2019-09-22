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
        public event Add Added;
        List<string> listnumber = new List<string>();
        public void Push(string message)
        {
            listnumber.Add(message);
            Console.WriteLine("Added to AlphaNumbericCollector : " + message);
        }
    }
    public class StringCollector
    {
        public event Add Added;
        List<string> liststring = new List<string>();
        public void Push(string message)
        {
            liststring.Add(message);
            Console.WriteLine("Added to StringCollector : " + message);
        }
    }
    class WithEvents

    {
        public static void Main(string[] args)
        {
            string parsed;
            AlphaNumbericCollector alphaNumbericCollector = new AlphaNumbericCollector();
            StringCollector stringCollector = new StringCollector();

            while (true)
            {
                Console.WriteLine("Enter the string :");
                parsed = Console.ReadLine();
                if (HasDigits(parsed))
                {
                    alphaNumbericCollector.Added += alphaNumbericCollector.Push;
                    alphaNumbericCollector.Push(parsed);
                }
                else
                {
                    stringCollector.Added += stringCollector.Push;
                    stringCollector.Push(parsed);
                }
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

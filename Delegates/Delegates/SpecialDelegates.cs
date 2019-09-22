using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class AlphaNumbericCollector
    {
        static List<string> listnumber = new List<string>();
        public static void Push(string message)
        {
            listnumber.Add(message);
            Console.WriteLine("Added to AlphaNumbericCollector : " + message);

            //foreach (var item in listnumber)
            //    Console.WriteLine(item);
        }
    }
    public class StringCollector
    {
        static List<string> liststring = new List<string>();
        public static void Push(string message)
        {
            liststring.Add(message);
            Console.WriteLine("Added to StringCollector : " + message);

            //foreach (var item in liststring)
            //    Console.WriteLine(item);
        }
    }
    class SpecialDelegates
    {
        public static void Main(string[] args)
        {
            string parsed;
            AlphaNumbericCollector alphaNumbericCollector = new AlphaNumbericCollector();
            StringCollector stringCollector = new StringCollector();

            Action<string> op = StringCollector.Push;

            //void flage=Operation(op);
            //Console.WriteLine(flage);
            Console.Read();
            while (true)
            {
                Console.WriteLine("Enter the string :");
                parsed = Console.ReadLine();
                if (HasDigits(parsed))
                {
                    AlphaNumbericCollector.Push(parsed);
                }
                else
                {
                    StringCollector.Push(parsed);
                }

            }
        }
        public static void Operation(Action<string>action)
        {
            action.Invoke("a");
        }
        public static bool HasDigits(string s)
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

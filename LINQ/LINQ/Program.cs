using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            string mystrings = " Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert";
             
            var myresult = mystrings.Split(' ').Aggregate((cur, next) => cur + "1 " + next);

            //for (int i = 0; i < result.Length; i++)
            //{
            //    result[i] = $"{i} {result[i]}";
            //} 

            Console.WriteLine(myresult);
            Console.WriteLine();


            //2
            string stringmy = @"Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; 
                                Kelvin Davis, 29 / 09 / 1976; Luke Shaw, 12 / 07 / 1995; 
                                Gaston Ramirez, 02 / 12 / 1990; Adam Lallana, 10 / 05 / 1988";
            var resultmy = stringmy.Split(';')
                .Select(playeyWithYear => playeyWithYear.Split(','))
                .Select(s => new { Player = s[0], Year = s[1] })
                .OrderBy(element => element.Year)
                .Select(p => p.Player);
             
            foreach (var item in resultmy)
            {
                Console.WriteLine(item.Trim());
            }
            Console.WriteLine();


            //3
            TimeSpan timeSpan = new TimeSpan(0, 0, 0);
            string stringtime = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";
            timeSpan = stringtime.Split(',')
                .Select(x => TimeSpan.Parse($"00:{x}"))
                .Aggregate((cur, next) => cur + next);

            Console.WriteLine(timeSpan);
        }
    }
}

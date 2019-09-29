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
            string mystrings = " Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert";
            //int a = 1;
            var result = mystrings.Split(' ').Aggregate((cur, next) => cur + "1 " + next);

            //for (int i = 0; i < result.Length; i++)
            //{
            //    result[i] = $"{i} {result[i]}";
            //}
            //for (int i = 0; i < result.Length; i++)
            //{
            //    Console.WriteLine(result[i]);
            //} 

            //Console.WriteLine(result);


            string stringmy = "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29 / 09 / 1976; Luke Shaw, 12 / 07 / 1995; Gaston Ramirez, 02 / 12 / 1990; Adam Lallana, 10 / 05 / 1988";
            var resultmy = stringmy.Split(';',',');
            //var myres = DateTime.Parse(resultmy);
            //Console.WriteLine(myres);
            TimeSpan datas;
            for (int i = 0; i < resultmy.Length; i++)
            {
                if (i % 2 != 0)
                {
                    datas = DateTime.Now.Subtract(DateTime.Parse(resultmy[i]));
                    Console.WriteLine(DateTime.Parse(resultmy[i]).ToShortDateString());
                }
            }
            //Console.WriteLine(datas);
            //foreach (var item in resultmy)
            //{
            //    Console.WriteLine(item.Trim());
            //}



            TimeSpan timeSpan = new TimeSpan(0, 0, 0);
            string stringtime = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";
            var resulttime = stringtime.Split(',');
            var claculated = TimeSpan.Parse($"00:{resulttime[0]}"); 

            //foreach (var res in resulttime)
            //{
            //    //Console.WriteLine(timeSpan);
            //    timeSpan += TimeSpan.Parse($"00:{res}");
            //   // Console.WriteLine(res);
            //} 
            //Console.WriteLine(claculated);
        }
    }
}

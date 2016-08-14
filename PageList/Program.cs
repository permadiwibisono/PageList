using PageList.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string> {
                "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u"
            };
            var pageList = new PageCollection<string>(list,2);
            Console.WriteLine("List Count: " + list.Count);
            Console.WriteLine("PageSize: " + pageList.PageSize);
            Console.WriteLine("Record Per Page: " + pageList.RecordPerPage);
            //var getPage = pageList.GetFirst();
            //Console.WriteLine("Get First Page:");
            //foreach (var a in getPage)
            //{
            //    Console.WriteLine(a);
            //}
            //getPage = pageList.GetLast();
            //Console.WriteLine("Get Last Page:");
            //foreach (var a in getPage)
            //{
            //    Console.WriteLine(a);
            //}
            //Console.ReadKey();
            Console.WriteLine(pageList.GeneratePager());
            while (true)
            {
                Console.Write("Go to page: ");
                var input = Console.ReadLine();
                int page = 0;
                if (Int32.TryParse(input, out page))
                {
                }
                else {
                    switch (input)
                    {
                        case ">": page = pageList.PageActive+1; break;
                        case ">>": page = pageList.PageSize; break;
                        case "<": page = pageList.PageActive - 1; break;
                        case "<<": page = 1; break;
                        default: page = 0; break;
                    }
                }
                if (page < 1)
                    break;
                pageList.PageActive = page;
                //var data = pageList.GetNow();

                //foreach (var a in data)
                //{
                //    Console.WriteLine(a);
                //}
                
                Console.WriteLine("Get Page Start:" + pageList.PageStart);
                Console.WriteLine("Get Page End:" + pageList.PageEnd);
                Console.WriteLine(pageList.GeneratePager());
            }
            //Console.ReadKey();
        }
        static void Square(int sisi, out int hasil) {
            hasil = sisi * sisi;
        }
    }
}

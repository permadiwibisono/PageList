using PageList.Commons;
using PageList.EntityClass;
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
            //List<string> list = new List<string> {
            //    "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u"
            //};
            //var pageList = new PageCollection<string>(list, 1);
            List<Customer> list = new List<Customer> {
                new Customer {Id=1,Name="Alfan" },
                new Customer {Id=2,Name="Budi" },
                new Customer {Id=3,Name="Candy" },
                new Customer {Id=4,Name="Dedi" },
                new Customer {Id=5,Name="Erin" },
                new Customer {Id=6,Name="Fika" },
                new Customer {Id=7,Name="Garry" },
                new Customer {Id=8,Name="Hanny" },
                new Customer {Id=9,Name="Ilham" },
                new Customer {Id=10,Name="Jaka" },
                new Customer {Id=11,Name="Kharisma" },
                new Customer {Id=12,Name="Luna" },
                new Customer {Id=13,Name="Mario" },
                new Customer {Id=14,Name="Nina" },
                new Customer {Id=15,Name="Olmi" },
                new Customer {Id=16,Name="Permadi" },
                new Customer {Id=17,Name="Qira" },
                new Customer {Id=18,Name="Rani" },
                new Customer {Id=19,Name="Sonia" },
                new Customer {Id=20,Name="Teguh" },
                new Customer {Id=21,Name="Uul" },
                new Customer {Id=22,Name="Veby" },
                new Customer {Id=23,Name="Wibi" },
                new Customer {Id=24,Name="Xena" },
                new Customer {Id=25,Name="Yulia" },
                new Customer {Id=26,Name="Zoro" },
            };
            var pageList = new PageCollection<Customer>(list, 5);
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
            while (true)
            {
                var getList = pageList.GetNow();
                Console.WriteLine();
                foreach (var item in getList)
                {
                    Console.WriteLine(item.Id + " - " + item.Name);
                }
                Console.WriteLine();
                var info = "Show data {0} to {1} of {2}";
                Console.WriteLine(String.Format(info, pageList.FirstIndex, pageList.LastIndex, pageList.Total));
                Console.WriteLine(pageList.GeneratePager());
                Console.Write("Go to page: ");
                var input = Console.ReadLine();
                int page = 0;
                if (!Int32.TryParse(input, out page))
                {
                    switch (input)
                    {
                        case ">": page = pageList.PageActive + 1; break;
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

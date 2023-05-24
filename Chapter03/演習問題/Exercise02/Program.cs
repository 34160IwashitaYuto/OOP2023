using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {

            var names = new List<string> {
                 "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            Exercise2_1(names);
            Console.WriteLine();
            Exercise2_2(names);
            Console.WriteLine();
            Exercise2_3(names);
            Console.WriteLine();
            Exercise2_4(names);
        }

        private static void Exercise2_1(List<string> names) {
            Console.WriteLine("都市名入力。空白で終了");
            do
            {
                var city = Console.ReadLine();
                if (string.IsNullOrEmpty(city))
                    break;
                var index = names.FindIndex(s => s == city);
                Console.WriteLine(index);

            } while (true);
           
        }

        private static void Exercise2_2(List<string> names) {
            var count = names.Where(s => s.Contains('o')).Count();
            //var count = names.Count(s => s.Contains('o'));
            Console.WriteLine(count);

        }

        private static void Exercise2_3(List<string> names) {
            var selected = names.Where(s => s.Contains('o')).ToArray();
            foreach (var name in selected)
                Console.WriteLine(name);
        }

        private static void Exercise2_4(List<string> names) {
            var selected = names.Where(s => s.StartsWith("B")).Select(s => new {s,s.Length }).ToArray();

            foreach (var item in selected)
            {
                Console.WriteLine("{0},{1}", item, item.Length);
            }
        }
    }
}

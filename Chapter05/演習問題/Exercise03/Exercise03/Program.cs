﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
        }


        private static void Exercise3_1(string text) {
            int cnt = 0;
            char ch = ' ';
            int freq = text.Count(f => (f == ch));
            //var contains = text.Contains(" ");
            //if (true)
            //{
             //   cnt += 1;
            //}
 
            Console.WriteLine("空白数:" + freq);

        }

        private static void Exercise3_2(string text) {
            var replaced = text.Replace("big","small");
            Console.WriteLine(replaced);
        }

        private static void Exercise3_3(string text) {
            foreach (var c in text)
            {
                
            }


            //Console.WriteLine("単語数:" + cnt);
        }

        private static void Exercise3_4(string text) {
            
        }

        private static void Exercise3_5(string text) {
            
        }
    }
}

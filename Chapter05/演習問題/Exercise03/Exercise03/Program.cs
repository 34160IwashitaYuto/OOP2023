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
            //char ch = ' ';
            //int freq = text.Count(f => (f == ch));

            //Console.WriteLine("空白数:" + freq);

            int spaces = text.Count(c=> c == ' ');
            Console.WriteLine("空白数:{0}", spaces);

            //Console.WriteLine(text.Count(c=>c==' '));



        }

        private static void Exercise3_2(string text) {
            var replaced = text.Replace("big","small");
            Console.WriteLine(replaced);
        }

        private static void Exercise3_3(string text) {
            var words = text.Split(' ');
            Console.WriteLine(words.Length);
        }

        private static void Exercise3_4(string text) {
            var words = text.Split(' ').Where(word => word.Length <= 4);
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }

        private static void Exercise3_5(string text) {
            var array = text.Split(' ').ToArray();

            var sb = new StringBuilder();
            sb.Append(array[0]);
            foreach(var word in array.Skip(1))
            {
                sb.Append(word);
                sb.Append(' ');
            }
            var createWords = sb.ToString();
            Console.WriteLine(createWords);

        }
    }
}

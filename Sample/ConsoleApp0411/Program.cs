using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0411 {
    class Program {
        static void Main(string[] args) {

            Console.Write("合計金額:");//金額入力
            int money = int.Parse(Console.ReadLine());

            Console.Write("支払い:");//金額入力
            int hpaymentar = int.Parse(Console.ReadLine());

            int change = hpaymentar - money;//お釣り
            int Ten_thousand = 0;
            int Five_thousand = 0;
            int Two_thousand = 0;
            int One_thousand = 0;
            int Five_hudred = 0;
            int One_hudred = 0;
            int goju = 0;
            int Ten = 0;
            int Five = 0;
            int one = 0;

            Console.WriteLine("お釣り:" + change);

            while (change >= 10000)
            {
                change -= 10000;
                Ten_thousand = Ten_thousand + 1;
            }

            while (change >= 5000)
            {
                change -= 5000;
                Five_thousand = Five_thousand + 1;
            }

            while (change >= 2000)
            {
                change -= 2000;
                Two_thousand = Two_thousand + 1;
            }

            while (change >= 1000)
            {
                change -= 1000;
                One_thousand = One_thousand + 1;
            }

            while (change >= 500)
            {
                change -= 500;
                Five_hudred = Five_hudred + 1;
            }

            while (change >= 100)
            {
                change -= 100;
                One_hudred = One_hudred + 1;
            }

            while (change >= 50)
            {
                change -= 50;
                goju = goju + 1;
            }

            while (change >= 10)
            {
                change -= 10;
                Ten = Ten + 1;
            }

            while (change >= 5)
            {
                change -= 5;
                Five = Five + 1;
            }

            while (change >= 1)
            {
                change -= 1;
                one = one + 1;
            }

            /*
            Console.WriteLine("一万円札:" + Ten_thousand + "枚");
            Console.WriteLine("五千円札:" + Five_thousand + "枚");
            Console.WriteLine("二千円札:" + Two_thousand + "枚");
            Console.WriteLine("千円札:" + One_thousand + "枚");
            Console.WriteLine("五百円玉:" + Five_hudred + "枚");
            Console.WriteLine("百円玉:" + One_hudred + "枚");
            Console.WriteLine("五十円玉:" + goju + "枚");
            Console.WriteLine("十円玉:" + Ten + "枚");
            Console.WriteLine("五円玉:" + Five + "枚");
            Console.WriteLine("一円玉:" + one + "枚");
            */

            

        }

        private static void asOut(int count) {
            for (int i = 0; i < count; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}

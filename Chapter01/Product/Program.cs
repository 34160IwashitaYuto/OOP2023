using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {

    class Program {
        static void Main(string[] args) {

            #region P26のサンプルプログラム
            //インスタンスの生成
            //Product karinto = new Product(123, "かりんとう", 180);
            //Product daifukumoti = new Product(235,"大福もち",160);

            //Console.WriteLine("かりんとうの税込み価格:"+ karinto.GetPriceIncludingTax());
            //Console.WriteLine("大福もちの税込み価格:" + daifukumoti.GetPriceIncludingTax());
            #endregion

            #region 
            //DateTime date = new DateTime(2023,5,8);
            //DateTime date = DateTime.Today;

            //10日後を求める
            //DateTime daysAfter10 = date.AddDays(10);

            //10日前を求める
            //DateTime daysformer10 = date.AddDays(-10);

            //Console.WriteLine("今日の日付:" +date.Year+"年"+ date.Month+"月"+ date.Day + "日です");
            //Console.WriteLine("10日後:" + daysAfter10.Year + "年" + daysAfter10.Month + "月"+ daysAfter10.Day + "日です");
            //Console.WriteLine("10日前:" + daysformer10.Year + "年" + daysformer10.Month + "月" + daysformer10.Day + "日です");
            #endregion




            Console.WriteLine("誕生日を入力");
            Console.Write("西暦:");
            int Anno_Domini = int.Parse(Console.ReadLine());
            Console.Write("月:");
            int Month = int.Parse(Console.ReadLine());
            Console.Write("日:");
            int Day = int.Parse(Console.ReadLine());

            DateTime date = DateTime.Today;
            DateTime barthday = new DateTime(Anno_Domini, Month, Day);


            TimeSpan timespan = date - barthday;
            Console.WriteLine("あなたは生まれてから"+timespan.Days+"日です");


        }
    }
}

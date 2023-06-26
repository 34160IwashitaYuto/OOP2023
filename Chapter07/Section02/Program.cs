using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            var prefDict = new Dictionary<string, List<CityInfo>>();
            string pref, city;
            int population;

            Console.WriteLine("県庁所在地の登録");
            while (true)
            {
                Console.Write("県名：");
                pref = Console.ReadLine();
                if (pref == "999") break;
                Console.Write("市町村：");
                city = Console.ReadLine();


                Console.Write("人口:");
                population = int.Parse(Console.ReadLine());

                //市町村インスタンスの生成
                var cityInfo = new CityInfo
                {
                    City = city,
                    Population = population,
                };

                //県名が未登録
                if (!prefDict.ContainsKey(pref))
                {
                    prefDict[pref] = new List<CityInfo>();  //既に県名が未登録ならリスト作成
                }
                prefDict[pref].Add(cityInfo);
            }
                //登録処理
                //prefDict[pref] = new CityInfo
                //{
                //    City = city,
                //    Population = population,
                //};


            Console.WriteLine();
            Console.WriteLine("1:一覧表示,2:県名指定");
            Console.Write(">");
            var selected = Console.ReadLine();

            if (selected == "1")
            {
                //一覧表示
                foreach (var dict in prefDict)
                {
                    foreach (var item in dict.Value)
                    {

                        Console.WriteLine("{0}県{1}市(人口:{2}人)", dict.Key, item.City, item.Population);
                    }
                    
                }
            }
            else
            {
                //県名指定表示
                Console.Write("県名を入力：");
                var inputPref = Console.ReadLine();
                foreach (var item in prefDict[inputPref])
                {
                Console.WriteLine("{0}市(人口:{1}人)", item.City,item.Population);

                }
            }
        }
    }
}
class CityInfo {
        public string City { get; set; }         //都市
        public int Population { get; set; }     //人口
}

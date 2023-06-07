using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 9, 7, 5, 4, 2, 5, 4, 0, 4, 1, 0, 4, };
            Console.WriteLine(numbers.Average());

            var books = Books.GetBooks();

            //Console.WriteLine(books.Average(x=> x.Price));

            //Console.WriteLine(books.Max(x => x.Pages));


            //物語がつく本

            var booksObj = books.Where(x => x.Title.Contains("物語")).Average(x => x.Pages);
            
                
            //Console.WriteLine("平均価格"+booksObj+"円");
            Console.WriteLine("平均{0}円",booksObj );

            var longTitleBooks = books.OrderByDescending(x=> x.Price);
            foreach (var book in longTitleBooks)
            {
                Console.WriteLine("{0}{1}",book.Title,book.Price);
            }

        }
    }
}

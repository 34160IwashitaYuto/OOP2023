using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            var sales = new SalesCounter(@"data\sales.csv");
            var amountPerStor = sales.GetPerStoreSales();
            foreach (var obj in amountPerStor)
            {
                Console.WriteLine("{0}{1:C}", obj.Key, obj.Value);
            }
        }
    }
}

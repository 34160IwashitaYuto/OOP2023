using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            var novelist = line.Substring(9,5);
            Console.WriteLine("作家:"+novelist);
            var bestwork = line.Substring(24,3);
            Console.WriteLine("代表作:" + bestwork);
            var born = line.Substring(33,4);
            Console.WriteLine("誕生年:" + born);
        }
    }
}

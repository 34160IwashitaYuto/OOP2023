using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConveter {
    //フィートとメートルの単位変換クラス
    public static class FeetConverter {

        //定数
        private const double ratio = 0.3048;
        

        //メートルからフィート
        public static double FromMeter(int meter) {
            return meter / ratio;

        }

        //フィートからメートルを求める
        public static double ToMeter(int feet) {
            return feet * ratio;
        }

    }
}

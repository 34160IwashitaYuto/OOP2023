﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConveter {
    //フィートとメートルの単位変換クラス
    public class FeetConverter {
        
        //メートルからフィート
        public double FromMeter(int meter) {
            return meter / 0.3048;

        }

        //フィートからメートルを求める
        public double ToMeter(int feet) {
            return feet * 0.3048;
        }

    }
}

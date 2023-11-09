using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    //グラム単位を表すクラス
    public class MetricUnit : DistanceUnit {
        private static List<MetricUnit> units = new List<MetricUnit> {
            new MetricUnit{Name="g",Coefficient = 1,},
            new MetricUnit{Name="kg",Coefficient = 1000,},
        };
        public static ICollection<MetricUnit> Units { get { return units; } }

        /// <summary>
        ///　ポンド単位からグラム単位に変換
        /// </summary>
        /// <param name="unit">ポンド単位</param>
        /// <param name="value">値</param>
        /// <returns>変換地</returns>
        public double FromImperialUnit(ImperialUnit unit, double value) {
            return (value * unit.Coefficient) * 28.35 / this.Coefficient;
        }
    }
}

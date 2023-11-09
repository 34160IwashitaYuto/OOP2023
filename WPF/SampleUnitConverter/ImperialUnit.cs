using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    public class ImperialUnit :DistanceUnit {
        private static List<ImperialUnit> units = new List<ImperialUnit> {
            new ImperialUnit{Name="オンス",Coefficient = 1,},
            new ImperialUnit{Name="ポンド",Coefficient = 16,},
        };
        public static ICollection<ImperialUnit> Units { get { return units; } }

        /// <summary>
        /// グラム単位からポンド単位に変換
        /// </summary>
        /// <param name="unit">グラム単位</param>
        /// <param name="value">値</param>
        /// <returns>変換地</returns>
        public double FromMetricUnit(MetricUnit unit, double value) {
            return (value * unit.Coefficient) / 28.35 / this.Coefficient;
        }
    }
}

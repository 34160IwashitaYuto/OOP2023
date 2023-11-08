using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleUnitConverter {
    public class MainWindowViewModel : ViewModel {
        private double metricValue, imperialValue;


        //プロパティ
        public double MetricValue {
            get { return this.metricValue; }
            set {
                this.metricValue = value;
                this.OnPropertyChanged();
            }
        }
        public double ImperiaValue {
            get { return this.imperialValue; }
            set {
                this.imperialValue = value;
                this.OnPropertyChanged();
            }
        }

        //上のComboBoxで選択されている値（単位）
        public MetricUnit CurrentMetriUnit { get; set; }

        //下のComboBoxで選択されている値（単位）
        public ImperialUnit CurrentImperialUnit { get; set; }

        //▲ボタンで呼ばれるコマンド
        public ICommand ImperialUnitToMetric { get; private set; }

        //▼ボタンで呼ばれるコマンド
        public ICommand MetricToImperiaUnit { get; private set; }

        //コンストラクタ
        public MainWindowViewModel() {
            this.CurrentMetriUnit = MetricUnit.Units.First();
            this.CurrentImperialUnit = ImperialUnit.Units.First();

            this.MetricToImperiaUnit = new DelegateCommand(
                () => this.ImperiaValue = this.CurrentImperialUnit.FromMetricUnit(
                    this.CurrentMetriUnit, this.MetricValue));

            this.ImperialUnitToMetric = new DelegateCommand(
                () => this.MetricValue = this.CurrentMetriUnit.FromImperialUnit(
                    this.CurrentImperialUnit, this.ImperiaValue));
        }
    }
}

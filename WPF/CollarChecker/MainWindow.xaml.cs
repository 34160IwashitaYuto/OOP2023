using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CollarChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = GetColorList();
        }


        /// <summary>
        /// すべての色を取得するメソッド
        /// </summary>
        /// <returns></returns>
        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                    .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }


        /// <summary>
        /// 色と色名を保持するクラス
        /// </summary>
        public class MyColor {
            public Color Color { get; set; }
            public string Name { get; set; }
            public override string ToString() {
                return "R:" + Color.R + "G:" + Color.G + "B:" + Color.B;
            }
        }


        private void SampleSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            colorArer.Background = new SolidColorBrush(Color.FromRgb((byte)rSampleSlider.Value,
                                            (byte)gSampleSlider.Value, (byte)bSampleSlider.Value));

        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            ListBox.Items.Add(new MyColor {
                Color = Color.FromRgb((byte)rSampleSlider.Value,
                                      (byte)gSampleSlider.Value,
                                      (byte)bSampleSlider.Value)
            });
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            

        }

    }
}

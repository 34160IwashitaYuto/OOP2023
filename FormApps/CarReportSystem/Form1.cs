using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //管理用データ
        BindingList<CarReport> CarReports = new BindingList<CarReport>();


        public Form1() {
            InitializeComponent();
            dgvCarReports.DataSource = CarReports;
        }

        //追加ボタンがクリックされた時のイベントハンドラー
        private void btAddReport_Click(object sender, EventArgs e) {
            var CarReport = new CarReport
            {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = GetSelectedMaker(),
                CarName = cbCarName.Name,
                CarImage = pbCarImage.Image,
            };
            CarReports.Add(CarReport);

        }

        private CarReport.MakerGroup GetSelectedMaker() {
            foreach (var item in gbMaker.Controls)
            {
                if (((RadioButton)item).Checked)
                {
                    Tag = int.Parse(((RadioButton)item).Tag.ToString());
                }
            }
            return CarReport.MakerGroup.その他;
        }

        private void btImageOpen_Click(object sender, EventArgs e) {
            ofdImageFileOpen.ShowDialog();
            pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
        }

        private void Form1_Load(object sender,EventArgs e) {
            
            dgvCarReports.Columns[5].Visible = false;   // 画像項目非表示
        }

        private void btDeleteReport_Clic(object sender,EventArgs e) {
            CarReport.RemoveAt(dgvCarReports.CurrentRow);
        }
    }
}

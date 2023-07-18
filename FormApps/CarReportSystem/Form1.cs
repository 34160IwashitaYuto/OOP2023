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

        //ステータスラベルのテキスト表示・非表示
        private void statasLabelDisp(string msg = "") {
            tsInfoText.Text = msg;
        }


        //追加ボタンがクリックされた時のイベントハンドラー
        private void btAddReport_Click(object sender, EventArgs e) {
            statasLabelDisp();
            if (cbAuthor.Text.Equals(""))
            {
                tsInfoText.Text = "記録者を入力してください";
                return;
            }else if(cbCarName.Text.Equals("")){
                tsInfoText.Text = "車名を入力してください";
                return;
            }
            else
            {
                statasLabelDisp(""); 
            }
                
            var CarReport = new CarReport
            {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = GetSelectedMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                CarImage = pbCarImage.Image,
            };

            CarReports.Add(CarReport);
            btModifyReport.Enabled = true;
            btDeleteReport.Enabled = true;
            if (!cbAuthor.Items.Contains(cbAuthor.Text))
            {
                cbAuthor.Items.Add(cbAuthor.Text);
            }
            if (!cbCarName.Items.Contains(cbCarName.Text))
            {
                cbCarName.Items.Add(cbCarName.Text);
            }


        }


        //選択されているメーカーを返却
        private CarReport.MakerGroup GetSelectedMaker() {
            foreach (var item in gbMaker.Controls)
            {
                if (((RadioButton)item).Checked)
                {
                    Tag = int.Parse(((RadioButton)item).Tag.ToString());
                    return (CarReport.MakerGroup)Tag;
                }
            }
            return CarReport.MakerGroup.その他;
        }


        //指定したラジオボタンをセット
        private void setSelectedMaker(CarReport.MakerGroup makerGroup) {
            switch (makerGroup)
            {
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.スズキ:
                    rbSuzuki.Checked = true;
                    break;
                case CarReport.MakerGroup.ダイハツ:
                    rbDaihatu.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                case CarReport.MakerGroup.その他:
                    rbOther.Checked = true;
                    break;
                default:
                    break;
            }
        }


        private void btImageOpen_Click(object sender, EventArgs e) {
            ofdImageFileOpen.ShowDialog();
            pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
        }

        private void Form1_Load(object sender,EventArgs e) {
            dgvCarReports.Columns[5].Visible = false;   // 画像項目非表示
            btModifyReport.Enabled = false; //マスクする
        }

        private void Form1_Load2(object sender, EventArgs e) {
            dgvCarReports.Columns[5].Visible = false;   // 画像項目非表示
            btDeleteReport.Enabled = false; //マスクする
        }

        //削除ボタンイベントハンドラ
        private void btDeleteReport_Click(object sender,EventArgs e) {
            CarReports.RemoveAt(dgvCarReports.CurrentRow.Index);
            if(CarReports.Count() == 0){
                btDeleteReport.Enabled = false;
                btModifyReport.Enabled = false; 
            }
            
        }

        //レコートの選択時
        private void dgvCarReports_Click(object sender,EventArgs e) {
            dtpDate.Value = (DateTime)dgvCarReports.CurrentRow.Cells[0].Value;
            cbAuthor.Text = dgvCarReports.CurrentRow.Cells[1].Value.ToString();
            setSelectedMaker((CarReport.MakerGroup)dgvCarReports.CurrentRow.Cells[2].Value);
            cbCarName.Text = dgvCarReports.CurrentRow.Cells[3].Value.ToString();
            tbReport.Text = dgvCarReports.CurrentRow.Cells[4].Value.ToString();
            pbCarImage.Image = (Image)dgvCarReports.CurrentRow.Cells[5].Value;

            btModifyReport.Enabled = true;  //修正ボタン
            btDeleteReport.Enabled = true;  //削除ボタン
                
        }
        private void btModifyReport_Click(object sender,EventArgs e) {
            if (dgvCarReports.Rows.Count != 0)
            {
                CarReports[dgvCarReports.CurrentRow.Index].Date = dtpDate.Value;
                CarReports[dgvCarReports.CurrentRow.Index].Author = cbAuthor.Text;
                CarReports[dgvCarReports.CurrentRow.Index].Maker = GetSelectedMaker();
                CarReports[dgvCarReports.CurrentRow.Index].CarName = cbCarName.Text;
                CarReports[dgvCarReports.CurrentRow.Index].Report = tbReport.Text;
                dgvCarReports.Refresh();

            }
        }

        

        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e) {
            var vf = new VersionForm();
            vf.ShowDialog();    //モーダイヤログとして表示
        }
    }
}

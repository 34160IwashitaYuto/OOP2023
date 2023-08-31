using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public partial class Form1 : Form {

        private int mode = 0;
        //管理用データ
        BindingList<CarReport> CarReports = new BindingList<CarReport>();

        //設定情報保存用オブジェクト
        Settings settings = new Settings(); 

        public Form1() {
            InitializeComponent();
            dgvCarReports.DataSource = CarReports;
        }

        //ステータスラベルのテキスト表示・非表示
        private void statasLabelDisp(string msg = "") {
            tsTimeDisp.Text = msg;
        }


        //追加ボタンがクリックされた時のイベントハンドラー
        private void btAddReport_Click(object sender, EventArgs e) {
            statasLabelDisp();
            if (cbAuthor.Text.Equals(""))
            {
                tsTimeDisp.Text = "記録者を入力してください";
                return;
            }else if(cbCarName.Text.Equals("")){
                tsTimeDisp.Text = "車名を入力してください";
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

           
        }
    //記録者コンボボックスの履歴登録処理
        private void setCbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author))
                    {
                    cbAuthor.Items.Add(author);
                    }
        }


        //車名コンボボックスの履歴登録処理
        private void setCbCarName(string author) {
            if (!cbCarName.Items.Contains(cbCarName.Text)) {
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

            tsInfoText.Text = "";
            tsTimeDisp.Text = DateTime.Now.ToString("HH時mm分ss秒");
            tmTimeUpdate.Start();

            dgvCarReports.Columns[5].Visible = false;   // 画像項目非表示
            btModifyReport.Enabled = false; //マスクする
        }

        private void Form1_Load2(object sender, EventArgs e) {
            dgvCarReports.Columns[5].Visible = false;   // 画像項目非表示
            btDeleteReport.Enabled = false; //マスクする

            try {
                //設定ファイルを逆シリアル化して背景を設定
                using (var reader = XmlReader.Create("settings.xml")) {
                    var serializer = new XmlSerializer(typeof(Settings));
                    settings = serializer.Deserialize(reader) as Settings;
                    BackColor = Color.FromArgb(settings.MainFormColor);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

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

        //修正ボタンイベントハンドラ
        private void btModifyReport_Click(object sender,EventArgs e) {
            if (dgvCarReports.Rows.Count != 0)
            {
                CarReports[dgvCarReports.CurrentRow.Index].Date = dtpDate.Value;
                CarReports[dgvCarReports.CurrentRow.Index].Author = cbAuthor.Text;
                CarReports[dgvCarReports.CurrentRow.Index].Maker = GetSelectedMaker();
                CarReports[dgvCarReports.CurrentRow.Index].CarName = cbCarName.Text;
                CarReports[dgvCarReports.CurrentRow.Index].Report = tbReport.Text;
                dgvCarReports.Refresh();    //一覧更新

            }
        }

        
        //.終了メニュー選択時のイベントハンドラ
        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e) {
            var vf = new VersionForm();
            vf.ShowDialog();    //モーダイヤログとして表示
        }

        private void btImageDelete_Click(object sender , EventArgs s) {
            pbCarImage.Image = null;
        }

        private void カラーToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK)
            {
                BackColor = cdColor.Color;
                settings.MainFormColor = cdColor.Color.ToArgb();
            }
        }

        private void btScaleChange_Click(object sender, EventArgs e) {

            mode = mode < 4 ? ++mode : 0;
            pbCarImage.SizeMode = (PictureBoxSizeMode)mode;

        }

        private void Form1_FormClosed(object sender ,FormClosedEventArgs e) {
            //設定ファイルのシリアル化
            using(var writer = XmlWriter.Create("settings.xml"))
            {
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer,settings);
            }
        }

        private void tmTimeUpdate_Tick(object sender, EventArgs e) {
            tsTimeDisp.Text = DateTime.Now.ToString("yyyy年MM月HH時mm分ss秒");
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            if(sfdCarRepoSave.ShowDialog() == DialogResult.OK) {

                try {
                        //バイナリ形式でシリアル化
                        var bf = new BinaryFormatter();
                        using (FileStream fs = File.Open(sfdCarRepoSave.FileName, FileMode.Create)) {
                            bf.Serialize(fs, CarReports);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            if (ofdCarRepoOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
                    var bf = new BinaryFormatter();
                    using(FileStream fs = File.Open(ofdCarRepoOpen.FileName, FileMode.Open,FileAccess.Read)) {
                        CarReports = (BindingList < CarReport >) bf.Deserialize(fs);
                        dgvCarReports.DataSource = null;
                        dgvCarReports.DataSource = CarReports;

                        
                        dgvCarReports.Columns[5].Visible = false;
                        foreach (var carReport in CarReports) {
                            setCbAuthor(carReport.Author);
                            setCbCarName(carReport.CarName);
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //背景色設定
        private void SetColor_Click(object sender, EventArgs e) {
            if(cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;
                settings.MainFormColor = cdColor.Color.ToArgb();
            }
        }
    }
}

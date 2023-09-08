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
        Settings settings =  Settings.getInstance(); 


        public Form1() {
            InitializeComponent();
            //dgvCarReports.DataSource = CarReports;
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

            DataRow newRow = infosys202318DataSet.CarReportTable.NewRow();

            newRow[1] = dtpDate.Value;
            newRow[2] = cbAuthor.Text;
            newRow[3] = GetSelectedMaker();
            newRow[4] = cbCarName.Text;
            newRow[5] = tbReport.Text;
            newRow[6] = pbCarImage.Image;

            infosys202318DataSet.CarReportTable.Rows.Add(newRow);
            this.carReportTableTableAdapter.Update(infosys202318DataSet.CarReportTable);

            setCbAuthor(cbAuthor.Text);     //記録者コンボボックスの履歴登録処理
            setCbCarName(cbCarName.Text);   //車名コンボボックスの履歴登録処理

            editItemsClear();       //項目クリア処理

            //var CarReport = new CarReport
            //{
            //    Date = dtpDate.Value,
            //    Author = cbAuthor.Text,
            //    Maker = GetSelectedMaker(),
            //    CarName = cbCarName.Text,
            //    Report = tbReport.Text,
            //    CarImage = pbCarImage.Image,
            //};
            //CarReports.Add(CarReport);

            //btModifyReport.Enabled = true;
            //btDeleteReport.Enabled = true;


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

        //項目クリア処理
        private void editItemsClear() {
            cbAuthor.Text = "";
            setSelectedMaker("トヨタ");
            cbCarName.Text = "";
            tbReport.Text = "";
            pbCarImage.Image = null;

            dgvCarReports.ClearSelection();     //選択解除
            btModifyReport.Enabled = false;     //修正ボタン
            btDeleteReport.Enabled = false;     //削除ボタン
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
        private void setSelectedMaker(string makerGroup) {
            switch (makerGroup)
            {
                case "トヨタ":
                    rbToyota.Checked = true;
                    break;
                case "日産":
                    rbNissan.Checked = true;
                    break;
                case "ホンダ":
                    rbHonda.Checked = true;
                    break;
                case "スズキ":
                    rbSuzuki.Checked = true;
                    break;
                case "ダイハツ":
                    rbDaihatu.Checked = true;
                    break;
                case "スバル":
                    rbSubaru.Checked = true;
                    break;
                case "輸入車":
                    rbImport.Checked = true;
                    break;
                case "その他":
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

            dgvCarReports.RowsDefaultCellStyle.BackColor = Color.AliceBlue;//全体に色設定
            dgvCarReports.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;  //奇数行の色を上書き設定

            dgvCarReports.Columns[5].Visible = false;   // 画像項目非表示
            btModifyReport.Enabled = false; //マスクする

            

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
            dgvCarReports.Rows.RemoveAt(dgvCarReports.CurrentRow.Index);
            carReportTableTableAdapter.Update(infosys202318DataSet);
            editItemsClear();            
        }

        //レコートの選択時
        private void dgvCarReports_Click(object sender,EventArgs e) {
           
                
        }

        //修正ボタンイベントハンドラ
        private void btModifyReport_Click(object sender, EventArgs e) {


            //if(dgvCarReports.Rows.Count != 0) {
            dgvCarReports.CurrentRow.Cells[1].Value = dtpDate.Value;
            dgvCarReports.CurrentRow.Cells[2].Value = cbAuthor.Text;
            dgvCarReports.CurrentRow.Cells[3].Value = GetSelectedMaker();
            dgvCarReports.CurrentRow.Cells[4].Value = cbCarName.Text;
            dgvCarReports.CurrentRow.Cells[5].Value = tbReport.Text;
            dgvCarReports.CurrentRow.Cells[6].Value = pbCarImage.Image;

            //CarReports[dgvCarReports.CurrentRow.Index].Date = dtpDate.Value;
            //CarReports[dgvCarReports.CurrentRow.Index].Author = cbAuthor.Text;
            //CarReports[dgvCarReports.CurrentRow.Index].Maker = GetSelectedMaker();
            //CarReports[dgvCarReports.CurrentRow.Index].CarName = cbCarName.Text;
            //CarReports[dgvCarReports.CurrentRow.Index].Report = tbReport.Text;
            //dgvCarReports.Refresh();
            //}

            this.Validate();
            this.carReportTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202318DataSet);
            
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

        private void dgvCarReports_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (dgvCarReports.Rows.Count != 0) {
                dtpDate.Value = (DateTime)dgvCarReports.CurrentRow.Cells[1].Value;
                cbAuthor.Text = dgvCarReports.CurrentRow.Cells[2].Value.ToString();
                setSelectedMaker(dgvCarReports.CurrentRow.Cells[3].Value.ToString());
                cbCarName.Text = dgvCarReports.CurrentRow.Cells[4].Value.ToString();
                tbReport.Text = dgvCarReports.CurrentRow.Cells[5].Value.ToString();

                pbCarImage.Image = !dgvCarReports.CurrentRow.Cells[6].Value.Equals(DBNull.Value) ?
                                    ByteArrayToImage((Byte[])dgvCarReports.CurrentRow.Cells[6].Value) : null;

                //if (!dgvCarReports.CurrentRow.Cells[6].Value.Equals(DBNull.Value)) {
                //    pbCarImage.Image = ByteArrayToImage((Byte[])dgvCarReports.CurrentRow.Cells[6].Value);
                //}else {
                //    pbCarImage.Image = null;
                //}

                btModifyReport.Enabled = true;  //修正ボタン有効
                btDeleteReport.Enabled = true;  //削除ボタン有効
            }
        }

        // バイト配列をImageオブジェクトに変換
        public static Image ByteArrayToImage(byte[] b) {
            ImageConverter imgconv = new ImageConverter();
            Image img = (Image)imgconv.ConvertFrom(b);
            return img;
        }

        // Imageオブジェクトをバイト配列に変換
        public static byte[] ImageToByteArray(Image img) {
            ImageConverter imgconv = new ImageConverter();
            byte[] b = (byte[])imgconv.ConvertTo(img, typeof(byte[]));
            return b;
        }


        private void carReportTableBindingNavigatorSaveItem_Click(object sender, EventArgs e) { 
            this.carReportTableBindingSource.EndEdit();

        }

        //接続ボタンイベントハンドラ
        private void btConnection_Click(object sender, EventArgs e) {
            // TODO: このコード行はデータを 'infosys202318DataSet.CarReportTable' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.carReportTableTableAdapter.Fill(this.infosys202318DataSet.CarReportTable);
            dgvCarReports.ClearSelection(); //選択解除
        }

        
    }
}
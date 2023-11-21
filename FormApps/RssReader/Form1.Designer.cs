
namespace RssReader {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.btGet = new System.Windows.Forms.Button();
            this.lbRssTitle = new System.Windows.Forms.ListBox();
            this.wbBrowser = new System.Windows.Forms.WebBrowser();
            this.cbUrl = new System.Windows.Forms.ComboBox();
            this.CollectionButton = new System.Windows.Forms.Button();
            this.rbMain = new System.Windows.Forms.RadioButton();
            this.rbDomestic = new System.Windows.Forms.RadioButton();
            this.rbinternationall = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbeconomy = new System.Windows.Forms.RadioButton();
            this.CollectionBox = new System.Windows.Forms.ComboBox();
            this.CollectionList = new System.Windows.Forms.Label();
            this.URL = new System.Windows.Forms.Label();
            this.CollectionAllClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btGet
            // 
            this.btGet.Location = new System.Drawing.Point(598, 30);
            this.btGet.Name = "btGet";
            this.btGet.Size = new System.Drawing.Size(66, 23);
            this.btGet.TabIndex = 1;
            this.btGet.Text = "取得";
            this.btGet.UseVisualStyleBackColor = true;
            this.btGet.Click += new System.EventHandler(this.btGet_Click);
            // 
            // lbRssTitle
            // 
            this.lbRssTitle.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbRssTitle.FormattingEnabled = true;
            this.lbRssTitle.ItemHeight = 16;
            this.lbRssTitle.Location = new System.Drawing.Point(222, 104);
            this.lbRssTitle.Name = "lbRssTitle";
            this.lbRssTitle.Size = new System.Drawing.Size(542, 180);
            this.lbRssTitle.TabIndex = 2;
            this.lbRssTitle.Click += new System.EventHandler(this.lbRssTitle_Click);
            // 
            // wbBrowser
            // 
            this.wbBrowser.Location = new System.Drawing.Point(12, 307);
            this.wbBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbBrowser.Name = "wbBrowser";
            this.wbBrowser.Size = new System.Drawing.Size(746, 392);
            this.wbBrowser.TabIndex = 3;
            // 
            // cbUrl
            // 
            this.cbUrl.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cbUrl.FormattingEnabled = true;
            this.cbUrl.Location = new System.Drawing.Point(31, 30);
            this.cbUrl.Name = "cbUrl";
            this.cbUrl.Size = new System.Drawing.Size(546, 23);
            this.cbUrl.TabIndex = 4;
            // 
            // CollectionButton
            // 
            this.CollectionButton.Location = new System.Drawing.Point(683, 30);
            this.CollectionButton.Name = "CollectionButton";
            this.CollectionButton.Size = new System.Drawing.Size(89, 23);
            this.CollectionButton.TabIndex = 6;
            this.CollectionButton.Text = "お気に入り追加";
            this.CollectionButton.UseVisualStyleBackColor = true;
            this.CollectionButton.Click += new System.EventHandler(this.CollectionButton_Click);
            // 
            // rbMain
            // 
            this.rbMain.AutoSize = true;
            this.rbMain.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbMain.Location = new System.Drawing.Point(6, 28);
            this.rbMain.Name = "rbMain";
            this.rbMain.Size = new System.Drawing.Size(55, 19);
            this.rbMain.TabIndex = 8;
            this.rbMain.TabStop = true;
            this.rbMain.Text = "主要";
            this.rbMain.UseVisualStyleBackColor = true;
            this.rbMain.CheckedChanged += new System.EventHandler(this.rbMain_CheckedChanged);
            // 
            // rbDomestic
            // 
            this.rbDomestic.AutoSize = true;
            this.rbDomestic.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbDomestic.Location = new System.Drawing.Point(6, 64);
            this.rbDomestic.Name = "rbDomestic";
            this.rbDomestic.Size = new System.Drawing.Size(55, 19);
            this.rbDomestic.TabIndex = 9;
            this.rbDomestic.TabStop = true;
            this.rbDomestic.Text = "国内";
            this.rbDomestic.UseVisualStyleBackColor = true;
            this.rbDomestic.CheckedChanged += new System.EventHandler(this.rbDomestic_CheckedChanged);
            // 
            // rbinternationall
            // 
            this.rbinternationall.AutoSize = true;
            this.rbinternationall.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbinternationall.Location = new System.Drawing.Point(6, 101);
            this.rbinternationall.Name = "rbinternationall";
            this.rbinternationall.Size = new System.Drawing.Size(55, 19);
            this.rbinternationall.TabIndex = 10;
            this.rbinternationall.TabStop = true;
            this.rbinternationall.Text = "国際";
            this.rbinternationall.UseVisualStyleBackColor = true;
            this.rbinternationall.CheckedChanged += new System.EventHandler(this.rbinternationall_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbeconomy);
            this.groupBox1.Controls.Add(this.rbinternationall);
            this.groupBox1.Controls.Add(this.rbDomestic);
            this.groupBox1.Controls.Add(this.rbMain);
            this.groupBox1.Location = new System.Drawing.Point(18, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 184);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // rbeconomy
            // 
            this.rbeconomy.AutoSize = true;
            this.rbeconomy.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbeconomy.Location = new System.Drawing.Point(6, 136);
            this.rbeconomy.Name = "rbeconomy";
            this.rbeconomy.Size = new System.Drawing.Size(55, 19);
            this.rbeconomy.TabIndex = 11;
            this.rbeconomy.TabStop = true;
            this.rbeconomy.Text = "経済";
            this.rbeconomy.UseVisualStyleBackColor = true;
            this.rbeconomy.CheckedChanged += new System.EventHandler(this.rbeconomy_CheckedChanged);
            // 
            // CollectionBox
            // 
            this.CollectionBox.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CollectionBox.FormattingEnabled = true;
            this.CollectionBox.Location = new System.Drawing.Point(31, 74);
            this.CollectionBox.Name = "CollectionBox";
            this.CollectionBox.Size = new System.Drawing.Size(546, 23);
            this.CollectionBox.TabIndex = 10;
            this.CollectionBox.SelectedIndexChanged += new System.EventHandler(this.CollectionBox_SelectedIndexChanged);
            // 
            // CollectionList
            // 
            this.CollectionList.AutoSize = true;
            this.CollectionList.Location = new System.Drawing.Point(29, 59);
            this.CollectionList.Name = "CollectionList";
            this.CollectionList.Size = new System.Drawing.Size(80, 12);
            this.CollectionList.TabIndex = 11;
            this.CollectionList.Text = "お気に入りリスト";
            // 
            // URL
            // 
            this.URL.AutoSize = true;
            this.URL.Location = new System.Drawing.Point(31, 12);
            this.URL.Name = "URL";
            this.URL.Size = new System.Drawing.Size(27, 12);
            this.URL.TabIndex = 12;
            this.URL.Text = "URL";
            // 
            // CollectionAllClear
            // 
            this.CollectionAllClear.Location = new System.Drawing.Point(598, 74);
            this.CollectionAllClear.Name = "CollectionAllClear";
            this.CollectionAllClear.Size = new System.Drawing.Size(102, 23);
            this.CollectionAllClear.TabIndex = 13;
            this.CollectionAllClear.Text = "お気に入り全削除";
            this.CollectionAllClear.UseVisualStyleBackColor = true;
            this.CollectionAllClear.Click += new System.EventHandler(this.CollectionDrop_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 711);
            this.Controls.Add(this.CollectionAllClear);
            this.Controls.Add(this.URL);
            this.Controls.Add(this.CollectionList);
            this.Controls.Add(this.CollectionBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CollectionButton);
            this.Controls.Add(this.cbUrl);
            this.Controls.Add(this.wbBrowser);
            this.Controls.Add(this.lbRssTitle);
            this.Controls.Add(this.btGet);
            this.Name = "Form1";
            this.Text = "Rss";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btGet;
        private System.Windows.Forms.ListBox lbRssTitle;
        private System.Windows.Forms.WebBrowser wbBrowser;
        private System.Windows.Forms.ComboBox cbUrl;
        private System.Windows.Forms.Button CollectionButton;
        private System.Windows.Forms.RadioButton rbMain;
        private System.Windows.Forms.RadioButton rbDomestic;
        private System.Windows.Forms.RadioButton rbinternationall;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CollectionBox;
        private System.Windows.Forms.Label CollectionList;
        private System.Windows.Forms.Label URL;
        private System.Windows.Forms.Button CollectionAllClear;
        private System.Windows.Forms.RadioButton rbeconomy;
    }
}


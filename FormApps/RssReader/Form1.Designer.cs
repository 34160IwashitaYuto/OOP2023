
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Collection = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btGet
            // 
            this.btGet.Location = new System.Drawing.Point(702, 12);
            this.btGet.Name = "btGet";
            this.btGet.Size = new System.Drawing.Size(75, 30);
            this.btGet.TabIndex = 1;
            this.btGet.Text = "取得";
            this.btGet.UseVisualStyleBackColor = true;
            this.btGet.Click += new System.EventHandler(this.btGet_Click);
            // 
            // lbRssTitle
            // 
            this.lbRssTitle.FormattingEnabled = true;
            this.lbRssTitle.ItemHeight = 12;
            this.lbRssTitle.Location = new System.Drawing.Point(31, 48);
            this.lbRssTitle.Name = "lbRssTitle";
            this.lbRssTitle.Size = new System.Drawing.Size(746, 184);
            this.lbRssTitle.TabIndex = 2;
            // 
            // wbBrowser
            // 
            this.wbBrowser.Location = new System.Drawing.Point(31, 237);
            this.wbBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbBrowser.Name = "wbBrowser";
            this.wbBrowser.Size = new System.Drawing.Size(746, 392);
            this.wbBrowser.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "https://news.yahoo.co.jp/rss/topics/top-picks.xml",
            "https://news.yahoo.co.jp/rss/topics/domestic.xml",
            "https://news.yahoo.co.jp/rss/topics/world.xml"});
            this.comboBox1.Location = new System.Drawing.Point(31, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(665, 20);
            this.comboBox1.TabIndex = 4;
            // 
            // Collection
            // 
            this.Collection.FormattingEnabled = true;
            this.Collection.Location = new System.Drawing.Point(31, 648);
            this.Collection.Name = "Collection";
            this.Collection.Size = new System.Drawing.Size(331, 20);
            this.Collection.TabIndex = 5;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 689);
            this.Controls.Add(this.Collection);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.wbBrowser);
            this.Controls.Add(this.lbRssTitle);
            this.Controls.Add(this.btGet);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btGet;
        private System.Windows.Forms.ListBox lbRssTitle;
        private System.Windows.Forms.WebBrowser wbBrowser;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox Collection;
    }
}


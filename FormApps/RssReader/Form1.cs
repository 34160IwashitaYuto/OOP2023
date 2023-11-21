using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {
        //取得データ保存用
        List<ItemData> ItemDatas = new List<ItemData>();
        List<ItemData> nodes;
        List<ItemData> Titlenames = new List<ItemData> {
                new ItemData{Title = "主要", Link = "https://news.yahoo.co.jp/rss/topics/top-picks.xml"},
                new ItemData{Title = "国内", Link = "https://news.yahoo.co.jp/rss/topics/domestic.xml"},
                new ItemData{Title = "国際", Link = "https://news.yahoo.co.jp/rss/topics/world.xml"},
                new ItemData{Title = "経済", Link = "https://news.yahoo.co.jp/rss/topics/business.xml"},
                new ItemData{Title = "エンタメ", Link = "https://news.yahoo.co.jp/rss/topics/entertainment.xml"},
                new ItemData{Title = "スポーツ",  Link = "https://news.yahoo.co.jp/rss/topics/sports.xml"},
                new ItemData{Title = "IT", Link = "https://news.yahoo.co.jp/rss/topics/it.xml"},
                new ItemData{Title = "科学", Link = "https://news.yahoo.co.jp/rss/topics/science.xml"},
                new ItemData{Title = "地域", Link = "https://news.yahoo.co.jp/rss/topics/local.xml"}
            };

        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {

            if(cbUrl.Text == "") {
                return;
            }

            lbRssTitle.Items.Clear();   //リストボックスクリア

            using (var wc = new WebClient()) {
                if (cbUrl.Text.Equals("")) {
                    return;
                }
                else {
                    var url = wc.OpenRead(cbUrl.Text);

                    XDocument xdoc = XDocument.Load(url);



                    nodes = xdoc.Root.Descendants("item")
                                           .Select(x => new ItemData {
                                               Title = (string)x.Element("title"),
                                               Link = (string)x.Element("link")
                                           }).ToList();

                    ItemDatas = (List<ItemData>)nodes;


                    foreach (var node in nodes) {
                        lbRssTitle.Items.Add(node.Title);
                    }
                }
            }
 
        }

        private void lbRssTitle_Click(object sender, EventArgs e) {
            if (lbRssTitle.SelectedItem == null) return;
            {
                wbBrowser.Navigate((nodes[lbRssTitle.SelectedIndex]).Link);
            }
        }

        //お気に入り追加
        private void CollectionButton_Click(object sender, EventArgs e) {
            if (CollectionBox.Items.Cast<ItemData>().Select(i => i.Title).Contains(Titlenames.Cast<ItemData>().Where(i => i.Link == cbUrl.Text).First().Title)) return;
            CollectionBox.Items.Add(new ItemData { Title = Titlenames.Where(i => i.Link == cbUrl.Text).Select(i => i.Title)?.First(), Link = cbUrl.Text });
        }

        //お気に入り全削除
        private void CollectionDrop_Click(object sender, EventArgs e) {
            CollectionBox.Items.Clear();
        }

        //お気に入りリストから選択
        private void CollectionBox_SelectedIndexChanged(object sender, EventArgs e) {
            cbUrl.Text = ((ItemData)(CollectionBox.Items[CollectionBox.SelectedIndex])).Link;
        }

        //タイトル一覧表示
        private void rbMain_CheckedChanged(object sender, EventArgs e) {
            cbUrl.Text = "https://news.yahoo.co.jp/rss/topics/top-picks.xml";
        }

        private void rbDomestic_CheckedChanged(object sender, EventArgs e) {
            cbUrl.Text = "https://news.yahoo.co.jp/rss/topics/domestic.xml";
        }

        private void rbinternationall_CheckedChanged(object sender, EventArgs e) {
            cbUrl.Text = "https://news.yahoo.co.jp/rss/topics/world.xml";
        }

        private void rbeconomy_CheckedChanged(object sender, EventArgs e) {
            cbUrl.Text = "https://news.yahoo.co.jp/rss/topics/business.xml";
        }
    }
}

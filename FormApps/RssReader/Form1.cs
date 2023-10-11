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
        

        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {

            if(tbUrl.Text == "") {
                return;
            }

            lbRssTitle.Items.Clear();   //リストボックスクリア

            using (var wc = new WebClient()) {
                var url = wc.OpenRead(tbUrl.Text);


                XDocument xdoc = XDocument.Load(url);

                var nodes = xdoc.Root.Descendants("item")
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
}

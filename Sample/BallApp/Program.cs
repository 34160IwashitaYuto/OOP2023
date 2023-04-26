using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BallApp {
    class Program :Form{

        Bar bar;            //Barインスタンス格納
        PictureBox pbBar;   //Bar表示用

        private Timer moveTimer;    //タイマー用
        private Obj obj;

        private List<Obj> balls = new List<Obj>();    //ボールインスタンス格納用
        private List<PictureBox> pbs = new List<PictureBox>();  //表示用

        private int cnt = 0;

        static void Main(string[] args) {
            Application.Run(new Program());
        }

        public Program() {
 
            this.Size = new Size(800, 600);
            this.BackColor = Color.Green;

            this.MouseClick += Program_MouseClick;
            this.KeyDown += Program_KeyDown;

            //Barインスタンス生成
            bar = new Bar(330, 500);
            pbBar = new PictureBox();
            pbBar.Image = bar.Image;
            pbBar.Location = new Point((int)bar.PosX, (int)bar.PosY);
            pbBar.Size = new Size(150, 10);
            pbBar.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBar.Parent = this;

            moveTimer = new Timer();
            moveTimer.Interval = 10; //タイマーのインターバル(ms)
            moveTimer.Tick += MoveTimer_Tick;   //デリゲート登録
        }

        //キーが押された時のイベントハンドラ
        private void Program_KeyDown(object sender, KeyEventArgs e) {
            bar.Move(e.KeyData);
            pbBar.Location = new Point((int)bar.PosX, (int)bar.PosY);

        }



        //マウスクリック時のイベントハンドラ
        private PictureBox pb;
        private void Program_MouseClick(object sender, MouseEventArgs e) {
            //ボールインスタンス生成
            pb = new PictureBox();   //画像を表示するコントロール
            if (e.Button == MouseButtons.Right)
            {
                obj = new SoccerBall(e.X - 25, e.Y - 25);
                pb.Size = new Size(50, 50); //画像の表示サイズ
            }

            else if (e.Button == MouseButtons.Left)
            {
                obj = new TennisBall(e.X - 25, e.Y - 25);
                pb.Size = new Size(25, 25); //画像の表示サイズ
            }
               
                pb.Image = obj.Image;
                pb.Location = new Point((int)obj.PosX, (int)obj.PosY);    //画像の位置
                
                pb.SizeMode = PictureBoxSizeMode.StretchImage;  //画像の表示モード
                pb.Parent = this;
                balls.Add(obj);
                pbs.Add(pb);

           
            

            this.Text = "BallGame " + "サッカーボール:" + SoccerBall.Count + "個 テニスボール:" + TennisBall.Count + "個";
            

            moveTimer.Start();  //タイマースタート
        }

        private void MoveTimer_Tick(object sender, EventArgs e) {

            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].Move(pbBar,pbs[i]);  //移動
                pbs[i].Location = new Point((int)balls[i].PosX, (int)balls[i].PosY);    //画像の位置
            }
        }
    }
}

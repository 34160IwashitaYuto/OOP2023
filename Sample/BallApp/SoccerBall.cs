using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    class SoccerBall {
        //フィールド
        private Image image;    //画像データ


        private double posX;    //x座表
        private double posY;    //y座表

        private double moveX = 15.0;//移動量
        private double moveY = 15.0;

        public SoccerBall() {
            Image = Image.FromFile(@"pic\soccer_ball.png");
            PosX = 0.0;
            PosY = 0.0;
            
        }

        //プロパティ
        public double PosX { get => posX; set => posX = value; }
        public double PosY { get => posY; set => posY = value; }
        public Image Image { get => image; set => image = value; }

        //メソッド
        public void Move() {

            Console.WriteLine("posX = {0},posY = {1}",posX,posY);

            if (posY > 550 || posY < 0)
            {
                moveY = -moveY;
            }

            if (posX > 720 || posX < 0)
            {
                moveX = -moveX;
            }

            posX += moveX;
            posY += moveY;

            
            
 
        }
    }
}

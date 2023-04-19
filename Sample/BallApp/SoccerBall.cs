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

        private double moveX;//移動量
        private double moveY;//移動量

        public SoccerBall(double xp,double yp) {
            Random random = new Random();
            Image = Image.FromFile(@"pic\soccer_ball.png");
            PosX = xp;
            PosY = yp;


            int rndX = random.Next(-15, 15);
            moveX = (rndX != 0 ? rndX : 1);
            int rndY = random.Next(-15, 15);
            moveX = (rndY != 0 ? rndY : 1);

          
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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {

    class SoccerBall : Obj{

        

        //フィールド


        Random random = new Random();

        private static int count;

        //プロパティ


        //コンストラクタ
        public SoccerBall(double xp,double yp)
            :base(xp,yp, @"pic\soccer_ball.png") {
            
            int rndX = random.Next(-25, 25);
            MoveX = (rndX != 0 ? rndX : 1);
            int rndY = random.Next(-25, 25);
            MoveY = (rndY != 0 ? rndY : 1);
            Count++;
        }

        public static int Count { get => count; set => count = value; }

        //メソッド
        public override void Move() {

            Console.WriteLine("posX = {0},posY = {1}",PosX,PosY);

            if (PosY > 550 || PosY < 0)
            {
                MoveY = -MoveY;
            }

            if (PosX > 720 || PosX < 0)
            {
                MoveX = -MoveX;
            }

            PosX += MoveX;
            PosY += MoveY;

        }
    }

}

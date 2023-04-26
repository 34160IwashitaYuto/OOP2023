using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    class TennisBall : Obj {

        private static int count;


        Random random = new Random();   //乱数のインスタンス

        public TennisBall(double xp, double yp)
           : base(xp, yp, @"pic\tennis_ball.png") {

            int rndX = random.Next(-25, 25);
            MoveX = (rndX != 0 ? rndX : 1);
            int rndY = random.Next(-25, 25);
            MoveY = (rndY != 0 ? rndY : 1);
            Count++;
        }

        public static int Count { get => count; set => count = value; }

        //メソッド
        public override void Move() {

            //Console.WriteLine("posX = {0},posY = {1}", PosX, PosY);

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

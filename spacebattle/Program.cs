using System;

namespace spacebattle{

    public class Move
    {
        public static double[] ConstantMotion(double x, double y, double sp_x, double sp_y, double MotionExist){
            double [] newPos = new double[2];
            if (MotionExist == 0 || x == double.NaN ) 
            {
                throw new Exception();
            }
            else
            {
                newPos[0] = x + sp_x;
                newPos[1] = y + sp_y;
            }
            return newPos;
        }
    }
}
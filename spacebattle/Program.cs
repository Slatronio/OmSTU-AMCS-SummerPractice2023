using System;

namespace spacebattle{

    public class Move
    {
        public static double[] ConstantMotion(double x, double y, double sp_x, double sp_y, double MotionExist)
        {
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
        public static double Fuel(double start_fuel, double fuelPerLine)
        {
            double end_fuel = 0;
            if (start_fuel < fuelPerLine){
                throw new Exception();
            }
            else{
                end_fuel = start_fuel - fuelPerLine;
            }
            return end_fuel;
        }
        public static double Angle(double start_angle, double angle_speed)
        {
            double end_angle = start_angle+angle_speed;
            return end_angle;
        }
    }
}
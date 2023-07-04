namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double eps = Math.Pow(10,-9);
        double[] answ = new double[0];

        if (Math.Abs(a) < eps || Double.IsNaN(a) || Double.IsPositiveInfinity(a) || Double.IsNegativeInfinity(a)) 
        {
            throw new System.ArgumentException();
        }
        if (Double.IsNaN(b) || Double.IsPositiveInfinity(b) || Double.IsNegativeInfinity(b)) 
        {
            throw new System.ArgumentException();
        }
        if (Double.IsNaN(c) || Double.IsPositiveInfinity(c) || Double.IsNegativeInfinity(c)) 
        {
            throw new System.ArgumentException();
        }

        double D = Math.Pow(b, 2) - (4*a*c);
        if (-eps < D && D < eps)
        {
            answ = new double[1];
            answ[0] = (-b) / (2 * a);
        }
        if (D >= eps) 
        {
            answ = new double[2];
            answ[0] = -(b + Math.Sign(b) * Math.Sqrt(D)) / 2;
            answ[1] = c / answ[0];
            answ[0] = answ[0] / a;
            if (-eps < b && b < eps)
            {
                answ[0] = Math.Sqrt(-c/a);
                answ[1] = -answ[0];
            }
        }
        return answ;
    }
}

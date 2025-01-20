using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalculatorDZ.Pages
{
    public class IndexModel : PageModel
    {
        public double A {  get; private set; }
        public double B { get; private set; }

        public double C { get; private set; }
        public double Angle {  get; private set; }
        public string AngleeUnit { get; private set; } = string.Empty;
        public string? Error {  get; private set; }

        public void OnGet(double c ,double a,double b,double angle, string angleUnit="rad")
        {
            A = a;
            B = b;
            C = c;
            Angle = angle;
            AngleeUnit = angleUnit;

            if (a == 0 || b == 0 || angle == 0)
            {
                Error = "Значение не может быть равным 0!";
            }
            Error = null;


            if (a < 0 || b < 0 || angle < 0)
            {
                Error = "Значения параметров должны быть положительными!";
            }
            Error = null;


            if(angleUnit=="deg")
            {
                Angle *= (Math.PI / 180);
            }
            C = side(A, B, Angle);
        }

        private double side(double a, double b, double angle)
        {
            double result;

            result=Math.Sqrt(a*a+b*b-2*a*b*Math.Cos(angle));

            return result;
        }

        
    }
}

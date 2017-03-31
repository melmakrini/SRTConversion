using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConversionSRT
{
    public class Ellipse
    {
        /* Demi-grand axe (m)*/
        double a;

        public double A
        {
            get { return a; }
        }
        
        /* Aplatissement*/
        double f;

        public double F
        {
            get { return f; }          
        }

        public Ellipse(double _a, double _f)
        {
            a = _a;
            f = _f;
        }
        /// <summary>
        /// /*Première excentricité*/
        /// </summary>
        /// 
        /// <returns></returns>
        public double E()
        {
            return Math.Sqrt((1 - Math.Pow(B()/a, 2)));
        }
        /// <summary>
        /// /* Demi-petit axe (m)*/
        /// </summary>
        /// <returns></returns>
        public double B()
        {
            return a * (1.0 - f);
        }
    }
}

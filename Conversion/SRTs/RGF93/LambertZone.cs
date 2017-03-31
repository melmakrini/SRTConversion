using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConversionSRT
{
    public class LambertZone
    {
        double n;

        public double N
        {
            get { return n; }
            set { n = value; }
        }
        double c;

        public double C
        {
            get { return c; }
            set { c = value; }
        }
        double x_S;

        public double X_S
        {
            get { return x_S; }
            set { x_S = value; }
        }
        double y_S;

        public double Y_S
        {
            get { return y_S; }
            set { y_S = value; }
        }
        double lambda0;

        public double Lambda0
        {
            get { return lambda0; }
            set { lambda0 = value; }
        }

        public LambertZone(double _n, double _c, double _x_s, double _y_s,  double _lambda0)
        {
            n = _n;
            c = _c;
            x_S = _x_s;
            y_S = _y_s;
            lambda0 = _lambda0;
        }
    }
}

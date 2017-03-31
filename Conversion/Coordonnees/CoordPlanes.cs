using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConversionSRT 
{
   public  class CoordPlanes:Coordonnees
    {
        double x;

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        double y;
 

        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public CoordPlanes(ISRT _srt,double X_2, double Y_2):base(_srt)
        {           
            this.x = X_2;
            this.y = Y_2;
        }

        public override CoordPlanes ToPlanes(ISRT srtDest)
        {
            throw new NotImplementedException();
        }

        public override CoordGeographiques ToGeographiques(ISRT srtDest)
        {
            throw new NotImplementedException();
        }

        public override CoordCartesiennes ToCartesiennes(ISRT srtDest)
        {
            throw new NotImplementedException();
        }
    }
}

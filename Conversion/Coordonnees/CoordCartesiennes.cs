using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ConversionSRT 
{
   public  class CoordCartesiennes:Coordonnees
    {
        double x;
        double y;
        double z;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        public CoordCartesiennes(ISRT _srt):base(_srt)
        {

        }

        public CoordCartesiennes(ISRT _srt, double _x,double  _y,double _z): base(_srt)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public override CoordPlanes ToPlanes(ISRT srtDest)
        {
            if (Referentiel.getSRTName() == srtDest.getSRTName())
            {
                return Referentiel.GeographiquesToPlanes(Referentiel.CartesiennesToGeographiques(this));
            }
            else
            {
               
                
                //TODO 
            }
            return null;
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

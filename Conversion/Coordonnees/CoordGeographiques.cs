using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConversionSRT 
{
   public class CoordGeographiques:Coordonnees
    {
        double lambda;
        double phi;
        double h;

        public double Lambda
        {
            get { return lambda; }
            set { lambda = value; }
        }
        
        public double Phi
        {
            get { return phi; }
            set { phi = value; }
        }
        
        public double H
        {
            get { return h; }
            set { h = value; }
        }

        public CoordGeographiques(ISRT srt):base(srt)
        {
        }
        
        /// <summary>
        /// Coordonnées géographiques
        /// </summary>
        /// <param name="_lambda">longitude</param>
        /// <param name="_phi">latitude</param>
        /// <param name="_h">altitude</param>
        public CoordGeographiques(ISRT _srt,double _lambda, double _phi, double _h=0):base(_srt)
        {
            lambda = _lambda;
            phi = _phi;
            h = _h;
        }


        public override CoordPlanes ToPlanes(ISRT srtDest)
        {
            if (Referentiel.getSRTName() == srtDest.getSRTName())
            {
                return Referentiel.GeographiquesToPlanes(this);
            }
            else
            {

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

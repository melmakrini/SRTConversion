using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConversionSRT 
{
    /// <summary>
    /// 
    /// </summary>
   public class CoordGeographiques:Coordonnees
    {
        double lambda;
        double phi;
        double h;
       /// <summary>
       /// 
       /// </summary>
        public double Lambda
        {
            get { return lambda; }
            set { lambda = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double Phi
        {
            get { return phi; }
            set { phi = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double H
        {
            get { return h; }
            set { h = value; }
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="srt"></param>
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
       /// <summary>
       /// 
       /// </summary>
       /// <param name="srtDest"></param>
       /// <returns></returns>
        public override CoordGeographiques ToGeographiques(ISRT srtDest)
        {
            throw new NotImplementedException();
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="srtDest"></param>
       /// <returns></returns>
        public override CoordCartesiennes ToCartesiennes(ISRT srtDest)
        {
            throw new NotImplementedException();
        }
    }
}

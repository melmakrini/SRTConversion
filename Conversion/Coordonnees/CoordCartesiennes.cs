using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ConversionSRT 
{
    /// <summary>
    /// 
    /// </summary>
   public  class CoordCartesiennes:Coordonnees
    {
        double x;
        double y;
        double z;
       /// <summary>
       /// 
       /// </summary>
        public double X
        {
            get { return x; }
            set { x = value; }
        }
       /// <summary>
       /// 
       /// </summary>
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
       /// <summary>
       /// 
       /// </summary>
        public double Z
        {
            get { return z; }
            set { z = value; }
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="_srt"></param>
        public CoordCartesiennes(ISRT _srt):base(_srt)
        {

        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="_srt"></param>
       /// <param name="_x"></param>
       /// <param name="_y"></param>
       /// <param name="_z"></param>
        public CoordCartesiennes(ISRT _srt, double _x,double  _y,double _z): base(_srt)
        {
            x = _x;
            y = _y;
            z = _z;
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="srtDest"></param>
       /// <returns></returns>
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

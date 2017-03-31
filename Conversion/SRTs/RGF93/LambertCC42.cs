using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConversionSRT
{
    class LambertCC42:GenericSRT
    {
        // Ellipsoïde IAG GRS 80 (associé au référentiel géodésique RGF93)
        /* Demi-grand axe (m)*/
        const double A_GRS80 = 6378137.0f;

        /* Aplatissement*/
        const double F_GRS80 = 1.0f / 298.257222101f;

        // Longitude d'origine = 3° 00' Est Greenwich
        const double LAMBDA_O_LAMBERT93 = (Math.PI / 180) * 3.0f;
        /// <summary>
        /// 
        /// 
        /// 
        /// A corriger 
        /// 
        /// 
        /// </summary>
        public static LambertZone ZONE = new LambertZone(0.7256077650f, 11754255.426f, 700000.0f, 12655612.050f, LAMBDA_O_LAMBERT93);
        public static Ellipse ELLIPSE = new Ellipse(A_GRS80, F_GRS80);


        public LambertCC42(Ellipse _ellipse, LambertZone _zone):base( _ellipse, _zone)
        {
        }
        public override SRTName getSRTName()
        {
            return SRTName.LambertCC42 ;
        }

        public override CoordCartesiennes fromNTF(CoordCartesiennes cart)
        {
            throw new NotImplementedException();
        }

        public override CoordCartesiennes ToNTF(CoordCartesiennes cart)
        {
            throw new NotImplementedException();
        }
    }
}

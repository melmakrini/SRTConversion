using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConversionSRT
{
    public class NTF : GenericSRT
    {
        // Ellipsoïde Clarke 1880 IGN (associé à la NTF)
        /* Demi-grand axe (m)*/
        const double A_CLARKE1880IGN = 6378249.2f;	// Demi-grand axe (m)
       // static const float B_CLARKE1880IGN = 6356515.0f;	// Demi-petit axe (m)

        /* Aplatissement*/
        const double F__CLARKE1880IGN = 1.0 / 293.4660212936;
       
        public static LambertZone ZONE = null;
        public static Ellipse ELLIPSE = new Ellipse(A_CLARKE1880IGN, F__CLARKE1880IGN);

        public NTF()
            : base(ELLIPSE, ZONE)
        {
        }
        public override SRTName getSRTName()
        {
            return SRTName.NTF;
        }

        public override CoordCartesiennes ToNTF(CoordCartesiennes cart)
        {
            return cart;
        }

        public override CoordCartesiennes fromNTF(CoordCartesiennes cart)
        {
            return cart;
        }
    }
}

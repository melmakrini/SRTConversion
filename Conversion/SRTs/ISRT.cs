using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConversionSRT
{
    public interface ISRT
    {
        #region conversion coordonnées
        SRTName getSRTName();
        Ellipse getEllipse();
        CoordCartesiennes   GeographiquesToCartesiennes(CoordGeographiques geo);
        CoordGeographiques  CartesiennesToGeographiques(CoordCartesiennes cart);
        CoordPlanes         GeographiquesToPlanes(CoordGeographiques geo);
        CoordGeographiques  PlanesToGeographiques(CoordPlanes planes);
        CoordCartesiennes   fromNTF(CoordCartesiennes cart);
        CoordCartesiennes   ToNTF(CoordCartesiennes cart);
        #endregion
    }
    
    
}

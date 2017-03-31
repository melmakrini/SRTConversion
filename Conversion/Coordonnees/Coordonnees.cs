using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConversionSRT 
{
	///
	///modif master
	///
    abstract public class Coordonnees
    {
        private ISRT referentiel;

        public ISRT Referentiel
        {
            get { return referentiel; }            
        }
        protected Coordonnees(ISRT _srt)
        {
            referentiel = _srt;
        }
        public abstract CoordPlanes ToPlanes(ISRT srtDest);
        public abstract CoordGeographiques ToGeographiques(ISRT srtDest);
        public abstract CoordCartesiennes ToCartesiennes(ISRT srtDest);
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConversionSRT
{
    /**
     * La source de ces informations est le site http://geodesie.ign.fr/
     * 
     * Le Réseau Géodésique Français 1993
     * 
     * Le RGF93 est un système de référence :
     * - tridimensionnel géocentrique
     * - lié au système de référence mondial ITRS
     * - associé à l'ellipsoïde IAG GRS 1980
     * - ayant pour méridien origine le méridien international (ou méridien de Greenwich)
     * - ayant pour projections associées la projection Lambert-93 et les projections CC 9 Zones
     * - d'exactitude horizontale comprise entre 1 et 2 cm (par rapport aux systèmes mondiaux)
     * - d'exactitude verticale comprise entre 2 et 5 cm (par rapport aux systèmes mondiaux)
     * - adapté aux techniques modernes de positionnement
     * */
    public class Lambert93 : GenericSRT
    {
        // Ellipsoïde IAG GRS 80 (associé au référentiel géodésique RGF93)
        /* Demi-grand axe (m)*/
        const double A_GRS80 = 6378137.0;

        /* Aplatissement*/
        const double F_GRS80 = 1.0 / 298.257222101;

        // NTF->WGS
        double T0_x = -168.0;
        double T0_y = -60.0;
        double T0_z = 320.0;

        // Longitude d'origine = 3° 00' Est Greenwich
        const double LAMBDA_O_LAMBERT93 = (Math.PI / 180) * 3.0f;
        public static LambertZone ZONE = new LambertZone(0.7256077650f, 11754255.426f, 700000.0f, 12655612.050f, LAMBDA_O_LAMBERT93);
        public static Ellipse ELLIPSE = new Ellipse(A_GRS80, F_GRS80);
        public Lambert93()
            : base(ELLIPSE, ZONE)
        {

        }

        public override SRTName getSRTName()
        {
            return SRTName.Lambert93;
        }

        public override CoordCartesiennes fromNTF(CoordCartesiennes cart)
        {
            // NTF->WGS
            double x = cart.X + T0_x;
            double y = cart.Y + T0_y;
            double z = cart.Z + T0_z;
            return new CoordCartesiennes(this, x, y, z);
        }

        public override CoordCartesiennes ToNTF(CoordCartesiennes cart)
        {
            // WGS -> NTF
            double x = cart.X - T0_x;
            double y = cart.Y - T0_y;
            double z = cart.Z - T0_z;
            NTF ntf = new NTF();
            return new CoordCartesiennes(ntf, x, y, z);
        }
    }
}

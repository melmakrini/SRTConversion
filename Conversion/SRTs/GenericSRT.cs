using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConversionSRT
{
    public abstract class GenericSRT : ISRT
    {
       const double DEFAULT_EPSILON = 1e-10f;	// Tolérance de convergence
       
       protected abstract  static LambertZone ZONE;
       protected abstract  Ellipse ELLIPSE; 
       

        protected GenericSRT(Ellipse _ellipse, LambertZone _zone)
        {
            ELLIPSE = _ellipse;
            ZONE = _zone;
        }

        public abstract SRTName getSRTName();
        public abstract CoordCartesiennes fromNTF(CoordCartesiennes cart);
        public abstract  CoordCartesiennes ToNTF(CoordCartesiennes cart);
        

        public CoordCartesiennes GeographiquesToCartesiennes(CoordGeographiques geo)
        {
            
            // Grande normale (m)
            double N = lambertNormal(geo.Phi);

            double elt = (N + geo.H) * Math.Cos(geo.Phi);

            double X = elt * Math.Cos(geo.Lambda);
            double Y = elt * Math.Sin(geo.Lambda);
            double Z = (N * (1.0f - Math.Pow(ELLIPSE.E(), 2)) + geo.H) * Math.Sin(geo.Phi);

            return new CoordCartesiennes(this,X,Y,Z);
        }
        /// <summary>
        /// Transforme, pour un ellipsoïde donné, les coordonnées cartésiennes d'un
        /// point en coordonnées géographiques.
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public CoordGeographiques CartesiennesToGeographiques(CoordCartesiennes cart)
        {
           
            double X2 = Math.Pow(cart.X, 2);
            double Y2 = Math.Pow(cart.Y, 2);
            double Z2 = Math.Pow(cart.Z, 2);
            double mod = Math.Sqrt(X2 + Y2);

            double e2 = Math.Pow(ELLIPSE.E(), 2);
            double e2a = e2 * ELLIPSE.A;

            double f = 1.0f - Math.Sqrt(1.0f - e2);

            double R = Math.Sqrt(X2 + Y2 + Z2);

            double oneMinusF = 1.0f - f;

            double lambda = Math.Atan2(cart.Y, cart.X);

            double mu = Math.Atan((cart.Z / mod) * (oneMinusF + e2a / R));

            double phi = Math.Atan((cart.Z * oneMinusF + e2a * Math.Pow(Math.Sin(mu), 3)) / (oneMinusF * (mod - e2a * Math.Pow(Math.Cos(mu), 3.0f))));

            double sinPhi = Math.Sin(phi);

            double h = mod * Math.Cos(phi) + cart.Z * sinPhi - ELLIPSE.A * Math.Sqrt(1 - e2 * Math.Pow(sinPhi, 2));
            return new CoordGeographiques(this, lambda, phi, h);
        }

        /// <summary>
        ///  Transforme des coordonnées géographiques en coordonnées en projection
        ///  conique conforme de Lambert.
        ///  @remark cf. $3.4 in http://geodesie.ign.fr/contenu/fichiers/documentation/pedagogiques/TransformationsCoordonneesGeodesiques.pdf 
        ///  @remark cf. ALG0003 in http://geodesie.ign.fr/contenu/fichiers/documentation/algorithmes/notice/NTG_71.pdf
        /// </summary>
        /// <param name="geo"></param>
        /// <returns></returns>
        public CoordPlanes GeographiquesToPlanes(CoordGeographiques geo)
        {
            // Paramètres de la projection de Lambert
            double n = ZONE.N;	// Exposant de la projection
            double C = ZONE.C;	// Constante de la projection
            double X_S = ZONE.X_S;	// Coordonnées en
            double Y_S = ZONE.Y_S; // projection du pôle

            // Latitude isométrique (rad)
            double Lambda = isoLatFromLat(geo.Phi);

            double R = C * Math.Exp(-n * Lambda);

            double gamma = n * (geo.Lambda -ZONE.Lambda0);

            double X = X_S + R * Math.Sin(gamma);
            double Y = Y_S - R * Math.Cos(gamma);

            CoordPlanes result = new CoordPlanes(this,X, Y);
            return result;
        }

        public CoordGeographiques PlanesToGeographiques(CoordPlanes plane)
        {
            // Paramètres de la projection de Lambert
            double n = ZONE.N;	// Exposant de la projection
            double C = ZONE.C;	// Constante de la projection
            double X_S = ZONE .X_S;	// Coordonnées en
            double Y_S = ZONE.Y_S; // projection du pôle

            double deltaX = plane.X - X_S;
            double deltaY = plane.Y - Y_S;

            double R = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            double gamma = Math.Atan(deltaX / -deltaY);

            // Latitude isométrique (rad)
            double Lambda = -1.0f / n * Math.Log(Math.Abs(R / C));

            double lambda = ZONE.Lambda0 + gamma / n;
            double phi = latFromIsoLat(Lambda, ELLIPSE.E(), DEFAULT_EPSILON);
            CoordGeographiques result = new CoordGeographiques(this,lambda, phi);
            return result;
        }

        private double lambertNormal(double phi)
        {
            return ELLIPSE.A / Math.Sqrt(1.0f - (Math.Pow(ELLIPSE.E(), 2) * (Math.Pow(Math.Sin(phi), 2))));
        }

        /// <summary>
        /// Calcule la latitude à partir de la latitude isométrique \c Lambda.
        /// @remark cf. $3.5 in http://geodesie.ign.fr/contenu/fichiers/documentation/pedagogiques/TransformationsCoordonneesGeodesiques.pdf
        /// @remark cf. ALG0002 in http://geodesie.ign.fr/contenu/fichiers/documentation/algorithmes/notice/NTG_71.pdf
        /// </summary>
        /// <param name="Lambda"></param>
        /// <param name="e"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        private double latFromIsoLat(double Lambda, double e, double epsilon)
        {
            double expLambda = Math.Exp(Lambda);
            double half_e = 0.5f * e;

            double phi_0 = 2.0f * Math.Atan(Math.Exp(Lambda)) - Math.PI / 2;

            double elt = e * Math.Sin(phi_0);

            double phi_i = 2.0f * Math.Atan(Math.Pow((1.0f + elt) / (1.0f - elt), half_e) * expLambda) - Math.PI / 2;

            double delta = Math.Abs(phi_i - phi_0);

            while (delta > epsilon)
            {
                phi_0 = phi_i;

                elt = e * Math.Sin(phi_0);

                phi_i = 2.0f * Math.Atan(Math.Pow((1.0f + elt) / (1.0f - elt), half_e) * expLambda) - Math.PI / 2;

                delta = Math.Abs(phi_i - phi_0);
            }

            return phi_i;
        }
        /// <summary>
        /// * Calcule la latitude isométrique sur un ellipsoïde de première excentricité \c e au point de latitude \c phi.        
        /// @remark cf. ALG0001 in http://geodesie.ign.fr/contenu/fichiers/documentation/algorithmes/notice/NTG_71.pdf
        /// 
        /// @param[in] phi latitude (rad)
        /// @param[in] e première excentricité de l'ellipsoïde
        /// 
        /// @return Latitude isométrique (rad)
        /// </summary>
        /// <param name="phi"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        double isoLatFromLat(double phi)
        {
            double sinPhi = Math.Sin(phi);
            return Math.Log(Math.Tan(phi / 2.0f + Math.PI / 4) * Math.Pow((1 - ELLIPSE.E() * sinPhi) / (1 + ELLIPSE.E() * sinPhi), ELLIPSE.E() / 2.0f));
        }        
    }
}

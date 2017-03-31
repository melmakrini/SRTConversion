using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConversionSRT.SRTs
{

    /// <summary>
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    ///        A Compléter! Ou pas !
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    public class SRTFactory
    {
        public static ISRT Create(SRTName srtName,LambertZone zone)
        {
            switch (srtName)
            {
                case SRTName.Lambert93:
                    {
                        return new Lambert93();
                
                    }
                case SRTName.LambertCC42:
                    {
                        return null;

                    }
                case SRTName.NTF:
                    {
                        return null;

                    }
            }
            return null;
        }
    }
}

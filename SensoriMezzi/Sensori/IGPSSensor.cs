using SensoriMezzi.Modelli;
using System;
using System.Collections.Generic;
using System.Text;

namespace SensoriMezzi.Sensori
{
    interface IGPSSensor
    {
        string getTimestamp();
        string getGps();
        double[][][] GetPercorso();
        double getLatitudine();
        double getLongitudine();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SensoriMezzi.Modelli
{

    public class Percorso
    {
        public string type { get; set; }
        public Features features { get; set; }
    }

    public class Features
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public double[][][] coordinates { get; set; }
    }

    public class Properties
    {
        public string name { get; set; }
        public string desc { get; set; }
    }

}

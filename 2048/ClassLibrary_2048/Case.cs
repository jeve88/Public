using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_2048
{
    [Serializable]
    public class Cases
    {
        public int saValeur;
        public bool aFusione;
        public Cases()
        {
            saValeur = 0;
            aFusione = false;
        }
    }
}

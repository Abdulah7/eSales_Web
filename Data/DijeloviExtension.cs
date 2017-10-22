using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdajaServis.Data
{
   public partial class Dijelovi
    {
        public override string ToString()
        {
            return Naziv + "-" + Model + "-" + Zalihe + "-" + Cijena;

        }

    }
}

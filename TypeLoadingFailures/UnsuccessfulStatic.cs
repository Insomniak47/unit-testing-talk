using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLoadingFailures
{
    public class UnsuccessfulStatic
    {
        private static readonly ExplodesWhenNull _badInit = new ExplodesWhenNull(null); //Explosion

        public ExplodesWhenNull Explode => _badInit;
    }
}

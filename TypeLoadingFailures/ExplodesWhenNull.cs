using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLoadingFailures
{
    public class ExplodesWhenNull
    {
        private readonly string _explodeString;
        public ExplodesWhenNull(string determinesIfExplodes)
        {
            _explodeString = determinesIfExplodes 
                ?? throw new ArgumentNullException(nameof(determinesIfExplodes));
        }
    }
}

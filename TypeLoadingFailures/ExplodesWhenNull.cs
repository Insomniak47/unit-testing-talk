using System;

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

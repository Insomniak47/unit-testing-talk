using System;
using System.Linq;
using TypeLoadingFailures;

namespace TypeLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            var shouldExplode = args.FirstOrDefault() == "explode";

            if (shouldExplode)
            {
                var explody = new UnsuccessfulStatic();
                _ = explody.Explode;
            }
            else
            {
                var noSplody = new UnsuccessfulStatic();
            }



        }
    }
}

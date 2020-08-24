using System.Linq;
using TypeLoadingFailures;

namespace TypeLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            bool shouldExplode = args.FirstOrDefault() == "explode";

            if (shouldExplode)
            {
                UnsuccessfulStatic explody = new UnsuccessfulStatic();
                _ = explody.Explode;
            }
            else
            {
                UnsuccessfulStatic noSplody = new UnsuccessfulStatic();
            }
        }
    }
}

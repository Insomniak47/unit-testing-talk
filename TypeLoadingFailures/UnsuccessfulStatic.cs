namespace TypeLoadingFailures
{
    public class UnsuccessfulStatic
    {
        private static readonly ExplodesWhenNull _badInit = new ExplodesWhenNull(null); //Explosion

        public ExplodesWhenNull Explode => _badInit;
    }
}

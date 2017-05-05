namespace NewspaperKids.Data
{
    public class Data
    {
        private static NewspaperKidsContext context;

        public static NewspaperKidsContext Context 
            => context ?? (context = new NewspaperKidsContext());
    }
}

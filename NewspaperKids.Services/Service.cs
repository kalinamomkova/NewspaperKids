namespace NewspaperKids.Services
{
    using NewspaperKids.Data;
    using NewspaperKids.Data.Repository;

    public abstract class Service
    {
        protected Service()
        {
            this.Context = new UnitOfWork();
        }

        protected UnitOfWork Context { get; }
    }
}
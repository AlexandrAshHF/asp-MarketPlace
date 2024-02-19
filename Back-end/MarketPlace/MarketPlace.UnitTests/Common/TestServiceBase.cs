using MarketPlace.DAL;

namespace MarketPlace.UnitTests.Common
{
    public abstract class TestServiceBase : IDisposable
    {
        protected readonly ApplicationContext _context;
        public TestServiceBase()
        {
            _context = ContextFactory.CreateContext();
        }

        public void Dispose()
        {
            ContextFactory.Destroy(_context);
        }
    }
}

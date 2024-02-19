using MarketPlace.API;
using MarketPlace.DAL;
using Xunit;

namespace MarketPalce.UnitTests.Common
{
    public abstract class TestSeviceBase : IDisposable
    {
        protected readonly ApplicationContext _context;
        public TestSeviceBase()
        {
            _context = ContextFactory.Create();
        }
        public void Dispose()
        {
            ContextFactory.Destroy(_context);
        }
    }
}

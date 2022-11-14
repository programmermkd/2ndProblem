using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2ndProblemTests
{
    [TestClass]
    public class CacheServiceTests
    {
        private MockyService _cacheService;

        [TestInitialize]
        public void Setup()
        {
            _cacheService = new MockyService();
        }

        [TestMethod]
        public void TestMethod1()
        {
            _cacheService.GetMockyResponseAsync();
        }
    }
}